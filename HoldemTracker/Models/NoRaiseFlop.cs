using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class NoRaiseFlop : State
    {
        public NoRaiseFlop(Manager m) : base(m)
        {

        }

        public override void Fold(Player player)
        {
            base.Fold(player);
        }

        public override void Check(Player player)
        {
            base.Check(player);
            if (!HasAction()) manager.State = manager.Turn;
        }

        public override void Call(Player player)
        {
            base.Call(player);
            if (!HasAction()) manager.State = manager.Turn;
        }

        public override void Bet(Player player)
        {
            base.Bet(player);
        }

        public override void Raise(Player player)
        {
            base.Raise(player);
        }
    }
}