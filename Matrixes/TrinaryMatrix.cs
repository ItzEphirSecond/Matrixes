using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes
{
    internal class TrinaryMatrix : Matrix
    {
        public TrinaryMatrix() : base(3, 3) 
        {
            
        }

        public override int GetDeterminant()
        {
            int result = 0;

            BinaryMatrix ost = new();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    ost.SetNode(MatrixList[i + 1][j + 1], i, j);
                }
            }

            result += MatrixList[0][0] * ost.GetDeterminant();

            ost.SetNode(MatrixList[1][0], 0, 0);
            ost.SetNode(MatrixList[2][0], 1, 0);
            ost.SetNode(MatrixList[1][2], 0, 1);
            ost.SetNode(MatrixList[2][2], 1, 1);

            result -= MatrixList[0][1] * ost.GetDeterminant();

            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    ost.SetNode(MatrixList[i + 1][j], i, j);
                }
            }

            result += MatrixList[0][2] * ost.GetDeterminant();

            return result;
        }
    }
}
