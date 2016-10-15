using Akka.Actor;
using Akka.Common;
using DataProcessor.Akka.Messsage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Akka.Actors
{
    public class CommunicationActor : ReceiveActor
    {
        private Dictionary<int, bool> _runningTasks;

        int _taskCount;
        int _completedTasks = 0;
        Action<int, ProcessStatus> _statusDelegate;
        Action<TimeSpan, bool> _completedDelegate;
        Stopwatch _sw;

        public CommunicationActor(Action<int, ProcessStatus> statusDelegate, Action<TimeSpan, bool> completedDelegate, int count)
        {
            _taskCount = count;
            _sw = new Stopwatch();
            _runningTasks = new Dictionary<int, bool>();
            _statusDelegate = statusDelegate;
            _completedDelegate = completedDelegate;

            Receive<StatusMessage>(display => HandleDisplayStatus(display));
        }


        #region MessageHandlers

        private void HandleDisplayStatus(StatusMessage message)
        {
            if(_runningTasks.Count == 0)
            {
                //is first message
                _sw.Start();
            }

            _statusDelegate.BeginInvoke(message.Id, message.Status, null, null);

            //string text = string.Format("Sending Status for id: {0}. Status: {1}", message.Id, message.Status);
            //string txt = "";
            //Debug.WriteLine(txt);
            //Console.WriteLine(txt);

            if (message.Status == ProcessStatus.Completed || message.Status == ProcessStatus.Exception)
            {
                _completedTasks++;
            }

            if (_completedTasks >= _taskCount)
            {
                _sw.Stop();
                _completedDelegate.BeginInvoke(_sw.Elapsed, false, null, null);
            }
        }


        #endregion



    }
}
