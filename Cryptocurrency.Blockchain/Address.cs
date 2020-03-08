using Cryptocurrency.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Blockchain
{
    public struct Address
    {
        public string Hash { get; private set; }

        public static implicit operator Address (string publicKeyHash)
        {
            return 