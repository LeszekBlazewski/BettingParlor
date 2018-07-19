namespace BettingParlor_Refactor
{
    /// <summary>
    /// Extension of the <see cref="Bet"/> class.
    /// Special type of bet used when player places standard bet.
    /// </summary>
    /// <remarks>
    /// <para> This class defines the body of IBetSort <see cref="IBetSort"/> interface.</para>
    /// </remarks>
    /// <seealso cref="BetDummy"/>
    /// <seealso cref="BetHandicap"/>
    class BetStandard :Bet
    {
        /// <summary>
        /// Returns the amount which is currently stored in <see cref="Bet.amount"/> field.
        /// </summary>
        public decimal GetAmount => amount;

        /// <summary>
        /// Takes two parameters <paramref name="amount"/> and <paramref name="dogToWin"/> and initializes the fields properly.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"> Thrown when null is passed.
        /// </exception>
        /// <param name="amount"> Amount of the bet.</param>
        /// <param name="dogToWin"> Dog number on which the bet has been placed.</param>
        public BetStandard(decimal amount, int dogToWin)
        {
            this.amount = amount;
            this.dogToWin = dogToWin;
        }

        /// <summary>
        /// Checks whether the dog number who won the game - <paramref name="winner"/> is equal to dog number which is stored in object.
        /// If yes the amount multiplied by 2 is returned. Otherwise Bettor has made a bad guess and 0 is returned (he lost his cash).
        /// </summary>
        /// <param name="winner">Number of the dog which has won the race.</param>
        /// <returns>The amount wich was bet multiplied by 2 or 0 if dog number was not equal to the dog number - <paramref name="winner"/>which won the race.</returns>
        public override decimal PayOutTheAmountWon(int winner)
        {
            if (winner == dogToWin)         
                return (2 * amount);      
            else
                return 0;
        }
    }
}
