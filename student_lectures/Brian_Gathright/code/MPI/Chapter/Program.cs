using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPI;

namespace Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;
                int root = 0;
                string[] nums = new string[5];

                if (comm.Rank == root)
                {
                    nums[1] = "Chapter 1: MPI";
                    nums[2] = "Chapter 2: BitCoins";
                    nums[3] = "Chapter 3: MongoDB";
                    nums[4] = "Chapter 4: How to Make a Sandwich";

                    comm.Scatter(nums, root);
                }

                else
                {
                    string value = comm.Scatter(nums, root);
                    Console.WriteLine(comm.Rank + " was assigned " + value);
                }
            }
        }
    }
}
