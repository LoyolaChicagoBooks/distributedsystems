MPI - Message Passing Interface
=================================

What is MPI?
-------------

MPI stands for Message Passing Interface.
 
- MPI is used to send messages from one process (computer, workstation etc.) to another. These
  messages can contain data ranging from primitive types (integers, strings and so forth) to actual objects.

- MPI is only an Interface, as such you will need an Implementation of MPI before you can start coding. 
  The interface itself lists the functions that any implementation of it must be able to perform. 
  As such, MPI implementations are standardized on the basis that they all conform to the overarching interface. 
  Think of MPI as a protocol: it defines the rules for Message Passing, but it is up to implementations to implement 
  functions that follow the rules.

- MPI is a language-independent communications protocol. Implementations of MPI have been developed for several different languages.
  For example, pyMPI is used for Python and MPI.NET is used for C#. Note: in this lecture we are using MPI.NET and C#.
 
- To summarize: MPI is a message passing library whose implentations are used to send messages (data, instructions, etc.) 
  to other processes in order to perform specific tasks. In this way MPI is very much a Distributed topic.  

Uses of MPI
------------

MPI is helpful whenever you need several workstations (or clusters) to work together efficiently and effectively.

Two examples of such tasks are Parallel Computing and Monte Carlo Simulations.

Parallel Computing
~~~~~~~~~~~~~~~~~~~

Parallel computing is a form of computation in which multiple calculations are done at the same time.

For example, imagine you want to calculate the sum of a large amount of numbers (as in hundreds of thousands). You could do this several ways. 

- Obviously, you could simply sum all the numbers in a linear fashion with one process. If there are a ton of numbers, 
  this is not ideal. 

- You could improve your solution by implementing threading, but this would require you to have a lot of overhead 
  for making sure the threads communicate effectively. That is they need to be assigned explicit numbers to sum 
  and where to save those numbers. We would also need a master (or root) thread to get all of the info from the other threads. 
  Not to mention you would need to make everything thread safe. This sounds bothersome. 

- Luckily, MPI would make this type of problem fairly painless. MPI can make use of collective functions (more on that in a minute), 
  in which one process, the root, can communicate with all other processes. Using an MPI call the root process can assign numbers to 
  the other processes and allot space for where the results should go. Once the other processs receive their numbers they sum them and
  return the results to the root process. The root process can then simply sum the sums. That's it. We will look at the code in a bit.

Monte Carlo Simulations
~~~~~~~~~~~~~~~~~~~~~~~~~

Briefly, Monte Carlo computations are computations that rely on random simulations that are done repeatably to derive probablities.

MPI works great for this! Imagine you want to calculate the approximate value of Pi. 

- One way of doing this is to simulate throwing darts at a circle inside a square. The ratio of darts inside 
  the circle is the approximate value of Pi. Just like the summation problem above, we can do this in a linear fashion. 

- However, MPI would allow us to scale up the number of simulations we do. For example, we could throw 1000 darts at a board, but our
  results would be much more accurate if we threw 1000 darts at 10 different boards. With MPI we can do that: each operation is done
  on a different process and in parallel. The results can then be compiled and are much closer.


