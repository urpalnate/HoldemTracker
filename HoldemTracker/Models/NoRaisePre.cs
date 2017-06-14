using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class NoRaisePre : State
    {
        public NoRaisePre(Manager m) : base(m)
        {

        }

        public override void Fold(Player player)
        {
            player.TotalAction++;
            player.TwoBetOpps++;
            base.Fold(player);
        }

        public override void Check(Player player)
        {

            player.TwoBetOpps++;
            base.Check(player);
            manager.State = manager.NoRaiseFlop;
        }

        public override void Call(Player player)
        {
            player.TotalAction++;
            player.VPIPCounter++;

            player.TwoBetOpps++;
            base.Call(player);
            if (!HasAction())
            {
                if (manager.Raiser != null)
                {
                    manager.State = manager.RaisedFlop;
                }
                else manager.State = manager.NoRaiseFlop;
            }
        }

        public override void Raise(Player player)
        {
            //move to 2 bet pre
            player.VPIPCounter++;
            player.TotalAction++;

            player.TwoBetCounter++;
            player.TwoBetOpps++;

            player.Action = Actions.TWOBET;
            base.Raise(player);
            manager.State = manager.TwoBetPre;
        }
    }
}