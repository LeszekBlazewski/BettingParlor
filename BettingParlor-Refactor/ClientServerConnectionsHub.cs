using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Inherits from <see cref="Hub"/> class implemented in SignalR framework.
    /// Connection hub which is the base for all server-client methods used in the programm.
    /// Contains methods which are used to properly manage all events related to client requests and responses.
    /// Class contains all server methods which are used by administrator to push information to clients.
    /// </summary>
    public class ClientServerConnectionsHub:Hub        
    {
        /// <summary>
        /// Proxy used to access hub correctly.
        /// </summary>
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ClientServerConnectionsHub>();

        /// <summary>
        /// Responisble for withdrawing user data from database.
        /// </summary>
        private static LoadUserData loadUserData = new LoadUserData();

        /// <summary>
        /// Responisble for mantaining client operations.
        /// </summary>
        private static ManageUserData manageUserData = new ManageUserData(); 

        /// <summary>
        /// Property used to access form of the administrator and write logs to his console.
        /// </summary>
        public static FormServer FormServer { get; set; }         

        /// <summary>
        /// Name of group which stores connected clients.
        /// Group is created automatically by SignalR framework.
        /// Group allows easy management with all clients who successfully established connection.
        /// It prevents sending data to clients which are not fully prepared to receive it
        /// </summary>
        private static string connectedClientsGroup = "connectedClients";          

        #region Connection Management
        /// <summary>
        /// Used to add users who connected succesfuly to server to group which is created when first client signs in.
        /// </summary>
        /// <returns>Task which adds client wich established connection.</returns>
        private Task JoinGroup()
        {
            return Groups.Add(Context.ConnectionId,connectedClientsGroup);
        }
        /// <summary>
        /// Used to remove user from group who managed to disconnect successfully from the server.
        /// </summary>
        /// <returns>Task which removes client from group after he closed his connection.</returns>
        private Task LeaveGroup()
        {
            return Groups.Remove(Context.ConnectionId,connectedClientsGroup);
        }
        /// <summary>
        /// First function wich is used when client connects to server.
        /// Checks whether user should be allowed to join the game or not.
        /// </summary>
        /// <returns>Task which connects user to server or rejects the connection reques when requirements are not met.</returns>
        public override Task OnConnected()
        {
            var userName = Context.QueryString["userName"];              //receive current connecting player name to create his object on server.

            if(FormServer.CheckIfRaceIsOn())                            //check if race is currently in progresss.
            {
                Clients.Caller.StopConnection(true);                   //pass true if log in is aborted due to race 
                WriteToAdminConsole("Client log in aborted due the race: " + Context.ConnectionId);
                return base.OnDisconnected(true);
            }

            if (loadUserData.AddClientToList(Context.ConnectionId, userName))   //check if client with queried username isn't logged in on another app.
            {
                //TODO: COMMENT NEXT LINE BEFORE UNIT TESTING
                WriteToAdminConsole("Client connected: " + Context.ConnectionId);
                JoinGroup();                   //add client to group wich stores successfully connected users
                return base.OnConnected();
            }
            else
            {
                Clients.Caller.StopConnection(false);                   //pass false if login is aborted due to login on another form.
                WriteToAdminConsole("Client log in aborted due to his login on another form: " + Context.ConnectionId);
                return base.OnDisconnected(true);
            }
        }
        /// <summary>
        /// Fired when client disconnects.
        /// Removes client from connected clients group nad his object from dictionary on server.
        /// </summary>
        /// <returns>Task which properly closes client connection after he signs out.</returns>
        public override Task OnDisconnected()
        {
            loadUserData.RemoveClientFromList(Context.ConnectionId);
            LeaveGroup();
            WriteToAdminConsole("Client disconnected: " + Context.ConnectionId);
            return base.OnDisconnected();
        }

        /// <summary>
        /// Functions is responsible for displaying current clients logs in admin console.
        /// </summary>
        /// <param name="message"> Log which should be written to admin console.</param>
        /// <remarks>Invoke is necessary because console is accessed from another thread.</remarks>
        private void WriteToAdminConsole(string message)
        {
            FormServer.Invoke((Action)(() => FormServer.GetRichTextBoxConsole.AppendText(message + Environment.NewLine)));
        }
        #endregion

        #region Manage Race operations
        /// <summary>
        /// Pushes dog data to all connected clients to update position of each dog on client's forms.
        /// </summary>
        /// <param name="dogNumber">Number of the dog which location is send to clients.</param>
        /// <param name="location">Location of the dog on server form.</param>
        /// <remarks>Send dog number and his location to clinets stored in connectedClientsGroup.</remarks>
        public static void SendDogsLocationToAllPlayers(int dogNumber, int location)
        {
            hubContext.Clients.Group(connectedClientsGroup).MoveDogs(dogNumber, location);
        }

        /// <summary>
        /// Used by administrator to inform clients whether the race starts or handicapPanel should be disabled.
        /// </summary>
        /// <param name="notification">Information sent to clients which specifies what function should be executed on client form.</param>
        public static void SendNotificationRace(string notification)
        {
            hubContext.Clients.Group(connectedClientsGroup).HandleControlsOnTheForm(notification);
        }

        /// <summary>
        /// Resets the controls on client form after the race has finished and displays dog which won the race.
        /// </summary>
        /// <param name="dogWinner">Number of the dog which won the race.</param>
        public static void EndRaceOnClientForm(int dogWinner)
        {
            hubContext.Clients.Group(connectedClientsGroup).ManageControlsAfterRaceHasFinished(dogWinner);
        }

        /// <summary>
        /// Collects bet for each player object stored in dictionary on server.
        /// </summary>
        /// <remarks>For more information <see cref="ManageUserData"/></remarks>
        /// <param name="dogWinner">Number of the dog which won the race.</param>
        public static void CollectClientBetsAfterRaceEnd(int dogWinner)
        {
            manageUserData.CollectClientBets(dogWinner);
        }
        #endregion

        #region Chat functions
        /// <summary>
        /// Responsible for passing messages from one player to all connected users.
        /// </summary>
        /// <param name="name">Name of the client who sends the message.</param>
        /// <param name="message">Message in chat which should be sent to other players.</param>
        public void Send(string name, string message)
        {
            Clients.Group(connectedClientsGroup).addMessage(name, message);
        }
        #endregion

        #region client operations
        /// <summary>
        /// Send request to server to place bet of the current calling client.
        /// </summary>
        /// <param name="connectionId">Id which specifies the client who is requesting to place a bet.</param>
        /// <param name="betValue">Value of the bet that should be placed.</param>
        /// <param name="dogToWin">Number of the dog on which bet is placed.</param>
        /// <param name="isStandardBet">Defines what bet is requested standrd bet or handicap.</param>
        public void PlaceBetOfTheCurrentCaller(string connectionId, decimal betValue, int dogToWin, bool isStandardBet)
        {
            bool resultIfBetWasPlaced = false;  //result sent to client after his request to display on his form whether 
                                                //he was able or not to place bet.

            if (manageUserData.PlaceClientBet(connectionId, betValue, dogToWin, isStandardBet))
            {
                resultIfBetWasPlaced = true;
                //Send information to all clents to update their dataGriedViews to display new bets.
                UpdateClientsBetTable();
                //Update dataGriedView on admin side (formServer).
                FormServer.Invoke((Action)(() =>
                FormServer.UpdateDataGriedView()
                ));
            }
            else
                resultIfBetWasPlaced = false;

            //Send response to client which requested to place his bet.
            hubContext.Clients.Client(connectionId).PlaceBetResult(resultIfBetWasPlaced,isStandardBet);
        }

        /// <summary>
        /// Sends a request to server to update cash in client object on server and in database.
        /// </summary>
        /// <param name="connectionId">Id which specifies the client who transfers money to his account.</param>
        /// <param name="moneyTransfer">Amount of cash which has been transfered.</param>
        public void AddCashToCurrentCallerAccount(string connectionId, decimal moneyTransfer)
        {
            manageUserData.AddCashToClientAccount(connectionId, moneyTransfer);
        }
        /// <summary>
        /// Send request to recive current account balance of calling client and update label which shows account balance on his form.
        /// </summary>
        /// <param name="connectionId">Id which specifies the client who sends the request.</param>
        /// <param name="userName">Username of client which sends the request.</param>
        public void UpdateCurrentCallerLabel(string connectionId, string userName)
        {
            decimal saldo = ((loadUserData as UserData).GetCurrentClientAccountBalance(userName));

            //Send response to client which requested his accountbalance
            hubContext.Clients.Client(connectionId).UpdateSaldoLabel(saldo);
        }

        /// <summary>
        /// Sends notification to all connected users to refresh their dataGriedViewBets.
        /// Used every time player places bet to display it in all client forms.
        /// </summary>
        private static void UpdateClientsBetTable()
        {
            hubContext.Clients.Group(connectedClientsGroup).UpdateBetTable();
        }
        #endregion

        #region administrator operations
        /// <summary>
        /// Updates admin cash in database after the race has finished.
        /// </summary>
        /// <param name="adminName">Name of the administrator.</param>
        /// <param name="amount">Amount of cash which should be added to administrator row in database.</param>
        public static void SendAdminCurrentAccountBalanceToDatabase(string adminName, decimal amount)
        {
            manageUserData.SendCashToDatabase(adminName, amount);
        }

        /// <summary>
        /// Sends administrator bet to database to display it in dataGriedView.
        /// </summary>
        /// <param name="adminName">Name of the administrator who places the bet.</param>
        /// <param name="betValue">Value of the bet which should be placed.</param>
        /// <param name="dogToWin">Number of dog on which bet should be placed.</param>
        /// <param name="betSort">Defines what kind of bet should be placed.</param>
        public static void PlaceAdminBet(string adminName,decimal betValue, int dogToWin,BetFactory.BetSort betSort)
        {
            manageUserData.PlaceAdminBet(adminName, betValue, dogToWin,betSort);    //place admin bet in database.
            UpdateClientsBetTable();                                                //send information to all clients that they should update their dataGriedViews.
        }

        /// <summary>
        /// Returns admin current account balance withdrawed from database.
        /// Used when creating administrator object to initialize his cash properly.
        /// </summary>
        /// <param name="userName">Name of the administrator whose account balance is returned.</param>
        /// <returns>Account balance stored in SQL database.</returns>
        public static decimal GetAdminAccountBalance(string userName)
        {
            return (loadUserData as UserData).GetCurrentClientAccountBalance(userName);
        }

        /// <summary>
        /// Adds cash to administrator account stored in database.
        /// </summary>
        /// <param name="adminName">Name of the administrator.</param>
        /// <param name="moneyTransfer">Amount od cash which is added to administrator row in dataBase.</param>
        public static void AddCashToAdminAccountInDatabase(string adminName,decimal moneyTransfer)
        {
            manageUserData.AddCashToAdminAccount(adminName, moneyTransfer);
        }
        #endregion
    }
}
