using Cryptocurrency.Blockchain;
using Cryptocurrency.Consensus.Networking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Cryptocurrency.Consensus.Tests
{
    [TestClass]
    public class Peer2PeerServerTests
    {
        Peer2PeerServer server;

        [TestInitialize]
        public void Init()
        {
            this.server = new Peer2PeerServer();
            this.server.Start();
        }

        [TestMethod]
        public async Task TestRequestBlocks()
        {
   