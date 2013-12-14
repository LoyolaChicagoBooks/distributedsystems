Communication is Key
======================

Our Hello World program is technically an MPI program, but there was no actual communication between the different processes. Let's remedy that.

MPI allows two major types of communication: Point to Point and Collectives. Before we get to those, let's briefly discuss the Communicator object.

The Communicator
-----------------

The Communicator is crucial to MPI projects. 
The Communicator is what allows the different processes to, well, communicate with eachother. 
MPI programs can have several Communicators.  
In the HelloWorld example we used "Communicator.world.Rank". 
All projects will have the "world" Communicator.
This Communicator is useful because it keeps track of all the different ranks of the processes within our project. 

More advanced projects may have several Communicators each with their own amount of processes.
Multiple Communicators are needed if you want to section off the processes in your code such that only certain processes receive messages to and from each other.

You will notice all of our code uses the world communicator for sending and receiving messages. For convenience sake we use the variable comm to refer to Communicator.world.

Point to Point
---------------

Point to Point communication is the most basic. This is simply when the processes communicate on a one to one basis. Rank 0 talks to
Rank 1, Rank 1 talks to Rank 2 etc. or even more simply Rank 0 talks to Rank 1 and Rank 1 talks to Rank 0. Point to Point can have its
uses, but we will primarily use it to illustrate message sending and then focus on the more exciting Collective Communication.

Point to Point makes use of the Send and Receive functions.

The Send function is used to send the messages. The send message takes three parameters (data, rank, tag)

- data is what we are sending
- rank is the rank of the destination of the message
- tag is used to differieniate between types of messages.
  
  - tags are useful for when we are sendign around multiple types of data, such as integers and strings. We could tag all integers with 0 and all 
    strings with 1. When a message is received it is only used if the tag matches, this is so we don't accidentally receive an integer in place of a string.

Before we continue let us talk really briefly about what data can be sent. All implementations of MPI need to be able to send primitive types.
Depending on your implementation of MPI you can also send other things. For example, MPI.NET allows the sending of:

- Primitive Types (integers, strings, floats...)
- Structures
- Serializable Classes

What you send can effect perfomance. Primitives and Structures are generally sent in a single message and are the "fastest".
Classes need to be serialized and can be split up between multiple messages, which is obviously slower. But, if you need the classes
then there isn't much you can do. 

Now let's move on to the recieve function.

The receive function is similar with parameters (rank, tag)

- rank is used so it knows who is sending the data
- tag for the reasons mentioned above: if the tags don't match that's not the message we want.

When you receive a primitive type you must match it directly, i.e. you can't receive a message with a string and save it as an integer.
However, with classes you can receive it via its base class. For example you can receive a poodle as a dog.

When you send Arrays you must make sure the receiving side has an array with enough room.

One final note is that Point to Point can be blocking or unblocking. Blocking means the process will not continue until it has received its message.
Unblocking means the process can continue executing steps while waiting for its message. 

For this example let's simply pass a string around between our processes, starting at the root and ultimately returning to the root. Each process will
add something to the string and print it so we can see the progress of our message.

::

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
	
	//switches two letters in the word
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

output with 4 processes and word "chicago":

::

	Root: Let's play a game of telephone.
	Root: The inital word is "chicago".
	1: chicaog
	2: hcicaog
	3: hcciaog
	Root: Close enough...

We could just have easily sent an array around and change values or an integer. 

This example used blocking receive: processes waited until they received a message from their neighbor. Hence, the order will always be 1, 2, 3, ... n 

Here is a really simple example with unblocking receive.

::

	static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;
                //root
                if (comm.Rank == 0)
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
                    Console.WriteLine("If root was blocking, it wouldn't have been able to print until now!");
                }
            }
        }

output:

::

	Root sent a message to Rank 1
	We are performing a nonblocking receive, so we print instantly.
	We waited half a second before sending something to the root.
	If root was blocking, it wouldn't have been able to print until now!

Collective
-------------

The other type of communication we can do is Collective, that is all the processes communicate with each other in one way or another.
You could probably do all of your coding in Point to Point Communication, but this would get messy pretty quickly. Here are two reasons
to consider Collective Communication:

- Code Readability and Maintainability.
  
  - It is easier to read and maintain code with collectives. 
  - For example if we want to send something to every process it would require N^2 point to point communications, with a collective it is one simple call.

- Performance 

  - MPI has designed algorithms that are optimized to do collective communication. As mentioned above, we can also save a lot of time having one call versus several.

The five major ways of communication that MPI implements are:

- barriers: wait for others before proceeding
  - uses Barrier

- all-to-one: all processes send data to one
  - uses Gather and Allgather

- one-to-all: sends data to all processes from one
  - uses Broadcast and Scatter

- all-to-all: all processes send data to all processes
  - uses Alltoall 

- combining results: get results from every process and do something with it.
  - uses Reduce

Barriers
~~~~~~~~~~~

Barriers are not exclusive to MPI. You might have encountered them before when using threads. A barrier simply blocks all processes
from going past a certain point in your code until all processes are at that point, hence the name: barrier.

In MPI its as simple as calling the Barrier function. 

Put barriers where you need every process to be on the same page before proceeding.

::

	static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;

                if (comm.Rank == 0)
                {
                    Console.WriteLine("Get to the CHOPPA!");
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

output:

::

	Get to the CHOPPA!
	//waits until all the sleeps are finished
	Everyone is on the CHOPPA!

All-to-One
~~~~~~~~~~~~

This type of communication is where one process requests information from all the other processes. 

The Gather and Allgather functions are used. 

Gather has two parameters: (value, rank of destination). The call to Gather returns to the destination an array of whatever the
value returns based on the rank of each process. For example we could just call gather(comm.rank, 0) and we would have an array of all
the ranks of processes we have. The ith value in the array corresponds to the value provided by the process with rank i.

Allgather is similar, but it sends data from all the processes to all the processes. In gather anyone who isn't the root will just have
an empty array, in Allgather everyone will have a copy of an array that contains everyone.

Generally the root does all the gathering. Say we want all the processes to pick a random number between 1 and 1000 and we want the root
to sort the numbers and print them out.

::

	static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;
                Random rand = new Random();

		//root's array will contain all the values returned by the rand call. all other nodes will have an empty array.
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

example output with 6 processes:

::

	117
	520
	722
	835
	877
	979

One-to-All
~~~~~~~~~~~~

This type of communication is where one process sends information to all the other processes.

The Broadcast and Scatter commands are used.

Broadcast has two parameters (value, rank) 
It sends the same value to each process for them to do whatever they want to do with.

Scatter is similar except it's value is an array and it sends the ith entry in the array to the ith process, thus spreading out 
different info to differnt processes.

Say a Professor wants his students to each write a chapter of a book... here is a program that could assign chapters.

::

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
			
		    //if the rank is yours, then you are sending the data
                    comm.Scatter(nums, root);
                }

                else
                {
	            //if the rank is not yours, then you are receiving data
                    string value = comm.Scatter(nums, root);
                    Console.WriteLine(comm.Rank + " was assigned " + value);
                }
            }
        }

output (note this example is currently hardcoded for 5 processes):

::

	1 was assigned Chapter 1: MPI
	4 was assigned Chapter 4: How to Make a Sandwich
	3 was assigned Chapter 3: MongoDB
	2 was assigned Chapter 2: BitCoins

All-to-All
~~~~~~~~~~~~~

Every process sends to every other process. Again the ith value will be sent to the process with rank i. Each process will in turn
receive a different array where the jth value will be the value from the process with rank j.

The command is simply Alltoall

Alltoall is different from Allgather. Allgather is essentially a gather followed by a broadcast; the root gathers all the info and then broadcast it out to everyone. In Alltoall, all ranks gather from all ranks - there is no gathering on one process and then dispersed.

::

	static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator comm = Communicator.world;
                string[] data = new string[comm.Size];
                for (int i = 0; i < comm.Size; i++)
                {
		    //each process fills their data with a string marked with their rank
                    data[i] = "This string came from Rank " + comm.Rank;
                }
               
		//each process will have in order the strings from each process
                string[] results = comm.Alltoall(data);


		//prints out the roots contents to show what happened
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

sample output with N processes:

::

	The root's array contains: 
	This string came from Rank 0
	This string came from Rank 1
	This string came from Rank 2
	...
	This string came from Rank N-2
	This string came from Rank N-1

Combining Results
~~~~~~~~~~~~~~~~~~~~

This is the most interesting Collective Communication (in our opinion).

It uses the Reduce function (and usually some kind of Broadcast).

This is used to sum, multiple, etc the stuff from all the processs and return it all to the process who requested it. Think back to our summation problem.

Here is the code using the call to Reduce:

::

	static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                int root = 0;
                int arraySize = 100;
                Intracommunicator comm = Communicator.world;

                int[] lotsOfNumbers = new int[arraySize];
                
		//fill the array with the numbers 0 through arraySize-1
		for (int i = 0; i < lotsOfNumbers.Length; i++)
                {
                    lotsOfNumbers[i] = i;
                }

                int sum = 0;
		
		//root shares the array of numbers with everyone else
                comm.Broadcast(ref lotsOfNumbers, 0);

                //divides up the work, this is how each process knows which numbers to sum
                int x = arraySize / comm.Size;
                int startingIndex = comm.Rank * x;
                int endingIndex = startingIndex + x;

		//the last process will grab the outliers if the size isn't divisible
                if (comm.Rank == comm.Size - 1)
                {
                    endingIndex = lotsOfNumbers.Length;
                }

		//each process sum's its part of the numbers
                for (int i = startingIndex; i < endingIndex; i++)
                {
                    sum += lotsOfNumbers[i];
                }
		//print out what process was and what it was responible for and what it came up with.
                Console.WriteLine("Rank " + comm.Rank + ": " + "summed the numbers from index " + startingIndex + " to index " + (endingIndex - 1) + " and got " + sum + ".");

		//the root gets the total sum, he gets the sum values of all the processes and adds them together
                int totalSum = comm.Reduce(sum, Operation<int>.Add, root);

                if (comm.Rank == root)
                {
                    Console.WriteLine("The total sum is: " + totalSum);
                }
            }
        }

And here is some sample output:

with size 100 and 5 processes

::

	Rank 4: summed the numbers from index 80 to index 99 and got 1790.
	Rank 1: summed the numbers from index 20 to index 39 and got 590.
	Rank 0: summed the numbers from index 0 to index 19 and got 190.
	Rank 2: summed the numbers from index 40 to index 59 and got 990.
	Rank 3: summed the numbers from index 60 to index 79 and got 1390.
	The total sum is: 4950
