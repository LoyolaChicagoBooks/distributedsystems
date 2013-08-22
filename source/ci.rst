Continuous Integration
======================

What Does Continuous Integration Do?
------------------------------------

- To support incremental, agile development for one or more developers
- Provides notification of success or failure of forward integration as rapidly as possible. This is especially important on larger teams.
- Performs validation of the product by running unit tests, and automated user interface tests
- Can perform scheduled test or production environment deployments.


How Often is Continuous Integration Run?
----------------------------------------

- Continuous Integration can be run as:
	- Batches - once one build and verification is complete, another immediately starts (grouping more than once change, potentially)
	- Upon changes - build and validate the product at every change
	- Iteration builds - every day, every week, or some other short period, a distributable product with an installer or package is created. This can be used for manual testing by a test team or by customers.


What are the Bits and Pieces of Continuous Integration?
-------------------------------------------------------

- Build Controllers:
	- A service that coordinates build requests and build operations
	- Manages resources such as artifact repositories, build folders, and individual build nodes.
	- One or more of these may exist depending upon the product involved.
	- Usually a very I/O and memory bound service
- Build nodes:
	- Answer requests from the build controller (the work horse of continuous integration)
	- Pulls source code, performs compilation, executes automated tests
	- Some environments have as few as 2-3 build nodes, some have hundreds
	- Usually a CPU and I/O bound service
- Artifact Database:
	- Stores the N most recent continuous integration builds
	- Stores external 3rd party libraries used in building various versions of the product
	- Stores several versions of released builds of individual modules of the product (in the case of component or plugin architectures)
	- Stores installers for released or testable products
	- Typically has dozens of TB of storage on a fast SAN
- Deployment of Continuous Integration:
	- Build controllers typically have fairly high resource utilization
	- Build nodes typically do not have high resource utilization
	- The process of compiling and running unit tests typically does not fully utilize the power of a build node
	- So, a common practice is to virtualize hosts that run build nodes and place at run at least two hosts per build node
	- It is uncommon to allow more than one build task to occur simultaneously on a build node
	- Build nodes are commonly re-imaged every day - every few days.
	- Many continuous integration products are capable of running in the cloud with dynamic resource utilization for the build nodes. Both Team City and Team Foundation Server are well known for this


.. figure:: figures/ci/ci_system.jpg
   :scale: 60 %

   A Possible Corporate Deployment of a Continuous Integration System

Continuous Integration Products / Vendors
-----------------------------------------

- Many exist, but these are what you see out there in the wild:
- Jet Brains - Team City
- Microsoft - Team Foundation Server
- Borland - Silk 
- IBM - Rational Suite
- Apache Foundation - Continuum
- Eclipse Foundation - Hudson
- Many in-house / script based systems

