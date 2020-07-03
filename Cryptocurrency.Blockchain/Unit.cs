using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cryptocurrency.Blockchain
{
    [DataContract]
    public class Unit
    {
        [DataMember(Order = 1)]
        private byte[] ValueBytes
        {
            get
            {
                return this.Value?.ToByteArray();
            }
         