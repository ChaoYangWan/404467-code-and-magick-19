
﻿using Cryptocurrency.Cryptography;
using Cryptocurrency.Cryptography.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Cryptocurrency.Blockchain
{
    [DataContract]
    public class Transaction : BlockchainObject
    {
        private string hash;

        [DataMember(Order = 1)]
        public string Hash
        {
            get
            {
                if (!String.IsNullOrEmpty(this.hash))
                    return this.hash;

                return this.ComputeHash();
            }
            set
            {
                this.hash = value;
            }