.. sphinx_project_1 documentation master file, created by
   sphinx-quickstart on Mon Oct 14 18:02:19 2013.
   You can adapt this file completely to your liking, but it should at least
   contain the root `toctree` directive.

Distributed Data
================

Mongo Doesn't (always) Know Best
--------------------------------

- `MongoDB <http://www.mongodb.org/>`_ is great, but has some shortcomings
        - Unreliable on a massive scale
        - B-Tree Indexes (large RAM requirements)
        - No update history
        - Might be an adequate, but non-ideal tool for the job

- Alternative
        - Message Queues
                - `RabbitMQ <http://rabbitmq.com/>`_
                - `ØMQ / ZeroMQ <http://zeromq.org/>`_
        - Key-Value Store
                - `DynamoDB <http://aws.amazon.com/dynamodb/>`_
                - `Riak <http://basho.com/riak/>`_
        - Graph
                - `Neo4j <http://neo4j.org/>`_
                - `OrientDB <http://www.orientdb.org/>`_
        - Deductive
                - `Datomic <http://datomic.com/>`_

Messaging Queues
----------------

- Basic introduction

- Basic example: Task Distribution
        - Consider a system similar to homework 3
        - There is a master M, and several workers
        - M sends to the messaging queue
        - The workers poll the messaging queue

- Basic Applications
	- Distributed task system
	- System and log monitoring

- Relation to distributed systems
        - Single message queue allows several different nodes to work over same data
        - Queue itself can be distributed

RabbitMQ
--------- 
- `Documentation <http://www.rabbitmq.com/documentation.html>`_
- What is RabbitMQ?
	- Robust messaging for applications
	- Easy to use
	- Runs on all major operating systems
	- Supports a huge number of developer platforms
	- Open source and commercially supported

- Sending and Receiving Messages From a Single Queue
	- When sending a message, the computer sending a message is called the *producer*.
	- Any computer receiving a message is call a *consumer*. 
	- Producers send messages to a *queue*. 
- Messaging queues made simple
    - List
    - Code example here?

.. figure:: Images/Rabbit/OneToOne.png
        :align: center
        :width: 400px

**Send class:**
::
  class RabbitNodeWriter implements NodeWriter{
    Channel channel
    Connection connection
    String QUEUE_NAME = "systems"

  }

- Here we define the queue name and dedicate a class to handling the Queue creation 


**Connecting to a Server:** 
::
    void initialize() {
        ConnectionFactory factory = new ConnectionFactory()
        factory.setHost("192.168.216.100")
        connection = factory.newConnection()
        channel = connection.createChannel()
	. . .

- The server can be the IP address of any server. In this case, we have a VM at this address. 

**Declaring the Queue to Send to:**
::
	. . .
        channel.queueDeclare(QUEUE_NAME, false, false, false, null)
    }

- The channel handles most of the API
- Declare the name of the queue to publish to
	- This allows for selective publishing and listening based on queue

**Closing the connection:**
::
    void tearDown() {
        channel.close()
        connection.close()
    }


**Receiver Class:**
::
  class RabbitNodeReader implements NodeReader {
    Channel channel
    Connection connection
    String QUEUE_NAME = "systems"
    QueueingConsumer consumer
    QueueingConsumer.Delivery currentDelivery
    . . .
    void initialize() {
        ConnectionFactory factory = new ConnectionFactory()
        factory.setHost("rabbit.dev.ds.internal")
        connection = factory.newConnection()
        channel = connection.createChannel()
        channel.queueDeclare(QUEUE_NAME, false, false, false, null)
        consumer = new QueueingConsumer(channel)
        channel.basicConsume(QUEUE_NAME, false, consumer)

    }
  }

- Class for receiving nodes
- Similar initialization. Stating the queue it’s listening to.
- In the case that the consumer is started before the producer, Rabbit will automatically create the queue
- Rabbit will ensure no duplicate queues


**Output from Two Workers:**
::
  shell1$ java -cp .:commons-io-1.2.jar:commons-cli-1.1.jar:rabbitmq-client.jar
  Worker
   [*] Waiting for messages. To exit press CTRL+C
   [x] Received 'First message.'
   [x] Received 'Third message...'
   [x] Received 'Fifth message.....'
  shell2$ java -cp .:commons-io-1.2.jar:commons-cli-1.1.jar:rabbitmq-client.jar
  Worker
   [*] Waiting for messages. To exit press CTRL+C
   [x] Received 'Second message..'
   [x] Received 'Fourth message....'

- This shows an example of output if we pushed five messages to a queue that two workers were listening to simultaneously. 


**Consuming Messages:**
::
    TaskNode getNode() {
        currentDelivery = consumer.nextDelivery()
        String message = new String(currentDelivery.getBody())
        TaskNode node = processRabbitString(message)
        return node
    }

- Rabbit pushes messages from the queue asynchronously 

- Acknowledgements: What Happens to Dead Workers?
	- There aren't any message timeouts so tasks can work indefinitely 
	- Message acknowledgments are turned on by default
	- RabbitMQ will redeliver the message only when the worker connection dies

- Durability
	- When RabbitMQ quits or crashes it will forget the queues and messages unless you tell it not to
	- Need to mark both the queue and messages as durable
		- This is done by setting the durable boolean = true before we declare our queue (in both producer and consumer)

**Bindings:**

.. figure:: Images/Rabbit/direct-exchange.png
        :align: center
        :width: 400px

- We can set a producer to send to an exchange, which will then delegate specific messages to specific queues
	- This is helpful for having certain nodes listen for certain queues, such as a dedicated error consumer (listens only to an error queue)

**Exchanges and Publishing to an Exchange:**
::
  channel.exchangeDeclare(“exchangeName”, “exchangeType”);
  .. 
  .. 
  channel.basicPublish( “exchangeName”, "", null, message);
  ..
  ..
  channel.queueBind(queueName, “exchangeName”, "");

- Application to Distributed Systems
	- RabbitMQ can handle any number of nodes (adding or subtracting) dynamically
		- Acknowledgements so no tasks are lost
		- Durability so the queue and tasks are never lost if the server goes down
- Possible Issue
	- What happens if the server or the publisher goes down?
		- Need a way to determine if the server or publisher fails and have a node become the next server or publisher
			- Need to tell all nodes about the change without losing work

ZeroMQ
------
- `Documentation <http://zguide.zeromq.org/page:all>`_
- ZeroMQ vs RabbitMQ Quick Summary
	- ØMQ is more of a framework that allows you to use any of the models or even combine different models to get the optimal performance/functionality/reliability ratio.
		- Ultimate flexibility
	- RabbitMQ Provides a broker system with its own set of distinct advantages and disadvantages
	- ØMQ requires a lot of reading and knowledge to set up because it requires putting various pieces together
	- RabbitMQ is very easy to manage because of the broker style of messaging 

**Broker vs Brokerless:**
	- Advantages of Broker
		- Applications don't have to have any idea about location of other applications. The only address they need is the network address of the broker.
		- Message sender and message receiver lifetimes don't have to overlap. Sender application can push messages to the broker and terminate. The messages will be available for the receiver application any time later.

	- Disadvantages of Broker
		- It requires excessive amount of network communication.
		- The fact that all the messages have to be passed through the broker can result in broker turning out to be the bottleneck of the whole system.

.. figure:: Images/0mq/broker1.png
        :align: center
        :width: 400px

- Brokerless System
	- At the cost of manageability 

.. figure:: Images/0mq/broker3.png
        :align: center
        :width: 400px

- Each application has to connect to the applications it communicates with and thus it has to know the network address of each such application. 
- In real world enterprise environment with hundreds of interconnected applications managing the solution would quickly become a nightmare.

**Solutions With ØMQ Framework:**

- Broker as a Directory Service
	- Broker has a repository of applications running on the network. It knows that application X runs on host Y and that messages intended for X should be sent to Y.
	- Brings back easier manageability while maintaining higher performance

.. figure:: Images/0mq/broker4.png
        :align: center
        :width: 400px

- Distributed Broker
	- Brings back advantages of broker model
	- The sender application and the receiver application don't have to have overlapped lifetimes. 
	- The messages are stored in the broker while sender is already off and receiver has not yet started. 
	- Also, if the application fails, the messages that were already passed to the broker are not lost.

.. figure:: Images/0mq/broker5.png
        :align: center
        :width: 400px

- Distributed Directory Service 
	- Extreme fault tolerance
	- We can copy the configuration to all the nodes of the network. 
		- The idea is that once deployed the network topology of production line will be completely stable and thus the issue of having to modify configuration on all the nodes is irrelevant.
		- An example may be LDAP service
			- Such a service supports replication - meaning that the configuration is available even if it goes offline as there is replicated LDAP server

.. figure:: Images/0mq/broker7.png
        :align: center
        :width: 400px



Key-Value Stores
----------------

- Key-Value stores are a method of storing a basic amount of information, looked up by a single key.
- These are somewhat analagous to a dict in Python, or a Map in Java.
- Below is a basic example of a Key-Value store that represents a few aspects of a person::

  [1: [color: "Red", siblings: 3,  children:, name: "Bob"], 2: [name: "Alice", occupation: "Chef"]]

- Notice that the values don't necessarily follow the same structure at all, and can even be null.
- However, where many databases can do similar things, key-value stores are optimized for looking up by a single key. For example, people may be looked up by a single key. In the above example, it is a basic ID number, but we could just as easily rearrange it to be [Bob: [color:"Red"] ...], and key off the name.


Riak
----

- `Documentation <http://docs.basho.com/riak/latest/>`_

- A decentralized approach to information

- Used by Riot Games

DynamoDB
-------------

- `Documentation <http://aws.amazon.com/documentation/dynamodb/>`_

Graph
-----

- What is the highest educational degree of the wife of the current president of the united states.
- Graph databases represent things as, coincidentally, graphs.
- Most other datastores have the concept of an object, which may be related to other objects. Graph databases take this conclusion to the most logical conclusion, and describe everything as their relation.

Neo4j
-----

- `Documentation <http://docs.neo4j.org/>`_

Deductive
---------

Datomic
-------

- `Documentation <http://docs.datomic.com/>`_


Sources
-------
- http://zeromq.org/whitepapers:brokerless
- http://www.rabbitmq.com/documentation.html

.. toctree::
   :maxdepth: 7



