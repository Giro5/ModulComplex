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
            Complex c1 = new Complex();
            Complex c2 = new Complex();
            Console.Write("Введите целую часть первого комплексного числа: ");
            c1.r = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите мнимую часть первого комплексного числа: ");
            c1.i = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите целую часть второго комплексного числа: ");
            c2.r = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите мнимую часть первого комплексного числа: ");
            c2.i = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите необходимую степень: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Введенные комплексные числа: ");
            c1.Print(c1);
            c2.Print(c2);
            Console.ReadLine();
            Console.WriteLine($"Сложение комплексных чисел: {c1.Sum(c1, c2).r} + {c1.Sum(c1, c2).i}i");
            Console.WriteLine($"Умножение комплексных чисел: {c1.Multiplication(c1, c2).r} + {c1.Multiplication(c1, c2).i}i");
            Console.WriteLine($"Вычитание комплексных чисел: {c1.Subtract(c1, c2).r} + {c1.Subtract(c1, c2).i}i");
            Console.WriteLine($"Деление комплексных чисел: {c1.Divine(c1, c2).r} + {c1.Divine(c1, c2).i}i");
            Console.WriteLine($"Модуль комплексных чисел: {c1.Abs(c1)}, {c2.Abs(c2)}");
            Console.WriteLine($"Возведение комплексных чисел в степень {n}: {c1.DegreeN(c1, n).r} + {c1.DegreeN(c1, n).i}i, {c2.DegreeN(c2, n).r} + {c2.DegreeN(c2, n).i}i");
            Console.ReadLine();
        }
    }
    class Complex
    {
        public double r, i;
        public Complex Sum(Complex a, Complex b)
        {
            return new Complex() { r = a.r + b.r, i = a.i + b.i };
        }
        public Complex Multiplication(Complex a, Complex b)
        {
            return new Complex() { r = a.r * b.r + a.i * b.i * -1, i = a.r * b.i + a.i * b.r };
        }
        public Complex Subtract(Complex a, Complex b)
        {
            return new Complex() { r = a.r - b.r, i = a.i - b.i };
        }
        public Complex Divine(Complex a, Complex b)
        {
            Complex res = new Complex() { r = b.r, i = -1 * b.i };
            Complex numerator = res.Multiplication(a, res);
            double denominator = res.Multiplication(b, res).r + res.Multiplication(b, res).i;
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
            for (int i = 1; i < n; i++)
                res = res.Multiplication(res, a);
            return res;
        }
        public void Print(Complex a)
        {
            Console.WriteLine($"{a.r} + {a.i}i");
        }
    }
}
