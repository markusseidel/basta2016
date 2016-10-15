using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akka.Common
{
    public abstract class DataProcessorBase : IDataProcessor
    {
        protected bool IsCancellationRequested;
        public event Action<object, CompletedEventArgs> Completed;
        public event Action<object, DataProcessorEventArgs> StatusChanged;
        private bool _throwExceptions;


        public DataProcessorBase(bool throwExceptions)
        {
            _throwExceptions = throwExceptions;
        }


        public abstract void Start(int count);


        public virtual void StartMessages()
        { }

        public virtual void Stop()
        {
            IsCancellationRequested = true;
        }



        protected void OnStatusChanged(int id, ProcessStatus status)
        {
            if (StatusChanged != null)
            {
                StatusChanged(this, new DataProcessorEventArgs()
                {
                    Status = status,
                    TaskId = id
                });
            }
        }

        protected void OnCompleted(TimeSpan ts, bool isFailed = false)
        {
            if (Completed != null)
            {
                Completed(this, new CompletedEventArgs() { Duration = ts, Failed = isFailed });
            }
        }

        protected void PerformWork(int id)
        {

            //prime_num(15000);

            Thread.Sleep(100);
            if (_throwExceptions)
            {
                Random r = new Random();
                int i = r.Next(0, 10);
                int numberToMatch = 5;

                if (i == numberToMatch)
                {
                    OnStatusChanged(id, ProcessStatus.Exception);
                    throw new Exception("Die Hütte brennt!");
                }
            }
        }


        bool prime_num(long num)
        {

            bool isPrime = true;
            for (long i = 0; i <= num; i++)
            {
                //bool isPrime = true; // Move initialization to here
                for (long j = 2; j < i; j++) // you actually only need to check up to sqrt(i)
                {
                    if (i % j == 0) // you don't need the first condition
                    {
                        isPrime = false;
                        break;
                    }
                }
                // if (isPrime)
                // {
                //     Console.WriteLine ( "Prime:" + i );
                //}
                isPrime = true;
            }
            return isPrime;
        }
    }
}
