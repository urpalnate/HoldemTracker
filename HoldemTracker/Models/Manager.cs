using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class Manager
    {
        public List<Player> Players = new List<Player>();
        public State NoRaisePre;
        public State TwoBetPre;
        public State ThreeBetPre;
        public State FourBetPre;
        public State RaisedFlop;
        public State NoRaiseFlop;
        public State Turn;
        public State River;

        public State State { get; set; }
        //Might only use this when I call the constructor
        public int NumPlayers { get; set; }

        public int ActivePlayers { get; set; }

        public Player Raiser { get; set; }

        public Player ColdCaller { get; set; }

        public bool CBetter { get; set; } = false;
        public bool DoubleBetter { get; set; } = false;

        public Manager(int p)
        {
            NumPlayers = p;
            ActivePlayers = NumPlayers;
            NoRaisePre = new NoRaisePre(this);
            State = NoRaisePre;
            TwoBetPre = new TwoBetPre(this);
            ThreeBetPre = new ThreeBetPre(this);
            FourBetPre = new FourBetPre(this);
            RaisedFlop = new RaisedFlop(this);
            NoRaiseFlop = new NoRaiseFlop(this);
            Turn = new Turn(this);
            River = new River(this);
        }

        public void Fold(Player player)
        {
            State.Fold(player);
        }

        public void Check(Player player)
        {
            State.Check(player);
        }

        public void Call(Player player)
        {
            State.Call(player);
        }

        public void Raise(Player player)
        {
            State.Raise(player);
        }

        public void NextRound()
        {
            foreach (Player p in Players)
            {
                p.Action = Actions.HASACTION;
                p.Position--;
                if (p.Position < 0)
                {
                    p.Position = Players.Count - 1;
                }
            }
            Players.Sort((x, y) => x.Position.CompareTo(y.Position));

            ActivePlayers = Players.Count;
            State = NoRaisePre;
            Raiser = null;
            ColdCaller = null;
            CBetter = false;
            DoubleBetter = false;
        }

        public void Delete(Player player)
        {
            Players.Remove(player);
            var playersToShift = Players.FindAll(p => p.Position > player.Position);
            foreach (Player p in playersToShift)
            {
                p.Position--;
            }

            Players.Sort((x, y) => x.Position.CompareTo(y.Position));
        }
    }
}