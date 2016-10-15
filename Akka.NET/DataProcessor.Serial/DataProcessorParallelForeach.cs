using Akka.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataProcessor.Serial
{
    public class DataProcessorParallelForeach : DataProcessorBase
    {
        public DataProcessorParallelForeach(bool throwExceptions) : base(throwExceptions)
        {

        }

        public override void Start(int count)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var t = Task.Factory.StartNew(() => ProcessData(count));
            t.ContinueWith((task) =>
            {
                sw.Stop();
                OnCompleted(sw.Elapsed, task.IsFaulted);
            });
        }

        private void ProcessData(int count)
        {
            Parallel.For(0, count, (i) =>
            {
                if (IsCancellationRequested)
                {
                    return;
                }

                OnStatusChanged(i, ProcessStatus.Running);
                PerformWork(i);
                OnStatusChanged(i, ProcessStatus.Completed);
            });
        }


    }
}
