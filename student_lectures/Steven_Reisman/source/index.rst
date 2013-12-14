.. boinc_chapter documentation master file, created by
   sphinx-quickstart on Tue Oct 22 19:57:25 2013.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

Welcome to boinc_chapter's documentation!
=========================================

Contents:

.. toctree::
   :maxdepth: 2



Indices and tables
==================

* :ref:`genindex`
* :ref:`modindex`
* :ref:`search`

Volunteer Computing
===================

Volunteer computing is a network arrangement which allows individuals to donate their computer resources, typically processing power and storage, in order to aid different distributed system projects.  Individuals who volunteer their computational resources are typically members of the general public working with personal computers and have an internet connection.  Although the majority of users are individuals, come companies and schools also partake in the system. 

.. figure:: ./_static/boinc_sample.png

.. [Ref] http://boinc.berkeley.edu/w/images/1/14/Comm_simple3.png 

The projects which utilize these volunteered resources are mostly academic in nature, although some exceptions exist for projects which are not used for scientific research.  

Although there are not strict guidelines as to what defines volunteer computing, it is commonly characterized by several different characteristics 

* All volunteers of the system are **anonymous** to the system(although they may need to first register with their basic information)

* Since each volunteer is anonymous, they cannot be held accountable for the computed results they return to any project

* Most importantly for the system to work, volunteers must **trust** each project they take part in

	* They must trust that projects are not running malicious code on their personal computers

	* They trust that the projects are honest about how the data collected will be used

	* They trust the security measures set up by projects to prevent hackers from taking advantage of the distributed system

	



History of Volunteer Computing
##############################  

The first volunteer computing project started in 1995 and was released in January of 1996, called the Great Internet Mersenne Prime Search (`GIMPS <http://mersenne.org>`_).  The GIMPS project sets out to find the world's largest known prime numbers.  Similar pioneer projects include 
`distributed.net <http://distributed.net>`_, which uses the distributed system to solve many different types of computationally intensive algorithms, `SETI@home <http://setiathome.berkeley.edu>`_, which allows volunteer computers to analyze radio telescope data in search of extraterrestrial intellignece, and `Folding@home <http://folding.stanford.edu>`_, which aims to solve difficult protein structures. Today there exist over 50 active projects.  

Current Projects
################


.. list-table::
   :widths: 15 30 20 30 30
   :header-rows: 1
    

   * - Name
     - Category
     - Area
     - Sponsor
     - Supported Platforms
   * - `ABC@home <http://abcathome.com/>`_
     - Mathematics, computing, and games
     - Mathematics
     - Mathematical Institute of Leiden University / Kennislink
     - Mac OS X, Linux/x86, Mac OS X (PowerPC), powerpc-linux-gnu, Windows, Windows/x64, Mac OS X 64-bit, Linux/x64
   * - `Asteroids@home <http://asteroidsathome.net/boinc/>`_
     - Astronomy, Physics, and Chemistry
     - Astrophysics
     - Charles University in Prague
     - Android/ARM, arm-unknown-linux-gnueabihf, armv6l-unknown-linux-gnueabihf, Mac OS X, i686-pc-freebsd, Linux/x86, Windows, Windows/x64, Mac OS X 64-bit, FreeBSD/x86, Linux/x64
   * - `CAS@home <http://casathome.ihep.ac.cn/>`_
     - Multiple applications
     - Physics, biochemistry, and others
     - Chinese Academy of Science
     - Linux/x86, Windows
   * - `Climateprediction.net <http://climateprediction.net/>`_
     - Earth Sciences
     - Climate Study
     - Oxford University
     - Mac OS X, Linux/x86, Windows
   * - `Collatz Conjecture <http://boinc.thesonntags.com/collatz/>`_
     - Mathematics, computing, and games
     - Mathematics
     - Private
     - Mac OS X, Mac OS X (NVIDIA GPU), Linux/x86, Linux/x86 (NVIDIA GPU), Linux/x86 (AMD/ATI GPU), Windows, Windows (AMD/ATI GPU), Windows (NVIDIA GPU), Windows/x64, Windows/x64 (AMD/ATI GPU), Windows/x64 (NVIDIA GPU), Mac OS X 64-bit, Mac OS X 64-bit (NVIDIA GPU), Linux/x64, Linux/x64 (NVIDIA GPU), Linux/x64 (AMD/ATI GPU)
   * - `Constellation <http://aerospaceresearch.net/constellation/>`_
     - Astronomy, Physics, and Chemistry
     - Aerospace-related science and engineering
     - Rechenkraft.net, DGLR, Selfnet, and shack
     - Mac OS X, Linux/x86, Windows, Windows/x64, Mac OS X 64-bit, Linux/x64
   * - `Cosmology@Home <http://www.cosmologyathome.org/>`_
     - Astronomy, Physics, and Chemistry
     - Astronomy
     - University of Illinois at Urbana-Champaign
     - Linux/x86, Windows, Linux/x64
   * - `DistrRTgen <http://boinc.freerainbowtables.com/distrrtgen/>`_
     - Mathematics, computing, and games
     - Cryptography
     - Private
     - i386-pc-freebsd, Linux/x86, Windows, Windows (NVIDIA GPU), Windows (AMD/ATI GPU), Windows/x64, FreeBSD/x86, Linux/x64, Linux/x64 (NVIDIA GPU)
   * - `Docking@Home <http://docking.cis.udel.edu/>`_
     - Biology and Medicine
     - Study of protein-ligand interactions
     - University of Deleware
     - Mac OS X, Linux/x86, Mac OS X (PowerPC), Windows/Opteron, Windows, Windows/x64, Linux/x64
   * - `EDGeS@Home <http://home.edges-grid.eu/home/>`_
     - Multiple applications
     - European research projects
     - MTA-SZTAKI Laboratory of Parallel and Distributed Systems (Hungary)
     - Linux/x86, Windows, Linux/x64
   * - `Einstein@home <http://einstein.phys.uwm.edu/>`_
     - Astronomy, Physics, and Chemistry 
     - Astrophysics
     - Univ. of Wisconsin - Milwaukee, Max Planck Institute
     - Android/ARM, arm-unknown-linux-gnueabihf, Mac OS X, Mac OS X (NVIDIA GPU), Mac OS X (AMD/ATI GPU), Linux/x86, Linux/x86 (NVIDIA GPU), Linux/x86 (AMD/ATI GPU), Mac OS X (PowerPC), SPARC Solaris 2.7, Windows, Windows (NVIDIA GPU), Windows (AMD/ATI GPU), Windows/x64 (AMD/ATI GPU), Windows/x64, Linux/x64, Linux/x64 (NVIDIA GPU), Linux/x64 (AMD/ATI GPU)
   * - `Enigma@Home <http://www.enigmaathome.net/>`_
     - Mathemics, computing, and games
     - Cryptography
     - Private
     - Android/ARM, arm-unknown-linux-gnueabi, arm-unknown-linux-gnueabihf, Mac OS X, Linux/x86, Mac OS X (PowerPC), Windows
   * - `eOn <http://eon.ices.utexas.edu/eon2/>`_
     - Astronomy, Physics, and Chemistry
     - Chemistry
     - University of Texas at Austin
     - Linux/x86, Windows, Mac OS X 64-bit, Linux/x64
   * - `FightMalaria@Home <http://boinc.ucd.ie/fmah/>`_
     - Biology and Medicine
     - Antimalarial drug discovery
     - University College Dublin
     - Mac OS X, Linux/x86, Windows
   * - `FreeHAL <http://www.freehal.net/freehal_at_home/>`_
     - Cognitive science and artificial intelligence
     - Artificial intelligence
     - Private 
     - Linux/x86, Windows
   * - `GPUGrid.net <http://www.gpugrid.net/>`_ 
     - Biology and Medicine
     - Molecular simulations of proteins
     - Barcelona Biomedical Research Park (PRBB)
     - Windows (NVIDIA GPU), Linux/x64 (NVIDIA GPU)
   * - `Ibercivis <http://registro.ibercivis.es/>`_
     - Mulitple application
     - Various Spanish research projects
     - Spanish universities and research centers
     - Mac OS X, Linux/x86, Linux/x86 (NVIDIA GPU), Windows, Windows/x64, Mac OS X 64-bit, Linux/x64, Linux/x64 (NVIDIA GPU)
   * - `Leiden Classical <http://boinc.gorlaeus.net/>`_
     - Astronomy, Physics, and Chemistry
     - Chemistry
     - Leiden University, The Netherlands
     - Unknown
   * - `LHC@home <http://lhcathomeclassic.cern.ch/sixtrack/>`_
     - Astronomy, Physics, and Chemistry
     - Physics
     - CERN (European Organization for Nuclear Research)
     - Linux/x86, Windows, Windows/x64, Linux/x64
   * - `LHC@home Test4Theory <http://lhcathome2.cern.ch/test4theory/>`_
     - Astronomy, Physics, and Chemistry
     - Physics
     - CERN (European Organization for Nuclear Research)
     - Mac OS X, Linux/x86, Windows, Windows/x64, Mac OS X 64-bit, Linux/x64
   * - `Malariacontrol.net <http://www.malariacontrol.net/>`_
     - Biology and Medicine
     - Epidemiology
     - The Swiss Tropical Institute 
     - Mac OS X, Linux/x86, Windows, Linux/x64
   * - `Milkyway@home <http://milkyway.cs.rpi.edu/milkyway/>`_
     - Astronomy, Physics, and Chemistry
     - Astronomy
     - Rensselaer Polytechnic Institute
     - amd64-pc-freebsd, amd64-unknown-freebsd, Mac OS X, Linux/x86, Linux/x86 (AMD/ATI GPU), Mac OS X (PowerPC), Windows, Windows (AMD/ATI GPU), Windows/x64, Windows/x64 (AMD/ATI GPU), Mac OS X 64-bit, Mac OS X 64-bit (AMD/ATI GPU), FreeBSD/x86, Linux/x64, Linux/x64 (AMD/ATI GPU)
   * - `MindModeling@Home <http://mindmodeling.org/>`_
     - Cognitive science and artificial intelligence
     - Cognitive Science
     - University of Dayton and Wright State University
     - Mac OS X, Linux/x86, Windows, Mac OS X 64-bit, Linux/x64
   * - `NFS@home <http://escatter11.fullerton.edu/nfs/>`_
     - Mathematics, computing, and games
     - Factorization of large integers
     - California State University Fullerton
     - Mac OS X, Linux/x86, Windows, Windows/x64, Mac OS X 64-bit, FreeBSD/x86, Linux/x64
   * - `NumberFields@home <http://numberfields.asu.edu/NumberFields/>`_
     - Mathematics, computing, and games
     - Mathematics
     - Arizona State University, school of Mathematics
     - Linux/x86, Windows, Mac OS X 64-bit, Linux/x64
   * - `OProject@Home <http://oproject.info/>`_
     - Mathematics, computing, and games
     - Mathematics, Physics, Artificial Intelligence
     - Private
     - arm-android, Android/ARM, Linux/ARM, arm-unknown-linux-gnueabi, Linux/x86, i686-pc-solaris, Playstation3/Linux, ppc64-linux-gnu, Windows, Windows/x64, Mac OS X 64-bit, FreeBSD/x86, Linux/x64
   * - `POEM@Home <http://boinc.fzk.de/poem/>`_
     - Biology and Medicine
     - Protein structure prediction
     - University of Karlsruhe (Germany)
     - Mac OS X, Linux/x86, Windows, Windows (AMD/ATI GPU), Mac OS X 64-bit, Linux/x64, Linux/x64 (AMD/ATI GPU)
   * - `primaboinca <http://www.primaboinca.com/>`_
     - Mathematics, computing, and games
     - Mathematics
     - Hochschule RheinMain University of Applied Sciences
     - Mac OS X, Linux/x86, Windows
   * - `PrimeGrid <http://www.primegrid.com/>`_
     - Mathematics, computing, and games
     - Mathematics 
     - Private
     - Android/ARM, Mac OS X, Mac OS X (NVIDIA GPU), Linux/x86, Linux/x86 (AMD/ATI GPU), Linux/x86 (NVIDIA GPU), Windows, Windows (AMD/ATI GPU), Windows (NVIDIA GPU), Windows/x64, Mac OS X 64-bit, Mac OS X 64-bit (NVIDIA GPU), Linux/x64, Linux/x64 (AMD/ATI GPU), Linux/x64 (NVIDIA GPU)
   * - `Quake Catcher Network <http://qcn.stanford.edu/sensor/>`_
     - Distributed sensing 
     - Seismology 
     - Stanford University
     - armv5tel-unknown-linux-gnueabi, armv6l-unknown-linux-gnueabihf, Mac OS X, Linux/x86, Mac OS X (PowerPC), Windows, Windows/x64, Mac OS X 64-bit
   * - `Radioactive@Home <http://radioactiveathome.org/boinc/>`_
     - Distributed sensing
     - Environmental research
     - BOINC Poland Foundation
     - Linux/x86, Windows
   * - `RNA World <http://www.rnaworld.de/rnaworld/>`_
     - Biology and Medicine
     - Molecular biology
     - Rechenkraft.net e.V.
     - Mac OS X, Linux/x86, Windows, Windows/x64, Mac OS X 64-bit, Linux/x64
   * - `Rosetta@home <http://boinc.bakerlab.org/rosetta/>`_
     - Biology and Medicine
     - Biology
     - University of Washington
     - Mac OS X, Linux/x86, Windows, Windows/x64, Mac OS X 64-bit, Linux/x64
   * - `SAT@home <http://sat.isa.ru/pdsat/>`_
     - Mathematics, computing, and games
     - Computer Science
     - Institute for System Dynamics and Control Theory and Institute for Information Transmission Problems, Russian Academy of Science
     - Linux/x86, Windows, Windows/x64, Linux/x64
   * - `SETI@home <http://setiathome.berkeley.edu/>`_
     - Astronomy, Physics, and Chemistry
     - Astrophysics, astrobiology
     - University of California, Berkeley
     - Mac OS X, Linux/x86, Mac OS X (PowerPC), Windows, Windows (AMD/ATI GPU), Windows (NVIDIA GPU), Linux/x64, Linux/x64 (NVIDIA GPU), Linux/x64 (AMD/ATI GPU)
   * - `SIMAP <http://boincsimap.org/boincsimap/>`_
     - Biology and Medicine
     - Biology
     - University of Vienna
     - Mac OS X, Linux/x86, Mac OS X (PowerPC), Windows, Windows/x64, Linux/x64
   * - `Simulation One <http://mmgboinc.unimi.it/>`_
     - Biology and Medicine
     - Molecular biology
     - Universita degli Studi, Milan, Italy
     - Linux/x86, Windows, Linux/x64
   * - `Spinhenge@home <http://spin.fh-bielefeld.de/>`_
     - Astronomy, Physics, and Chemistry
     - Chemical engineering and nanotechnology
     - Bielefeld University of Applied Sciences
     - Unknown
   * - `SubsetSum@Home <http://volunteer.cs.und.edu/subset_sum/>`_
     - Mathematics, computing, and games
     - Computer Science
     - University of North Dakota, Computer Science Department
     - Linux/x86, Windows, Mac OS X 64-bit, Linux/x64
   * - `sudoku@vtaiwan <http://sudoku.nctu.edu.tw/>`_
     - Mathematics, computing, and games
     - Mathematics
     - National Chiao Tung University, Taiwan
     - Mac OS X, Linux/x86, Windows, Windows/x64, Linux/x64
   * - `Superlink@Technion <http://cbl-boinc-server2.cs.technion.ac.il/superlinkattechnion/>`_
     - Biology and Medicine
     - Genetic linkage analysis
     - Technion, Israel
     - Unknown
   * - `SZTAKI Desktop Grid <http://szdg.lpds.sztaki.hu/szdg/>`_
     - Mathematics, computing, and games
     - Mathematics
     - MTA-SZTAKI Laboratory of Parallel and Distributed Systems (Hungary)
     - Mac OS X, Linux/x86, Mac OS X (PowerPC), Windows, Windows/x64, Mac OS X 64-bit, Linux/x64
   * - `The Lattice Project <http://boinc.umiacs.umd.edu/>`_
     - Biology and Medicine
     - Life science research
     - University of Maryland Center for Bioinformatics and Computational Biology
     - Mac OS X, Linux/x86, Mac OS X (PowerPC), Windows, Windows/x64
   * - `theSkyNet POGS <http://pogs.theskynet.org/pogs/>`_
     - Astronomy, Physics, and Chemistry
     - Astronomy
     - The International Centre for Radio Astronomy Research (Perth, Australia)
     - Android/ARM, Linux/x86, Windows, Windows/x64, Mac OS X 64-bit, Linux/x64
   * - `VolPEx <http://volpex.cs.uh.edu/VCP/>`_
     - Mathematics, computing, and games
     - Computer Science
     - University of Houston
     - Linux/x86, Windows, Linux/x64
   * - `VTU@home <http://boinc.vgtu.lt/vtuathome/>`_
     - Mathematics, computing, and games
     - Software testing
     - Vilnius Gediminas Technical University and Kaunas University of Technology (Lithuania)
     - Linux/x86, Windows, Windows/x64, Linux/x64
   * - `World Community Grid <http://www.worldcommunitygrid.org/>`_
     - Multiple applications
     - Medical, environmental and other humanitarian research
     - IBM Corporate Citizenship
     - Mac OS X, Linux/x86, Mac OS X (PowerPC), Windows, Windows (AMD/ATI GPU), Windows (NVIDIA GPU), Windows/x64, Mac OS X 64-bit, Linux/x64, Android/ARM
   * - `Yoyo@home <http://www.rechenkraft.net/yoyo/>`_
     - Multiple applications
     - Mathematics, physics, evolution
     - Private 
     - Android/ARM, arm-linux-gnu, arm-unknown-linux-gnueabi, arm-unknown-linux-gnueabihf, Mac OS X, Linux/x86, Mac OS X (PowerPC), Playstation3/Linux, SPARC Solaris, Windows, Windows/x64, Mac OS X 64-bit, Linux/x64


   

What Volunteer Computing is NOT
===============================

* Unlike a peer-to-peer computing service which exchanges data between individual users' computers, volunteer computing makes usage of centralized servers which distribute information between any given pc

* Volunteer computing is not for the direct benefit of the participants like peer-to-peer computing, but rather a means of donating their resources

* Volunteer computing allows for the remote computing of resource intensive problems, rather than simply storing and retrieving data

Berkley Open Infrastructure for Network Computing (BOINC)
=========================================================

BOINC is an open source software system to manage volunteer computing for many different distributed applications.  Many different independent projects utilize BOINC on their own applications and servers to more efficiently analyze large data.  
**Computing Workflow**


.. figure:: ./_static/work_flow.png


The BOINC application is built with several different programs which function together as one piece of software.  This software is all installed localy on each volunteer.  At BOINC's heart lies the core client which is reponsible for managing each of the projects a volunteer is subscribed to.  Volunteers with pcs that have multiple cpus can run separate projects concurrently which are all managed by the core client.  Information between project servers and schedulers is communicated via HTTP, while the core client utilzes local TCP to send and recieve information from the GUI, which allows the user to manage the client through a graphical interface.  Some projects also contain screensavers which can be controlled via the client program.  

.. figure:: ./_static/boinc_software.png

.. [Ref] http://boinc.berkeley.edu/wiki/File:Client.png


Basic Concepts
##############

* Each project contains a hierarchical directory tree, a MySQL database, and a configuration file

  * Directory Tree::

              PROJECT/
              apps/
              bin/
              cgi-bin/
              log_HOSTNAME/
              pid_HOSTNAME/
              download/
              html/
                  inc/
                  ops/
                  project/
                  stats/
                  user/
                  user_profile/
              keys/
              upload/

  * The BOINC MySQL database contains seven main tables:

    * **platform** = the compilation targets of the client
    * **app** = the applications for the core client
    * **app_version** = contains version info for the applications and a URL for downloading them
    * **user** = includes the users and their email addresses
    * **host** = description of the hosts
    * **workunit** = information for the workunits, here the input files are stored as XML documents.
    * **result** = includes the result files, a state describing whether the results have been dispatched, and CPU info such as computation time and status

  * The configuration file, called config.xml resides in the project's directory and contains the following structure::

                    <boinc>
                      <config>
                        [ configuration options ]
                      </config>
                      <daemons>
                        [ list of daemons ]
                      </daemons>
                      <tasks>
                        [ list of periodic tasks ]
                      </tasks>
            
                    </boinc>

A client application structure is implemented with XML code since Windows computers do not support symbolic links like Unix environments.  

.. figure:: ./_static/client_dir.png

.. [Ref] http://boinc.berkeley.edu/trac/attachment/wiki/AppIntro/client_dir.png

* Projects contain **applications** which themselves contain several programs that are each designed to target different compilation targets, or **platforms**

* **Workunits** are the basic computations which are to be sent to volunteers.  Each workunit contains various input files, resource requirements, and a deadline.  

* After computing a given workunit, the client returns its **result** to the server

* Every volunteer has an associated **account** which is identified by an email address and password.  Each account has a credit value associated with it.  

* Volunteers connect to projects with the **BOINC client**. 

The local running application and client communicate with eachother through a shared memory resource.  The client can start and stop an application from running, while the application can send back its cpu time and progress.

.. figure:: /_static/client_msgs.png

.. [Ref] http://boinc.berkeley.edu/trac/attachment/wiki/AppIntro/client_msgs.png

* As volunteers complete workunits, additional **scheduler requests** are sent to any of the account's subscribed projects. These projects contain their own daemon script **schedulers** which return jobs to the client that are specific for their platform.  


Geting Started with BOINC Locally
=================================

The BOINC client application software can be downloaded `here <http://boinc.berkeley.edu/download.php>`_.  Once downloaded, the client will ask the user to set up an account or add an existing one.  The user is then given the option to either select individual projects which they wish to contribute to, or subscribe to a manager of their choice, who will be responsible for choosing projects.  Users can also join teams of volunteers who have similar interests.  

Credit
######

Each project's server keeps track of how much computational work has been completed by individual volunteers and alots credit based on this work.  In order to fairly distribute credit,

* A given task can be given to at most two volunteers
* When volunteers send results to the project server they also send the amount of CPU time which was required to complete the task
* The results from both volunteers are compared and if the results are the same, the smaller of the two CPU times required is used to calculate the credit which will be given to each volunteer

.. figure:: ./_static/boinc_credit.png

.. [Ref] http://boinc.berkeley.edu/w/images/a/af/Credit.png

BOINC in Action
===============

To get started, the creators have provided a virtual image to be run on virtualbox which includes everthing necessary to start a new volunteer project.  The virtual image can be downloaded `here <http://boinc.berkeley.edu/dl/debian-6-boinc-server-130327.7z>`_, and is a debian 64 bit operating system.  Shown below is a new project being created within the vm with the command::

  $ ./make_project --url_base http://a.b.c.d --test_app test


.. figure:: ./_static/virtualMachine.png

After starting the server::
  

  $ cd ~/projects/test
  $ su -c 'cat test.httpd.conf >> /etc/apache2/httpd.conf'
  $ su -c 'apache2ctl -k restart'
  $ crontab test.cronjob
  $ ./bin/xadd
  $ ./bin/update_versions
  $ ./bin/start

.. figure:: ./_static/vmServerStart.png

On the client pc, projects can be subscribed to either through BOINC's GUI client manager or the command line utility::

  $ boinccmd --create_account http://a.b.c.d/test/ email-addr password account-name account key: XXX
  $ boinccmd --project_attach http://a.b.c.d/test/ XXX


BOINC Client Manager GUI 

.. figure:: ./_static/boinc_manager.png


	
