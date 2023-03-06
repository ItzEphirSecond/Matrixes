namespace Matrixes
{
    internal class BinaryMatrix : Matrix
    {
        public BinaryMatrix() : base(2, 2)
        {

        }

        public override int GetDeterminant()
        {
            return MatrixList[0][0] * MatrixList[1][1] - MatrixList[0][1] * MatrixList[1][0];
        }
    }
}
