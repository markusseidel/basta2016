//using Akka.Common;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace DataProcessor.Serial
//{
//    public class DataProcessorParallelForeachEx : DataProcessorBase
//    {
//        public DataProcessorParallelForeachEx(): base(true)
//        {

//        }

//        public override void Start(int count)
//        {
//            try
//            {
//                Stopwatch sw = Stopwatch.StartNew();
//                var t = Task.Factory.StartNew(() => ProcessData(count));
//                t.ContinueWith((task) =>
//                {
//                    sw.Stop();
//                    OnCompleted(sw.Elapsed, task.IsFaulted);
//                });
//            }
//            catch (Exception)
//            {
                
//                throw;
//            }
//        }

//        private void ProcessData(int count)
//        {
//            //Random r = new Random();
//            //List<int> numbers = new List<int>();
//            //for (int i = 0; i < 5; i++)
//            //{
//            //    numbers.Add(r.Next(0, count));
//            //}



//            Parallel.For(0, count, (i) =>
//            {
//                if (IsCancellationRequested)
//                {
//                    return;
//                }

//                OnStatusChanged(i, ProcessStatus.Running);
//                PerformWork(i);

//                //if (numbers.Contains(i))
//                //{
//                //    OnStatusChanged(i, ProcessStatus.Exception);
//                //    throw new Exception("Alles am arsch");
//                //}
//                //else
//                //{
//                    OnStatusChanged(i, ProcessStatus.Completed);
//                //}
//            });
//        }


//    }
//}
