using System.Linq;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Contains methods used to handle the registration and loggin process.
    /// </summary>
    /// <remarks> All connections to database related to loggin and registration process are performed in this class.</remarks>
    /// <seealso cref="FormLogin"/>
    class Login
    {
        /// <summary>
        /// Represents result which defines the message shown to player.
        /// </summary>
        /// <remarks>
        /// Object of type <see cref="FormLogin.Result"/>
        ///  Defines which message should be displayed to user after he enters his credentials.
        ///  </remarks>
        private FormLogin.Result result;

        /// <summary>
        /// Registers new player by creating new account in dataBase which stores his credentials.
        /// </summary>
        /// <param name="userName">Name of the player who wants to create new account.</param>
        /// <param name="password">Password which is used to sign into account.</param>
        /// <param name="formLogin">Form used to display information whether registration was successfull.</param>
        /// <remarks>
        /// Returns true if client account with given user name has been created.
        /// False if client account has not been created because username is already taken.
        /// </remarks>
        /// <returns>
        /// True if client account with given user name has been created.
        /// False if client account has not been created because username is already taken.
        /// </returns>
        public bool RegisterNewPlayer(string userName, string password, FormLogin formLogin)
        {
            using (var dataBase = new DataClassesBettingParlorDataContext())
            {
                if (!formLogin.CheckIfTextBoxesAreEmpty())
                {
                    Player player = dataBase.Players.SingleOrDefault(p => p.UserName == userName);

                    if (player == null)
                    {
                        Player newPlayer = new Player()
                        {
                            UserName = userName,
                            Password = password,
                            CurrentAccountBalance = 0,
                            UserTypeID = 1
                        };
                        dataBase.Players.InsertOnSubmit(newPlayer);
                        dataBase.SubmitChanges();

                        result = FormLogin.Result.RegistrationSuccessful;
                        formLogin.ShowResult(result);
                        return true;
                    }
                    else
                    {
                        result = FormLogin.Result.RegistrationFailed;
                        formLogin.ShowResult(result);
                        return false;
                    }
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// Checks whether credentials provided by client are valid.
        /// </summary>
        /// <param name="userName">Name of the player who wants to sign in.</param>
        /// <param name="password">Password which is used to sign into account.</param>
        /// <param name="formLogin">Form used to display information whether logging was successfull.</param>
        /// <remarks>
        /// Returns true if user has entered valid credentials and managed to sing in.
        /// False if user entered wrong credentials.
        /// </remarks>
        /// <returns>
        /// True if user has entered valid credentials and managed to sing in.
        /// False if user entered wrong credentials.
        /// </returns>
        public bool LogInToExistingAccount(string userName, string password, FormLogin formLogin)
        {
            using (var dataBase = new DataClassesBettingParlorDataContext())
            {
                if (!formLogin.CheckIfTextBoxesAreEmpty())
                {
                    Player player = dataBase.Players.SingleOrDefault(p => p.UserName == userName && p.Password == password);
                    if (player != null)
                    {
                        result = FormLogin.Result.LoginToDataBaseSuccessful;
                        formLogin.ShowResult(result);
                        return true;
                    }
                    else
                    {
                        result = FormLogin.Result.LoginToDataBaseFailed;
                        formLogin.ShowResult(result);
                        return false;
                    }
                }
                else
                    return false;
            }
        }
    }
}
