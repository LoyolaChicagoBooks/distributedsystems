What are Distributed Hash Tables?
********************************************************
Overall
===================================================
- Lookup system that is similar to a standard hash table.
- Distribute data over peer to peer networks to quickly find any item and form data storage responsibility
- Nodes can retrieve the values.
- Because responsibility is distributed among the notdes, things can change with minimal disruption.
- Scales very well.
Properties
===================================================
- Autonomony and Decentralization.
- Fault Tolerance.
- Scalability (up to millions of nodes).
Structure
===================================================
- Foundation of an abstract keyspace (160-bit strings).
- Keyspace partitioning: splits ownership of space among the nodes.
- Overlay network: connects the nodes.
Keyspace Partitioning
===================================================
- Map keys to nodes.
- Each node has an identifier key.
- Most DHTs use consistent hashing: allows for adding and removing nodes with less impact
- Locality-preserving hashing: similar keys assigned to similar objects
Overlay Network
===================================================
- Each node has links to other nodes which form the network.
- Network Topology.
- Key-based routing.
- Worst case route.
Algorithms for Overlay Networks
===================================================
- Overlay multicast.
- Range queries.
- Collect Statistics.
Architecture
===================================================
- place a picture here. 
What are DHTs good at?
===================================================
- Very scalable because they can automatically distribute things to new nodes.
- Designed to prevent node failure.  Data is automatically moved away from a failed node.
- They have no need for a central server because they are self organizing. 
What are DHTs bad at?
===================================================
- Searching: due to their hash algorithm, similar data can be at different nodes.  ****This is not the same as a DHT lookup.
- Security: data integrity is hard to verify and secure routing is a problem.

Indices and tables
==================

* :ref:`genindex`
* :ref:`modindex`
* :ref:`search`

