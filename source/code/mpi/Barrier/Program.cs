using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPI;

namespace ConsoleApplication1
{
    class Barrier
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;

                if (comm.Rank == 0)
                {
                    Console.WriteLine("Everyone get to the CHOPPA!");
                }
                else
                {
                    Random rand = new Random();
                    System.Threading.Thread.Sleep(rand.Next(1000, 7000));
                }

                comm.Barrier();

                if (comm.Rank == 0)
                {
                    Console.WriteLine("Everyone is on the CHOPPA!");
                }
            }
        }
    }
}