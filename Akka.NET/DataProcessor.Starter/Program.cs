using Akka.Actor;
using DataProcessor.Akka.Actors;
using DataProcessor.Akka.Messsage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Starter
{
    class Program
    {
        static void Main(string[] args)
        {

            //ActorSystem actorSystem = ActorSystem.Create("akka");

            //IActorRef communicationActor = actorSystem.ActorOf(Props.Create(() =>
            //    new CommunicationActor()), "communicator1");

            //IActorRef processingActor1 = actorSystem.ActorOf(Props.Create(() =>
            //    new ProcessDataActor(communicationActor)), "processingActor1");


            //for (int i = 0; i < 10; i++)
            //{
            //    processingActor1.Tell(new StartProcessingMessage() {  Iteration = i });

            //}


            //Console.WriteLine("Done");
            //Console.ReadLine();

        }
    }
}
