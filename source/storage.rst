Distributed Systems and Storage
===============================

Types of Non-Local Storage
--------------------------
#. SANs - Storage Area Networks
#. NASs - Network Area Storage
#. NFS/CIFS - Network File System / Common Internet File System
#. Cloud Storage / Sync Services
#. Distributed File Systems
#. Parallel File Systems

How Do We Evaluate Storage Systems?
-----------------------------------
 - Latency - How long does a single operation of the smallest fundamental unit take to complete.
 - Throughput - How many bytes of data per second can we read or write
 - Parallel scaling - When several requests are issued at the same, or nearly the same time, how are latency and throughput affected.
 - Resilience to failure of storage components - How many and which types of storage hardware failures can be tolerated without the system availability being interrupted and how is performance affected.
 - Resilience to failure of network components - If a network is partitioned or fails, does the storage system remain consistent and how are partially complete operations handled
 - Semantics - What capabilities are offered to clients? Can existing files be re-written? Are there folders? Is random access possible? How are files locked and shared? Are there any transactional semantics?
 - Location Transparency

 
