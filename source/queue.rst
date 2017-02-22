
Distributed Queues
==================


What is a Distributed Queue?
----------------------------

- A distributed queue is a distributed, transactional database that supports queued, structured messages. Distributed queues are read/write databases.

- Distributed queues are a commonly used mechanism to provide reliable and scalable messaging between components in a distributed system



A simple Hello World with Rabbit MQ
-----------------------------------

* Prerequisites are getting the 3rd party RabbitMQ library, setting up the service, and creating an instance of the distributed queue in RabbitMQ’s database. These are all fairly straight forward:

* The sender code:


::

	import com.rabbitmq.client.Channel;
	import com.rabbitmq.client.Connection;
	import com.rabbitmq.client.ConnectionFactory;

	public class Send {

	  private final static String QUEUE_NAME = "hello";

	  public static void main(String[] argv) throws Exception {
	    ConnectionFactory factory = new ConnectionFactory();
	    factory.setHost("localhost");
	    Connection connection = factory.newConnection();
	    Channel channel = connection.createChannel();

	    channel.queueDeclare(QUEUE_NAME, false, false, false, null);
	    String message = "Hello World!";
	    channel.basicPublish("", QUEUE_NAME, null, message.getBytes("UTF-8"));
	    System.out.println(" [x] Sent '" + message + "'");

	    channel.close();
	    connection.close();
	  }
	}


* The receiver code:

::

	import com.rabbitmq.client.*;

	import java.io.IOException;

	public class Recv {

	  private final static String QUEUE_NAME = "hello";

	  public static void main(String[] argv) throws Exception {
	    ConnectionFactory factory = new ConnectionFactory();
	    factory.setHost("localhost");
	    Connection connection = factory.newConnection();
	    Channel channel = connection.createChannel();

	    channel.queueDeclare(QUEUE_NAME, false, false, false, null);
	    System.out.println(" [*] Waiting for messages. To exit press CTRL+C");

	    Consumer consumer = new DefaultConsumer(channel) {
	      @Override
	      public void handleDelivery(String consumerTag, Envelope envelope, AMQP.BasicProperties properties, byte[] body) throws IOException {
	        String message = new String(body, "UTF-8");
	        System.out.println(" [x] Received '" + message + "'");
	      }
	    };
	    channel.basicConsume(QUEUE_NAME, true, consumer);
	  }
	}


* Overall, this kind of code is fairly simple


Using Distributed Queues in Distributed software
------------------------------------------------

* A key thing to remember is that distributed queues are a building block, and not a complete queueing solution in and of themselves. What distributed queues give you are the tools to build a proper distributed message or job processing system. Actual implementations need further consideration

* For example, if you’re trying to ensure that a client queueing a job, and the processing of the job is fully successful or not you need to be careful with how you use the queue:

	* If the job processor dequeues a job and crashes while processing it, the client will not know for sure that the job was completed.
	* If the job processor simply leaves the job in the queue while processing, you cannot guarantee that another job processor won’t redundantly perform the work itself.
	* If there are more transactions within a system (such as from another database), there may not be a more global transaction to make the entire job atomic.






