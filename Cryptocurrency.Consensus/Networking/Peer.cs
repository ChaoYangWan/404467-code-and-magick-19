
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
        private CancellationTokenSource cancellationToken;

        public Peer()
        {
            this.cancellationToken = new CancellationTokenSource();
            this.tasks = new Dictionary<string, TaskCompletionSource<PeerMessage>>();
        }

        public Peer(string connection) : this()
        {
            // connection should be in form of [host]:[port]
            string[] connectionSplit = connection.Split(':');

            string
                host = connectionSplit[0],
                port = connectionSplit[1];

            this.Tcp = new TcpClient(host, int.Parse(port));
            this.TcpStreamHandler();
        }

        public Peer(TcpClient client) : this()
        {
            this.Tcp = client;
            this.TcpStreamHandler();
        }

        private void TcpStreamHandler() => Task.Run(() =>
        {
            while (!this.cancellationToken.IsCancellationRequested)
            {
                if (!this.Tcp.Connected)
                    break;

                NetworkStream stream = this.Tcp.GetStream();

                while (!this.cancellationToken.IsCancellationRequested)
                {
                    if (!this.Tcp.Connected)
                        break;

                    if (!stream.DataAvailable)
                    {
                        Task.Delay(100).Wait();
                        continue;
                    }

                    PeerMessage msg = ProtoBuf.Serializer.DeserializeWithLengthPrefix<PeerMessage>(stream, ProtoBuf.PrefixStyle.Base128);

                    TaskCompletionSource<PeerMessage> waitingTask;
                    if (this.tasks.TryGetValue(msg.Id, out waitingTask))
                    {
                        // Is a result message returned from another peer

                        this.tasks.Remove(msg.Id);
                        waitingTask.SetResult(msg);
                    } else
                    {
                        // Is a request message from another peer

                        MethodInfo messageMethod = typeof(Peer).GetMethod(msg.Message, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        Type messageMethodArgType = messageMethod.GetParameters().FirstOrDefault()?.ParameterType;

                        object result;
                        if (messageMethodArgType != null)
                        {
                            object arg = ProtoBuf.Serializer.Deserialize(messageMethodArgType, msg.DataStream);

                            result = messageMethod.Invoke(this, new object[] { arg });
                        } else
                        {
                            result = messageMethod.Invoke(this, null);
                        }
                            