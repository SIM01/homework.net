using System;

namespace stage10
{
    public interface IJobExecutor
    {
        /// Кол-во задач в очереди на обработку
        public int Amount { get; }

        /// <summary>
        /// Запустить обработку очереди и установить максимальное кол-во параллельных задач
        /// </summary>
        /// <param name="maxConcurrent">максимальное кол-во одновременно выполняемых задач</param>
        public void Start(int maxConcurrent);

        /// <summary>
        /// Остановить обработку очереди и выполнять задачи
        /// </summary>
        public void Stop();

        /// <summary>
        /// Добавить задачу в очередь
        /// </summary>
        /// <param name="action"></param>
        public void Add(Action action);

        /// <summary>
        /// Очистить очередь задач
        /// </summary>
        public void Clear();
    }
}