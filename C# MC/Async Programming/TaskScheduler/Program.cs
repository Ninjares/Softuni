using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TaskSchedulr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    internal class SimpleScheduler : TaskScheduler
    {
        BlockingCollection<Task> tasks = new BlockingCollection<Task>();

        public SimpleScheduler():base()
        {

        }
       // [return: NullableAttribute(new[] { 2, 1 })]
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return tasks.GetConsumingEnumerable();
        }

        protected override void QueueTask(Task task)
        {
            throw new NotImplementedException();
        }

        private void Execute()
        {
            while (tasks.Count > 0)
            {
                var task = tasks.Take();
                TryExecuteTask(task);
            }
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
    }
}
