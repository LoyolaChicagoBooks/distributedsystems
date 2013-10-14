Writing with Sphinx
=========================

Introduction
------------

Common document models such as Rich Text Format, or Microsoft Word formats are based around one properly encoded file or around a compressed archive containing several folders and files. In both cases, to the user, a single file is presented. This file will contain all text, formatting metadata, and non text objects such as pictures.

Alternatively, other document models like those used in LaTeX, Pandoc, Sphinx, and similar systems allow/require the author to create the individual parts of a document in separate files and typically with separate software packages. Theses systems consume these individual files to create a final document in one or more possible formats. 

The first model often has the advantage of WYSIWYG (What You See Is What You Get) editors, and have all document data managed through one program that has one set of paradigms. This is a great way to go for many types of document authoring. The approach is simple to understand and the tools are relatively easy to use.

The second model often does not have a WYSIWYG editing experience. It, however allows you to use separate programs to manage each part of your document. For example, creating diagrams, authoring code, collecting tables of data, can all be done in a more comfortable way in non-text editor programs. This model also allows for a great deal of distributed authoring. When authoring books, it is possible for several contributors to work on the same document in parallel by working on separate files that contain different chapters of the document's text. Many of these tools also allow document authors to create several precisely formatted documents from one source of authored text and supplemental objects. For example, it is possible in Pandoc to create a paper formatted to the IEEE standard, a book chapter, and a webpage all by running the pandoc software with different arguments.

About Sphinx
------------

Sphinx makes use of Restructured Text. A great explanation of reST can be found on WikiPedia here: http://en.wikipedia.org/wiki/ReStructuredText. Essentially restructured text allows the user to write text in plain ASCII using ASCII representations of common formatting such as underlines, bullets, numbered lists, and others. Sphinx can take this restructured text and translate it into a document that has the same kind of formatting but in a way that is native to that document format.

We note that Sphinx is not the only authoring framework of its kind. We use other tools based on a similar design for different situations. As examples:

- `Jekyll <http://jekyllrb.com/>`_ is a framework based on `Markdown <http://daringfireball.net/projects/markdown/>`_ (an alternative to reStructuredText) for static website generation. We use this for maintaining sites like http://thiruvathukal.com. While awesome in general, it is not the best solution when you want the ability to author documents intended for print (PDF) and e-reading (ePub). Sphinx does all of the above, so to speak.

- `LaTeX <http://www.latex-project.org/>`_ itself could be used to author the content directly. LaTeX does a delightful job at its core competency, which is *typesetting*, which is clearly a relic of the print era. With a number of supplementatal tools, we can go to other formats. However, LaTeX has a rather steep learning curve for new users and is much more complex than reStructuredText and Markdown. 

- `Pandoc <http://johnmacfarlane.net/pandoc/>`_ is a delightful tool that can target all of the different formats as Sphinx does. In fact, it generates some of the *cleanest* output we've seen from any tool. Unlike Sphinx, however, it lacks innate support for writing chapter-oriented works (a concept we still find useful) and also suffers from the drawback of making it virtually impossible to externalize code examples.


We think you'll find Sphinx as enjoyable as we do and might even wonder how it is possible to organize a meaningful book without support for its core ideas (especially books having code examples and mathematics!)

Additional Resources
--------------------
 #. http://sphinx-doc.org/rest.html
 #. http://sphinx-doc.org/tutorial.html
 #. http://pythonhosted.org/an_example_pypi_project/sphinx.html


Setting up Sphinx - Ubuntu Linux
--------------------------------

Run the following commands to get a Sphinx environment setup on your Linux machine (as the super user):
 #. apt-get update
 #. apt-get install python python-setuptools python-pip make
 #. easy_install -U sphinx
 #. pip install sphinx_bootstrap_theme

If those commands all succeed, you will have sphinx installed. To test if the command is installed you can run "sphinx-build". This will launch the sphinx program. It will print its version and possible arguments.

Sphinx on non-Linux Platforms
-----------------------------

If you are setting up Sphinx on Linux, you will by far have the easiest time getting things up and running. So, if that is an option for you, your best bet is to pursue it. Sphinx is supported on other platforms such as Windows and OSX, but the installation process isn't as reliable as it is on Linux and might take some more effort to get it running properly.


Setting up Sphinx - Mac OSX (Using HomeBrew instead of MacPorts)
----------------------------------------------------------------

Getting things up and running on OSX takes a bit more work. Here's essentially what needs to be done:
 #. Install Mac HomeBrew - http://brew.sh
 #. Using the brew command from HomeBrew, install python, python-setuptools and python-pip
 #. easy_install -U sphinx
 #. pip install sphinx_bootstrap_theme.


Setting up Sphinx - Windows
---------------------------

The Sphinx documentation is a great resource for installing on Windows. You can find it here - http://sphinx-doc.org/latest/install.html

Setting up Sphinx in a Python virtualenv
-------------------------------------------

If you are working with a *copy* or *clone* of https://bitbucket.org/loyolachicagocs_books/distributedsystems, you might notice that the top level folder, contains a shell script, ``sphinx.sh`` that drives the Sphinx build process.

.. literalinclude:: ../sphinx.sh
	:linenos:

In this example, there is the following line that checks (my setup) for the presence of a Python virtual environment.

::
	[ -f ~/.env/sphinx/bin/activate ] && . ~/.env/sphinx/bin/activate

What this achieves is to give you your own Python interpreter and set of libraries and Python tools if the virtualenv can be successfully activated.

On George's system, observe what the following does::

	$ . ~/.env/sphinx/bin/activate
	(sphinx)atomium:distributedsystems gkt$ which python
	/Users/gkt/.env/sphinx/bin/python
	(sphinx)atomium:distributedsystems gkt$ which sphinx-build
	/Users/gkt/.env/sphinx/bin/sphinx-build

First, ensure the ``virtualenv`` command is present::

	$ pip install virtualenv

Create the virtualenv. It can be anywhere you like, but I keep all of my virtualenv instances in the ~/.env directory (.env in my home folder). You can put it anywhere you like:

	$ virtualenv ~/.env/sphinx

This generates a bunch of output::

	$ virtualenv ~/.env/sphinx
	New python executable in /Users/gkt/.env/sphinx/bin/python2.7
	Also creating executable in /Users/gkt/.env/sphinx/bin/python
	Installing Setuptools..............................................................................................................................................................................................................................done.
	Installing Pip.....................................................................................................................................................................................................................................................................................................................................done.


Activate the virtualenv::

	$ . ~/.env/sphinx/bin/activate
	(sphinx)imac-g5:~ gkt$ 

Install the ``sphinx`` and ``sphinx_bootstrap_theme``. Both of these are needed to rebuild the course notes.

	$ pip install sphinx sphinx_bootstrap_theme

	(you'll get a LOT of output, not shown here but ending with the following)

	Successfully installed sphinx sphinx-bootstrap-theme Pygments Jinja2 docutils markupsafe
	Cleaning up...

You are unlikely to have any problems if you do this on OS X or Windows. If you are on Linux, it is likely that you need some additional packages (already covered in our Ubuntu section above).

virtualenv has the added advantage of allowing you to do Python experimentation with as little use of the *root* user as possible. Once you have it going, you'll come to realize that you can't live without it, especially when doing Python work!

Authoring in Sphinx
-------------------

An excellent way to learn Sphinx is to look at existing documents. The concurrency lecture has several example usages of reST: http://distributed.cs.luc.edu/html/_sources/concurrency.txt. The entire source repository for the distributed systems lecture notes is available on BitBucket here - https://bitbucket.org/loyolachicagocs_books/distributedsystems. You can download the source, and see an entire working example.

You are encouraged to look through the `Sphinx documentation <http://sphinx-doc.org/>`_ for full details.

Examples
--------


Creating a Heading: 

::

	This Is a Heading Underlined With Dashes To Make It A Heading
	-------------------------------------------------------------



Creating a Heading with bullets under it

::

	My List (notice indentation and space after dash)
	-------------------------------------------------
		- Item 1 
		- Item 2


Creating a heading with a numbered list under it (numbers are generated by sphinx automatically)

::

	My Numbered List (notice space after the pound and dot)
	-------------------------------------------------------
		#. First Item
		#. Second Item
		#. Third Item


Including a figure from a PNG image

::

	.. figure:: figures/figure01.png
		:align: center
		:width: 600px
		:alt: Figure 01


Creating an inline code snippet (Approach 1) (notice the blank line after the two colons and the indentation)

::

	::
		#include <stdio.h>

		int main() {
			printf("Hello World\n);
			return 0;
		}


Creating an inline code snippet (Approach 2) (this approach uses an actual code file, it will start the snippet from the line in the file matching the text after the "start-after" and end the snippet before the "end-before". Your best bet is to add the pattern .. in this case begin-main-function and end-main-function as comments in your example code file.)

::

	.. literalinclude:: examples/main.c
		:start-after: begin-main-function
		:end-before: end-main-function
		:linenos:




