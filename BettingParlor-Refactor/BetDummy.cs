namespace BettingParlor_Refactor
{
     /// <summary>
     /// Extension of the <see cref="Bet"/> class.
     /// Fake bet used when player does not place bet or all bets are reset after the race.
     /// </summary>
     /// <seealso cref="BetStandard"/>
     /// <seealso cref="BetHandicap"/>
    class BetDummy:Bet
    {
        /// <summary>
        /// Method always returns 0.
        /// Used when player has not placed a bet or bets are reset after the race has finished.
        /// </summary>
        /// <param name="winner">Number of dog which won the race.</param>
        /// <returns>Always 0 to not affect current account balance.</returns>
        /// <remarks>Method ensures that player cash will not change if he has not placed a bet in current race.</remarks>
        public override decimal PayOutTheAmountWon(int winner)
        {
            return 0;
        }
    }
}
