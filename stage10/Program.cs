using System;
using System.Threading;

namespace stage10
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskQueue = new TaskQueue();
            int number = 1;

            while (number < 25)
            {
                taskQueue.Add(new Action(() =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"Print task №{number}");
                }));
                number++;
            }

            Thread.Sleep(500);
            taskQueue.Start(3);
            Console.WriteLine("-----------------------------------");
            taskQueue.Start(6);
            Console.WriteLine("-----------------------------------");
            taskQueue.Stop();
            taskQueue.Start(6);
        }
    }
}