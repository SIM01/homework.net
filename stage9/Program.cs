using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace stage9
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            var mass100M = new int[100000000];
            for (int i = 0; i < mass100M.Length; i++)
            {
                mass100M[i] = rnd.Next(0, 9999);
            }

            var timer = Stopwatch.StartNew();
            double averagemass100M = CalcAdaveragemass10M(mass100M);
            timer.Stop();
            Console.WriteLine(
                $"Время на генерацию и расчёт среднего арифметического(mass10M - {averagemass100M}) составило {timer.ElapsedMilliseconds} мс");

            timer = Stopwatch.StartNew();


            long summass100m = 0;
            int parts = 100000;
            int partSize = mass100M.Length / parts;
            Parallel.For(0, parts,  (index) =>
            {
                long tmp = 0;
                for (int j = index * partSize; j < (index + 1) * partSize; j++)
                {
                    tmp = tmp + mass100M[j];
                }
                Interlocked.Add(ref summass100m, tmp);
            });

            double threadaveragemass100M = summass100m / mass100M.Length;

            timer.Stop();
            Console.WriteLine(
                $"Время с потоками на генерацию и расчёт среднего арифметического(mass10M - {threadaveragemass100M}) составило {timer.ElapsedMilliseconds} мс");
        }

        static double CalcAdaveragemass10M(int[] mass10M)
        {
            long summass100m = 0;
            for (int i = 0; i < mass10M.Length; i++)
            {
                summass100m = summass100m + mass10M[i];
            }

            return summass100m / mass10M.Length;
        }
    }
}