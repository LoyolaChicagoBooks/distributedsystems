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
                    Console.WriteLine("Sending a message and blocking");
                    comm.Send("blah", 1, 0);
                    Console.WriteLine("Note: This was not printed until the message was recieved.");
                }
                //not the root
                else
                {
                    comm.Receive<string>(0, 1);
                    Console.WriteLine("Recieved the Message. Note: This was not printed until the message was received.");
                }
            }
        }
    }
}