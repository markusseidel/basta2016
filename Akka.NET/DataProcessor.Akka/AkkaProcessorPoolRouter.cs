using Akka.Actor;
using Akka.Common;
using Akka.Monitoring;
using Akka.Monitoring.PerformanceCounters;
using Akka.Routing;
using DataProcessor.Akka.Actors;
using DataProcessor.Akka.Messsage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Akka
{
    public class AkkaProcessorPoolRouter: DataProcessorBase
    {
        IActorRef _processingActor1;
        public static ActorSystem MyActorSystem;
        int _poolSize;
        int _count;

        public AkkaProcessorPoolRouter(int poolSize, bool throwExceptions):base(throwExceptions)
        {
            _poolSize = poolSize;
        }

        public override void Start(int count)
        {
            #region Management
            var statusDel = new Action<int, ProcessStatus>(OnStatusChanged);
            var performWorkDel = new Action<int>(PerformWork);
            var completedDel = new Action<TimeSpan, bool>(OnCompleted);
            #endregion
            _count = count;

            MyActorSystem = ActorSystem.Create("akka");

            IActorRef communicationActor = MyActorSystem.ActorOf(Props.Create(() =>
                new CommunicationActor(statusDel, completedDel, count)), "communicator1");

            _processingActor1 = MyActorSystem.ActorOf(Props.Create(() =>
                new ProcessDataActor(communicationActor, performWorkDel)).
                WithRouter(new SmallestMailboxPool(_poolSize))
                , "processingActor1");

            for (int i = 0; i < _count; i++)
            {
                _processingActor1.Tell(new StartProcessingMessage() { Id = i });

            }
        }

        public override void Stop()
        {
            MyActorSystem.Stop(_processingActor1);
        }
    }
}
