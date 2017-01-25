Homework #1 Due Feb 15th
========================

Requirements
------------
 - You will write a web application that works with an existing 3rd application framework and 3rd party data storage system.
 - For example:
	- An ASP.NET web application hosted in IIS with a SQL server database
	- A PHP web application hosted in Apache with a MySQL database
	- A RESTful web service that uses a MongoDB database
 - This system will involve one application host and one database host
 - This application should include basic CRUD (Create, Read, Update, Delete) operations


An example of how to get started with Java and Linux
----------------------------------------------------

Getting your software ready:

1. Install maven, jdk8, and git (apt-get install openjdk-8-jdk maven git)
2. Install Eclipse Neon (Version: Neon.2 Release (4.6.2)) (can be downloaded from eclipse.org

Creating a basic web service with Maven

3. Launch eclipse and create a workspace.
4. Open a terminal, cd into your workspace and run this command to create the basic project: 

::

	mvn archetype:generate -DarchetypeArtifactId=jersey-quickstart-grizzly2 -DarchetypeGroupId=org.glassfish.jersey.archetypes -DinteractiveMode=false -DgroupId=SampleService -DartifactId=Sample-Service -Dpackage=SampleService -DarchetypeVersion=2.17



5. In Eclipse, go to File->Import. Then open the Maven folder, and select "Existing maven projects". Browse to the folder that was just created in #4 and open the project
6. If you launch the project in the debugger and browse to http://localhost:8080/myapp/myresource you’ll be able to see the object represented by the source file MyResource.java

If you’d like to see the code for a simple web service app, just clone the git repository found here: https://github.com/sarahkaylor/DistRestSample


