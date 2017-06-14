using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public abstract class State
    {
        public Manager manager;
        public State(Manager m)
        {
            manager = m;
        }
        public virtual void Fold(Player player)
        {
            if (player.LastAction == Actions.CHECKED)
            {
                player.CheckRaiseOpps++;
            }
            player.LastAction = player.Action;
            player.Action = Actions.FOLDED;
            manager.ActivePlayers--;
            if (manager.ActivePlayers <= 1) manager.NextRound();
        }
        public virtual void Check(Player player)
        {
            player.AggroOpps++;
            player.LastAction = player.Action;
            player.Action = Actions.CHECKED;
        }
        public virtual void Call(Player player)
        {
            if (player.LastAction == Actions.CHECKED)
            {
                player.CheckRaiseOpps++;
            }
            player.AggroOpps++;
            player.LastAction = player.Action;
            player.Action = Actions.CALLED;
        }
        public virtual void Raise(Player player)
        {
            if (player.LastAction == Actions.CHECKED)
            {
                player.CheckRaiseOpps++;
                player.CheckRaiseCounter++;
            }
            player.AggroOpps++;
            player.AggroAction++;

            player.LastAction = player.Action;
            manager.Raiser = player;
        }
        public virtual void Bet(Player player)
        {
            player.AggroOpps++;
            player.AggroAction++;
            player.LastAction = player.Action;
            player.Action = Actions.BET;
        }

        public bool HasAction()
        {
            foreach (Player p in manager.Players)
            {
                if (p.Action == Actions.HASACTION)
                {
                    return false;
                }
            }
            return true;
        }
    }
}