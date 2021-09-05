using System;
using System.Diagnostics;
using System.Threading;

namespace stage9
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            double averagemass10M = CalcAdaveragemass10M();
            double averagemass100M = CalcAdaveragemass100M();
            timer.Stop();
            Console.WriteLine(
                $"Время на генерацию и расчёт среднего арифметического(mass10M - {averagemass10M}, mass100M - {averagemass100M}) составило {timer.ElapsedMilliseconds} мс");

            timer = Stopwatch.StartNew();
            var countdown = new CountdownEvent(2);
            double threadaveragemass10M = 0;
            double threadaveragemass100M = 0;
            ThreadPool.QueueUserWorkItem
            (
                new WaitCallback
                (
                    (_) =>
                    {
                        threadaveragemass10M = CalcAdaveragemass10M();
                        countdown.Signal();
                    }
                )
            );
            ThreadPool.QueueUserWorkItem
            (
                new WaitCallback
                (
                    (_) =>
                    {
                        threadaveragemass100M = CalcAdaveragemass100M();
                        countdown.Signal();
                    }
                )
            );
            
            countdown.Wait();
            timer.Stop();
            Console.WriteLine(
                $"Время с потоками на генерацию и расчёт среднего арифметического(mass10M - {threadaveragemass10M}, mass100M - {threadaveragemass100M}) составило {timer.ElapsedMilliseconds} мс");
        }

        static double CalcAdaveragemass10M()
        {
            Random rnd = new Random();
            var mass10M = new int[10000000];
            long summass10m = 0;
            for (int i = 0; i < mass10M.Length; i++)
            {
                mass10M[i] = rnd.Next(0, 9999);
                summass10m = summass10m + mass10M[i];
            }

            return summass10m / mass10M.Length;
        }

        static double CalcAdaveragemass100M()
        {
            Random rnd = new Random();
            var mass100M = new int[100000000];
            long summass100m = 0;
            for (int i = 0; i < mass100M.Length; i++)
            {
                mass100M[i] = rnd.Next(0, 9999);
                summass100m = summass100m + mass100M[i];
            }

            return summass100m / mass100M.Length;
        }
    }
}