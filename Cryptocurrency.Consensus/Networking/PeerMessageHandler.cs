using Cryptocurrency.Blockchain;
using Cryptocurrency.Database.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency.Consensus.Networking
{
    public partial class Peer
    {
        public void SubmitTransactions(params Transaction[] transactions)
        {
            this.SubmitMessage(
              