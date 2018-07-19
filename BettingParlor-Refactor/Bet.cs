namespace BettingParlor_Refactor
{
    /// <summary>
    ///  Contains definition for all kinds of bets in project.
    /// </summary>
    /// <remarks>
    /// Class is a base for all Bet-related classes in the project.</remarks>
    /// <seealso cref="BetDummy"/>
    /// <seealso cref="BetHandicap"/>
    /// <seealso cref="BetStandard"/>
    abstract class Bet : IBetSort
    {
        /// <summary>
        /// Stores the amount of cash which was bet by user.
        /// </summary>
        protected decimal amount;

        /// <summary>
        /// Stores the dog number on which bet has been placed.
        /// </summary>
        protected int dogToWin;

        /// <summary>
        /// Abstract implementation of interface <see cref="IBetSort"/> to force derived classes
        /// to implement the body of the interface method.
        /// </summary>
        /// <returns>
        /// Amount which was won.
        /// </returns>
        /// <remarks>
        /// Returns the amount which was won.
        /// </remarks>
        /// <param name="winner">Number of the dog which has won the race.</param>
        /// <see cref="IBetSort"/>
        public abstract decimal PayOutTheAmountWon(int winner);
    }
}

