namespace BettingParlor_Refactor
{
    /// <summary>
    /// Contains one method used to pay out the amount which was won by sepcific player.
    /// </summary>
    /// <remarks>Implemented by <see cref="Bet"/> class to force implementation on derived classes.
    /// Interface allows storing multiple Bets in one object which is overriden each time new bet is placed.</remarks>
    public interface IBetSort
    {
        /// <summary>
        /// This function is used by bets to pay out amount wich was won by certain player.
        /// </summary>
        /// <param name="winner"> number of dog which won the game.</param>
        /// <returns> Amount of cash which was won by specific player.</returns>
        decimal PayOutTheAmountWon(int winner);
    }
}
