
﻿using Cryptocurrency.Blockchain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cryptocurrency.Consensus.Networking
{
    public delegate TEventResult EventHandlerWithResult<TEventArgs, TEventResult>(object sender, TEventArgs e);

    public partial class Peer
    {
        public TcpClient Tcp { get; private set; }

        private Dictionary<string, TaskCompletionSource<PeerMessage>> tasks;