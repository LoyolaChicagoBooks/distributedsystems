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


Storage Devices
===============

-  Types of permanent devices:

   -  Magnetic - hard disk, tape, floppy disk

   -  Optical - CD/DVD/Blu-Ray, Laser Disc, Paper, Punch Cards, Photo
      Film

   -  Solid State - CMOS, NAND based flash, battery backed dynamic
      memory

-  Types of transient devices:

   -  RAM, Processor Caches


Storage and Failure
-------------------

-  An excellent paper about hard disk failure rates at Google is
   available here:

-  https://www.usenix.org/legacy/event/fast07/tech/full_papers/pinheiro/pinheiro.pdf

-  At Google, the failure rates of disks of a given age are:

   -  3-months - 2.5

   -  6-months - 2.0

   -  1-year - 2

   -  2-year - 8

   -  3-year - 8.5


Maximizing Availability - RAID
------------------------------

-  To prevent the loss of availability of data, the use of RAID
   (Redundant Array of Inexpensive Disks) allows for redundant copies of
   data to be stored.

-  Common RAID levels are:

   -  RAID 0 - splits data across disks. Increases disk space and
      provides no redundancy. 2 or more disks are needed.

   -  RAID 1 - creates an exact copy of data on two or more disks.

   -  RAID 5/6 - splits data across disks. Uses one or more disks for
      parity. This allows 1-K out of N disks to fail and allow the data
      of any lost disk to be recovered. 3 or more disks are needed.

RAID
----

-  RAID has three common implementation approaches:

   -  Complete hardware implementation - a disk controller or expansion
      card implements RAID. Several disks are connected to this
      controller and it is presented to the operating system as a single
      storage device. Often have reliability guarantees.

   -  Partial hardware implementation - Same as the complete hardware
      implementation, except parity calculations, and buffering are
      delegated to the host CPU and memory. Don’t often have reliability
      guarantees.

   -  Software implementation - The operating system itself manages
      several disks and presents to the file-system layer a single
      storage device.


RAID - 0
--------

    .. figure:: figures/raid_0.*
       :align: center
       :alt: image

       image

RAID - 1
--------

    .. figure:: figures/raid_1.*
       :align: center
       :alt: image

       image

RAID - 5
--------

    .. figure:: figures/raid_5.*
       :align: center
       :alt: image

       image


Local Storage
=============
 - At the basis of almost any distributed system are the factors involved in local storage systems.
 - The problems presented in local storage are simpler and less composed than in their distributed counter-parts.


Implementing Files and Folders
------------------------------

-  How files and folders are implemented in a storage medium can greatly
   depend upon the physical characteristics and capabilities of that
   medium.

-  For example, on tape-drives, CD/DVD/Blu-Ray, or write-once media,
   files and folders are stored contiguously with no fragmentation. All
   of the information about the filesystem can be held in a TOC (Table
   Of Contents).

-  For filesystems with files that have a finite lifetime, such as on
   flash media, hard disks, SSDs, and others, the layout of files and
   folders must be maintained in a more complex way.

-  Among these more advanced methods are linked lists and i-nodes.

-  To manage free-space, objects like bit-maps and linked lists are
   possibilities.

Inodes
------

-  inodes are the fundamental structures of a UNIX filesystem

-  inodes have the following attributes:

   -  File Ownership - user, group

   -  File Mode - rwx bits for each of user, group, and others

   -  Last access and modified timestamps

   -  File size in bytes

   -  Device id

   -  Pointers to blocks on the storage device for the file or folder’s
      contents

Inodes - Indirect Blocks
------------------------

-  The strategy of using indirect, double indirect, and even triple
   indirect blocks is a very successful implementation strategy

-  This approach is used by ext2 / ext3 / ext4 in Linux.

.. figure:: figures/ext2-inode.*
   :align: center
   :alt: image


Block Caches
------------

-  To improve the performance of a filesystem, and to make disk
   scheduling algorithms more realizable, most operating systems
   implement some kind of block cache.

-  The block cache allows for read-ahead and write-behind. It also
   allows for lower latency I/O operations.

-  With a block cache, the write() system call for instance only needs
   to complete modifications to the cache before returning. The
   operating system can complete the operation on disk in a background
   thread.

-  Without this cache, the system call would not be able to return until
   the write had been committed to disk.


-  Important parameters of any block cache are:

   -  The size of the cache in physical memory

   -  The delay before committing ’dirty’ items in the cache to disk

-  The larger the cache, the better the filesystem will likely perform,
   but this can come at the cost of available memory for programs.

-  The larger the delay before writing items to the disk, the better the
   disk allocation and scheduling decisions the operating system can
   make.

-  The shorter the delay before writing to disk, the greater the
   guarantee in the presence of failure that modifications will be
   persisted to disk.

Folders and Path Traversal
--------------------------

-  In all but the most simple filesystems, there is a concept of a
   folder and a path.

-  In UNIX operating systems, folder entries are held within inodes that
   have the filetype in the mode set to type directory.

-  The contents of the inode then are a list of filenames and pointers
   to the inodes of those files and/or folders.

-  Resolving paths involve accessing a root folder, and accessing each
   folder recursively until reaching a file or finding the folder to be
   invalid.

-  An example of path traversal. When traversing paths, the path may
   cross into different filesystems.


	.. figure:: figures/path_traversal.*
	   :align: center
	   :alt: image



Virtual Filesystems / VFS
-------------------------

-  Aside from files and folders there are other things like named pipes,
   domain sockets, symbolic and hard links that need to be handled by
   the filesystem.

-  Rather than have the semantics of these implemented in each
   filesystem implementation, many OS architectures include a virtual
   filesystem or VFS.

-  The VFS stands between the OS kernel and the filesystem
   implementation.

Virtual Filesystems / VFS
-------------------------

-  The VFS can help adapt both foreign filesystems (such as VFAT) by
   producing a contract that these implementations can adapt to.

-  The VFS can also help reduce code duplication between FS
   implementations by providing common structures and handling shared
   behavior:

   -  Path traversal

   -  Handling named pipes, domain sockets, etc...

   -  Managing file handles and file locking

   -  Structures and functions for the block cache.

   -  Structures and functions for accessing storage devices

Virtual Filesystems and Stacking
--------------------------------

-  In some VFS implementations it is possible to stack filesystems on
   top of each other.

-  A great example of this in Linux is UMSDOS: the base VFAT filesystem
   does not have support for users, groups, security or extended
   attributes. By creating special files on VFAT and then hiding them,
   UMSDOS can adapt VFAT to be a UNIX-like filesystem

-  Another great example of this is UnionFS. It allows two filesystems
   to be transparently overlaid.


Distributed Filesystems
=======================

 - Flat file service
	- implements operations on the contents of file
	- UFID (Unique File Ids) used to refer to files
	- new UFID assigned when file created
 - Directory  service
	- provides mapping between text names and UFIDs
	- Functions to create, update.. directories
 - Client module
	- runs on client computer
	- provides APIs to access files
	- holds information about network location of file server and directory server 
	- sometimes caching at client


File Service Model
------------------

 - Upload/download model
	- read/write file operations
	- entire file transferred to client
	- requires space on client
	- Products like SkyDrive and DropBox work like this
 - Remote Access Interface
	- large number of operations 
		- seek, changing file attributes, read/write part of file…
		- does not require space (as much) on client


Directory Service
-----------------

 - Key issue for distributed file system
	- whether all clients have the same VIEW of the directory hierarchy


Naming Transparency
-------------------
 - Location Transparency
	- path names give no hint as to where the files are located
  	- e.g., /server1/dir1/dir2/X indicates X located on server1 but NOT where server1 is located
	- Problems? If X needs to be moved to another server (e.g., due to space) - say server2 - programs with strings built in will not work!
 - Location Independence
	- files can be moved without changing their names
 - Three common approaches to file and directory naming
	- Machine + path naming, such as /machine/path or machine:path (location dependent)
	- Mounting remote file systems onto the local file hierarchy (location dependent)
	- A single name space that looks the same on all machines (location independent)

File Sharing Semantics
----------------------

- When files are shared (and one or more write) what are the semantics?


UNIX Semantics
--------------

 - A read is always provided with the last write (system enforces absolute time ordering)
 - UNIX semantic can be achieved by
	- read/write going to server
	- no caching of files
	- sequential processing by server
	- BUT in distributed systems, this may perform poorly!
 - How to improve performance?
	- requires caching
 - Modify Semantics?
	- “changes to an open file are initially visible only to the process that modified the file. When file closes, changed become visible to others”
	- Called Session Semantics

More Semantics
--------------

 - Q What is the result of multiple (simultaneous) updates of cached file?
	#. final result depends on who closed last!
	#. one of the results, but which one it is can not be specified (easier to implement)
 - Immutable Files
	- can only create and read files
	- can replace existing file atomically
	- to modify a file, create new one and replace
	- what if two try to replace the same file?
	- what if one is reading while another tries to replace?


Distributed File System Implementation
--------------------------------------

 - Need to understand file usage (so that)
	- implement common operations well
	- achieve efficiency
 - Satyanarayan (CMU) of file usage pattern on UNIX


System Structure
----------------

 - How should the system be organized?
	- are clients and server different?
	- how are file and directory services organized?
	- caching/no caching
		- server
		- client
	- how are updates handled?
	- sharing semantics?
	- stateful versus stateless


Directory Service
-----------------
- Separate
	- (-) requires going to directory servers to map symbolic names onto binary names
	- (+) functions are unrelated (e.g., implement DOS directory server and UNIX server- both use same file server
	- (+) simpler
	- requires more communication
- Lookup

Stateless versus Stateful
-------------------------
 - Stateless advantages
	- Fault tolerance
	- No OPEN/CLOSE calls needed
	- No server space wasted on tables
	- No limits on number of open files
	- No problem if client crashes
 - For example,
	- each request self contained
	- if server crashes - no information lost 


Caching
-------
 - One of the most important design considerations
	- impacts performance
	- If caching  --  how should it be done?


Caching - Server
----------------
 - Server Disk
	- (+) most space
	- (+) one copy of each file
	- (+) no consistency problem
	- (-) performance
		- each access requires disk access --> server memory --> network --> client memory
 - Server Memory
	- keep MRU files in server’s memory
	- If request satisfied from cache ==> no disk transfer BUT still network transfer
	- Q. Unit of caching? Whole files
		- (+) high speed transfer
		- (-) too much memory
	- Blocks  + better use of space
	- Q. What to replace when cache full?
		- LRU


Caching - Client
----------------
 - Client Caching
 - Disk 
	- slower
	- more space
 - Memory
	- less space
	- faster
 - Where to cache?
 - User Address Space
	- cache managed by system call library
	- library keeps most heavily used files
	- when process exits - written back to server
	- (+) simple
	- (+) low overhead
	- (-) effective if file repeatedly used
 - Kernel
	- (-) kernel needed in all cases )even for a cache hit)
	- (+) cache survives beyond process ( e.g., two pass compiler - file from first pass available in cache)
	- (+) kernel free of file system 
	- (+) more flexible
	- little control over memory space allocation
		- e.g., virtual memory may result in disk operation even if cache hit


Client - Cache Consistency
--------------------------

 - client caching introduces inconsistency
	- one or more writers and multiple readers
 - Write-thru
	- similar to between processor cache and memory
	- when a block modified - immediately sent to server (also kept in cache)
 - problem
	- client on machine 1 reds file
		- modify file (server updated)
	- client on machine 2 reads and modifies files
		- server updated
	- another client on machine 1 reads file
		- gets local copy (which is stale)
 - solution: write-thru
	- cache manager checks with the server before providing file to client
	- If local copy upto-date
		- provide to client
	- Else get from server
	- RPC for check is not as expensive as file access
 - Performance problems
	- read is fine
	- each write generates network traffic (very expensive)
	- compromise - periodic updates (say 30 sec) of writes
	- collected and sent to server
	- eliminates writing of many scratch files completely (which otherwise would be written)
 - Note- semantics have changed for delayed writes


Client - Cache Consistency - Other Options
------------------------------------------

 - Write-on-Close
	- session semantics
	- wait (delay - say 30 sec) after close to see if file deleted
		- in that case write eliminated
 - Centralized Control
	- File server keeps track of who has file and in what mode
	- if new request for read - server checks to see if file opened read/write
	- if read  - grant request
	- if write - deny request
	- when file closed - inform others
	- Many variations possible


Replication
-----------
 - Multiple copies of files for
	- increased reliability so no data is lost
	- increased availability when one server is down
	- improved performance through division of load


Replication - Update Protocols
------------------------------

 - send update to each file in sequence
	- problem - if process updating crashes in the middle ==> inconsistent copies
 - Primary Copy Replication
	- one server designed as primary 
	- primary updated (changes made locally by primary server)
	- primary server updates secondary copies
	- reads can be done from any copy
	- to guard against primary copy failure
		- updates first stored on stable storage
	- But if primary copy down - No update can be made!!


Replication - Voting Algorithm
------------------------------

 - Requires clients to acquire permission of multiple servers before reading/writing file
 - File replicated on N servers - to update client needs to contact  majority , N/2 + 1 servers
 - File changed and new version no assigned
 - To read - client contacts N/2 + 1 servers
	- will always get the latest version       


Replication - General Quorum Algorithm
--------------------------------------

 - No of replicas - N
 - Read Quorum - Nr
 - Write Quorum - Nw
 - Constraints  Nr + Nw > N
 - Read/write requires participation of the corresponding quorum 


Case Study - SUN NFS
====================

 - NFS - Network File System
	- designed to allow an arbitrary collection of clients and servers to share a common file system
 - Design Goals
	- heterogeneity
	- access transparency
	- local and remote accesses look the same - e.g., normal UNIX system calls
	- failure transparency
	- stateless
	- idempotent
	- performance transparency
	- client caching
	- server caching
 - Location Transparency
	- client establishes file name space by adding remote file systems to local name space
	- file system exported by servers (node holding it)
	- file system remote-mounted by  client
 - Not Supported in Design Goals
	- Replication transparency
		- separate service for replication (NIS)
	- Concurrency
		- Naïve locking
	- Scalability
		- limited
		- originally designed to support 5-10 clients


SUN NFS - Implementation
------------------------

 - VFS Layer
	- maintains table with one entry for each open file
	- entry called v-node (indicates  whether local or remote)
	- v-node points to I-node (for local files) and r-node (for remote files)

 - Typical Operation
	- Read 
		- locate v-node
		- determine local or remote
		- transfer occurs in 8K (normally) byte blocks
		- automatic prefetching (read-ahead) of next block
	- Write
		- writes not immediately written to server
		- 8K bytes collected before writing

 - Caching
	- server caches (to reduce disk accesses)
	- client maintains cache for
		- for file attributes (I-nodes)
		- for file data
	- cache block consistency problems
		- with each cache block is a timer
		- entry discarded when timer expired
		- when file opened- server checked for last modification of file
	- UNIX semantics not completely enforced


