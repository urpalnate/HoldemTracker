using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class Turn : State
    {
        public Turn(Manager m) : base(m) { }

        public override void Fold(Player player)
        {
            if (manager.CBetter &&
                manager.Raiser != player &&
                manager.Raiser.Action == Actions.BET)
            {
                player.FoldToDoubleBarrelOpps++;
                player.FoldToDoubleBarrelCounter++;
            }
            base.Fold(player);
        }

        public override void Check(Player player)
        {
            if (manager.CBetter && manager.Raiser == player)
            {
                player.DoubleBarrelOpps++;
            }
            base.Check(player);
            if (!HasAction()) manager.State = manager.River;
        }

        public override void Call(Player player)
        {
            base.Call(player);
            if (!HasAction()) manager.State = manager.River;
        }

        public override void Bet(Player player)
        {
            if (manager.CBetter && manager.Raiser == player)
            {
                player.DoubleBarrelOpps++;
                player.DoubleBarrelCounter++;
                manager.DoubleBetter = true;
            }
            base.Bet(player);
        }

        public override void Raise(Player player)
        {
            base.Raise(player);
        }
    }
}