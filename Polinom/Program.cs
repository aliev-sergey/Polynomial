using System;
using System.Linq;


namespace Polynom
{
    public class Program
    {
        static void Main(string[] args)
        {
            String firstPol = "";
            String secondPol = "";
            Polynomial firstPolynom, secondPolynom, resultPolynom;
            bool isOpSelected = false;
            string op = "";

            while (!ValidateInput(firstPol) && !ValidateInput(secondPol))
            {
                if (!ValidateInput(firstPol))
                {
                    Console.WriteLine("Запишите коэффициенты первого многочлена через пробел: ");
                    firstPol = Console.ReadLine();
                }
                if (!ValidateInput(secondPol))
                {
                    Console.WriteLine("Запишите коэффициенты второго многочлена через пробел: ");
                    secondPol = Console.ReadLine(); ;
                }
            }

            firstPolynom = new Polynomial(firstPol.Split(' ').Select(decimal.Parse).ToArray());
            secondPolynom = new Polynomial(secondPol.Split(' ').Select(decimal.Parse).ToArray());

            while (!isOpSelected)
            {
                Console.WriteLine("Введите операцию (+, -, *, /): ");
                op = Console.ReadLine();

                switch (op)
                {
                    case "+":
                        resultPolynom = firstPolynom + secondPolynom;
                        isOpSelected = true;
                        Console.WriteLine(FormatResultStr(firstPolynom, secondPolynom, resultPolynom, op));
                        break;
                    case "-":
                        resultPolynom = firstPolynom - secondPolynom;
                        isOpSelected = true;
                        Console.WriteLine(FormatResultStr(firstPolynom, secondPolynom, resultPolynom, op));
                        break;
                    case "*":
                        resultPolynom = firstPolynom * secondPolynom;
                        isOpSelected = true;
                        Console.WriteLine(FormatResultStr(firstPolynom, secondPolynom, resultPolynom, op));
                        break;
                    case "/":
                        resultPolynom = firstPolynom / secondPolynom;
                        isOpSelected = true;
                        Console.WriteLine(FormatResultStr(firstPolynom, secondPolynom, resultPolynom, op));
                        break;
                    default:
                        Console.WriteLine("Неверная операция, попробуйте еще раз!");
                        break;
                }
            }
            Console.Read();
        }

        public static bool ValidateInput(string polynom)
        {
            string[] monomials = polynom.Split(' ');
            decimal temp;
            foreach (string mon in monomials)
            {
                if (!Decimal.TryParse(mon, out temp))
                {
                    return false;
                }
            }
            return true;
        }

        public static string FormatResultStr(Polynomial firstPol, Polynomial secondPol, Polynomial resultPol, string op)
        {
            return $"Результат: \n {firstPol.ToString()} \n {op} \n {secondPol.ToString()} \n = \n {resultPol.ToString()}";
        }
    }
}
