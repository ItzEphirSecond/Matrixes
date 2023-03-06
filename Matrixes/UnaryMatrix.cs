using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixes
{
    internal class UnaryMatrix : Matrix
    {
        private int num;

        public int Num
        {
            get => num;
            set
            {
                num = value;
                base.MatrixList[0][0] = value;
            }
        }

        public UnaryMatrix() : base(1, 1)
        {

        }

        public UnaryMatrix(int value) : this()
        {
            Num = value;
        }

        public override int GetDeterminant()
        {
            return Num;
        }
    }
}
