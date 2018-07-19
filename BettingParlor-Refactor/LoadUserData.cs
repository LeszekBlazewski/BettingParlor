using System.Linq;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Extension of the <see cref="UserData"/> class.
    /// Contains all methods responsible for loading user data from SQL dataBase to application.
    /// </summary>
    /// <seealso cref="UserData"/>
    class LoadUserData : UserData
    {
        /// <summary>
        /// Maps <paramref name="connectionId"/> with <paramref name="userName"/> in dictionary which stores connected clients.
        /// Creates new <see cref="Bettor"/> object for each client who is allowed to connect.
        /// </summary>
        /// <param name="connectionId">connection id of client who connects to server.(Created dynamically by SignalR framework)</param>
        /// <param name="userName">Name of the client who connects to server.</param>
        /// <remarks>
        /// Returns true if client is allowed to establish connection.
        /// False if client is already on the list - that means he is signed in on another form and he needs to sign out first.
        /// </remarks>
        /// <returns>
        /// True if client is allowed to establish connection.
        /// False if client is already on the list - that means he is signed in on another form and he needs to sign out first.</returns>
        public bool AddClientToList(string connectionId, string userName)
        {
            if (connectedClients.Count == 0)
            {
                connectedClients.Add(connectionId, new Bettor(userName, GetCurrentClientAccountBalance(userName)));      //map user connection with his newly created object on server
            }
            else
            {
                foreach (var user in connectedClients)  //check if user is already signed in on another form.
                {
                    if (user.Value.Name == userName)
                    {
                        return false;
                    }
                }
                connectedClients.Add(connectionId, new Bettor(userName, GetCurrentClientAccountBalance(userName)));
            }
            //When client connects place dummy bet to avoid checking if betsort is different from null.
            connectedClients.LastOrDefault().Value.PlaceBet(BetFactory.BetSort.dummyBet, 0, 0); 

            return true;
        }

        /// <summary>
        /// Removes client from dictionary when he signs out by destroying his object.
        /// </summary>
        /// <param name="connectionId">connection id of client which signs out.</param>
        /// <remarks> Userd data is saved to database after each race, so when they sign out object can be safely destroyed.</remarks>
        public void RemoveClientFromList(string connectionId)
        {
            connectedClients.Remove(connectionId);    
        }
    }
}
