MPI and Distributed Topics
===========================

General Points
~~~~~~~~~~~~~~~
 
- Optimized for performance. Algorithms for collective communications are optimized based on the knowledge of the network. 
 
- Reliable when sending/receiving messages. The use of tags and ranks make sure the right messages are received.

- Messages arrive in order: If I send two back to back string messages, you will get them in the order I sent them.
 
- Maintainability and Readability: a lot of the algorithms are done under the hood so in your code you will simply see calls to
  scatter, gather etc, and not have to worry about the inner workings. 

Openness
~~~~~~~~~~

- Anyone is welcome to write an MPI implementation for any language or platform.

- MPI forums are open and publically available as well as many implementations.

Scalability
~~~~~~~~~~~~~

- In one sense MPI scales really well: if you want to add more processes you simply resend the command with more processes. 
  On the other hand, some of MPI's collective communications can cause problems when scaling.

- For example, Alltoall requires an array of the size of the number or processes. If we had say a million processes, 
  then each process would have a huge array.

- Also the make up of the processes is generally a graph of some sort. Some of these are not very efficient when handling a lot
  or processes.

Fault Tolerance
~~~~~~~~~~~~~~~~~

MPI, being an Interface, says very little about Fault Tolerance. 
However implementations of MPI should and to an extend do have some Fault Tolerances Built in. 

- Resend Messages. If a message is lost or corrupt resend it. 

- Give errors that the application can then use to survive.

Other forms of fault tolerance are left up to the application.
	
- One example is that when a process fails, it can return an error to all processes who try to talk to it instead of 
  crashing the program. The remaining processes can then do something about it. For example, if the process 
  responsible for summing some section of the indexes bombs out, we could write our code to reassign the section.

- Another example is checkpoints. Putting checkpoints in is expensive, but can be worth it.

Transparency
~~~~~~~~~~~~~~~

MPI is fairly transparent.

Access - We can access local or remote processes.

Location - We do not care / do not need to be aware of where they are being performed.

Migration - Messages (data) can go from local to remote processes. We can move around an array and edit it between processes. Without the user needing to know.

Failure - Failures can be concealed and handled inside the code (to an extent).




