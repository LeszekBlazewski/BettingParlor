using System.Linq;

namespace BettingParlor_Refactor.UnitTests
{
    /// <summary>
    /// Creates temporary client instance in database to allow other tests to work properly.
    /// </summary>
    /// <remarks>
    /// Used whenever client account must be already in database.
    /// Creates client with fake credentials only for testing purpouses.
    /// </remarks>
    public class ClientFactory
    {
        #region variables used in logging process.
        /// <summary>
        /// Username of player.
        /// </summary>
        protected string username;

        /// <summary>
        /// Password of player.
        /// </summary>
        protected string password;

        /// <summary>
        /// Id of connection made by client.
        /// </summary>
        protected string connectionId;

        /// <summary>
        /// Form used to pass empty textBoxes verification.
        /// </summary>
        protected FormLogin formLogin;

        #endregion

        /// <summary>
        /// Creates temporary client in dataBase.
        /// </summary>
        /// <remarks> Used whenever client storted in database is needed.</remarks>
        protected bool CreateUserinDatabase()
        {
            //Arrange
            var login = new Login();
            var randomStringGenerator = new RandomStringGenerator();
            formLogin = new FormLogin();
            var database = new DataClassesBettingParlorDataContext();
            username = randomStringGenerator.GenerateRandomString();
            password = randomStringGenerator.GenerateRandomString();
            connectionId = randomStringGenerator.GenerateRandomString();

            //Fill textBoxes on form to pass checkIfTextBoxesAreEmpty verification.
            formLogin.textBoxUsername.Text = username;
            formLogin.textBoxPassword.Text = password;

            //true if client is able to register, false if not.
            return login.RegisterNewPlayer(username, password, formLogin);
        }

        /// <summary>
        /// Removes temporary client from database.
        /// </summary>
        /// <param name="username">Name of client who should be deleted.</param>
        /// <remarks> Removes client from database to avoid conflicts in other tests.</remarks>
        protected void DeleteUserFromDatabase(string username)
        {
            var database = new DataClassesBettingParlorDataContext();
          
            Player recentlyRegisteredPlayer = database.Players.SingleOrDefault(p => p.UserName == username);

            database.Players.DeleteOnSubmit(recentlyRegisteredPlayer);
            database.SubmitChanges();
        }
    }
}
