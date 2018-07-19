namespace BettingParlor_Refactor
{
    /// <summary>
    /// Base class for are players in the application.
    /// Contains a skeleton of methods for derived classes to implement them correctly.
    /// </summary>
    abstract class User
    {
        /// <summary>
        /// Name of the player.
        /// </summary>
        protected string name;

        /// <summary>
        /// Amount of cash which player has.
        /// </summary>
        protected decimal cash;

        /// <summary>
        /// Stores currently placed bet.
        /// </summary>
        /// <remarks>
        /// Can contain one of three types of bets.
        /// <see cref="BetStandard"/>,<see cref="BetHandicap"/>,<see cref="BetDummy"/>
        /// </remarks>
        protected IBetSort betSort;

        /// <summary>
        /// Returns the name of the player.
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Returns the amount of cash which player has.
        /// </summary>
        public decimal Cash => cash;

        /// <summary>
        /// Factory responsible for creating <see cref="Bet"/> derivatives.
        /// </summary>
        /// <remarks>
        /// Creates specific kind of bet whenever user decides to place a bet.
        /// </remarks>
        protected BetFactory betFactory = new BetFactory();

        /// <summary>
        /// Collects the winning after the race has finished.
        /// </summary>
        /// <param name="dogWinner">Number of dog which won the race.</param>
        /// <remarks>
        /// Function is implemented differently in <see cref="Bettor"/> and <see cref="Parlor"/> class to suit their needs.
        /// </remarks>
        public virtual void CollectBet(int dogWinner)
        {
        }

        /// <summary>
        /// Creates new bet object by the use of <see cref="BetFactory"/>.
        /// </summary>
        /// <param name="betSort">Enum type which specifies what sort of bet should be placed.</param>
        /// <param name="betValue">Amount of cash which is placed.</param>
        /// <param name="dogToWin">Dog number on which the bet should be placed.</param>]
        /// <remarks>
        /// Function is implemented differently in <see cref="Bettor"/> and <see cref="Parlor"/> class to suit their needs.
        /// </remarks>
        public virtual void PlaceBet(BetFactory.BetSort betSort, decimal betValue, int dogToWin)
        { 
        }

        /// <summary>
        /// Adds cash to player account stored in application and in database.
        /// </summary>
        /// <param name="moneyTransfer">Amount of cash which is transfered.</param>
        /// <remarks>
        /// Function is implemented differently in <see cref="Bettor"/> and <see cref="Parlor"/> class to suit their needs.
        /// </remarks>
        public virtual void AddCashToMyAccount(decimal moneyTransfer)
        {
        }

        /// <summary>
        /// Clears bet object by overriding it with bet instance of <see cref="BetDummy"/> class.
        /// </summary>
        /// <remarks>
        /// <see cref="BetDummy"/> class ensures that object is overriden and garbage collected.
        /// <see cref="BetDummy"/> also provides safe implementation of <see cref="IBetSort"/>.
        /// </remarks>
        public void ClearBet()
        {
            betSort = betFactory.CreateBet(BetFactory.BetSort.dummyBet, 0, 0); 
        }

        /// <summary>
        /// Initializes the fields properly.
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <param name="cash">Amount of cash user has.</param>
        /// <remarks>
        /// Used to force on derived classes implementation of the constructor.
        /// </remarks>
        public User(string name,decimal cash)
        {
            this.name = name;
            this.cash = cash;
        }
    }
}
