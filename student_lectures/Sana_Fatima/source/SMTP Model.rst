SMTP Model
======================

* Sender’s client machine → sender’s local SMTP server → recipient’s local SMTP server → recipient’s local host* Relaying
	* Absence of DNS made electronic mail delivery complex.	* SMTP routing information had to be included along with the e-mail address.
	* Routing information specified the SMTP servers that the mail had to be relayed through in order to reach its destination.	* This early process was inconvenient: requiring many devices to handle the mail, resulting in delays, and requiring communication of source routes between servers.* Direct Email Communication (preferred method)
	* Utilizes DNS		* Support for mail exchanger (MX): record that allows mapping of domain name to IP address of the SMTP server.	* Sender SMTP server can make a connection to directly send the message to the receiver’s SMTP server.	* Direct email delivery is faster and more efficient. 	* SMTP is used for the transfer between the sender’s client to it’s local SMTP server and the transfer between that SMTP server to the recipient’s local SMTP server. Retrieval of email by the recipient is done using POP or IMAP. 	* Each email transfer requires establishing a TCP connection and then sending the email headers and body using the SMTP mail transaction process. 


