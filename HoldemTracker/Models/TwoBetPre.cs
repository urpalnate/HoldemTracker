using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class TwoBetPre : State
    {
        public TwoBetPre(Manager m) : base(m)
        {

        }

        public override void Fold(Player player)
        {
            if (player.LastAction == Actions.CALLED)
            {
                player.FoldAsCallerOpps++;
                player.FoldAsCallerTicker++;

                player.ReRaiseAsCallerOpps++;
            }
            player.TotalAction++;
            player.ThreeBetOpps++;
            base.Fold(player);
        }

        public override void Call(Player player)
        {
            if (player.LastAction == Actions.CALLED)
            {
                player.FoldAsCallerOpps++;
                player.ReRaiseAsCallerOpps++;
            }
            player.TotalAction++;
            player.VPIPCounter++;

            player.ThreeBetOpps++;
            base.Call(player);
            if (!HasAction()) manager.State = manager.RaisedFlop;
        }

        public override void Raise(Player player)
        {
            if (player.LastAction == Actions.CALLED)
            {
                player.ReRaiseAsCallerCounter++;
                player.ReRaiseAsCallerOpps++;
            }
            player.ThreeBetCounter++;
            player.ThreeBetOpps++;

            player.VPIPCounter++;
            player.TotalAction++;
            base.Raise(player);
        }
    }
}