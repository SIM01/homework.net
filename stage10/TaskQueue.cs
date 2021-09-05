using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace stage10
{
    public class TaskQueue : IJobExecutor
    {
        public int Amount { get; private set; }

        public TaskQueue()
        {
            Amount = 0;
        }

        private List<Action> tasks = new List<Action>();

        public CancellationTokenSource cancelTokSSrc = new CancellationTokenSource();

        public void Start(int maxConcurrent)
        {
            //Stop();
            
            int countRunTask = 0;
            List<Action> taskstmp = new List<Action>(tasks);
            
            foreach (var task in tasks)
            {
                if ((tasks.Count > countRunTask) && (countRunTask < maxConcurrent))
                {
                    Task.Factory.StartNew(task, cancelTokSSrc.Token, TaskCreationOptions.DenyChildAttach,
                        TaskScheduler.Default);
                    Thread.Sleep(500);
                    countRunTask++;
                    taskstmp.Remove(task);
                }
            }

            tasks = taskstmp;
        }

        public void Stop()
        {
            cancelTokSSrc.Cancel();
        }

        public void Add(Action action)
        {
            Amount = Amount + 1;
            tasks.Add(action);
        }

        public void Clear()
        {
            Stop();
            tasks.Clear();
        }
    }
}