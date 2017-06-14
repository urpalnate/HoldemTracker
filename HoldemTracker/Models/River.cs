using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class River : State
    {
        public River(Manager m) : base(m)
        {

        }

        public override void Fold(Player player)
        {
            base.Fold(player);
        }

        public override void Check(Player player)
        {
            base.Check(player);
            if (!HasAction()) manager.NextRound();

        }

        public override void Call(Player player)
        {
            base.Call(player);
            if (!HasAction()) manager.NextRound();
        }

        public override void Bet(Player player)
        {
            if (manager.DoubleBetter && manager.Raiser == player)
            {
                player.TripleBarrelOpps++;
                player.TripleBarrelCounter++;
            }
            base.Bet(player);
        }

        public override void Raise(Player player)
        {
            base.Raise(player);
        }


    }
}