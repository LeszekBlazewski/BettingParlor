using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BettingParlor_Refactor.UnitTests
{
    /// <summary>
    /// Contains tests related to <see cref="Login"/> class.
    /// </summary>
    /// <remars>
    /// Checks whether loggin and registration process is working correctly.
    /// </remars>
    [TestClass]
    public class LoginTests:ClientFactory
    {
        /// <summary>
        /// Test whether client can create new account with valid credentials.
        /// </summary>
        [TestMethod]
        public void RegisterNewPlayer_ThereIsNoUserWithSpecifiedNameInDatabase_NewAccountIsCreatedInDatabase()
        {
            var registrationResult = CreateUserinDatabase();
            var database = new DataClassesBettingParlorDataContext();

            //Search currently added player in database.
            Player recentlyRegisteredPlayer = database.Players.SingleOrDefault(p => p.UserName == username);

            //Assert
            Assert.IsNotNull(recentlyRegisteredPlayer);
            Assert.IsTrue(registrationResult);

            //Delete recently added player in database to avoid conflicts with further tests.
            DeleteUserFromDatabase(username);
        }

        /// <summary>
        /// Test whether client can create new account with invalid credentials.
        /// </summary>
        [TestMethod]
        public void RegisterNewPlayer_ThereIsAUserWithSpecifiedNameInDatabase_RegistrationIsRefused()
        {
            //Arrange
            var login = new Login();
            //Client makes new account.
            CreateUserinDatabase();
            //Other client tries to register with same username as the client before.
            var registrationResult = login.RegisterNewPlayer(username, password, formLogin);

            //Assert
            Assert.IsFalse(registrationResult);

            //Delete recently added player in database to avoid conflicts with further tests.
            DeleteUserFromDatabase(username);
        }

        /// <summary>
        /// Test whether client can loggin with valid credentials.
        /// </summary>
        [TestMethod]
        public void LogInToExistingAccount_ThereIsAUserWithSpecifiedNameInDatabase_LoginIsSuccessfull()
        {
            //Arrange
            CreateUserinDatabase();
            var login = new Login();
            //Log in player with validate credentials
            var loginResult = login.LogInToExistingAccount(username, password, formLogin);

            //Assert
            Assert.IsTrue(loginResult);

            //Delete recently added player in database to avoid conflicts with further tests.
            DeleteUserFromDatabase(username);
        }

        /// <summary>
        /// Test whether client can connect with invalid credentials.
        /// </summary>
        [TestMethod]
        public void LogInToExistingAccount_UserWithSpecifiedNameIsNotRegistered_LoginFails()
        {
            //Arrange
            var login = new Login();
            var randomStringGenerator = new RandomStringGenerator();
            var formLogin = new FormLogin();
            var database = new DataClassesBettingParlorDataContext();
            var username = randomStringGenerator.GenerateRandomString();
            var password = randomStringGenerator.GenerateRandomString();

            //Action
            formLogin.textBoxUsername.Text = username;
            formLogin.textBoxPassword.Text = password;
            //Log in to account which not exists.
            var loginResult = login.LogInToExistingAccount(username, password, formLogin);

            //Assert
            Assert.IsFalse(loginResult);
        }
    }
}
