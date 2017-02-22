
Homework #2 Due March 15th
==========================

Assignment Goals
~~~~~~~~~~~~~~~~

- One goal of this homework will to keep the system working from the client perspective despite random errors and / or crashes. 
- Another goal is to see what the performance limitations of the service are. Does it scale up to 100s or 1000s or 10000s of request per minute?

Code changes to Homework #1
~~~~~~~~~~~~~~~~~~~~~~~~~~~

- In your service, add crashing as a feature. This means, for each of your service methods, use a random number generator to cause an error to be returned at a specific probability. A good number to start with is 1 out of 10.
- Update your client to the service to be able to identify these kinds of random errors and compensate for them.
- Update your client to be able to send at least 750 requests per minute. If possible, aim for 2000 per minute.
- Implement some kind of “back off” behavior in your client (to be explained in class)


Deliverables
~~~~~~~~~~~~

- Your updated code
- A 2-3 page paper describing the performance limitations of your process, and how your client works around those performance and stability limitations. You should also begin to discuss how you might improve your service and client to improve performance and reliability even further in Homework #3

