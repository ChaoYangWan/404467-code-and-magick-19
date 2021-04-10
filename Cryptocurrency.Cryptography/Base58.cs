
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Cryptography
{
    public static class Base58
    {
        const string b58 = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        const string leadingZeroCharacter = "c";

        public static string ToBase58String(byte[] data)
        {
            Org.BouncyCastle.Math.BigInteger toConvertToBase58 = new Org.BouncyCastle.Math.BigInteger(1, data);

            Org.BouncyCastle.Math.BigInteger big0 = new Org.BouncyCastle.Math.BigInteger("0");
            Org.BouncyCastle.Math.BigInteger big58 = new Org.BouncyCastle.Math.BigInteger("58");

            StringBuilder base58Builder = new StringBuilder();

            while (toConvertToBase58.CompareTo(big0) > 0)
            {
                int d = Convert.ToInt32(toConvertToBase58.Mod(big58).ToString());
                toConvertToBase58 = toConvertToBase58.Divide(big58);

                base58Builder.Insert(0, b58.Substring(d, 1));
            }

            // handle leading zeroes
            foreach (byte b in data)
            {
                if (b != 0) break;

                base58Builder.Insert(0, leadingZeroCharacter);
            }

            return base58Builder.ToString();
        }

        public static byte[] FromBase58String(string base58)
        {
            Org.BouncyCastle.Math.BigInteger bi2 = new Org.BouncyCastle.Math.BigInteger("0");

            foreach (char c in base58)
            {
                if (b58.IndexOf(c) != -1)