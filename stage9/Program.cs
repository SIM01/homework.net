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
            var timer = Stopwatch.StartNew();
            double averagemass10M = CalcAdaveragemass10M();
            double averagemass100M = CalcAdaveragemass100M();
            timer.Stop();
            Console.WriteLine(
                $"Время на генерацию и расчёт среднего арифметического(mass10M - {averagemass10M}, mass100M - {averagemass100M}) составило {timer.ElapsedMilliseconds} мс");

            timer = Stopwatch.StartNew();
            var rnd = new Random();
            var mass10M = new int[10000000];
            long summass10m = 0;
            Parallel.For<long>(0, mass10M.Length, () => 0, (j, loop, subtotal) =>
                {
                    mass10M[j] = rnd.Next(0, 9999);
                    subtotal += mass10M[j];
                    return subtotal;
                },
                (x) => Interlocked.Add(ref summass10m, x)
            );

            double threadaveragemass10M = summass10m / mass10M.Length;
            var mass100M = new int[100000000];
            long summass100m = 0;
            Parallel.For(0, mass100M.Length,
                i =>
                {
                    mass100M[i] = rnd.Next(0, 9999);

                    Interlocked.Add(ref summass100m, mass100M[i]);
                });
            double threadaveragemass100M = summass100m / mass100M.Length;
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