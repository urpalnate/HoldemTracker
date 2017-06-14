using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class RaisedFlop : State
    {
        public RaisedFlop(Manager m) : base(m)
        {
        }

        public override void Fold(Player player)
        {
            int raiser = manager.Players.Count(p => p.Action == Actions.TWOBET);
            if (manager.Raiser != player && manager.Raiser.Action == Actions.BET && raiser == 0)
            {
                player.FoldsToContinuationOpps++;
                player.FoldsToContinuationCounter++;

                if (manager.ColdCaller == player)
                {
                    player.FoldAsColdCallOpps++;
                    player.FoldAsColdCallCounter++;
                }
            }

            if (manager.Raiser == player && player.Action == Actions.HASACTION && raiser == 0)
            {
                player.FoldToDonkBetOpp++;
                player.FoldToDonkBet++;
            }

            base.Fold(player);
        }

        public override void Check(Player player)
        {
            if (manager.Raiser == player)
            {
                player.FollowThroughOpps++;
            }
            else player.DonkBetOpp++;

            base.Check(player);
            if (!HasAction()) manager.State = manager.Turn;
        }

        public override void Call(Player player)
        {
            if (manager.Raiser == player && player.Action == Actions.HASACTION)
            {
                player.FoldToDonkBetOpp++;
            }

            if (player.Action == Actions.HASACTION && manager.Raiser != player &&
                manager.Raiser.Action == Actions.BET)
            {
                player.FoldsToContinuationOpps++;

                if (manager.ColdCaller == player)
                {
                    player.FoldAsColdCallOpps++;
                }
            }


            base.Call(player);
            if (!HasAction()) manager.State = manager.Turn;
        }

        public override void Bet(Player player)
        {
            if (manager.ColdCaller == player)
            {
                player.FoldAsColdCallOpps++;
            }
            if (manager.Raiser == player)
            {
                player.FollowThroughOpps++;
                player.FollowThroughBets++;
                manager.CBetter = true;
            }
            if (manager.Raiser != player)
            {
                player.DonkBetOpp++;
                player.DonkBet++;
            }
            base.Bet(player);
        }

        public override void Raise(Player player)
        {
            if (manager.Raiser == player && player.Action == Actions.HASACTION)
            {
                player.FoldToDonkBetOpp++;
            }
            if (manager.ColdCaller == player)
            {
                player.FoldAsColdCallOpps++;
            }
            if (manager.Raiser != player && manager.Raiser.Action == Actions.BET)
            {
                player.FoldsToContinuationOpps++;
            }
            manager.CBetter = false;

            base.Raise(player);
        }
    }
}