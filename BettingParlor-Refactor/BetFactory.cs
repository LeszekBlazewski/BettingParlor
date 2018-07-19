namespace BettingParlor_Refactor
{
    /// <summary>
    /// Factory class.
    /// Returns a new instance of <c>Bet</c> derivatives.
    /// </summary>
    public class BetFactory
    {
        /// <summary>
        /// Enum type used by BetFactory to clearly specifiy what sort of Bet instance should be returned.
        /// </summary>
        public enum BetSort
        {
            /// <summary>
            /// Specifies bet which fields are always equal to 0.
            /// </summary>
            /// <remarks> Method <see cref="BetDummy.PayOutTheAmountWon(int)"/> always return 0.
            /// Used to clear bets after race and initialize bet field stored in <see cref="Bettor"/> and <see cref="Parlor"/> with default value.</remarks>
            dummyBet,

            /// <summary>
            /// Specifies standard bet.
            /// </summary>
            /// <remarks>
            /// Method <see cref="BetStandard.PayOutTheAmountWon(int)"/> returns double of the amount which was placed.</remarks>
            standartBet,

            /// <summary>
            /// Specifies handicap bet.
            /// </summary>
            /// <remarks> Method <see cref="BetHandicap.PayOutTheAmountWon(int)"/> returns the amount which was placed multiplied by 3 and divided by 2.</remarks>
            handicapBet
        }
        /// <summary>
        /// Takes 3 arguments: <paramref name="betSort"/>, <paramref name="amount"/>, <paramref name="dogToWin"/> and in switch statement base on <paramref name="betSort"/> decides
        /// which bet instance should be created.
        /// </summary>
        /// <param name="betSort"> Enum type which specifies what sort of bet should be returned.</param>
        /// <param name="amount"> Amount of the bet.</param>
        /// <param name="dogToWin"> Dog number on which the bet has been placed.</param>
        /// <seealso cref="BetSort"/>
        /// <returns> New bet instance with initialized fields.</returns>
        public virtual IBetSort CreateBet(BetSort betSort, decimal amount, int dogToWin)
        {
            IBetSort bet = null;
            switch (betSort)
            {
                case BetSort.dummyBet:
                    bet = new BetDummy();       
                        break;
                case BetSort.standartBet:
                    bet = new BetStandard(amount, dogToWin);
                    break;
                case BetSort.handicapBet:
                    bet = new BetHandicap(amount, dogToWin);
                    break;
            }
            return bet;
        }
    }
}
