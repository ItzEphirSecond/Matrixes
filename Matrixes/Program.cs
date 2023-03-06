namespace Matrixes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Well, well, well, in this program you can easily make a matrix, so let`s do it");
            Console.WriteLine("Write a matrix (when you stop, write a letter on black line)");

            Matrix m1 = CreateMatrix();

            Console.Clear();
            Console.WriteLine("Well, it`s your matrix:");

            Console.WriteLine(m1);

            Console.WriteLine();
            Console.WriteLine("Now, you can add a new one");

            Matrix m2 = CreateMatrix();

            Console.Clear();

            Console.WriteLine("Well, it`s your matrixes:");
            Console.WriteLine(m1);
            Console.WriteLine();
            Console.WriteLine(m2);

            Console.WriteLine("Well, if they are same, you can plus:");
            Console.WriteLine(m1 + m2);
            Console.WriteLine();
            Console.WriteLine("minus:");
            Console.WriteLine(m1 - m2);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.WriteLine("If the first`s rows count is equal to second`s columns count, you can multiplie");
            Console.WriteLine(m1 * m2);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.WriteLine("If it`s unary or binary or trinary, you can count determinant");
            Console.WriteLine("And the first`s determinant is:");
            Console.WriteLine(m1.GetDeterminant());

            Console.WriteLine();
            Console.WriteLine("Well, that`s all!");
        }

        static string Read()
        {
            string result = "";
            string? a = Console.ReadLine();
            int num = 0;
            string st = "";
            foreach (string s in a.Split())
            {
                st += s;
            }
            while (true)
            {
                st = "";
                result += a + '\n';
                a = Console.ReadLine();
                foreach (string s in a.Split(' '))
                {
                    if (!int.TryParse(s, out num)) return result;
                    st += s;
                }
            }
            return result;
        }

        static Matrix CreateMatrix()
        {
            string s = Read();
            Matrix m = Matrix.Create(s);
            return m;
        }
    }
}