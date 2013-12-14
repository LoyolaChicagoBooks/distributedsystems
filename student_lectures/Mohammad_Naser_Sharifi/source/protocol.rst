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
