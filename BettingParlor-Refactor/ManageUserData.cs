  using System.Linq;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Contains methods which process user data stored in database.
    /// </summary>
    /// <remarks>
    /// All database connections are made by the use of LINQ TO SQL which maps the database tables on the start of the program and allows easy access to them.
    /// For more information check LINQ TO SQL documentation.
    /// </remarks>
    class ManageUserData : UserData
    {
        /// <summary>
        /// Updates cash in database and in current user object in the programm.
        /// </summary>
        /// <param name="connectionId">Id of the client who transfered money.</param>
        /// <param name="moneyTransfer">Amount of cash which should be added to user account in database.</param>
        public void AddCashToClientAccount(string connectionId, decimal moneyTransfer)
        {
            using (var dataBase = new DataClassesBettingParlorDataContext())
            {
                var currentuserRowInDictionary = GetCurrentClientRow(connectionId);

                var searchUserAccountInDatabase = (from player in dataBase.Players
                                                   where player.UserName == currentuserRowInDictionary.Value.Name
                                                   select player).SingleOrDefault();

                searchUserAccountInDatabase.CurrentAccountBalance += moneyTransfer;

                dataBase.SubmitChanges();

                currentuserRowInDictionary.Value.AddCashToMyAccount(moneyTransfer);
            }
        }

        /// <summary>
        /// Updates administrator cash stored in database.
        /// </summary>
        /// <param name="adminName">Name of the administrator.</param>
        /// <param name="moneyTransfer">Amount of cash which should be added to administrator account in database.</param>
        public void AddCashToAdminAccount(string adminName, decimal moneyTransfer)
        {
            using (var dataBase = new DataClassesBettingParlorDataContext())
            {
                var adminAccount = dataBase.Players.Where(p => p.UserName == adminName).SingleOrDefault();

                adminAccount.CurrentAccountBalance += moneyTransfer;

                dataBase.SubmitChanges();
            }
        }

        /// <summary>
        /// Handles the process of placing bet by clients.
        /// Adds new bet which was created to database and respectively places it in client object stored on server.
        /// </summary>
        /// <param name="connectionId">Id of client which wants to place a bet.</param>
        /// <param name="betValue">Value of the bet which should be placed.</param>
        /// <param name="dogToWin">Number of the dog on which bet should be placed.</param>
        /// <param name="isStandard">Specifies whether standard bet or handicap should be placed.</param>
        /// <returns>
        /// True if bet was successsfully created.
        /// False if client is not able to place bet which he requested.
        /// </returns>
        /// <remarks>
        /// Returns true if bet was successsfully created.
        /// False if client is not able to place bet which he requested.
        /// Returend parameter is used on client side in <see cref="Client"/> class to show him result whether he can or not place bet he requested.
        /// </remarks>
        public bool PlaceClientBet(string connectionId, decimal betValue, int dogToWin, bool isStandard)
        {
            using (var dataBase = new DataClassesBettingParlorDataContext())
            {
                var currentUserRowInDictionary = GetCurrentClientRow(connectionId);

                var searchUserAccountInDatabase = (from player in dataBase.Players
                                                   where player.UserName == currentUserRowInDictionary.Value.Name
                                                   select player).SingleOrDefault();

                if (currentUserRowInDictionary.Value.Cash >= betValue)                              //check if client has enough cash to place this bet.
                {
                    searchUserAccountInDatabase.CurrentAccountBalance -= betValue;                  //substract money from client account in database.

                    if (isStandard)                                                                 //check what sort of bet it is.
                    {
                        CurrentBet currentBet = new CurrentBet                                      //create bet in dataBase to display it in dataGriedView
                        {
                            Bettor_name = currentUserRowInDictionary.Value.Name,
                            Amount_bet = betValue,
                            Dog_to_win = dogToWin
                        };

                        currentUserRowInDictionary.Value.PlaceBet(BetFactory.BetSort.standartBet, betValue, dogToWin);      //place bet in user object.
                        dataBase.CurrentBets.InsertOnSubmit(currentBet);
                    }
                    else
                    {
                        var searchCurrentBetRow = dataBase.CurrentBets.SingleOrDefault(p => p.Bettor_name == currentUserRowInDictionary.Value.Name); //Check if client has placed standardBet

                        if (searchCurrentBetRow != null)    //If user has placed standard bet.
                        {      
                            searchCurrentBetRow.Amount_bet += betValue;
                            searchCurrentBetRow.Dog_to_win = dogToWin;
                        }
                        else                                //If user has not placed standard bet.
                        {
                            CurrentBet currentBet = new CurrentBet      //create bet in dataBase to display it in dataGriedView
                            {
                                Bettor_name = currentUserRowInDictionary.Value.Name,
                                Amount_bet = betValue,
                                Dog_to_win = dogToWin
                            };

                            dataBase.CurrentBets.InsertOnSubmit(currentBet);
                        }
                        currentUserRowInDictionary.Value.PlaceBet(BetFactory.BetSort.handicapBet, betValue, dogToWin);
                    }
                    dataBase.SubmitChanges();       //submit all changes made to database.

                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// Handles the process of placing bet by administrator.
        /// Adds new bet which was created to database.
        /// </summary>
        /// <param name="adminName">Name of the administrator.</param>
        /// <param name="betValue">Value of the bet which should be placed.</param>
        /// <param name="dogToWin">Number of dog on which bet should be placed.</param>
        /// <param name="betSort">What sort of bet should be placed.</param>
        /// <remarks>
        /// Only database operations are stored here because admin object (<see cref="Parlor"/>) is already on server so whenever he places bet his object is instantly updated.
        /// </remarks>
        public void PlaceAdminBet(string adminName,decimal betValue, int dogToWin,BetFactory.BetSort betSort)
        {
            using (var dataBase = new DataClassesBettingParlorDataContext())
            {
                var searchAdminAccount = (from player in dataBase.Players
                                          where player.UserName == adminName
                                          select player).SingleOrDefault();

                searchAdminAccount.CurrentAccountBalance -= betValue;     //substract money from database.

                if (betSort == BetFactory.BetSort.standartBet)
                {
                    CurrentBet currentBet = new CurrentBet
                    {
                        Bettor_name = adminName,
                        Amount_bet = betValue,
                        Dog_to_win = dogToWin
                    };

                    dataBase.CurrentBets.InsertOnSubmit(currentBet);
                }
                else
                {
                    var searchCurrentBetRow = dataBase.CurrentBets.SingleOrDefault(p => p.Bettor_name == adminName);  //Check if admin has placed standardBet.

                    if (searchCurrentBetRow != null)    //If admin has placed standard bet.
                    {
                        searchCurrentBetRow.Amount_bet += betValue;
                        searchCurrentBetRow.Dog_to_win = dogToWin;
                    }
                    else                                //If admin has not placed standard bet.
                    {
                        CurrentBet currentBet = new CurrentBet      //create bet in dataBase to display it in dataGriedView.
                        {
                            Bettor_name = adminName,
                            Amount_bet = betValue,
                            Dog_to_win = dogToWin
                        };

                        dataBase.CurrentBets.InsertOnSubmit(currentBet);
                    }
                }
                dataBase.SubmitChanges();
            }
        }

        /// <summary>
        /// Searches for current user and sends his current cash to update money stored in database.
        /// </summary>
        /// <param name="userNameOfTheCurrentBettor">Name of the player which cash should be updated.</param>
        /// <param name="amount">Amount of cash which represents current account balance of player.</param>
        /// <remarks>
        /// Updates account balance stored in database to actual stored in application which was changed after the race.
        /// </remarks>
        public void SendCashToDatabase(string userNameOfTheCurrentBettor,decimal amount)
        {
            using (var dataBase = new DataClassesBettingParlorDataContext())
            {
                var searchCurrentUserAccount = (from currentBettor in dataBase.Players
                                                where currentBettor.UserName == userNameOfTheCurrentBettor
                                                select currentBettor).SingleOrDefault();

                searchCurrentUserAccount.CurrentAccountBalance = amount;
                dataBase.SubmitChanges();
            }
        }

        /// <summary>
        /// Runs collect bet method for each user who placed a bet and sends cash to database.
        /// </summary>
        /// <param name="winner">Number of the dog which won the race.</param>
        /// <remarks>
        /// Resets all bets to default value.
        /// At the end truncates table with bets from previous game to prepare it for next race.
        /// </remarks>
        public void CollectClientBets(int winner)
        {
            foreach (var user in connectedClients)
            {
                user.Value.CollectBet(winner);                                      //collect client bet.

                SendCashToDatabase(user.Value.Name, user.Value.Cash);               //send his cash to databse.

                user.Value.ClearBet();                                              //place dummy bet (simply clear object).
            }
            using (var dataBase = new DataClassesBettingParlorDataContext())
            {
                dataBase.ExecuteCommand("TRUNCATE TABLE CurrentBets");              //resets SQL table
            }
        }
    }
}
