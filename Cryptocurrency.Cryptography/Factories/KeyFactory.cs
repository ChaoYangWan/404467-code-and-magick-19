using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Cryptography.Factories
{
    public static class KeyFactory
    {
        public static ECPrivateKeyParameters ECPrivateKeyParamsFromPrivateKey(PrivateKey pk, ECDo