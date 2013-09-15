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

- Threads:
	- Threads can be thought of (and are often referred to as) lightweight processes
	- Provide multiple threads of control
	- Have multiple program counters
	- Have multiple stacks
	- One parent process, the virtual address space is shared across processes
	- Each thread runs sequentially
	- In a given process with N threads, 0-i threads may be blocked, and 0-k threads are runnable or running.


	


