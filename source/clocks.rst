
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



