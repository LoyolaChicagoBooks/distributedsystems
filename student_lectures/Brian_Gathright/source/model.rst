The MPI Programming Model
===========================

Now that you see that MPI has uses and benefits, let us talk briefly on the nitty-gritty details of how an implementation of MPI
looks and works. All implementations of MPI should have the following capabilities.

Multiple Processes - Ranks
---------------------------

As mentioned above, MPI works on multiple processes, that is multiple computers in a workstation or cluster all working together (or all on one machine).
In MPI, each process is assigned a Rank. Rank is used to split up the work and allow communication between the processes and also
to allow specific processes to have specific tasks. In our Summation example, the Root process (Rank 0), was responsible for sending 
out the tasks (the numbers to be summed) while all other processes (Rank's 1 - N) were responsible for summing a list of numbers and returning
the results. By convention, the root is always Rank 0 and is generally the master process, assuming your program needs such a process.

A naive approach to setting this up would be to define the root process, give it specific instructions, and then define the other processes. We could do this via classes for example.
However, MPI does this for us (by assigning the ranks) and so we can simply write our code with reference to Ranks. 
For instance, the summing example could look like this:

::

	if Rank == 0 
	{ 
		assign numbers; 
		wait for responses; 
		sum the responses;
                return the sum;
	}
 
	else
	{ 
		wait for numbers;
		sum them;
		return them;
	}

In this way we only have to write the program once, and then the processes will know what to do based on their Rank.
Each process is running the same program, but is working on different parts of it. We will look back at the Summation problem later on.

Writing a Simple MPI Program
-----------------------------

In order to write your own MPI programs you will need an Implementation of MPI for the language you wish to code in.

We used:

- MPI.NET: http://osl.iu.edu/research/mpi.net/software/
- Microsoft Compute Cluster Server: http://www.microsoft.com/en-us/download/details.aspx?id=239 is necessary for cluster work.

Once you have an implementation installed you can begin coding. You will need to reference that you wish to use MPI (in C# this is done by the "using" statement at the top of your code). You will also need to add MPI to your project references. Next inside your code you will need to set up an MPI Environment. 
In C# the skeleton looks like this:

::

	using System;
	using MPI;

	class MPIProgram
	{
		static void Main(string[] args)
		{
			using (new MPI.Environment(ref args))
			{
				// code goes in here
			}
		}
	}

All of your code must go inside the MPI Environment, that way MPI can handle setting up and tearing down the environment for you.


Hello World
~~~~~~~~~~~~~

Assume we want to write the quintessential Hello World program. We could simply add

::

	static void Main(string[] args)
	{
		using (new MPI.Environment(ref args))
		{			
			Console.WriteLine("Hello, World!");
		}
	}

However, that would be boring; every process would just print the same thing. Instead let's make the output vary based on rank:

Here is the code:

::

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

Running the MPI Program
~~~~~~~~~~~~~~~~~~~~~~~~~

We can run the program from the command line using MPI. Most implementations use "mpiexec", though it might vary slightly. 
For MPI.NET we would write: 

::
 
	"mpiexec.exe ProgramName.exe" 

However, this would only run with one process and so our output would just be:

::

	Hello, World! I am the root.

MPI makes it easy to launch N processes: 

::

	"mpiexec.exe -n 5 ProgramName.exe" 

would launch 5 processes and so the output would now be something like:

::

	Hello, World! I am the root.
	Hello, World! I am rank 3.
	Hello, World! I am rank 4.
	Hello, World! I am rank 1.
	Hello, World! I am rank 2.

The order the processes print will vary each call. This is due to the fact they are all run concurrently. 

Note: In our examples we only launched processes from our local computer, but this is similar to how it would work on a cluster of computers. In the call to mpiexec.exe you also supply the host and the names of the various workstations.
