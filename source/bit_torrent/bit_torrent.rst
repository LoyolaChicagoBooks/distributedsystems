BitTorrent
=============

- BitTorrent is a protocol for peer-to-peer content sharing over the Internet.
- In November 2004 BitTorrent share of the whole Internet Traffic was estimated at 35% (Wikipedia).
- The protocol was designed by Bram Cohen in 2001.
- Bram Cohen released an implementation in the same year.
- The final Version was released in 2008.

.. Figure:: figures/BitTorrentModel.png
	:align:  center
	:width:	 700px
	:height: 600px
	:alt:    Figure 1

Terminology
-------------
- Seeder 
	A peer with complete file is called seeder.
	Initially there is only one seeder (the one who uploads the file).
	Peers who download the file completely and contunue to share, become seeders.
- Peer
	A host that is in process of downloading the file while uploading at the same time. This is sometimes called a leecher as well; however, the term leecher is sometimes used for peers that just download and decide to not upload.

- Bencoding
  Messages exchanged between peers and trackers are bencoded as explained below:

  - Strings are prefixed with an integer representing their length followed by a colon and the string itself. For example 4:info corresponds to 'info'
  - Integers are prefixed by an i followed by the integer and ending with an e. Example, i3e corresponds to 3.
  - Lists are prefixed with l followed by elements (also bencoded) ending with e. Example l4:info3:abce corresponds to ['info', 'abc']
  - Dictionaries are prefixed by d followed by an alternating list of keys and values, and they end in e. For example, d1:a4:spam1:b4:infoe corresponds to {'a': 'spam', 'b': 'info'}

- Metainfo (.torrent) File 

  - A light-weight file that contains meta-data about the file(s), trackers, etc. as explained below.
  - URL of the tracker(s).
  - info field which is a dictionary with the following elements

    - name: maps to the name of the file/directory being shared
    - piece length: The size of the file pieces.
    - length: Length of the file in bytes.

- Tracker

  - A host that coordinates file distribution.
  - Maintains IP address, port number and an ID for every peer.
  - Transfer state for peers: downloading, completed.
  - It returs a random list of peers to the clients when requested.
  - Peers send Tracker GET requests to trackers and they get Responses back from the tracker.
  - Tracker GET requests have the following fields

    - info_hash: a sha1 hash of the metainfo file
    - peer_id: a 20 byte identifier that the peer generates when it first starts
    - ip: The IP address of the peer
    - port: The port number that the peer uses
    - uploaded: The total amount (in bytes) uploaded so far
    - downloaded: The total amount (in bytes) this peer has downloaded so far
    - left: The amount (in bytes) this peer has yet to download to complete download
    - event: An optional key that maps to one of 'completed', 'started', stopped'. The peers can inform the trackers of their status using event messages.
  
  - Tracker responses are dictionaries with the following elements:

    - interval: Number of seconds downloader should wait before sending another request
    - peers: A list of dictionaries corresponding to peers
    - failure reason: A string explaining the reason why the request failed, in case there is a failure

How It Works
----------------
- BitTorrent client is the tool used to achieve the majority of the activities in sharing.
- The file(s) being distribted is divided into pieces.

  - When a peer receives a piece, it can then redistribute it to other peers.
  - Pieces are protected by a cryptographic hash so as to avoid accidental or malicious modification.
  - Pieces are distributed non-sequentially and the client rearranges them when it receives all the pieces.
  - Piece size can be set arbitrarily by the client. For example, with piece size of 1 MB a 10 MB file will divided into 10 equal pieces and will be shared in chunks of 1 MB.

- Transfer is done via TCP as follows:

  - The protocol makes sure that several requests are pending before a piece is being sent.
  - At the receiving end once a piece arrives, another request is sent.
  - At any point in time, a specific number of pieces (usually 5) is requested.

==========================
Piece Selection Policy
==========================

If pieces are not selected in a well-thought way, all peers may endup having downloaded the same pieces but some (of the more difficult pieces) may be missing. If the seeder disappears preamturely, all peers may end up with incomplete files.
To solve this issue, one or more of the following policies are used:

- Random First Piece Selection

  - Initially the peer has no pieces.
  - Select a first piece and downoad it as soon as possibly.
  - Select a random piece of the file and download it.

- Rarest Piece First

  - Determine the piecest that are not found or are rare among the peers and download those first.
  - This ensures that the common pieces are left towards the end to be downloaded.

=================================
Create and Share Torrent Files
=================================

When a user wants to share a file, they would create a torrent file (Torrent files are identified by .torrent extension) using the client application.
The torrent file wraps around information such as the specifi file(s) to be shared, location of the file(s) on the seed machine, etc.
The torrent file is then shared with other peers.
The original uploader is known as seed/seeder and others who start downloading from seeder are known as peers or leechers.

============================================
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

=================
Peer Protocol
=================
- Peer connections are symmetrical: same data can be sent in both directions
- File pieces are referred to by indexes
- When a peer finishes downloading a piece it announces to all other peers that it has that piece
- Connections on both sides contain two bits of state: choked/unchoked and interested/not_interested
- Choking the status indicating that no data can be sent until the unchoking happens
- Data transfer happens when one side is interested and the other side is not choking
- Connections start in unchoked and not-interested state
- Downloaders should keep several piece requests queued for best TCP performance
- The peer data stream is started by a handshake and followed by a continuous stream of data transfers
- The first chunk of bytes is the header
- Next comes the 20 byte hash of the info value from the metainfo file i.e. the info_hash
- Then comes the 20 byte peer id
- At this point handshake is finished and an alternating stream of length prefixes and messages continue flowing
- Peer messages start with a byte that specifies their type as follows:

  - 0: choke
  - 1: unchoke
  - 2: interested
  - 3: not interested
  - 4: have
  - 5: bitfield
  - 6: request
  - 7: piece
  - 8: cancel

choke, unchoke, interested and not interested have no payload.
The 'have' message has a number as its payload which is the index of the piece the downloader has just completed.
Cancel messages are sent when the download is completed.

================================
Distributed Characteristics
================================

- Support for resource sharing

  - Trackers are used to make sure that resources are shared among as many peers as possible

- Openness

  - The specification is open for implementation.
  - No restriction to any particular platform whatsover. There are implementations for various platforms.

- Concurrency

  - Each peer is both a client and server
  - Many processes interact to achieve the job

- Scalability

  - Peers are added or removed seamlessly without affecting the reliability of the system.
  - New trackers can be added and old one can disappear without much effect to the whole system.

- Fault Tolerance
 
  - When peers appear or disappear at random, the system is not affected significantly as long as there is at least one seeder.
  - One or more trackers should always exist to propogate peers information.
  - If number of seeders goes to zero, peers keep sharing the portions of the files that they have. This might mean that the file(s) might be incomplete. As soon as a seeder re-appears all peers can catch up and get the whole file(s).
  - There are implementations in which there is no need for trackers.

- Transparency

  - All details are hidden from the end users.
  - It looks much like a normal client-server download manager

=============
Advantages
=============

- Economical: Almost no maintenance cost is involved
- It is very efficient since every participant is a content provider. No dependency on a single party.
- Highly extensible: peers join and leave with almost no effect on the content with the exception that there always should be at least one seeder.
- It is reliable: As long as there is one seeder (and more peers), it is guaranteed that the system works well.
- It gives flexibility: The work is evenly distributed among peers.

==============
Disadvantages
==============

- If there is no seeder, for some content the peers may end up exchanging only part of the whole content.
- Peers are loosely dependent on one another for bandwidth.
- Designed for public file sharing and hence not the best option for private sharing
- Copyright infringment concerns: it is hard to control whether the shared resources for copyright infringement.

References
-------------------
- BitTorrent Official specification: http://www.bittorrent.org/beps/bep_0003.html
- Wikipedia entry: http://en.wikipedia.org/wiki/BitTorrent
- The Pirate Bay, a BitTorrent distribution server: http://thepiratebay.sx/
- An example of list of trackers: http://tech.thaweesha.com/2013/02/torrent-tracker-list-2013.html 
