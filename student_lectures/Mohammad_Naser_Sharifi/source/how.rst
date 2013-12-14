How It Works
================
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

Piece Selection Policy
--------------------------
If pieces are not selected in a well-thought way, all peers may endup having downloaded the same pieces but some (of the more difficult pieces) may be missing. If the seeder disappears preamturely, all peers may end up with incomplete files.
To solve this issue, one or more of the following policies are used:

- Random First Piece Selection

  - Initially the peer has no pieces.
  - Select a first piece and downoad it as soon as possibly.
  - Select a random piece of the file and download it.

- Rarest Piece First

  - Determine the piecest that are not found or are rare among the peers and download those first.
  - This ensures that the common pieces are left towards the end to be downloaded.

Create and Share Torrent Files
---------------------------------
When a user wants to share a file, they would create a torrent file (Torrent files are identified by .torrent extension) using the client application.
The torrent file wraps around information such as the specifi file(s) to be shared, location of the file(s) on the seed machine, etc.
The torrent file is then shared with other peers.
The original uploader is known as seed/seeder and others who start downloading from seeder are known as peers or leechers.
