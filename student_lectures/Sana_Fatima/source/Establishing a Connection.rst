Establishing a Connection
================================
* Using TCP to ensure efficient and reliable communication.* SMTP servers must be available 24/7 to allow mail to be delivered at any time. 	* This is why end-users use other protocols to retrieve an email over running their own SMTP servers.* Server listens on well known port 25 for TCP connection requests from other servers.* Communication is similar to FTP.	* SMTP commands are sent as plain ASCII text over the TCP connection. 

.. figure:: smtpEstablishing.jpg* Commands and Replies	* EHLO (extended hello) command includes the domain name of the sender as a parameter. Sent to greet a SMTP receiver and ask for a list of extensions it supports. 	* 220 greeting reply includes server name.	* 250 reply states successful execution of command.	* 221 quitting reply includes server name.

.. figure:: smtpConnection.jpg

* Shows some supported extensions
	* 8BITMIME: 8-bit content transfer encoding type in MIME.
	* SIZE: Message size declaration.
	* PIPELINING: multiple commands can be sent in groups instead of the command/reply format.
	* ETRN: extended Turn.
	* VRFY: checks if email address is valid.

