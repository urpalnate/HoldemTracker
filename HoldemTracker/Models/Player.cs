using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoldemTracker.Models
{
    public class Player
    {
        public Actions Action { get; set; } = Actions.HASACTION;
        public Actions LastAction { get; set; }

        public Player(int id, bool me)
        {
            Id = id; Me = me;
        }

        public int Id
        {
            get;
            set;
        }

        public int Position
        {
            get;
            set;
        }
        public bool Me
        {
            get;
            set;
        }

        //PRE-FLOP STATS
        public int VPIPCounter
        {
            get;
            set;
        }
        public int TotalAction
        {
            get; set;
        }

        public double VPIPPercentage
        {
            get
            {
                return (VPIPCounter / TotalAction) * 100;
            }
        }

        public int ReRaiseAsCallerOpps
        { get; set; }
        public int ReRaiseAsCallerCounter
        { get; set; }
        public double ReRaiseAsCallerPercent
        {
            get
            {
                return (ReRaiseAsCallerCounter / ReRaiseAsCallerOpps) * 100;
            }
        }

        public int ColdCallOpps
        { get; set; }
        public int ColdCallCounter
        { get; set; }
        public double ColdCallPercent
        {
            get
            {
                return (ColdCallCounter / ColdCallOpps) * 100;
            }
        }

        public int TwoBetCounter
        {
            get;
            set;
        }

        public int TwoBetOpps
        {
            get;
            set;
        }

        public double TwoBetPercentage
        {
            get
            {
                return (TwoBetCounter / TwoBetOpps) * 100;
            }
        }
        public int ThreeBetCounter
        {
            get;
            set;
        }

        public int ThreeBetOpps
        {
            get;
            set;
        }
        public double ThreeBetPercentage
        {
            get
            {
                return (ThreeBetCounter / ThreeBetOpps) * 100;
            }
        }

        public int FourBetCounter
        {
            get;
            set;
        }

        public int FourBetOpps
        {
            get;
            set;
        }
        public double FourBetPercentage
        {
            get
            {
                return (FourBetCounter / FourBetOpps) * 100;
            }
        }

        public int FoldAsCallerTicker
        {
            get;
            set;
        }
        public int FoldAsCallerOpps
        {
            get;
            set;
        }

        public int FoldAsRaiserTicker
        {
            get;
            set;
        }

        public int FoldAsRaiserOpps
        {
            get;
            set;
        }
        public double FoldCaller
        {
            get
            {
                return (FoldAsCallerTicker / FoldAsCallerOpps) * 100;
            }

        }

        public double FoldRaiser
        {
            get
            {
                return (FoldAsRaiserTicker / FoldAsRaiserOpps) * 100;
            }
        }

        //POST-FLOP STATS
        public int CheckRaiseOpps
        { get; set; }
        public int CheckRaiseCounter
        { get; set; }
        public double CheckRaisePercent
        {
            get
            {
                return (CheckRaiseCounter / CheckRaiseOpps) * 100;
            }
        }

        public int AggroOpps
        {
            get;
            set;
        }
        public int AggroAction
        {
            get;
            set;
        }
        public double AggressionPercentage
        {
            get
            {
                return (AggroAction / AggroOpps) * 100;
            }
        }

        //FLOP-ONLY STATS

        public int FoldAsColdCallOpps
        { get; set; }
        public int FoldAsColdCallCounter
        { get; set; }
        public double FoldAsColdCallPercent
        {
            get
            {
                return (FoldAsColdCallCounter / FoldAsColdCallOpps) * 100;
            }
        }

        public int FoldsToContinuationCounter
        { get; set; }

        public int FoldsToContinuationOpps
        { get; set; }

        public double FoldsToContinuationPercentage
        {
            get
            {
                return (FoldsToContinuationCounter / FoldsToContinuationOpps) * 100;
            }
        }

        public int FollowThroughBets
        {
            get;
            set;
        }

        public int FollowThroughOpps
        {
            get;
            set;
        }

        public double FollowThroughPercentage
        {
            get
            {
                return (FollowThroughBets / FollowThroughOpps) * 100;
            }
        }

        public int FoldToDonkBet { get; set; }
        public int FoldToDonkBetOpp { get; set; }

        public double FoldToDonkBetPercentage
        {
            get
            {
                return (FoldToDonkBet / FoldToDonkBetOpp) * 100;
            }
        }

        public int DonkBet { get; set; }
        public int DonkBetOpp { get; set; }

        public double DonkBetPercentage
        {
            get
            {
                return (DonkBet / DonkBetOpp) * 100;
            }
        }

        //TURN-ONLY STATS
        public int DoubleBarrelOpps
        { get; set; }
        public int DoubleBarrelCounter
        { get; set; }
        public double DoubleBarrelPercent
        {
            get
            {
                return (DoubleBarrelCounter / DoubleBarrelOpps) * 100;
            }
        }

        public int FoldToDoubleBarrelOpps
        { get; set; }
        public int FoldToDoubleBarrelCounter
        { get; set; }
        public double FoldToDoubleBarrelPercent
        {
            get
            {
                return (FoldToDoubleBarrelCounter / FoldToDoubleBarrelOpps) * 100;
            }
        }

        //RIVER-ONLY STATS
        public int TripleBarrelOpps
        { get; set; }
        public int TripleBarrelCounter
        { get; set; }
        public double TripleBarrelPercent
        {
            get
            {
                return (TripleBarrelCounter / TripleBarrelOpps) * 100;
            }
        }

        public int FoldToTripleBarrelOpps
        { get; set; }
        public int FoldToTripleBarrelCounter
        { get; set; }
        public double FoldToTripleBarrelPercent
        {
            get
            {
                return (FoldToTripleBarrelCounter / FoldToTripleBarrelOpps) * 100;
            }
        }
    }
}