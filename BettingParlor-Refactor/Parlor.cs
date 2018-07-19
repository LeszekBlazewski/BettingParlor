namespace BettingParlor_Refactor
{
    /// <summary>
    /// Main administrator class.
    /// Contains all methods used by administrator to manage the race and take part in the game.
    /// </summary>
    /// <seealso cref="User"/>
    class Parlor:User
    {
        /// <summary>
        /// Initializes the fields properly.
        /// </summary>
        /// <param name="name">Name of the administrator.</param>
        /// <param name="cash">Current account balance of administrator stored in database.</param>
        public Parlor(string name,decimal cash):base(name,cash)
        {
        }

        #region Race operations
        /// <summary>
        /// Sends data to all connected users about the current location of each dog.
        /// </summary>
        /// <param name="dogNumber">Number of the dog which location is sent.</param>
        /// <param name="location">Location of specific dog on server form.</param>
        /// <remarks>Used by clients to fetch dogs position and update they dog location as the race continues.</remarks>
        public void SendDogsLocationToUsers(int dogNumber,int location)
        {
           ClientServerConnectionsHub.SendDogsLocationToAllPlayers(dogNumber,location);
        }

        /// <summary>
        /// Sends notification to all connected users to update their GUI.
        /// </summary>
        /// <param name="notification">Specifies what action should be taken by clients to update their GUI properly.</param>
        /// <remarks>
        /// Administrator sends notification which specifies whether race starts or handicap panel should be disabled.</remarks>
        public void SendNotificationAboutTheRace(string notification)
        {
            ClientServerConnectionsHub.SendNotificationRace(notification);
        }
        
        /// <summary>
        /// Sends number of dog which won the race to clients to display on their form notification who won the game and correctly update GUI to prepare it for next race.
        /// </summary>
        /// <param name="dogWinner">Number of dog which won the race.</param>
        public void UpdateUserFormOnRaceEnd(int dogWinner)
        {
            ClientServerConnectionsHub.EndRaceOnClientForm(dogWinner);   
        }

        /// <summary>
        /// Calls aprioprate functions for each object to collect bet and update cash in dataBase.
        /// Collects bet for administrator and for each client object stored on server.
        /// </summary>
        /// <param name="dogWinner">Number of dog which won the race.</param>
        public override void CollectBet(int dogWinner)
        {
            cash += betSort.PayOutTheAmountWon(dogWinner);                                       //Collect admin bet.
            ClientServerConnectionsHub.SendAdminCurrentAccountBalanceToDatabase(name, cash);    //Send admin winnings to dataBase.
            this.ClearBet();                                                                    //Clear admin bet.

            ClientServerConnectionsHub.CollectClientBetsAfterRaceEnd(dogWinner);                // Collect client bets on server (foreach client object).
        }
        #endregion


        /// <summary>
        /// Returns current account balance of administrator which is stored in database.
        /// </summary>
        /// <returns>Current account balance of administrator stored in database.</returns>
        /// <remarks> Used to update the label which shows current account balance on administrator form to display most recent saldo.</remarks>
        public decimal UpdateAdminCashLabel()
        {
            return ClientServerConnectionsHub.GetAdminAccountBalance(name);
        }

        /// <summary>
        /// Place bet in administrator object and send it to sql table.
        /// </summary>
        /// <param name="betSort">Sort of bet which should be placed.</param>
        /// <param name="betValue">Value of the bet which should be placed.</param>
        /// <param name="dogToWin">Number of dog on which bet is placed.</param>
        public override void PlaceBet(BetFactory.BetSort betSort, decimal betValue, int dogToWin)
        {
            cash -= betValue;                                                     //substract amount bet.
            decimal standardBetValue = 0;                                         //variable used to get amount which was bet when placeing standard bet.

            if (betSort == BetFactory.BetSort.handicapBet)                        //check if admin has placed standard bet                            
            {
                try
                {
                    standardBetValue = (this.betSort as BetStandard).GetAmount;            //handicap uses the betValue from standardBet.
                }
                catch (System.NullReferenceException)
                {
                    standardBetValue = 0;
                }  
            }

            this.betSort = betFactory.CreateBet(betSort, betValue+standardBetValue, dogToWin);        //place bet in admin object(add standardBet with current value of handicap).

            if (betSort == BetFactory.BetSort.dummyBet)                                            //prevents sending dummy bet to sql table. 
                return;

            ClientServerConnectionsHub.PlaceAdminBet(name,betValue, dogToWin,betSort);             //send bet to database.
        }

        /// <summary>
        /// Adds cash to administrator object and updates his cash in database.
        /// </summary>
        /// <param name="moneyTransfer">Amount of cash which should be added to administrator account.</param>
        public override void AddCashToMyAccount(decimal moneyTransfer)
        {
            cash += moneyTransfer;
            ClientServerConnectionsHub.AddCashToAdminAccountInDatabase(name, moneyTransfer);
        }
    }
}
