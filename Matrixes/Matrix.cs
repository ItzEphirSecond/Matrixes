using System;
using System.Threading.Tasks.Dataflow;

namespace Matrixes
{
    internal class Matrix
    {
        public List<List<int>> MatrixList
        {
            get; protected set;
        }

        public int Rows { get; protected set; }

        public int Columns { get; protected set; }

        public Matrix()
        {
            MatrixList = new List<List<int>>();
            Rows = 0;
            Columns = 0;
        }

        public Matrix(Matrix matrix)
        {
            MatrixList = matrix.MatrixList;
            Rows = matrix.Rows;
            Columns = matrix.Columns;
        }

        public Matrix(int rows, int columns)
        {
            MatrixList = new List<List<int>>();
            Rows = rows;
            Columns = columns;
            for(int i = 0; i < rows; i++)
            {
                MatrixList.Add(new List<int>());
                for(int j = 0; j < columns; j++)
                {
                    MatrixList[i].Add(0);
                }
            }
        }

        public void SetNode(int node, int row, int column)
        {
            if(row < MatrixList.Count && column < MatrixList[0].Count) 
            {
                MatrixList[row][column] = node;
            }
        }

        public static Matrix operator+(Matrix a, Matrix b)
        {
            Matrix result;
            if (a.Columns == b.Columns && a.Rows == b.Rows)
            {
                result = new Matrix(a.Rows, a.Columns);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Columns; j++)
                    {
                        result.SetNode(a.MatrixList[i][j] + b.MatrixList[i][j], i, j);
                    }
                }
            }
            else
            {
                result = new Matrix();
            }
            return result;
        }

        public static Matrix operator-(Matrix a, Matrix b) 
        {
            Matrix bb = new Matrix(b);
            for(int i = 0; i < b.Rows; i++)
            {
                for(int j = 0; j < b.Columns; j++)
                {
                    bb.SetNode(-b.MatrixList[i][j], i, j);
                }
            }

            return a + bb;
        }

        public static Matrix operator*(Matrix a, Matrix b)
        {
            Matrix result;

            if (a.Rows == b.Columns)
            {
                result = new Matrix(a.Rows, b.Columns);
                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < b.Columns; j++)
                    {
                        int N = 0;
                        for (int k = 0; k < a.Columns; k++)
                        {
                            N += a.MatrixList[i][k] * b.MatrixList[k][j];
                        }
                        result.SetNode(N, i, j);
                    }
                }
            }
            else
            {
                result = new Matrix();
            }

            return result;
        }

        public static Matrix Create(String str)
        {
            Matrix result;
            string[] rows = str.Split('\n');
            int rowsCount = rows.Length;
            var columnsCount = rows[0].Split(' ').Length;
            if (rowsCount == 2 && columnsCount == 1)
            {
                result = new UnaryMatrix(int.Parse(str));
                return result;
            }
            else if (rowsCount == 3 && columnsCount == 2)
            {
                result = new BinaryMatrix();
            }
            else if (rowsCount == 4 && columnsCount == 3)
            {
                result = new TrinaryMatrix();
            }
            else result = new Matrix(rowsCount - 1, columnsCount);
            for (int i = 0; i < rowsCount - 1; i++)
            { 
                var rowList = rows[i].Split(' ');
                if(rowList.Length != columnsCount)
                {
                    throw new Exception("Wrong data for matrix");
                }
                for(int j = 0; j < rowList.Length; j++)
                {
                    int node = int.Parse(rowList[j]);
                    result.SetNode(node, i, j);
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";

            foreach(var l in MatrixList)
            {
                foreach(var i in l)
                {
                    result += i.ToString();
                    result += " ";
                }
                result += "\n";
            }

            return result;
        }

        public virtual int GetDeterminant()
        {
            throw new NotImplementedException("Determinant cannot be counted during this data:\n" + ToString() + "\n");
        }
    }
}
