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
            EcdsaKeyPair keyPair = new EcdsaKeyPa