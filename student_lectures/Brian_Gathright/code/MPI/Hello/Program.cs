using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPI;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                //root's instructions
                if (Communicator.world.Rank == 0)
                {
                    Console.WriteLine("Hello, World! I am the root.");
                }

                //non-root's instructions
                else
                {
                    Console.WriteLine("Hello, World! I am rank " + Communicator.world.Rank + ".");
                }
            }
        }
    }
}
