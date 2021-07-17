using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cryptocurrency.Cryptography
{
    public interface IKey
    {
        byte[] Data { get; }
    }

    [DataContract]
    public struct PublicKey : IKey
    {
        [DataMember(Order = 1)]
   