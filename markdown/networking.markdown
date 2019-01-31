# Networking Primer

## Overview

- Introduction to networks
- Protocols and Layers
- Interprocess Communication
- Network Case Studies (Ethernet, ATM)
- Protocol Case Studies (TCP/IP, Client-Server)

## References

- Tanenbaum, *Computer Networks, 5th Edition*, Prentice Hall PTR
- Coulouris, Dollimore, and Kindberg, Introduction to Distributed Systems, 3rd Edition
- Dordal, Peter L., Introduction to Computer Networks Open Source
  Book, <http://intronetworks.cs.luc.edu/html>.

## Methods

- Sockets
- RPC

## Networks

- Communication between semi-autonomous computers
- Attached to host system by an adapter

## Infrastructure

Communication networks provide an infrastructure for communication in
distributed systems

Infrastructure is required at various levels

- Cables/wires
- Switches
- Interfaces
- Software components at various levels: protocol managers, network managers

The entire collection of the above is a "communication system".

## Many Types of Networks

Physical Media
- copper wires (Ethernet, RS232-C, V.32, etc.)
- fiber optics (ATM, FDDI)
- air (IR, Radio, micro-wave)

## Relative Speeds

Speeds (link not aggregate)

- low: modems and pagers
- medium: Ethernet and Token Ring (10M-10Gbps and beyond)
- high: ATM (155-655 Mbps), Myrinet (600 Mbps), SONET (OC-48 - 2488
  Mbps)

## Local Area Networks

- Relatively high-speed (oh yeah!)
- Normally single building, campus, Office
- Most of the time direct (does not mean all-to-all) connection
  between computers
- Low Latency
- Eg., Ethernet, FDDI, IBM Token Ring

## Wide Area Networks

- Msgs at lower speeds between systems separated by large distances
- Communication circuits connected by "Packet switching" computers,
  that also manage the network
- Messages are routed by "packet switches"
- E.g., ISDN, BISDN, ATM

## Metropolitan Area Networks (MANs)

- within cities, towns, use fiber-optics cables
- recent, to carry voice, video\...

## Internetworks

- Remember - distributed systems require extensibility
- Must be able to connect/link networks together =\> Internetworks
- Normally achieved by linking component networks with dedicated
  routers OR
- by connecting them by general purpose computers called "gateways"
- protocols that support addressing and transmission between these
  networks are added
- Internet is a GIANT Wide-Area-Network connecting thousands of
  component networks.

## Performance Issues

- Latency - time needed to transfer an empty message between two
  systems - normally measures software delay and transit time
- Bandwidth (or Data Transfer Rate): rate at which data is transferred
  over the network once the transmission started
- Network Bandwidth - Volume of traffic per unit time transferred
  across the network
- Quality of Service (QoS) - other guarantees such as delay and b/w
  guarantees, reliability and availability guarantees
- Assuming no delays due to congestion

## What is software delay?

- time to access the network, I.e., put bits on the network from the
  time a message is sent by the application and time to retrieve the
  bits and supply the msg to the receiver
- software delay can be quite large because message has to go through
  several layers (later)

## Example: Campus Network

![University of Michigan Network](networking/umich-network.png)

## Network Topologies

How are the communicating objects connected

- Fully connected
  - link between all sites
- Partially connected
  - links between subset of sites 
  - be an arbitrary graph
- Hierarchical networks
  - network topology looks like a tree
  - internal nodes route messages between different sub-trees
  - if an internal node fails, children can not communicate with each other
  - star network - hierarchical network with single internal node

## Network Topologies

![Internet Map](networking/1024px-Internet_map_1024.jpg)

## A Network is not an Island

Reason for networks is to share information

- must be able to communicate in a common language
- called protocols
- The nice thing about protocols is that there are so many of them!

## Protocols

- must be unambiguous and followed exactly
- rule of thumb: be rigorous is what you generate, be liberal in what you accept
- there are many different aspects to protocols: electrical through web services

## Design Issues In Layers

Rules for data transmission (Protocol)

- full vs. half duplex
- error control (detection, correction, etc.)
- flow control (rate matching, overuse of shared resources)
- message order (do things arrive in the same order as sent?)

Abstractions for communications

- end points for communication
- switches, nodes, processes, threads in a process
- how are these end points named (addresses)?
- service providers and service users

Service Primitives

- operations performed by a layer
- events and their actions
- request, indication, response, confirm

## Protocols are divided into layers


ISO - seven layer reference model

- Application
- Presentation
- Session
- Transport
- Network
- Link
- Physical

TCP/IP - four layer model

- application
- transport
- network (internet)
- link

## Physical Layer

Goal: Raw bits over a communication channel

Sample Issues

- how to encode a 0 Vs. 1?
- what voltage should be used?
- how long does a bit need to be signaled?
- what does the cable, plug, antenna, etc. look like?

Examples

- modems
- "knock once for yes, twice for no"
- X.21

## Physical Layer - Representing 0 and 1

![Square Wave](https://upload.wikimedia.org/wikipedia/commons/f/f8/SquareWave.gif "Sqaure Wave")


## Many Types of Networks

- Local Area Networks
- Wide Area Networks
- Wireless Networks
- Metropolitan Area Networks

## Local Area Networks

-   Relatively high-speed (oh yeah!)
-   Normally single building, campus, Office
-   Most of the time direct (does not mean all-to-all) 

connection between computers
-   Low Latency
-   Eg., Ethernet, FDDI, IBM Token Ring

## Wide Area Networks

-   Messages at lower speeds between systems separated by large distances
-   Communication circuits connected by "Packet switching" computers, that also manage the network
-   Messages are routed by "packet switches"
-   E.g., ISDN, BISDN, ATM

## Wireless Networks

## Metropolitan Area Networks

Metropolitan Area Networks (MANs)
-   within cities, towns, use fiber-optics cables
-   recent, to carry voice, video\...

Not clear whether this type of network is still relevant or just a special case of WANs.

## Many Types of Networks

## Internetworks

- Remember - distributed systems require extensibility
- Must be able to connect/link networks together =\> Internetworks
- Normally achieved by linking component networks with dedicated routers OR
- by connecting them by general purpose computers called "gateways"
- protocols that support addressing and transmission between these networks are added
- Internet is a GIANT Wide-Area-Network connecting thousands of component networks.

## Data Link Layer

Goal: transmit error free frames over the physical link 

Sample Issues:

-   how big is a frame?
-   can I detect an error in sending the frame?
-   what demarks the end of the frame?
-   how to control access to a shared channel?

Examples:

-   Ethernet framing
-   CSMA/CD

## The Network Layer

Goal: controlling operations of the subset

Sample Issues:
- how route packets that have to travel several hops?
- control congestion - too many messages at once
- accounting - charge for use of the network
- fragment or combine packets depending on rules of link layer

Examples:
- IP
- X.25

## The Transport Layer

Goal: accurately transport session data in order

-   end points are the sending and receiving machines

Sample Issues:

-   how to order messages and detect duplicates
-   error detection (corrupt packets) and retransmission
-   connectionless or connection-oriented

Examples:

-   TCP (connection-oriented)
-   UDP

## The Session & Presentation Layers

Goal: common services shared by several applications

Sample Issues:
-   network representation of bytes, ints, floats, etc.
-   encryption?? (this point is subject to lots of debate)
-   synchronization

Examples:

-   eXternal Data Representation (XDR)

## Application Layer

Goal: common types of exchanges standardized

Sample Issues:

-   when sending email, what demarks the subject field
-   how to represent cursor movement in a terminal

Examples:

-   Simple Mail Transport Protocol (SMTP)
-   File Transfer Protocol (FTP)
-   Hyper-Text Transport Protocol (HTTP)
-   Simple Network Management Protocol (SNMP)
-   Network File System (NFS)
-   Network Time Protocol (NTP)
-   Net News Transport Protocol (NNTP)
-   X (X Window Protocol)

## Interprocess Communication:

Sockets & RPC (Basic operations)

-   Send
-   Receiver
-   Synchronize
-   =\> Send must specify destination
-   =\> Clients need to know an identifier for communicating with another process (e.g., server)

## Reliability

- "Unreliable Message" - single msg sent from sender to recipient without acknowledgment (e.g., UDP)
- Processes that use unreliable messages are responsible for enforcing correct/reliable message passing
- Reliability introduces overhead
  - need to store state information at the source and destination
  - transmit extra messages (e.g., ack)
  - latency (for processing information related to reliability)

## Mapping Data to Messages

- Programs have data structures
- Messages are self-contained sequence of bytes
- =\> For communication
  - data structures must be flattened before sending
  - rebuilt upon receipt
- Problem: How does the receiver know how the sender has flattened?
- What if sender and receiver have different representations?
- =\> Follow standard (possibly external) data format - or the one which has been agreed upon between sender and receiver in advance

## Marshaling

- Process of taking a collection of data items and assembling them into a form for transmission
- Unmarshaling - Disassemble message upon receipt
- Normally programs supplied with standards
- For example msg - 5 smith 6 London 1934
- In C, `sprintf()` (data item -\> array of characters), `sscanf()` for opposite:

## Simple Marshalling

The following shows how to marshall some data using `sprintf()`:

```c
  char *name = “smith”;
  char *place = “London”;
  int year = 1934;
  sprintf(message, “%d %s %d %s %d”, strlen(name), name, strlen(place), place, years);
```

Can you think of how to write the unmarshalling version using
`sscanf()`?

## Case Study: UNIX Interprocess Communication (IPC)

- IP C provided as systems calls implemented over TCP and UDP
- Message destinations - Socket addresses (Internet address and port id)
- Communication operations based on socket pairs (sender and receiver)
- Msgs queued at sender socket until network protocol transmits them and ack
- Before communication can occur - recipient must BIND its socket descriptor to a socket address

## Example - Simple TCP Messaging Framework (from HPJPC)

- TCP/IP example
- simple messaging service where the client/server exchange Message objects containing key/value parameters
- can send all primitive types or binary-encoded data
- Key classes
  -   Message
  -   MessageClient
  -   MessageServer and MessageServerDispatcher (handles concurrent
      requests)
  -   MessageService interface (for building your own services)
- Example Service
  -   DateService
  -   DateClient

## Example: Simple Key-Value Messaging

An example we presented as part of the book, High-Performance Java Platform Computing, published by Sun Microsystems Press.

The code for this entire example appears in the 
[src/info/jhpc/message](https://github.com/LoyolaChicagoCode/hpjpc-source-java/tree/master/src/info/jhpc/message) package at GitHub.


## Example: Components

- MessageServer: The server side
- MessageClient: The client side
- MessageServerDispatcher: Used to handle incoming messages
- DateService: Concrete example to use message server to get time of day
- DateClient: Concrete example of a client (to DateService)


## Sockets Communication Using Datagram

- "socket" call to create and a get a descriptor
- Bind call to bind socket to socket address (internet address & port
  number)
- Send and receive calls use socket descriptor to send receive
  messages
- UDP, no ack


## Java SDK Example / Quote Server with Datagrams

- The quote server sends back a quote (not a stock quote) to the client. This is obtained from a file of one-line quotes.

- The server continuously receives datagram packets over a datagram socket. 

- Each datagram packet received by the server indicates a client request for a quotation.

- When the server receives a datagram, it replies by sending a datagram packet that contains a one-line "quote of the moment" back to the client.

- The client application sends a single datagram packet to the server indicating that the client would like to receive a quote of the moment.

- The client then waits for the server to send a datagram packet in response.
ß
## Quote Server

```java
import java.io.*;

public class QuoteServer {
    public static void main(String[] args) throws IOException {
        new QuoteServerThread().start();
    }
}
```


## Quote Server Dispatch Thread

```java
public QuoteServerThread() throws IOException {
    this("QuoteServer");
}

public QuoteServerThread(String name) throws IOException {
    super(name);
    socket = new DatagramSocket(4445);

    try {
        in = new BufferedReader(new FileReader("one-liners.txt"));
    }   
    catch (FileNotFoundException e){
        System.err.println("Couldn't open quote file.  Serving time instead.");
    }
}  
```

## Quote Client

```java
public class QuoteClient {
    public static void main(String[] args) throws IOException {
 
        if (args.length != 1) {
             System.out.println("Usage: java QuoteClient <hostname>");
             return;
        }
 
            // get a datagram socket
        DatagramSocket socket = new DatagramSocket();
 
            // send request
        byte[] buf = new byte[256];
        InetAddress address = InetAddress.getByName(args[0]);
        DatagramPacket packet = new DatagramPacket(buf, buf.length, address, 4445);
        socket.send(packet);
     
            // get response
        packet = new DatagramPacket(buf, buf.length);
        socket.receive(packet);
 
        // display response
        String received = new String(packet.getData(), 0, packet.getLength());
        System.out.println("Quote of the Moment: " + received);
     
        socket.close();
    }
}
```


## Stream Communication

- First need to establish a connection between sockets
- Asymmetric because one would be listening for request for connection
  and the other would be asking
- Once connection, data communication in both directions

## Remote Procedure Call

- Question: How do me make "distributed computing look like traditional (centralized) computing"?

- Simple idea - Can we use procedure calls? Normally,
  - A calls B \--\> A suspended, B executes \--\> B returns, A executes
  - Information from A (caller) to B (callee) transferred using parameters
  - Somewhat easier since both caller and callee execute in the same address space

- But in Distributed systems - the callee may be on a different system
  - ==\> Remote Procedure Call (RPC)
  - Does not rely on *explicit message passing*!

## Remote Procedure Call (Figure)

![RPC](networking/rpc-overview.png)

## Remote Procedure Call (RPC)

- Although no message passing (at user level) - parameters must still be passed - results must still be returned!
- ==\> Many issues to be addressed - Look at an example to understand some issues

```c
count = read(fd, buf, nbytes) 
```

In the above:
- fd: file handle (int)
- buf: array of bytes
- nbyes: number of bytes

## Observations

- parameters (in C): call-by-reference OR call-by-value
- Value parameter (e.g., fd, nbytes) copied onto stack (original value
  not affected)
- Value parameter is just an initialized variable on stack for callee
- Reference parameter (array buf) is not copied \--\> pointer to it is passed (buf's address)
  - Original values modified

- Many options are language dependent but we will ignore them...
- How to deal with these situations?

## Design of RPC

Goal: Make RPC look (as much as possible) like local procedure call, that is,

-   call should not be aware of the fact that the callee is on a different machine (or vice versa)

- Look at the read call again and various involved components

  -   read routine is extracted from the library by linker and inserted into application object code
  -   call read `-->` Parameter onto stack `-->` kernel trap `-->` operation `-->` POP `-->` return
  -   programmer does not know all this

- in RPC, read is remote, so there is no way to put parameters on stack
  (no shared space/memory!)
- Solution: In the library keep "client stub" which acts like "read"
- So how does it work?

## RPC Mechanisms

- Client-stub packs parameters
- Ships them to "server"

## RPC Steps

1.  client calls client stub in normal fashion
2.  client stub builds msg and traps to kernel
3.  kernel sends msg to remote kernel
4.  remote kernel gives msg to server stub
5.  server stub unpacks parameters and calls server
6.  server processes and returns results to stub
7.  server stub packs result in msg and traps to kernel
8.  remote kernel sends msg to client kernel
9.  client kernel gives msg to client stub
10. stub unpacks results and returns to client

## Design Issues

- Parameter passing
- Binding
- Reliability/How to handle failures
  -   messages losses
  -   client crash
  -   server crash

- Performance and implementation issues
- Exception handling
- Interface definition

## Parameter Passing

- Some issues similar to messages passing
- Example below- what if clients and servers have different
  representations (Little endian vs big endian)

## Parameter Passing

- How to solve the problem?
  - client and server know parameter type 
  - msg will have n+1 fields
    -  1 - procedure identifier
    -  n - procedure parameters

## Binding

Q. How does a client locate the server?

- Hardwire?
  -   inflexible
  -   need to recompile all codes affected for any change

- Dynamic Binding
  -   formal specification of server

## Use of Specification

- Input to the stub generator - produces both client and server stub
  -   client stub linked to client function
  -   server stub linked to server function

- Server exports the server interface (initialize())
  -   server sends msg to binder to know it is up (registration)
  -   server gives the binder **name**, **version number**, **unique ID**, **handle** (e.g. IP address) 

## Locating the Server

- First call to RPC of function
- Client stub sees not bound to server
- Client stub sends msg to binder to "import" interface
- If server exists, binder gives unique id and handle to client stub
- Client stub uses these for communication



- Method flexible
  -   can handle multiple servers with same interface
  -   binder can poll servers to see if up or deregister them if down for fault tolerance
  -   can enforce authentication

- 

- Disadvantage
  -   overhead of interface export/import
  -   binder may be a bottleneck in large systems

## How to Handle Failures

Types of possible failures in RPC systems
- client unable to locate server
- request message from client to server is lost
- reply message from server to client is lost
- server crashes after receiving a request
-  client crashes after sending a request ( \^c!!)

Questions
- What are the semantics?
- How close can we get to the goal of transparency?

## Client Cannot Locate Server

Why?
-   server may be down
-   new version of server (using new stubs..) but older client ==\> binder cannot match

Solutions

- respond with error type "cannot locate server"
  -   simple
  -   not general (what if the error code, e.g. -1, is also a result of computation?)

- raise exception
  -   some languages allow calling special procedures for error
  -   not all languages support this
  -   destroys transparency

## Lost Request Message
Time Out

-   Kernel starts timer when request sent
-   If timer expires, resend message
-   If message was lost - server cannot tell the difference
-   If message lost too many times ==\> "cannot locate server"

## Lost Reply Message

- More difficult to handle
- Rely on timer again?
- Problem: Client's kernel doesn\'t know why no answer!
-  Must distinguish between
   -   request/reply got lost?
   -   server slow

Why?
-   some operations may be repeated without problems (e.g., reading a block from the same position in file\--no side effects)
-   property - "idempotent"

## Idempotent Property

- Idempotence is the property of certain operations in mathematics and computer science whereby they can be applied multiple times without changing the result beyond the initial application. 

- The concept of idempotence arises in a number of places in abstract algebra and functional programming

- See [Idempotence on Wikipedia](https://en.wikipedia.org/wiki/Idempotence).

## Lost Reply Message

- What if request is not idempotent?
  -   e.g., transferring 500 thousand dollars from your account
  -   do it five times and you are broke!

- Solution - Client kernel uses a sequence number (needs to maintain
  state) for each request

- Have a bit in message to distinguish initial vs. retransmissions

## Server Crashes

- Depends on when server crashes
  -   After execution
  -   After receiving message but BEFORE execution

- Solutions differ


## Server Crashes

- But the client cannot tell the difference!
- Solutions?

  - Wait until server reboots (or rebind)
      -   try operation again and keep trying until success
      -   "at least once semantics"

  - Give up immediately and report failure
      -   "at most once semantics"
  - Guarantee nothing
      -   (-) RPC may be tried from 0 - any no
      -   (+) easy to implement

  - But none of the above attractive

  - What we want is "exactly once semantics", which cannot be achieved

## Client Crashes

- Client sends a request and crashes
  -   computation active - but no parent active
  -   unwanted computation called "orphan"

- Orphan's can create problems

  -   wasted resources
  -   locked files?
  -   client reboots - does RPC - reply from orphan comes =\> confusion!

  Solutions (Extermination)

  -   client stub logs (on disk) request before sending
  -   after reboot check log - kill any orphan
  -   (+) simple
  -   (-) too expensive (each RPC requires disk access!)

- what if orphans do RPC `=>` grand orphans `=>` difficult to kill all


## Client Crashes

- Reincarnation

  -   divide time into numbered slots (epoch)
  -   when client reboots, it broadcasts to all machines with new slot
  -   all remote computations killed
  -   if network partitioned, some orphans will remain - but will be detected later

- Gentle Reincarnation

  -   locate the owner of the orphan first
  -   if not found, kill computations


## Flow Control

- Network Interface Chips (NICs) can send message fast
- But receiving more difficult due to finite buffer
- Overrun can occur when
  -   NIC serving one packet
  -   another arrives

- No overrun possible in stop-and-wait (assuming single sender)
- Sender can insert gaps (assume n buffer capacity)
  -   send n packets
  -   gap
  -   send n packets

- Performance
- Critical Path

## See Also

There are many RPC implementations
- [Sun RPC Tutorial](https://www.slideshare.net/PeterREgli/sun-rpc)
- [Java/CORBA Tutorial](https://docs.oracle.com/javase/7/docs/technotes/guides/idl/jidlExample.html)
- [Java RMI Tutorial](https://en.wikipedia.org/wiki/Java_remote_method_invocation)

Today there are many new ways of doing RPC, especially for web services.

While the systems are more modern/hip, they still require an understanding of the basic underlying principles, which are unchanged.
