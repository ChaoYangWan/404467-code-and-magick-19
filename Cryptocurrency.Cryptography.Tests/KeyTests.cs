using Cryptocurrency.Cryptography.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Cryptography.Tests
{
    [TestClass]
    public class KeyTests
    {
        [TestMethod]
        public void NewKey()
        {
            EcdsaKeyPair keyPair = new EcdsaKeyPair();

            Assert.AreNotEqual(new byte[] { }, keyPair.Private);
            Assert.IsTrue(!String.IsNullOrEmpty(keyPair.Private.ToString()));

            string publicKey = keyPair.Public.ToString();
            string publicKeyFromFactoryMethod = ((PublicKey)KeyFactory.ECPublicKeyParamsFromPublicKey(keyPair.Public, EcdsaKeyPair.Domain).Q.GetEncoded()).ToString();

            Assert.AreEqual(publicKey, publicKeyFromFactoryMethod);

            string privateKey = keyPair.Private.ToString();
            string privateKeyFrom