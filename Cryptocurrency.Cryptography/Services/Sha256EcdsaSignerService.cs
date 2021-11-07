using Cryptocurrency.Cryptography.Factories;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Cryptography.Services
{
    public static class Sha256EcdsaSignerService
    {
        public static byte[] SignData(PrivateKey privateKey, string data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            return SignData(privateKey, dataBytes);
        }

        public static byte[] SignData(PrivateKey pk, byte[] data)
        {
            ECPrivateKeyParameters privateKeyParams = KeyFactory.ECPrivateKeyParamsFromPrivateKey(pk, SignerFactory.Sha256EcdsaDomain);

            ISigner signer = SignerFactory.Sha256withECDSA();
            signer.Init(true, privateKeyParams