Choking and Optimistic Unchoking Algorithm
============================================
Choking is a mechanism using which the BitTorrent protocol avoids free riders, those who want to download but not upload.
Also, choking helps tackle network congestion???

#. Upload one file piece to peer p
#. Repeat 1 N times // N is typically between 2 and 5
#. If peer p uploads data go to 1 else go to 4
#. Stop uploading to p for S seconds
#. After S seconds go to step 1

The above procedure is applied for all peers. The last step is called optimistic unchoking. This way the algorithm makes sure that no peers are choked permanently.
This is a simplistic procedure for choking/unchoking mechanism. The real algorithm may be more complex depending on implementation.
In the the case where the uploader is a seeder rather than a simple peer, the overall upload rate for the downloading peer is checked and then it is decided whether to chokoe or unchoke.
And finally the seeders and peers upoad to those peers with the highest upload rate. This way, the protocol makes sure that the the uploads complete fast and the number of replica is large.
