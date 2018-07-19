using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BettingParlor_Refactor.UnitTests
{
    /// <summary>
    /// Contains tests related to <see cref="ManageUserData"/> class.
    /// </summary>
    /// <remarks>
    /// Checks whether retrieving data from database works correctly.
    /// </remarks>
    [TestClass]
    public class ManageUserDataTests:ClientFactory
    {
        /// <summary>
        /// Test whether client can transfer money properly.
        /// </summary>
        [TestMethod]
        public void AddCashToClientAccount_ClientTransfersCertainAmountOfCash_HisAccountBalanceIsUpdated()
        {
            //Arrange
            CreateUserinDatabase();
            var moneyTransfer = 100M;
            var manageUserData = new ManageUserData();
            var loadUserData = new LoadUserData();
            var database = new DataClassesBettingParlorDataContext();

            //Action
            //Add client to dictionary because all manageUserData methods relay on it.
            loadUserData.AddClientToList(connectionId, username);
            manageUserData.AddCashToClientAccount(connectionId, moneyTransfer);
            decimal accountBalanceAfterTransfer= database.Players.SingleOrDefault(p => p.UserName == username).CurrentAccountBalance;

            //Assert
            //New user is created so after transfer his accountBalance must equal the amount he transfered.
            Assert.AreEqual(moneyTransfer, accountBalanceAfterTransfer);

            //Delete recently added player in database to avoid conflicts with further tests.
            DeleteUserFromDatabase(username);
        }

        /// <summary>
        /// Test whether client is able to place certain bet.
        /// </summary>
        /// <remarks>
        /// Client has enoug cash to make the operation.
        /// </remarks>
        [TestMethod]
        public void PlaceClientBet_UserIsAbleToPlaceCertainBet_BetIsPlacedReturnTrue()
        {
            //Arrange
            CreateUserinDatabase();
            var moneyTransfer = 10M;
            var betValue = 10M;
            var dogToWin = 1;
            var isStandard = true;
            var manageUserData = new ManageUserData();
            var loadUserData = new LoadUserData();

            //Action
            //Add client to dictionary because all manageUserData methods relay on it.
            loadUserData.AddClientToList(connectionId, username);
            //Transfer money to client account that he is able to place given bet.
            manageUserData.AddCashToClientAccount(connectionId, moneyTransfer);
            //Get the result if bet has been placed.
            var result = manageUserData.PlaceClientBet(connectionId, betValue, dogToWin, isStandard);

            //Assert 
            Assert.IsTrue(result);

            //Delete recently added player in database to avoid conflicts with further tests.
            DeleteUserFromDatabase(username);
        }

        /// <summary>
        /// Test whether client is able to place certain bet.
        /// </summary>
        /// <remarks>
        /// Client has not enough cash to make the operation.</remarks>
        [TestMethod]
        public void PlaceClientBet_UserCanNotPlaceCertainBet_BetIsNotPlacedReturnFalse()
        {
            //Arrange
            CreateUserinDatabase();
            var betValue = 10M;
            var dogToWin = 1;
            var isStandard = true;
            var manageUserData = new ManageUserData();
            var loadUserData = new LoadUserData();

            //Action
            //Add client to dictionary because all manageUserData methods relay on it.
            loadUserData.AddClientToList(connectionId, username);
            //Get the result if bet has been placed. User tries to place bet with 0 cash on his account.
            var result = manageUserData.PlaceClientBet(connectionId, betValue, dogToWin, isStandard);

            //Assert 
            Assert.IsFalse(result);

            //Delete recently added player in database to avoid conflicts with further tests.
            DeleteUserFromDatabase(username);
        }
    }
}
