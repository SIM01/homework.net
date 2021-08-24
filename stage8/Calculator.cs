using System;
using System.Collections.Generic;

namespace stage8
{
    public class Calculator
    {
        public Calculator()
        {
            Console.WriteLine("Введите первый аргумент: ");
            var number1 = Console.ReadLine();
            
            List<string> osibleoperations = new List<string>(){ "+", "-", "*", "/"};
            string operation = "";
            while (!osibleoperations.Contains(operation))
            {
                Console.WriteLine("Введите операцию для расчёта(+,-,*,/): "); 
                operation = Console.ReadLine();
            }
            
            Console.WriteLine("Введите второй аргумент: ");
            var number2 = Console.ReadLine();

            string result = "";
            switch (operation)
            {
                case "+":
                    result = (Addition( Convert.ToDouble(number1),Convert.ToDouble(number2)).ToString());
                    Console.WriteLine($"{number1}{operation}{number2}={result}");
                    break;
                case "-":
                    result = (Subtract( Convert.ToDouble(number1),Convert.ToDouble(number2)).ToString());
                    Console.WriteLine($"{number1}{operation}{number2}={result}");
                    break;
                case "*":
                    result = (Multiply( Convert.ToDouble(number1),Convert.ToDouble(number2)).ToString());
                    Console.WriteLine($"{number1}{operation}{number2}={result}");
                    break;
                case "/":
                    result = (Divide( Convert.ToDouble(number1),Convert.ToDouble(number2)).ToString());
                    Console.WriteLine($"{number1}{operation}{number2}={result}");
                    break;
            }
        }

        public double Addition(double number1, double number2)
        {
            return number1 + number2;
        }

        public double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }

        public double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public double Divide(double number1, double number2)
        {
            var tmp = (int) number1 / (int) number2;
            return  Math.Round(number1 / number2,2);
        }
    }
}