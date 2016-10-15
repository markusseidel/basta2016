using Akka.Actor;
using Akka.Common;
using Akka.Monitoring;
using Akka.Monitoring.PerformanceCounters;
using DataProcessor.Akka.Actors;
using DataProcessor.Akka.Messsage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Akka
{
    public class AkkaProcessorSingleActor : DataProcessorBase
    {
        IActorRef _processingActor1;
        ActorSystem _actorSystem;

        public AkkaProcessorSingleActor(bool throwExceptions) : base(throwExceptions)
        {}

        public override void Start(int count)
        {
            #region Delegates
            var statusDel = new Action<int, ProcessStatus>(OnStatusChanged);
            var completedDel = new Action<TimeSpan, bool>(OnCompleted);
            var performWorkDel = new Action<int>(PerformWork);
            #endregion

            _actorSystem = ActorSystem.Create("akka");

            IActorRef communicationActor = _actorSystem.ActorOf(Props.Create(() =>
                new CommunicationActor(statusDel, completedDel, count)), "communicator1");

            _processingActor1 = _actorSystem.ActorOf(Props.Create(() =>
                new ProcessDataActor(communicationActor, performWorkDel)), "processingActor1");

            for (int i = 0; i < count; i++)
            {
                _processingActor1.Tell(new StartProcessingMessage() { Id = i });
            }
        }

        public override void Stop()
        {
            _actorSystem.Stop(_processingActor1);
        }
    }
}
