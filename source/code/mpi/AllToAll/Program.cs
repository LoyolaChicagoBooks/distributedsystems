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
                string[] data = new string[comm.Size];
                for (int i = 0; i < comm.Size; i++)
                {
                    data[i] = "This string came from Rank " + comm.Rank;
                }
               
                string[] results = comm.Alltoall(data);

                if (comm.Rank == 0)
                {
                    Console.WriteLine("The root's array contains: ");
                    foreach (string x in results)
                    {
                        Console.WriteLine(x);
                    }
                }
            }
        }
    }
}

