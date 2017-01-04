using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPI;

namespace Telephone
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;

                if (comm.Rank == 0)
                {
                    Console.WriteLine("Root: Let's play a game of telephone!");

                    string originalMsg = "chicago";

                    Console.WriteLine("Root: The inital word is: \"" + originalMsg + "\".");
                    comm.Send(originalMsg, 1, 0);

                    //example of a blocking Receieve
                    string msg = comm.Receive<string>(Communicator.anySource, 0);

                    //not printed until the message is received.
                    if (msg.Equals(originalMsg))
                    {
                        Console.WriteLine("Root: Good job guys! You got it!");
                    }
                    else
                    {
                        Console.WriteLine("Root: Close enough...");
                    }
                }
                else
                {
                    //more blocking Recieves
                    string msg = comm.Receive<string>(comm.Rank - 1, 0);

                    string newMsg = jumble(msg);

                    Console.WriteLine(comm.Rank + ": " + newMsg);

                    comm.Send(newMsg, (comm.Rank + 1) % comm.Size, 0);
                }
            }
        }

        static string jumble(string word)
        {
            Random rand = new Random();
            int i = rand.Next(0, word.Length);
            int j = rand.Next(0, word.Length);
            StringBuilder sb = new StringBuilder();

            for (int x = 0; x < word.Length; x++)
            {
                sb.Append(word[x]);
            }
            char temp = sb[i];
            sb[i] = sb[j];
            sb[j] = temp;
            return (sb.ToString());
        }
    }
}
