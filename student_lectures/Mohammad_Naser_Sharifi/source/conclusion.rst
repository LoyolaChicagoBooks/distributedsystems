BitTorrent as a Distributed Solution
======================================

Distributed Characteristics
--------------------------------
- Support for resource sharing

  - Trackers are used to make sure that resources are shared among as many peers as possible

- Openness

  - The specification is open for implementation.
  - No restriction to any particular platform whatsover. There are implementations for various platforms.

- Concurrency

  - Each peer is both a client and server
  - Many processes interact to achieve the job

- Scalability

  - Peers are added or removed seamlessly without affecting the reliability of the system.
  - New trackers can be added and old one can disappear without much effect to the whole system.

- Fault Tolerance
 
  - When peers appear or disappear at random, the system is not affected significantly as long as there is at least one seeder.
  - One or more trackers should always exist to propogate peers information.
  - If number of seeders goes to zero, peers keep sharing the portions of the files that they have. This might mean that the file(s) might be incomplete. As soon as a seeder re-appears all peers can catch up and get the whole file(s).
  - There are implementations in which there is no need for trackers.

- Transparency

  - All details are hidden from the end users.
  - It looks much like a normal client-server download manager

Advantages
-------------
- Economical: Almost no maintenance cost is involved
- It is very efficient since every participant is a content provider. No dependency on a single party.
- Highly extensible: peers join and leave with almost no effect on the content with the exception that there always should be at least one seeder.
- It is reliable: As long as there is one seeder (and more peers), it is guaranteed that the system works well.
- It gives flexibility: The work is evenly distributed among peers.

Disadvantages
--------------
- If there is no seeder, for some content the peers may end up exchanging only part of the whole content.
- Peers are loosely dependent on one another for bandwidth.
- Designed for public file sharing and hence not the best option for private sharing
- Copyright infringment concerns: it is hard to control whether the shared resources for copyright infringement.

