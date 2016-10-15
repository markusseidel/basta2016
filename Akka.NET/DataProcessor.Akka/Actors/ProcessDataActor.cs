using Akka.Actor;
using Akka.Common;
using DataProcessor.Akka.Messsage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataProcessor.Akka.Actors
{
    public class ProcessDataActor : ReceiveActor
    {
        public static int InstanceCount = 0;
        private IActorRef _communicationActor;
        private string _path;
        private Action<int> _performWorkDel;

        public ProcessDataActor(IActorRef communicationActor, Action<int> performWorkDel)
        {
            Interlocked.Increment(ref InstanceCount);
            //Debug.WriteLine("Created ProcessDataActor. InstanceCount: " + InstanceCount);
            _communicationActor = communicationActor;
            _path = Self.Path.ToString();
            _performWorkDel = performWorkDel;
            Receive<StartProcessingMessage>(sp => HandleStartProcessing(sp));
            Receive<GoodMorningMessage>(sp => HandleGoodMorningMsg());
        }

        #region InstanceCount
        ~ProcessDataActor()
        {
            Interlocked.Decrement(ref InstanceCount);
        }
        #endregion

        private void HandleStartProcessing(StartProcessingMessage msg)
        {
            _communicationActor.Tell(new StatusMessage(_path, msg.Id, ProcessStatus.Running));

            _performWorkDel(msg.Id);

            _communicationActor.Tell(new StatusMessage(_path, msg.Id, ProcessStatus.Completed));
        }

        private void HandleGoodMorningMsg()
        {

        }
    }
}
