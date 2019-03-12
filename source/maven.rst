Project Build Management With Maven
===================================

Introduction
------------

- The goal of this page is to give you a step-by-step guide to get a Java project up and running with Maven 3.x
- The instructions are written against Maven 3.0.4 and Java 1.6.0.51 on Mac OSX 10.8.4


Creating a Maven Project from Scratch
-------------------------------------

- Maven has a concept of archetypes. Archetypes are skeleton projects that a user can use to get a basic development setup for one purpose or another (desktop application, servlet, etc…)

- The following command will invoke maven, fetch some initial dependencies, and list a set of archetypes that are available. If you press 'enter' at the first question, you will create a default Java desktop application. Maven will ask you to fill out some identifying information for your project (such as a project name, group name, etc…).

::

	$ mvn archetype:generate


- After this command finishes, you will have three interesting objects in your folder, a pom.xml, src/main, and src/test
	- pom.xml contains the build, unit test, and dependency configuration
	- src/main contains the production code for your project
	- src/test contains the unit tests for the project.


Generating an Eclipse Project from a Maven Project
--------------------------------------------------

- After generating your Maven project, you won't be able to immediately open it in Eclipse

- Maven is able to generate the appropriate files to setup an eclipse project.

- This command will generate the necessary Eclipse project files

::

	$ mvn eclipse:eclipse



Configuring Eclipse
-------------------

- The created project should open in eclipse, but it is possible you might run into some problems.

- Often, you may see an error related to M2_REPO not begin defined. To fix this
	#. Right click on your project in the Package Explorer
	#. click on Properties in the context menu
	#. click on the Libraries tab
	#. click on the "Add Variable" button
	#. click "Configure Variables"
	#. click "New"
	#. Under name put M2_REPO
	#. Under Path, put your home folder and .m2/repository. On my system this is /Users/joe/.m2/repository

- Your project should build just fine. You are ready to develop your project.


Running Unit tests with Maven
-----------------------------

- Running unit tests on the command line is simple with Maven, just run the following command

::

	$ mvn test


- Maven will compile and run any unit test fixtures you have under src/test.





