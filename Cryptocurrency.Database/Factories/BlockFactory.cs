﻿using Cryptocurrency.Blockchain;
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
                uint lastBlockIndex = (uint)db.Blocks.Max(y => y.BlockIndex).AsInt32;
                Block lastBlock = db.Blocks.FindOne(y => y.BlockIndex == lastBlockIndex);

                Block newBlock = new Block
                {
                    PreviousBlockHash = lastBlock.Hash,
                    Date = DateTime.Now,
                    DifficultyMask = ChainParams.CalculateDifficultyMask(lastBlock),
                    BlockIndex = lastBlockIndex + 1
                };

                return newBlock;
            }
        }

        public static Block GenerateBlock(PublicKey minedBy)
        {
         