namespace BettingParlor_Refactor
{
    /// <summary>
    /// Extension of the <see cref="User"/> class.
    /// Contains all methods for performing basic bettor operations.
    /// </summary>
    /// <remarks>
    /// <para> This class represents each client object.</para>
    /// </remarks>
    /// <seealso cref="User"/>
    class Bettor :User
    {
        /// <summary>
        /// Takes two parameters<paramref name="cash"/> and <paramref name="name"/>and passes
        /// them to class User <see cref="User"/> to initialize correct fields.
        /// </summary>
        /// <param name="name">Name of the client whos object should be created.</param>
        /// <param name="cash">Amount of cash which user with given <paramref name="name"/> has.</param>
        public Bettor(string name, decimal cash):base(name,cash)
        { 
        }

        /// <summary>
        /// Updates bettor cash after the race by using <see cref="IBetSort.PayOutTheAmountWon(int)"/> method
        /// which returns the amount of money wich specified user should obtain.
        /// </summary>
        /// <param name="dogWinner">Number of the dog which has won the race.</param>
        public override void CollectBet(int dogWinner)
        {
            cash += betSort.PayOutTheAmountWon(dogWinner);
        }

        /// <summary>
        /// Substracts money from bettor object.
        /// Checks whether standard bet has been placed, to aquire amount of the bet and use it when handicap is created.
        /// Uses betFactory, which returns new instance of <see cref="BetStandard"/> or <see cref="BetHandicap"/> and the previous instance
        /// stored of bet in class gets overriden because only one type of each bet is allowed.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when one of the parameters is null.</exception>
        /// <param name="sortOfBet">Enum type which specifies what sort of bet should be placed.</param>
        /// <param name="betValue">Amount of cash which is placed.</param>
        /// <param name="dogToWin">Dog number on which the bet should be placed.</param>
        /// <seealso cref="BetFactory"/>
        public override void PlaceBet(BetFactory.BetSort sortOfBet, decimal betValue, int dogToWin)
        {
            cash -= betValue;                                                   //substract money from Bettor object.
            decimal standardBetValue = 0;

            if (sortOfBet == BetFactory.BetSort.handicapBet)                  //check whetether user has placed standardBet.
            {
                try
                {
                    standardBetValue = (this.betSort as BetStandard).GetAmount;     //handicap uses previously placed standard bet.
                }
                catch (System.NullReferenceException)                               //exception is thrown when dummybet is stored in betSort object.
                {
                    standardBetValue = 0;
                }
            }
    
            this.betSort = betFactory.CreateBet(sortOfBet, betValue + standardBetValue, dogToWin);        //place bet in bettor object(add standardBet with current value of handicap).
        }

        /// <summary>
        /// Adds the amount of cash wich has been transfered <paramref name="moneyTransfer"/> to current account balance of bettor.
        /// Updates the cash in bettor object.
        /// </summary>
        /// <param name="moneyTransfer">The amount of cash which specific user has transfered.</param>
        public override void AddCashToMyAccount(decimal moneyTransfer)
        {
            cash += moneyTransfer;
        }
    }
}
