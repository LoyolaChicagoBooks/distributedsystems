Concurrency and Threads
===========================

Threads vs Processes
--------------------

- Traditional Operating Systems have Processes
	- Each process has its own address space
	- Single thread of control
	- When a process makes a system call, the process blocks until the call completes.

- In many situations it is desirable to have multiple threads of control for:
	- Explicit parallelism - to take advantage of multiple processors
	- To allow computation to continue while waiting for system calls to return
		- example: one thread reads a file into a buffer, another thread compresses the buffer, and a final thread writes out a compressed file.
	- To reduce the cost of context switching
	- Implicit parallelism - to keep a single processor busy


What are Processes, Threads?
----------------------------

- Processes have:
	- Program counter
	- Stack
	- Register set
	- An exclusive virtual address space
	- Sandboxing from other process except to the extent that the process participates in IPC

	.. figure:: figures/concurrency/memory_layout.png
	   :align: center
	   :alt: Process Memory Layout

- Threads:
	- Threads can be thought of (and are often referred to as) lightweight processes
	- Provide multiple threads of control
	- Have multiple program counters
	- Have multiple stacks
	- One parent process, the virtual address space is shared across processes
	- Each thread runs sequentially
	- In a given process with N threads, 0-i threads may be blocked, and 0-k threads are runnable or running.

	.. figure:: figures/concurrency/memory_layout_multithreaded.png
	   :align: center
	   :alt: Threaded Memory Layout


Common Threading Use Cases
--------------------------

- Client / Server - ex: file servers:
	- One thread listens on a network socket for clients
	- When a client connects, a new thread is spawned to handle the request. This permits several clients to connect to the file server at one time because each request is handled by a separate thread of execution.
	- To send the file data, two threads can be used the first can read from the file on disk and the second can write the read buffers to the socket. 

	.. figure:: figures/concurrency/client_server.png
	   :align: center
	   :alt: Client-Server Thread Model

- Example Client-Server - a TCP echo server

.. literalinclude:: ../examples/systems-code-samples/threads/threads/TcpServer.cs
   :start-after: begin-class-TcpServer
   :end-before: end-class-TcpServer
   :linenos:


- Parallel computation:
	- An algorithm is designed to solve some small part or subproblem of a larger problem
	- To the extent that the subproblems are not inter-dependent, they can be executed in parallel
	- Multiple threads can work against a common task queue.

	.. figure:: figures/concurrency/parallel_threads.png
	   :align: center
	   :alt: Parallel Thread Model

.. warning:: 

   The focus of this course is on *distributed* (not *parallel*) systems. Nevertheless, you may find that you want to take advantage of parallel computing in your work. We encourage you to read Christopher and Thiruvathukal, http://hpjpc.googlecode.com, which contains many examples of parallel algorithms in Java. You may also find Läufer, Lewis, and Thiruvathukal's Scala workshop tutorial helpful. See http://scalaworkshop.cs.luc.edu. 

- Example Parallel Computation - factoring an integer

.. literalinclude:: ../examples/systems-code-samples/threads/threads/ParallelComputation.cs
   :start-after: begin-class-ParallelComputation
   :end-before: end-class-ParallelComputation
   :linenos:


- Pipeline processing:
	- An algorithm must be executed in several stages that depend upon each other.
	- For example if there are three stages, then three threads can be launched for each of the stages. As the first thread completes some part of the total work, it can pass it to a queue for the second stage to be processed by the second thread. At this time, the first thread and second thread can work on their own stages in parallel. The same continues to the third thread for the third stage of computation.

	.. figure:: figures/concurrency/pipeline_threads.png
	   :align: center
	   :alt: Pipeline Thread Model

- Example Pipeline Processing - file compression


.. literalinclude:: ../examples/systems-code-samples/threads/threads/PipelineComputation.cs
   :start-after: begin-class-PipelineComputation
   :end-before: end-class-PipelineComputation
   :linenos:


- Example Pipeline Processing - a more concise and language friendly file compression


.. literalinclude:: ../examples/systems-code-samples/threads/threads/ConcisePipelineComputation.cs
   :start-after: begin-class-ConcisePipelineComputation
   :end-before: end-class-ConcisePipelineComputation
   :linenos:


- Helper class - ThreadedList

.. literalinclude:: ../examples/systems-code-samples/threads/threads/ThreadedList.cs
   :start-after: begin-class-ThreadedList
   :end-before: end-class-ThreadedList
   :linenos:



Mutual Exclusion
----------------

- Mutual exclusion is a general problem that applies to both processes and threads.

- Processes
	- Occurs with processes that share resources such as shared memory, files, and other resources that must be updated atomically
	- When not otherwise shared, the address space of a process is protected against reads/writes by other processes
- Threads
	- Because threads share more resources such as having a shared process heap, there are more resources that need to be potentially protected
	- Because the address space is shared among threads in one process, cooperation and coordination is required for threads that read from and write to shared data structures

- When mutual exclusion is achieved, atomic operations on shared data structures are guaranteed to be atomic and not interrupted by other threads.


Tools for Achieving Mutual Exclusion
------------------------------------

- Mutex
	- Has two operations: Lock() and Unlock()
	- Has two states: Locked or Unlocked
	- A lock can be acquired before entering a critical region and unlock can be called when leaving the critical region
	- If all critical regions are covered by a mutex, then mutual exclusion has been achieved and operations can be said to be atomic
- Semaphore
	- Has two operations: Up() and Down()
	- Has N states: a counter that has a value from 0 - N
	- Up() increases the value by 1
	- Down() decreases the value by 1
	- When the semaphore has a value > 0, then a thread of execution can enter the critical region
	- When the semaphore has a value = 0, then a thread is blocked
	- The purpose of a semaphore is used to:
		- Limit the number of threads that enter a critical region
		- Limit the number of items in a queue between two threads working in a pipeline processing pattern.
- Monitor
	- Has four operations: Lock(), Unlock(), Pulse(), Wait()
	- Allows for more complicated and user-coded conditions for entering critical regions
	- The locking semantics are more complicated for the simplest cases, but can express more complicated mutual exclusion cases in simpler ways than can semaphores or mutexes

- Additional details may be found in the Operating Systems course
	- Mutual Exclusion - http://osdi.cs.courseclouds.com/html/mutualexclusion.html
	- Deadlock - http://osdi.cs.courseclouds.com/html/deadlock.html

Mutex Example/Java
--------------------

This code example shows how to implement a classic mutex, a.k.a. a Lock, in Java.

These examples come from http://hpjpc.googlecode.com by Christopher and Thiruvathukal.

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/thread/Lock.java
   :start-after: begin-class-Lock
   :end-before: end-class-Lock
   :linenos:

Semaphore Example
-------------------

This shows how to implement a counting semaphore in the Java programming language.

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/thread/Semaphore.java
   :start-after: begin-class-Semaphore
   :end-before: end-class-Semaphore
   :linenos:


Barrier
-------------

This shows how to implement a barrier, which is a synchronization mechanism for awaiting
a specified number of threads before processing can continue. Once all threads have arrived, 
processing can continue.

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/thread/SimpleBarrier.java
   :start-after: begin-class-SimpleBarrier
   :end-before: end-class-SimpleBarrier
   :linenos:


Deadlock - a classic problem
----------------------------------

A classic problem in computer science and one that is often studied in operating systems
to show the hazards of working with shared, synchronized state, is the *dining philosophers problem*.
We won't describe the entire problem here but you can read http://en.wikipedia.org/wiki/Dining_philosophers_problem.

our "solution" has the following design:

- Fork: A class to represent the forks shared by adjacent philosophers at the table.

- Diner0: A class used to represent a philosopher. The philosopher does three things a philosopher normally does: think(), sleep(), and eat().

- Diners0: A class used to represent all of the diners seated at the table with their shared forks. This is where the concurrency takes place.

Fork 
-----

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/Fork.java
   :start-after: begin-class-Fork
   :end-before: end-class-Fork
   :linenos:

Diner0
--------
.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/Diner0.java
   :start-after: begin-class-Diner0
   :end-before: end-class-Diner0
   :linenos:

Diners0
--------
.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/Diners0.java
   :start-after: begin-class-Diners0
   :end-before: end-class-Diners0
   :linenos:


Diners1 - eliminating deadlock with resource enumeration
------------------------------------------------------------
.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/Diners1.java
   :start-after: begin-fork-ordering
   :end-before: end-fork-ordering
   :linenos:

Common Data Structures in Concurrent Programming
------------------------------------------------

- Bound Buffer
	- Makes use of a mutex and semaphore internally
	- Defines a maximum number of items that exist in the bound buffer's queue.
	- Has two operations: Enqueue() and Dequeue()
	- Enqueue() - enqueues items in the data structure. If the enqueue operation would cause the bound buffer to exceed the maximum, the Enqueue() call will block until another thread dequeues at least one item.
	- Dequeue() - dequeues an item from the data structure. If there are zero items in the queue, Dequeue() will block until another thread enqueues an item in the data structure
	- Bound buffers are used to make sure that when one thread is producing work for a second thread, that if one thread is faster or slower than the other, that they appropriately wait to some extent for each other.

	.. figure:: figures/concurrency/bound_buffer.png
	   :align: center
	   :alt: Bound Buffer

- Example Bound Buffer

.. literalinclude:: ../examples/systems-code-samples/threads/threads/BoundBuffer.cs
   :start-after: begin-class-BoundBuffer
   :end-before: end-class-BoundBuffer
   :linenos:


Design Considerations
---------------------

- Threading requires the support of the operating system - a threading library / package is needed
	- In Windows, this is a part of the Windows SDK and .NET Framework
	- In Linux and Mac OSX, PThreads provides threading
- Thread usage and creation
	- Threads can be started and stopped on demand or a thread pool can be used
	- Starting threads dynamically:
		- Has some cost associated with asking the OS to create and schedule the thread
		- It can be architecturally challenging to maintain an appropriate number of threads across software components
		- This is overall the most simple approach
	- Thread Pools
		- The number of threads can be defined at compile time or when the program is first launched
		- Instead of creating a new thread, the program acquires a thread and passes a function pointer to the thread to execute
		- When the given task is completed, the thread is returned to the pool.
		- This approach does not have the overhead of creating / destroying threads as threads are reused.
		- This approach often requires library support or some additional code.
- The total number of threads
	- Having several hundred threads on a system with an order of magnitude fewer cores can cause you to run into trouble.
	- If a majority of those threads are runnable, then the program will spend most of its time context switching between those threads rather than actually getting work done.
	- If such a system is dynamically starting and stopping threads, then the program will most likely spend most of its time creating and destroying threads.


Kernel Threads vs User Mode Threads
-----------------------------------

- There are two types of threads:
	- Kernel Threads
		-Supported by modern operating systems
		-Scheduled by the operating system
	- User Threads
		-Supported by almost everything
		-Scheduled by the process

	.. figure:: figures/concurrency/kernel_user_threads.png
	   :align: center
	   :alt: Kernel and User Mode Threads


- Context switching:
	- Kernel threads have a higher overhead because the scheduler must be invoked and there might be a time lag before a runnable thread is actually executed.
	- Kernel threads often perform very well because the operating system has more information about the resource state of the computer and can make better global scheduling decisions than can a program
	- User-mode threads can context switch with fewer overall operations, but scheduling them is guess-work.
	- User mode threads can be created more rapidly because new stacks and scheduler entries do not need to be created by the operating system
- Where are user-mode threads used?
	- In systems without kernel mode threads
	- When the number of threads a system needs is in the hundreds or thousands (user-mode threads scale better in these scenarios)
- Where are kernel-mode threads used?
	- When the number of threads is not very high (less than 10 per core)
	- When blocking calls are involved (user-mode thread libraries usually have separate I/O libraries)

Concurrent File Copy Example
--------------------------------

- FileCopy0: The sequential version
- FileCopy1: The concurrent version

Sequential File Copy
------------------------------------------

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/FileCopy0.java
   :start-after: begin-class-FileCopy0
   :end-before: end-class-FileCopy0
   :linenos:

Concurrent File Copy Organization
------------------------------------------

Quick overview of the various classes:

- Pool: Maintains a list of buffers that can be used for allocating/freeing blocks of data without triggering new (or dispose) repeatedly.
- Buffer: Used as a shared object for reading and writing blocks of data (via the FileCopyReader1 and FileCopyWriter1 classes)
- BufferQueue: Used to queue up blocks as they are read or written. This allows for varying speeds of reader and writer, subject to the number of blocks available in the Pool.
- FileCopyReader1: Used to run the reader thread.
- FileCopyWriter1: Used to run the writer thread.
- FileCopy1: Used to act as a drop in replacement for FileCopy0. Sets up the reader and writer threads and then joins with both when the reading/writing are completed.

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/FileCopy1.java
   :start-after: begin-class-FileCopy1
   :end-before: end-class-FileCopy1
   :linenos:

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/FileCopyReader1.java
   :start-after: begin-class-FileCopyReader1
   :end-before: end-class-FileCopyReader1
   :linenos:

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/FileCopyWriter1.java
   :start-after: begin-class-FileCopyWriter1
   :end-before: end-class-FileCopyWriter1
   :linenos:

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/Buffer.java
   :start-after: begin-class-Buffer
   :end-before: end-class-Buffer
   :linenos:

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/BufferQueue.java
   :start-after: begin-class-BufferQueue
   :end-before: end-class-BufferQueue
   :linenos:

.. literalinclude:: ../examples/hpjpc/src/info/jhpc/textbook/chapter03/Pool.java
   :start-after: begin-class-Pool
   :end-before: end-class-Pool
   :linenos:

