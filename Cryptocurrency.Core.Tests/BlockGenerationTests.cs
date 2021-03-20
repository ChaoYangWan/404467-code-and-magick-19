﻿using Cryptocurrency.Cryptography;
using Cryptocurrency.Database.Factories;
using Cryptocurrency.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cryptocurrency.Blockchain.Tests
{
    [TestClass]
    public class BlockGenerationTests
    {
        [TestMethod]
        public void FromGenesisPoW()
        {
            Core core = new Core();

            EcdsaKeyPair genesisWalletKp = new EcdsaKeyPair(Globals.Keys.GenesisPrivateKey);
            EcdsaKeyPair otherKp = new EcdsaKeyPair();

            Block genesis = core.GenesisBlock;

            // find nonce for nextBlock
            Regex difficultyTestRegex = new Regex(genesis.DifficultyMask);

            UInt16 testNonce = 0;
            while (true)
            {
                string mineHash = Sha256Hash.Hash(BitConverter.GetBytes(testNo