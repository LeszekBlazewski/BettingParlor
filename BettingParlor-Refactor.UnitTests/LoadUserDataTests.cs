using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BettingParlor_Refactor.UnitTests
{
    /// <summary>
    /// Contains unit test related to <see cref="LoadUserData"/> class.
    /// </summary>
    /// <remarks>
    /// Checks whether loading user functions are working properly.
    /// </remarks>
    [TestClass]
    public class LoadUserDataTests:ClientFactory
    {
        /// <summary>
        /// Test whether client can be added to list when he signs in for the first time.
        /// </summary>
        [TestMethod]
        public void AddClientToList_ClientDictionaryIsEmptyOrClientIsNotInDictionary_CLientIsAddedToDictionaryReturnTrue()
        {
            //Arrange
            CreateUserinDatabase();
            var loadUserData = new LoadUserData();
            var result = loadUserData.AddClientToList(connectionId, username);

            //Assert
            Assert.IsTrue(result);

            //Delete recently added player in database to avoid conflicts with further tests.
            DeleteUserFromDatabase(username);
        }

        /// <summary>
        /// Test whether client can be added to list when he is signed in on another form already.
        /// </summary>
        [TestMethod]
        public void AddCLientToList_ClientIsAlreadyInDictionary_ClientIsNotAddedReturnFalse()
        {
            //Arrange
            CreateUserinDatabase();
            var loadUserData = new LoadUserData();
            var randomStringGenerator = new RandomStringGenerator();
            var fakeConnectionId = randomStringGenerator.GenerateRandomString();

            //Add recently created user to dictionary.
            loadUserData.AddClientToList(connectionId, username);
            //Try to add user with same username.
            var result = loadUserData.AddClientToList(fakeConnectionId, username);

            //Assert
            Assert.IsFalse(result);

            //Delete recently added player in database to avoid conflicts with further tests.
            DeleteUserFromDatabase(username);
        }
    }
}
