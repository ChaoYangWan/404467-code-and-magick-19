using System;

namespace Cryptocurrency.Consensus.DPoW
{
    public class DistributedPow
    {
        /*

         The concept is each node in the network accepts ownership of a parcel (like pass the parcel) one at a time and they have to unravel one layer
         In order to unravel a layer, it must do a quick and easy PoW puzzle. Once it solves t