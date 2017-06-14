using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class ThreeBetPre : State
    {
        public ThreeBetPre(Manager m) : base(m)
        {

        }

        public override void Fold(Player player)
        {
            if (player.LastAction == Actions.CALLED)
            {
                player.ReRaiseAsCallerOpps++;
            }
            player.TotalAction++;

            player.FourBetOpps++;

            player.ColdCallOpps++;
            base.Fold(player);
        }

        public override void Call(Player player)
        {
            if (player.LastAction == Actions.CALLED)
            {
                player.ReRaiseAsCallerOpps++;
            }

            if (player.LastAction == Actions.CALLED || player.Action == Actions.HASACTION)
            {
                player.ColdCallOpps++;
                player.ColdCallCounter++;
                manager.ColdCaller = player;
            }
            player.TotalAction++;
            player.VPIPCounter++;

            player.FourBetOpps++;
            base.Call(player);
            if (!HasAction()) manager.State = manager.RaisedFlop;
        }

        public override void Raise(Player player)
        {
            if (player.LastAction == Actions.CALLED)
            {
                player.ReRaiseAsCallerOpps++;
                player.ReRaiseAsCallerCounter++;
            }

            player.ColdCallOpps++;

            player.FourBetOpps++;
            player.FourBetCounter++;

            player.Action = Actions.FOURBET;
            base.Raise(player);
        }
    }
}