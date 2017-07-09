using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoldemTracker.Models
{
    public class Manager
    {
        public List<Player> Players { get; set; }
        public List<Player> TrackedPlayers { get; set; }
        public State NoRaisePre;
        public State TwoBetPre;
        public State ThreeBetPre;
        public State FourBetPre;
        public State RaisedFlop;
        public State NoRaiseFlop;
        public State Turn;
        public State River;

        public State State { get; set; }
        // TODO: This is only necessary for sit-n-go format
  
        public int ActivePlayers { get; set; }

        public Player Raiser { get; set; }

        public Player ColdCaller { get; set; }

        public bool CBetter { get; set; }
        public bool DoubleBetter { get; set; }

        public Manager(int p)
        {
            Players = new List<Player>();
            TrackedPlayers = new List<Player>();
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
            foreach (Player p in TrackedPlayers)
            {
                p.Action = Actions.HASACTION;
                p.Position--;
                if (p.Position < 0)
                {
                    p.Position = Players.Count - 1;
                }
            }
            TrackedPlayers.Sort((x, y) => x.Position.CompareTo(y.Position));

            ActivePlayers = TrackedPlayers.Count;
            State = NoRaisePre;
            Raiser = null;
            ColdCaller = null;
            CBetter = false;
            DoubleBetter = false;
        }

        public void Delete(Player player)
        {
            Players.Remove(player);
            TrackedPlayers.Remove(player);
            var playersToShift = TrackedPlayers.FindAll(p => p.Position > player.Position);
            foreach (Player p in playersToShift)
            {
                p.Position--;
            }

            TrackedPlayers.Sort((x, y) => x.Position.CompareTo(y.Position));
        }

        void Remove(Player player)
        {
            TrackedPlayers.Remove(player);
            var playersToShift = TrackedPlayers.FindAll(p => p.Position > player.Position);
            foreach (Player p in playersToShift)
            {
                p.Position--;
            }

            TrackedPlayers.Sort((x, y) => x.Position.CompareTo(y.Position));
        }

        public void Add(Player player)
        {
            foreach (Player p in Players)
            {
                if (player.Id == p.Id)
                {
                    Import(player);
                    return;
                }
            }
            Players.Add(player);
            TrackedPlayers.Add(player);
            var playersToShift = TrackedPlayers.FindAll(p => p.Position >= player.Position);
            foreach (Player p in playersToShift)
            {
                p.Position++;
            }
            TrackedPlayers.Sort((x, y) => x.Position.CompareTo(y.Position));
        }

        void Import(Player player)
        {
            TrackedPlayers.Add(player);
            var playersToShift = TrackedPlayers.FindAll(p => p.Position >= player.Position);
            foreach (Player p in playersToShift)
            {
                p.Position++;
            }
            TrackedPlayers.Sort((x, y) => x.Position.CompareTo(y.Position));
        }
    }
}