using System.Collections.Generic;
using System.Linq;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Stores all user data contained in static dictionary which is used by derived classes to access player information whenever needed.
    /// </summary>
    /// <remarks>
    /// Includes method which are used by derived classes to easily manage user data.
    /// </remarks>
    abstract class UserData
    {
        /// <summary>
        /// Dictionary which mapps client connection with his object on the server.
        /// </summary>
        /// <remarks>
        /// Static dictionary used to create client objects when the sign in.
        /// All client data is stored in this dictionary which is used whenever client operations are performed.
        /// </remarks>
        protected static Dictionary<string, Bettor> connectedClients = new Dictionary<string, Bettor>();


        #region Client operations
        /// <summary>
        /// Returns the current account balance of player stored in database.
        /// </summary>
        /// <param name="userName">Name of the player which current account balance should be returned.</param>
        /// <remarks>
        /// Returns current account balance of specified player.
        /// </remarks>
        /// <returns>Current account balance of specified player.</returns>
        public decimal GetCurrentClientAccountBalance(string userName)
        {
            using (var dataBase = new DataClassesBettingParlorDataContext())    
            {

                var searchUserAccount = (from player in dataBase.Players
                                         where player.UserName == userName
                                         select player).SingleOrDefault();

                return searchUserAccount.CurrentAccountBalance;
            }
        }

        /// <summary>
        /// Returns row from dictionary which contains Client object who sends the request to server. 
        /// </summary>
        /// <param name="connectionId">Id of the client who sends the request.</param>
        /// <remarks>
        /// Function is used in <see cref="LoadUserData"/> and <see cref="ManageUserData"/> to access player information fast and easily.
        /// Returns row from dictionary which contains Client data.
        /// </remarks>
        /// <returns>
        /// Row from dictionary which contains Client data.
        /// </returns>
        protected KeyValuePair<string,Bettor> GetCurrentClientRow(string connectionId)
        {
            foreach (var user in connectedClients)
            {
                if (user.Key == connectionId)
                    return user;
            }
            return connectedClients.FirstOrDefault();   // return default value when no specified client was found.
        }
        #endregion
    }
}
