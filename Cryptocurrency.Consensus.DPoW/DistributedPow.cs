using System;

namespace Cryptocurrency.Consensus.DPoW
{
    public class DistributedPow
    {
        /*

         The concept is each node in the network accepts ownership of a parcel (like pass the parcel) one at a time and they have to unravel one layer
         In order to unravel a layer, it must do a quick and easy PoW puzzle. Once it solves the puzzle, it broadcasts the new parcel to the network for the next node
         randomly, a node will accept a parcel and unwrap it completely. Thus mining a block.
         The node that completely unwraps a parcel determines how many layers the next parcel has as part of the "mining difficulty"

         Problems:
         How to pass the parcel without storing it on the blockchain?
             Let's say the last node to mine a block or unwrap a layer of the parcel goes offline before it broadcasts it to the next node
                 A: T