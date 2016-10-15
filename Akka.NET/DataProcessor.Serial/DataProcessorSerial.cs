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
    public class DataProcessorSerial : DataProcessorBase
    {
        public DataProcessorSerial(bool throwExceptions) : base(throwExceptions)
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
            for (int i = 0; i < count; i++)
            {
                if(IsCancellationRequested)
                {
                    break;
                }
                OnStatusChanged(i, ProcessStatus.Running);
                PerformWork(i);
                OnStatusChanged(i, ProcessStatus.Completed);
            }
        }
    }
}
