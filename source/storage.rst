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
---------------

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

-  http://labs.google.com/papers/disk_failures.pdf

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

    .. figure:: figures/storage/raid_0.*
       :align: center
       :alt: image

       image

RAID - 1
--------

    .. figure:: figures/storage/raid_1.*
       :align: center
       :alt: image

       image

RAID - 5
--------

    .. figure:: figures/storage/raid_5.*
       :align: center
       :alt: image

       image


Local Storage
-------------
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

	.. figure:: figures/storage/Ext2-inode.gif
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


	.. figure:: figures/storage/path_traversal.png
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



