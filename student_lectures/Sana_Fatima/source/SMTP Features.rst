SMTP Features
======================

* Relaying* Forwarding: SMTP server will accept an email for a nonlocal host and forward it. Similar to relaying but it is used for a different purpose.* Address Debugging: VRFY (verify) command used to check validity of email address.* Mailing List Expansion: EXPN (expand) command* Failure response: if initial attempt doesn’t go through the server will periodically retry to send the email until it reaches a timeout, returning a failure message. 


