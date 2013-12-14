Common Object Request Broker Architecture (CORBA)
==================================================

What is CORBA?
------------------------------------------------

- CORBA is Object Management Group's an open standard, infrastructure and vendor independent architecture that different computer applications use to work together via networking
- By using a standardized protocol Internet Inter-ORB Protocol, a CORBA specfic program of any programming language from a paticular vendor on any computer, operating system and network can communicate and does the operation with other CORBA specific program from the same or different vendor, operating system, programming language and network
- CORBA consists of a standard framework for maintaining and developing distributed software systems

CORBA Uses?
--------------------

- CORBA incorporates different machines ranging from mainframes through miniframes and desktops to embedded systems.
- It is basically a middleware technology architecture for large enterprises having large applications and also for small embedded systems.
- It is most frequently used in servers which handles large number of clients with high reliable hit rates.
- It is also considered as a back end technology architecture for many large websites. Scalability and fault tolerance specializations do support such systems.

What is IDL and how OMG IDL enables Distrubution?
--------------------------------------------------
- The OMG IDL is strongly typed and is enforced at compile time when used with object oriented language.
- To work with distrubution in CORBA architecture, an interface is defined which is understood by both client and server object irrespective of their operating system, platform, programming language and network connections. 
- The IDL specifies the operation which is to be performed including the input and ouput parameters of their types, where client and server are allowed to encode and decode values on network.
- The language should enforce architecture for CORBA and support robust exception handling.

IDL Type System
--------------------------------------------------

- Every CORBA object has a type name same as the interface name assinged in IDL declaration. All the operations to be performed, variables and their types are part of object type. When a new CORBA object is defined, a new CORBA type is created be declaring a new interface.
- The OMG IDL variables do are typed but not as same as CORBA objects. In this system, variables types are not created but are selected from the official types list allowed by IDL specification. The list includes three different precisions of integer and floating point numbers, characters and strings and also boolean. The constructed types includes the structure, union and enum, sequences, attributes, valuetypes and also other IDL types for creatinf efficient and flexible data structues for interfaces.
- CORBA objects are passed by reference and data such as intergers, structs, enums are passed by value.
- Example IDL is as shown below:

::
	interface incometax{
		float caculatetax(in float taxableamount);
	}


Technical Overview
--------------------------------------------------

- Applications based on CORBA are composed of different objects which are basically treated as individual units of the software in live production. There could be many instances of object of a single type. For Example, the shopping cart of different customers on an e-commerce website. There could also be only one instance of object of other type. For example, a legacy application accounting system. 
- For each object type, an interface is defined in OMG IDL where interface is basically the syntax representation of the contract the server object offers to clients that invokes the object. Different clients interact with the server and specific client that invokes an operation on the object must use the IDL interface inroder to specify the operation the client wants to perform and to marshal the arguments it sends. 
- When the client invocation reaches to the target object, the same interface definition is used to unmarshal the arguments in order to perform the requested operation.
- The results produced after executing the action placed on logical order (marshal) is again marshal and unmarshal through its process of reaching the destination.
- The IDL interface is programming language independent. OMG established severeal standardized mappings for IDL to popular programming languages such as C, C++, Java, Ruby, COBOL, Smalltalk, Ada, Lisp, Python and IDLscript.
- The ORB's communicate through GIOP Protocols.


	.. figure:: figures/corba.jpg
	   :align: center
	   :alt: Process Memory Layout

	#. Taken from "www.en.wikepedia.org"


Mapping of IDL to Programming languages
-------------------------------------------------

- Mapping assigns a language specific variable type to every IDL variable type and also a translation from the IDL's operation format to the specific language's invocation of a member function. Mapping to an object Oriented language also assign names to the base classes for the implementation and degine how this implementation classes should derive from the IDL generated classes
- The language mappings in the software is implemented by the IDL compilers. The ORB consists of one or more IDL compilers, that is specifically one for each language that ORB supports. 


CORBA Advantages
-------------------------------------------------

- Programming Language Independence
- Operating System Independence
- Open Standard
- Wide Platform Support
- Efficiency
- Scalability
- Stron Data Typing
- Compression through ZIOP protocol

CORBA Disadvantages
-------------------------------------------------

- Firewall Unfriendly
- Complicated
- Location Transparency

CORBA Sevices and Facilities
-------------------------------------------------

- Persistency
- Query Services
- Transaction Services
- Collections
- Lifcycle Services
- Transaction Services


	.. figure:: figures/corba1.jpg
	   :align: center
	   :alt: Process Layout

	#. Taken from "http://www.ece.uvic.ca/"


CORBA Distributed Objects Services
-------------------------------------------------

- Method Invocation
- Remote Notification
- Naming Services
- Object Services
- Exceptions
- Memory Management

CORBA ORB Products
-------------------------------------------------

- Orbacus
- Websphere
- Netscape Communicator
- Sun Java 2 Platform






