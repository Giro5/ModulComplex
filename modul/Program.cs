using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целую часть первого комплексного числа: ");
            double r1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите мнимую часть первого комплексного числа: ");
            double i1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите целую часть второго комплексного числа: ");
            double r2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите мнимую часть первого комплексного числа: ");
            double i2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите необходимую степень: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Complex c1 = new Complex();
            Complex c2 = new Complex();
            c1.r = r1;
            c1.i = i1;
            c2.r = r2;
            c2.i = i2;
            Console.WriteLine("Введенные комплексные числа: ");
            c1.Print(c1);
            c2.Print(c2);
            Console.ReadLine();
            Console.WriteLine("Сложение комплексных чисел: {0} + {1}i", c1.Sum(c1, c2).r, c1.Sum(c1, c2).i);
            Console.WriteLine("Умножение комплексных чисел: {0} + {1}i", c1.Multiplication(c1, c2).r, c1.Multiplication(c1, c2).i);
            Console.WriteLine("Вычитание комплексных чисел: {0} + {1}i", c1.Subtract(c1, c2).r, c1.Subtract(c1, c2).i);
            Console.WriteLine("Деление комплексных чисел: {0} + {1}i", c1.Divine(c1, c2).r, c1.Divine(c1, c2).i);
            Console.WriteLine("Модуль комплексных чисел: {0}, {1}", c1.Abs(c1), c2.Abs(c2));
            Console.WriteLine("Возведение комплексных чисел в степень n: {0} + {1}i, {2} + {3}i", c1.DegreeN(c1, n).r, c1.DegreeN(c1, n).i, c2.DegreeN(c2, n).r, c2.DegreeN(c2, n).i);
            Console.ReadLine();
        }
    }
    class Complex
    {
        public double r, i;
        public Complex Sum(Complex a, Complex b)
        {
            Complex res = new Complex();
            res.r = a.r + b.r;
            res.i = a.i + b.i;
            return res;
        }
        public Complex Multiplication(Complex a, Complex b)
        {
            Complex res = new Complex();
            res.r = a.r * b.r + (a.i * b.i * -1);
            res.i = a.r * b.i + a.i * b.r;
            return res;
        }
        public Complex Subtract(Complex a, Complex b)
        {
            Complex res = new Complex();
            res.r = a.r - b.r;
            res.i = a.i - b.i;
            return res;
        }
        public Complex Divine(Complex a, Complex b)
        {
            Complex res = new Complex();
            Complex tmp = new Complex()
            {
                r = b.r,
                i = -1 * b.i
            };
            Complex numerator = res.Multiplication(a, tmp);
            double denominator = res.Multiplication(b, tmp).r + res.Multiplication(b, tmp).i;
            res.r = numerator.r / denominator;
            res.i = numerator.i / denominator;
            return res;
        }
        public double Abs(Complex a)
        {
            return Math.Sqrt(Math.Pow(a.r, 2) + Math.Pow(a.i, 2));
        }
        public Complex DegreeN(Complex a, int n)
        {
            Complex res = a;
            for(int i = 1; i < n; i++)
            {
                res = res.Multiplication(res, a);
            }
            return res;
        }
        public void Print(Complex a)
        {
            Console.WriteLine("{0} + {1}i", a.r, a.i);
        }
    }
}
