using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace stage6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int numberoffigure = 9999;
            List<Figure> listfigures = new List<Figure>();
            Dictionary<Figure, string> dictionaryfigures = new Dictionary<Figure, string>();
            Figure figureneedtofind = new Figure();
            for (int i = 1; i <= numberoffigure; i++)
            {
                var fig = new Figure() {SideCount = rnd.Next(3, 9999), SideLenght = rnd.Next(1, 9999)};

                if (i == numberoffigure - 2)
                {
                    figureneedtofind = fig;
                }

                if (!listfigures.Contains(fig))
                {
                    listfigures.Add(fig);

                    dictionaryfigures.Add(fig, $"правильный {fig.SideCount}-угольник");
                }
                else
                {
                    numberoffigure++;
                }
            }

            var timer = Stopwatch.StartNew();
            Figure foundfigure1 = listfigures.Find(item => item.Equals(figureneedtofind));
            timer.Stop();
            Console.WriteLine($"Выполнение хитрого поиска по списку заняло {timer.Elapsed} мс");
            timer = Stopwatch.StartNew();
            Figure foundfigure2 = new Figure();
            foreach (var item in listfigures)
            {
                if (item.Equals(figureneedtofind))
                {
                    foundfigure2 = item;
                    break;
                }
            }

            timer.Stop();
            Console.WriteLine($"Выполнение поиска по списку заняло {timer.Elapsed} мс");
            
            timer = Stopwatch.StartNew();
            string foundfigure3 = dictionaryfigures[figureneedtofind];
            timer.Stop();
            Console.WriteLine($"Выполнение поиска(хотя это не поиск, а обращение по ключу) по словарю заняло {timer.Elapsed} мс");
            
            timer = Stopwatch.StartNew();
            string foundfigure4;
            dictionaryfigures.TryGetValue(figureneedtofind, out foundfigure4);
            timer.Stop();
            Console.WriteLine($"Выполнение поиска по словарю заняло {timer.Elapsed} мс");
            timer = Stopwatch.StartNew();
            foreach (var item in dictionaryfigures.Keys)
            {
                if (item.Equals(figureneedtofind))
                {
                    foundfigure2 = item;
                    break;
                } 
            }
            timer.Stop();
            Console.WriteLine($"Выполнение поиска(foreach) по словарю заняло {timer.Elapsed} мс");
        }
    }
}