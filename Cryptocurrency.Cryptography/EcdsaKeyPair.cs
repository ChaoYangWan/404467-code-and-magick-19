﻿using Cryptocurrency.Cryptography.Factories;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Cryptography
{
    public class EcdsaKeyPair
    {
        public static ECDomainParameters Domain = SignerFactory.Sha256EcdsaDomain;
        private static SecureRandom SecureRand = new SecureRandom();

        public PrivateKey Private { get; private set;