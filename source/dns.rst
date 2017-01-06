Domain Name Service
==========================

What is DNS ?
-------------
 - DNS is a hierarchal, decentralized naming system for computers, services, and resources connected to or not connected to the internet.
 - DNS implementations can reside on LANs or at internet scale

Types of DNS Records
--------------------
 - A Records: host name to ip address record
 - MX Records: records of host names and IP addresses of SMTP mail exchangers
 - NS Records:
 - PTR Records: records for reverse DNS lookups. To translate ip addresses to host names 


History of DNS
--------------
 - Original IP-address to host name translations were maintained in a text file on each host that was named hosts.txt. This approach still exists on Linux, Windows, and similar PC and server systems. This approach is still somewhat useful on statically addressed small networks that don’t implement dynamic network discovery services.
 - The IP address and host names were managed by 1-2 people from the 1970s to the early 1980s
 - In the early 1980s, Mockapetris created the original DNS system. Soon after, the IETF (Internet Engineering Task Force) published RFC 882 and 883 to document the protocols and capabilities of DNS
 - In 1984, UC Berkley students implemented the first UNIX based DNS server called BIND. This system was ported to Windows NT in the early 1990s
 - Currently, BIND is one of the most widely used DNS platforms used on the internet.
 - In subsequent years and decades, standards groups and researchers proposed and implemented new record types, improved security, and scaling of the DNS system as the internet itself expanded.


Top Level Domains
-----------------

 - A TLD is the right-most section of a internet address. For example, google.com’s TLD is .com, Luc.edu’s TLD is .edu
 - Originally, there were very few TLDs. These included .arpa, .org, .com, .net, .nato
 - Soon after, national / regional specific TLDs came into existence such as .dd for East Germany, or .us for America
 - In the 2000s, ICANN introduced many new TLDs, and in the 2010’s 1000s of new TLDs were introduced
 - TLDs are arbitrary and controlled by ICANN, the group that manages the Internet’s root DNS servers. In an isolated network or in your own LAN, you can create your own TLDs, but they will only be respected within your own network.

DNS and Its Hierarchies
-----------------------

.. figure:: figures/dns/dns_hierarchy.png


Credits
--------
 - Information for this lecture was drawn from:
	- Wikipedia
	- Distributed Systems by Andrew Tanenbaum

