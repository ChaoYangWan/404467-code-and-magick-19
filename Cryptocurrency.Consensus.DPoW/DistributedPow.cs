using System;

namespace Cryptocurrency.Consensus.DPoW
{
    public class DistributedPow
    {
        /*

         The concept is each node in the network accepts ownership of a parcel (like pass the parcel) one at a time and they have to unravel one layer
         In order to unravel a layer, it must do a quick and easy PoW puzzle. Once it solves the puzzle, it broadcasts the new parcel to the network for the next node
         randomly, a node will accept a parcel and unwrap it completely. Thus mining a block.
         The node that co