SMTP Process
======================

First you send an email from a stand-alone client. The client connects to your local SMTP server using port 25. The client has a conversation with the server, telling the server the address of the sender and recipients, and sending the message.

The server takes the TO address and breaks it into the recipient name and the domain name. If the email was intended for someone with the same domain name then it will hand the message to the POP3 server. If the recipient is at another domain than SMTP needs to communicate with the server at that domain.

The SMTP server uses DNS to retrieve the IP address for the recipient domain and connects with that server using port 25. A conversation, like the previous one with the client, is held with the SMTP receiver server and the email is sent. The receiver server recognizes the domain name is local and hands the message off to the POP3 server, which will place the message in the recipient’s mailbox.

If the sending server can’t connect with the receiving server than the message goes into a queue. The server will periodically try to resend the messages in its queue until it reaches a timeout and sends a failure notification.  







