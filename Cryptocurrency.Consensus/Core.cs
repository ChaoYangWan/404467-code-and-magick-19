using Cryptocurrency.Consensus.Networking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Consensus
{
    public class Core
    {
        internal Peer2PeerServer P2PServer { get; private set; }

        public Core()
    