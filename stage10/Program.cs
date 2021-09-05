using System;
using System.Threading;

namespace stage10
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskQueue = new TaskQueue();
            Action doWorkAction1 = new Action(DoWork1);
            Action doWorkAction2 = new Action(DoWork2);
            Action doWorkAction3 = new Action(DoWork3);
            Action doWorkAction4 = new Action(DoWork4);
            taskQueue.Add(doWorkAction1);
            taskQueue.Add(doWorkAction2);
            taskQueue.Add(doWorkAction3);
            taskQueue.Add(doWorkAction4);
            taskQueue.Start(3);
            
        }
 
        public static void DoWork1()
        {
            //Thread.Sleep(5000);
            Console.WriteLine("Hi, I am doing work.");
        }
        public static void DoWork2()
        {
            //Thread.Sleep(5000);
            Console.WriteLine("Hi, I am doing another work.");
        }
        public static void DoWork3()
        {
            //Thread.Sleep(5000);
            Console.WriteLine("Hi, I am doing another work1.");
        }
        public static void DoWork4()
        {
            //Thread.Sleep(5000);
            Console.WriteLine("Hi, I am doing another work2.");
        }
    }
    
}