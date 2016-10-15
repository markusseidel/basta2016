using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.Common
{

    public interface IDataProcessor
    {

        void Start(int count);
        void Stop();
        event Action<object, DataProcessorEventArgs> StatusChanged;
        event Action<object, CompletedEventArgs> Completed;
    }

    public class CompletedEventArgs: EventArgs
    {
        public TimeSpan Duration { get; set; }
        public bool Failed { get; set; }
    }

    public class DataProcessorEventArgs : EventArgs
    {
        public int TaskId { get; set; }
        public ProcessStatus Status { get; set; }
    }

    public enum ProcessStatus
    {
        Idle, Running, Completed, Exception
    }

}
