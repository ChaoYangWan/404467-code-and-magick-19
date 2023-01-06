using Cryptocurrency.Blockchain;
using Cryptocurrency.Cryptography;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Cryptocurrency.Database.Factories
{
    public static class BlockFactory
    {
        public static Block GenerateBlock()
        {
            using (BlockchainDatabase db = BlockchainDatabase.Create())
            {
                uint lastBlockIndex = (uint)db.Blocks.Max(y => y.BlockIndex).AsInt