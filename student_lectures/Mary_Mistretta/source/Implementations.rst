Implementations
********************************************************
Apache Cassandra
===================================================
- This is an open source distributed database management system.  It can handle large amounts of data and provides high availability without a single point of failure.  The system places a high value on performance. 
- Rows are organized into tables.  Tables can also be altered at runtime.  However, there is no support for joins or subqueries. 
- Column indexes with log-structures updates, support for denormalization and materialized views. Powerful Built in caching.
- The system is proven to work.  It is used in netflix, eBay, Twitter, Reddit, and more. The largest use has over 300TB of data in 400 machines.
- The main features of Apache Cassandra are: Fault tolerance, performance, decentralized, durable, control, elasticity, and professional support. 
Mainline DHT
===================================================
- Mainline DHT is teh DHT used by BitTorrent clients to find peers.  It was designed for decentralized peer-to-peer networks.  The decentralization allows for more resistance to a denial of service attack (proper internet use). 
- The DHT stores resource locations around the network allowing for quick and easy lookup.  This method makes it a perfect technology to use in peer-to-peer systems. 
CAN (Content Addressable Network)
===================================================
- This infrastructure provides hash table functionality on a large scale.  It is a distributed and decentralized peer-to-peer structure.  
- It is designed to be scalable, fault tolerant, and self-organizing.  It uses a Catersian coordinate system for virtual addresses.  Each node maintains a routing table holding the IP address and coordinate of each of its neighbors.  
- This structure can perform node joining and departing. 
BATON Overlay
===================================================
- BATON: BAlances Tree Overlay Network is a distributed tree structure for peer-to-peer systems. It supports range search by organizing peers in a tree structure. The systems keeps the tree balanced similarly to AVL trees. 
- Because of the tree structure BATON has a quick search of O(log N).
- It is a binary tree structure with links to child and parents nodes.  BATON does support node joining and leaving. The tree automatically restructures itself when it detects an inbalance.  
Tutorial
===================================================
- UTorrent is a small BitTorrent client. It uses a DHT and is very simple to use.  
- ***Please note Loyola blocks some of this software if it is detected on your machine.  I do not recommend using it while connected to Loyola's Network***.

Indices and tables
==================

* :ref:`genindex`
* :ref:`modindex`
* :ref:`search`

