Directories and LDAP
===================================

What is a Directory?
------------------------------------

- Yellow pages
- Personal phone/address book
- Mail order catalogs
- Library catalog cards
- TV Guides
- Your organization's mailing list
- Netscape's HTML directory


What is NOT a Directory?
------------------------------------

- Database: more costly, heavy-duty transaction support, frequent writes
- File system: allows partial retrieval, random access of data
- Web servers: delivers big image files, provides web application development 
  platform
- FTP servers: can't do search, not attribute-based information model
- DNS servers: not extensible, no updates

Types
---------

Types of (Network) Directories

- NOS-based: MS Active Directory (with LDAP core), Novell NDS
- Application-specific: Lotus Notes Address Book, MS Exchange Directory
- Purpose-specific: DNS
- General-purpose, standards-based: LDAP, X.500 directories

Characteristics of Directories
--------------------------------------

Characteristics of Directories
- Good at storing pointers to large data, not the large data
- Attribute-based information model
- High read-to-write ratio, unlike databases, file systems, or web browsers
- High search capability
- Standards-based access (for some)

Evolution of Directories
---------------------------------------

FIGURE 

Directory Services and Organizations

----------------------------------------

The Nerve Center of an Organization's Infrastructure?

- Naming: who/what are there?
- Location: where are they?
- Security: protect against unauthorized access and tempering
- Management: personnel, decision- making
- Resource: monitor load and usage
- Extensibility: grow with the organization

So what is LDAP, exactly?
------------------------------------

- LDAP: Lightweight Directory Access Protocol
- Preceded by the two X.500-related protocols: DAS, DIXIE (front ends)
- "Lightweight": simplified encoding methods, runs directly on commonly 
  available TCP/IP
- "Heavyweight":X.500DAPuses complex encoding methods, runs on rare OSI 
  network protocol stack
- Simplified implementation of clients and servers by eliminating infrequent
  and redundant DAP features/operations
- Data elements represented as simple text strings, while messages wrapped in 
  binary encoding for efficiency
- Uses a subset of the X.500 encoding rules to further simplify implementation
- Simplified transport: no need for OSI, runs directly over TCP.
- Supports both IPv4 and IPv6.

Early LDAP Implementations
------------------------------------

FIGURE

SLAPD: Stand-alone LDAP Daemon
------------------------------------

- Multi-platform LDAP directory server
- Flexible customization
- Support for both LDAPv2 and LDAPv3
- Support for both IPv4 and IPv6
- Simple Authentication and Security Layer
- Transport Layer Security through SSL
- Generic modules API: covers development for front-end communication with
  LDAP client, and back-end database operations with Perl, Shell, SQL, TCL, 
  and Python

SLAPD: Continued
-------------------------------------

- Access control based on LDAP authorization information, IP address, domain
  name, etc.
- Support for Unicode and language tags
- Choice of various backend databases
- A multi-threaded **slapd** process can handle all incoming requests => reduced 
  system overhead => higher performance
- Replication of data using single-master multiple-slave scheme for 
  high-volume environments
- Highly configurable via a single configuration file that "does it all"

LDAP Client-Server Exchange Protocol
---------------------------------------

FIGURE

Example LDAP Usage
------------------------------------

- A directory service that enables a user to locate remote resources ANYWHERE 
  on a distributed network.
- A dynamic system that provides/fetches resources based on individual user's
  queries.
- A model that would utilize and manage the existing system in a more 
  organized way.
- Examples:"OmniPrint" service from anywhere on the network, location and 
  availability of a coffeemaker!
- A robust and extensible client-server model
- Application needs: data elements, service performance (latency, throughput, 
  e.g., 480K searches per hour)
- User needs: accuracy, privacy, up-to-date, completeness, security, balance
  for all users
- Extensibility: Must be able to extend to distributed and replicated models
- Platforms supported: Should accommodate heterogeneous platforms

Schemas
-------------------------------------
- Similar to databases, needed for integrity and quality
- A set of rules that determines what can be stored in a directory service
- A set of rules that defines how directory servers and clients should treat
  information during a directory operation
- Each entity (called "attribute") has its own object identifier (called an
  *oid*)
- Reduce unnecessary data duplication resulted from some directory-enabled 
  applications

attributes and objectclasses
-------------------------------------

The following shows how to create your own schema in LDAP (for our example
fictitious domain)::

	description ATTRIBUTE ::= {
	  WITH SYNTAX DirectoryString {1024}
	  EQUALITY MATCHING RULE caseIgnoreMatch
	  SUBSTRINGS MATCHING RULE caseIgnoreSubstringsMatch ID 2.5.4.13
	}

	objectclass printer
	  requires cn
	  allows description, pagesPerMinute, languages

	objectclass networkDevice
	  requires ipaddress
	  allows cn, connectionSpeed

Note: the term objectclass is not the same terminology from object-oriented
programming. In LDAP, an objectclass defines a schema-aware data object but
does not define methods (functions) as in OOP.

Namespaces
---------------------------------------

- Means by which information in the directory will be named and referenced, 
  similar to a pointer or label (or index).
- Namespace can be of any topology, e.g. tree, star, triangular, or linear. 
  LDAP supports trees innately.
- Concept of DN and its components: CN, C, ST, L, O, OU, STREET, DC, UID
- Naming scheme could be internet-based or traditional, based on 
  organizational needs

Here's an example of a DN::

  ou=cpdc,ou=ece,ou=northwestern,ou=edu, c=evanston,st=illinois,c=us

Traditional (Internet-style) naming::

  CPDC.ECE.McCormick.Northwestern.Evanston.IL.US

Which is better?

LDAP Tree Topology
----------------------

FIGURE to show the distinguished name concept.

Network Architecture
----------------------

FIGURE

Distributed LDAP Server Model
--------------------------------

FIGURE

LDIF Example
------------------

::

    dn: uid=lt412-p3,ou=People,dc=cs,dc=luc,dc=edu
    uid: lt412-p3
    cn: LT 412 P3 Lab
    givenName: LT 412 P3
    sn: Lab
    objectClass: person
    objectClass: organizationalPerson
    objectClass: inetOrgPerson
    objectClass: posixAccount
    objectClass: top
    objectClass: shadowAccount
    userPassword: {crypt}$1$/I5v6ig6$aDHu3Idj8i98kb9XVHlvq0
    shadowLastChange: 12695
    shadowMax: 99999
    shadowWarning: 7
    loginShell: /bin/bash
    uidNumber: 1012
    gidNumber: 250
    homeDirectory: /homes/users/lt412-p3
    gecos: LT 412 P3 Lab


.. todo::

   Replication and standby serving with **slurpd**.
   
Acknowledgements
------------------------------------

The notes in this lecture are based on a presentation co-authored with 
Dr. Thiruvathukal's former students in Distributed Systems (at Northwestern
University), `Steve Chiu <http://www2.cose.isu.edu/~chiustev/>`_ and 
`Jay Pisharath <http://cucis.ece.northwestern.edu/members/jay/>`_.

References
----------------

- http://openldap.org

- T. Howes et. al., *Understanding and Deploying LDAP Directory Services*, 
  MacMillan Technical Publishing, 1999

- LDAP bindings are provided in many languages, such as Python and Java. 
  OpenLDAP provides C bindings.