namespace BettingParlor_Refactor
{
     /// <summary>
     /// Extension of the <see cref="Bet"/> class.
     /// Special type of bet used when player places handicap bet.
     /// </summary>
     /// <remarks>
     /// <para> This class defines the method included in <see cref="IBetSort"/>.</para>
     /// </remarks>
     /// <seealso cref="BetStandard"/>
     /// <seealso cref="BetDummy"/>
    class BetHandicap:Bet
    {
        /// <summary>
        /// Takes two parameters <paramref name="amount"/> and <paramref name="dogToWin"/> and initializes the fields properly.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"> Thrown when null is passed.
        /// </exception>
        /// <param name="amount"> Amount of the bet.</param>
        /// <param name="dogToWin"> Dog number on which the bet has been placed.</param>
        public BetHandicap(decimal amount, int dogToWin)
        {
            this.amount = amount;
            this.dogToWin = dogToWin;
        }
        /// <summary>
        /// Checks if dog number who won the game-<paramref name="winner"/> is equal to dog number which is stored in object.
        /// If so the amount multiplied by 3 and divided by 2 is returned. Otherwise Bettor has made a bad guess and 0 is returned (he lost his cash).
        /// </summary>
        /// <param name="winner">Number of the dog which has won the race.</param>
        /// <returns>The amount wich was bet multiplied by 3 and divided by 2 or 0 if dog number was not equal to the dog number - <paramref name="winner"/>which won the race.</returns>
        public override decimal PayOutTheAmountWon(int winner)
        {
            if (winner == dogToWin)
                return (amount * 3)/2;    
            else
                return 0;
        }
    }
}
