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
                 A: The node which sent the parcel waits for a confirmation reply that can only occur after the parcel has been actioned by the next node.
                 If the confirmation never comes back, the original sending node tries another node

         How to make it so the concensus algorithm doesn't require an "entry point"
             A: Similar to how bitcoin works, it's a race to see which parcel can get unravelled 