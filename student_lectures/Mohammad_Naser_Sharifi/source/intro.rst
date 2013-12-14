Introduction
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

