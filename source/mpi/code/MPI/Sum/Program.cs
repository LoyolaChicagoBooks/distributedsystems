using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPI;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                int root = 0;
                int arraySize = 100;
                if (args.Length == 1)
                {
                    arraySize = Convert.ToInt32(args[0]);
                }

                Intracommunicator comm = Communicator.world;

                int[] lotsOfNumbers = new int[arraySize];

                if (comm.Rank == 0)
                {
                    for (int i = 0; i < lotsOfNumbers.Length; i++)
                    {
                        lotsOfNumbers[i] = i;
                    } 
                }

                int sum = 0;

                comm.Broadcast(ref lotsOfNumbers, 0);

                //divides up the work
                int x = arraySize / comm.Size;
                int startingIndex = comm.Rank * x;
                int endingIndex = startingIndex + x;

                if (comm.Rank == comm.Size - 1)
                {
                    endingIndex = lotsOfNumbers.Length;
                }

                for (int i = startingIndex; i < endingIndex; i++)
                {
                    sum += lotsOfNumbers[i];
                }
                Console.WriteLine("Rank " + comm.Rank + ": " + "summed the numbers from index " + startingIndex + " to index " + (endingIndex - 1) + " and got " + sum + ".");

                int totalSum = comm.Reduce(sum, Operation<int>.Add, root);


                if (comm.Rank == root)
                {
                    Console.WriteLine("The total sum is: " + totalSum);
                }
            }
        }
    }
}
