using System;
using MPI;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;
                //root
                if (Communicator.world.Rank == 0)
                {
                    Console.WriteLine("Root sent a message to Rank 1");

                    comm.Send("blah", 1, 0);

                    //nonblocking receive
                    Request receive = comm.ImmediateReceive<string>(1, 0);
                    
                    Console.WriteLine("We are performing a nonblocking receive, so we can print instantly.");
                    receive.Wait();
                }
                //not the root
                else
                {
                    comm.Receive<string>(0, 0);

                    //Rank 1 will wait half a second before sending response
                    System.Threading.Thread.Sleep(5000);

                    Console.WriteLine("We waited half a second before sending something to the root.");
                    comm.Send("blah", 0, 0);
                    Console.WriteLine("If root was blocking, he wouldn't have been able to print until now!");
                }
            }
        }
    }
}