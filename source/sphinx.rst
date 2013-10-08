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


Authoring in Sphinx
-------------------

An excellent way to learn Sphinx is to look at existing documents. The concurrently lecture has several example usages of reST: http://distributed.cs.luc.edu/html/_sources/concurrency.txt. The entire source repository for the distributed systems lecture notes is available on BitBucket here - https://bitbucket.org/loyolachicagocs_books/distributedsystems. You can download the source, and see an entire working example.






