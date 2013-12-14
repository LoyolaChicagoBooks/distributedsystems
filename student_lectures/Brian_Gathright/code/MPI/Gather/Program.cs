using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPI;

namespace ConsoleApplication1
{
    class Hostnames
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;
                Random rand = new Random();

                int[] randomNums = comm.Gather(rand.Next(1, 1001), 0);
                
                if (comm.Rank == 0)
                {
                    Array.Sort(randomNums);

                    foreach (int num in randomNums)
                    {
                        Console.WriteLine(num);
                    }
                }
            }
        }
    }
}
