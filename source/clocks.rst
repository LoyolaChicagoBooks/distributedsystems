
Clocks and Synchronization
==========================


What is Time? Some Physics
--------------------------

- The understanding of time has evolved greatly in the past 150 years.
- With Einstein’s Special and General Relativity Theories, we’ve come to understand: 
	- That time is interwoven with space
	- Time is relative to the reference frame of an observer
	- We now know that simultaneity is a relative concept. Two events A and B occurring simultaneously in one reference frame may appear to be ordered A then B in another frame and B then A in yet another reference frame. 
	- All of this is true without invalidating the observations our causal relationships observed in any reference frame.

.. figure:: figures/clocks/Relativity_of_Simultaneity.svg
   
   Two events in space-time. The green observer sees A and B happening at the same time since the two events happen on the same X time plane for A. For the red observer, B is encountered first, then A second. For the blue observer A happens first, and B second. (Image taken from http://commons.wikipedia.org/wiki/File:Relativity_of_Simultaneity.svg under the Creative Commons License.)


Time and Computation
--------------------

- This dive into physics is not so much to give a lesson in physics, but to impress upon you the underlying complexity of something most people take for granted every day.
- In a similar fashion, in computation, the concept of time measurement can be very complicated
- When building a distributed system, do not take it for granted that you can simply trust the clock on the machine that is executing your code.
- More complicated solutions are needed to establish the order of events that have occurred or when they will occur in the future.


Physical Clocks
---------------

- Computer Timer: an integrated circuit that contains a precisely machined quartz crystal. When kept under tension the quartz crystal oscillates at a well-defined frequency.
- Clock Tick: after a predefined number of oscillations, the timer will generate a clock tick. This clock tick generates a hardware interrupt that causes the computer’s operating system to enter a special routine in which it can update the software clock and run the process scheduler.
- This system is fairly reliable on one system. With the timer we can define:
	- simultaneous: all actions that happen between clock ticks
	- before: an operation that happens in a previous clock tick
	- after: an operation that happens in a subsequent clock tick


Physical Clocks - Multiple Systems
------------------------------------

- Unfortunately, it is impossible for each machined quartz crystal in every computer timer to be exactly the same. These differences create clock skew.
- For example, if a timer interrupts 60 times per second, it should generate 216,000 ticks per hour.
- In practice, the real number of ticks is typically between 215,998 and 216,002 per hour. This means that we aren’t actually getting precisely 60 ticks per second.
- We can say that a timer is within specification if there is some constant p such that:

.. math::

	1 - p <= \frac{dC}{dT} <= 1 + p


- The constant p is the maximum drift rate of the timer.
- On any two given computers, the drift rate will likely differ.
- To solve this problem, clock synchronization algorithms are necessary.



Clock Synchronization
------------------------------------

- The common approach to time synchronization has been to have many computers make use of a time server.
- Typically the time server is equipped with special hardware that provides a more accurate time than does a cheaper computer timer
- The challenge with this approach is that there is a delay in the transmission from the time server to the client receiving the time update.
- This delay is not constant for all requests. Some request may be faster and others slower.
- So how do we solve this problem?


.. figure:: figures/clocks/ntp_request_response.jpg


- The relative time correction C can be calculated as:


.. math:: 

	C = \frac{(T2 - T1) + (T3 - T4)}{2}


- The way this works is that the client sends a packet with T1 recorded to the time server. The time server will record the receipt time of the packet T2. When the response is sent, the time server will write its current time T3 to the response. When the client receives the response packet, it will record T4 from its local clock. 
- When the value of C is worked out, the client can correct its local clock
- The client must be careful. If the value of C is positive, then C can be added to the software clock
- If the value of C is negative, then the client must artificially decrease the amount of milliseconds added to its software clock each tick until the offset is cleared.
- It is always inadvisable to cause the clock to go backwards. Most software that relies on time will not react well to this.



