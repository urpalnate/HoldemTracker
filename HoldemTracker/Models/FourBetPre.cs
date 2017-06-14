using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class FourBetPre : State
    {
        public FourBetPre(Manager m) : base(m)
        {

        }

        public override void Fold(Player player)
        {
            if (player.Action == Actions.CALLED || player.Action == Actions.HASACTION)
            {
                player.ColdCallOpps++;
            }
            player.TotalAction++;
            base.Fold(player);
        }

        public override void Call(Player player)
        {
            if (player.LastAction == Actions.CALLED || player.Action == Actions.HASACTION)
            {
                player.ColdCallOpps++;
                player.ColdCallCounter++;
                manager.ColdCaller = player;
            }
            player.TotalAction++;
            player.VPIPCounter++;
            base.Call(player);
            if (!HasAction()) manager.State = manager.RaisedFlop;
        }
    }
}