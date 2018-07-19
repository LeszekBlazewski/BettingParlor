using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Class contains methods which are used to send requests to server and receive the response.
    /// Class handels all client operations which relate to server-client communication.
    /// All methods are implemented by using SignalR framework.
    /// </summary>
    /// <seealso cref="Server"/>
    /// <seealso cref="ClientServerConnectionsHub"/>
    public class Client
    {
        /// <summary>
        /// Name of the client.
        /// </summary>
        private string userName;

        /// <summary>
        /// Proxy used to access <see cref="ClientServerConnectionsHub"/>.
        /// </summary>
        private IHubProxy HubProxy { get; set; }

        /// <summary>
        /// URL on which server is hosted.
        /// Used to establish a proper connection.
        /// </summary>
        const string ServerURI = "http://localhost:8080/signalr";

        /// <summary>
        /// Used to get all information about the current client connection.
        /// Holds necessary information to properly connect client to server.
        /// </summary>
        /// <remarks>
        /// Contains all methods implement in SignalR framework which are related to client connections.
        /// You can easily get the connectionID, clientName, add certificate and so on.
        /// For further informations see SignalR documentation.
        /// </remarks>
        public HubConnection Connection { get; set; }

        /// <summary>
        /// Gets access to user interface, to call functions which change the display of client UI.
        /// Property is the connection between GUI and client class.
        /// </summary>
        /// <remarks>
        /// Client GUI has to change after certain events which are handled on server, and this property enables the form to be updated properly.
        /// There are functions which have to be called only on server response and this property allows it.
        /// </remarks>
        public FormClient FormClient { get; set; }       // getter necessary to call function from client UI on server response.

        /// <summary>
        /// Takes one parameter <paramref name="userName"/> and initializes the correct field.
        /// </summary>
        /// <param name="userName">Name of the client who connects to server.</param>
        public Client(string userName)
        {
            this.userName = userName;
        }

        /// <summary>
        /// This method is the base for client-server connection.
        /// Includes the connection process and all methods wich are run on specific response from server.
        /// Every time server sends any kind of information to client this function is responisble for receiving it and handling it properly.
        /// Contains all client methods which can be exectuded on the server asynchronously.
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when connection can't be established.</exception>
        /// <param name="formLogin">UI is passed to display status of the connection properly.</param>
        public async void ConnectToServer(FormLogin formLogin)
        {
            bool successfulConnection = true;   //parameter user to define whether connection to server was successfull or not.

            //Quering user data to pass it to server
            var queryStringData = new Dictionary<string, string>
            {
                { "username",userName}
            };

            Connection = new HubConnection(ServerURI, queryStringData);
            HubProxy = Connection.CreateHubProxy("ClientServerConnectionsHub"); //create proxy which is used for receving responses from server.

            //Receive information from server that user tries to sign in on different forms without logging out or the  race is currently on.
            HubProxy.On<bool>("StopConnection", (raceIsOn) =>
            {
                successfulConnection = false;

                if (raceIsOn)
                    formLogin.Invoke((Action)(() =>
                  MessageBox.Show("Race is currently on. Please wait till the race ends and try to sign in again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                else
                    formLogin.Invoke((Action)(() =>
                       MessageBox.Show("You are already signed in on another form. Please close all open forms and reconnect to the server.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)));

                formLogin.labelStatusText.Invoke(new MethodInvoker(delegate { formLogin.labelStatusText.Text = "Log in failed due to error."; }));
                Disconnect();
            });


            //Receive notification whether the race started or not to handle buttons properly.
            HubProxy.On<string>("HandleControlsOnTheForm", (notification) =>
            {
                FormClient.Invoke((Action)(() =>
                {
                    if (notification == "race begins")
                    {
                        FormClient.EnableControlsOnRaceStart();
                    }
                    else if (notification == "disable handicap")
                    {
                        FormClient.DisableHandicapPanel();
                    }
                    else
                        return;
                }));

            });

            //Receive dog number which won the game to show the winner and prepare the GUI for next race.
            HubProxy.On<int>("ManageControlsAfterRaceHasFinished", (dogWinner) =>
                FormClient.Invoke((Action)(() =>
                FormClient.HandleControlsAfterRaceHasFinished(dogWinner))
                ));

            //Get response from server whether bet operation was successful or not and show aprioprate messagebox.
            HubProxy.On<bool,bool>("PlaceBetResult", (result,isStandardBet) =>
                FormClient.Invoke((Action)(() =>
                {
                    Task.Run(() => FormClient.ShowResultBet(result));   //run this method async to prevent block of the main UI thread.

                    if (result)  //check if user was able to place bet (had enough cash in his object on server)
                    {
                        if (isStandardBet)          //check if this response is about standard bet.
                            FormClient.DisableSignOutOptionAfterPlacingStandardBet();  //only one standard bet is allowed.
                        else
                            FormClient.DisableHandicapPanel();  //only one handicap is allowed.
                    }
                })));

            //Get current account balance of player and update his label on the form. 
                HubProxy.On<decimal>("UpdateSaldoLabel", (saldo) =>
                FormClient.Invoke((Action)(() =>
                FormClient.UpdateCurrentAccountBalanceLabel(saldo))
                ));

            //Receive location of each dog on the server form and update them on client form.
            HubProxy.On<int, int>("MoveDogs", (dogNumber, location) =>
                 FormClient.Invoke((Action)(() =>
                    FormClient.MoveDogsOnClientForm(dogNumber, location))
                 ));


            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            //Adds message of specific player to all connected clients chats.
            HubProxy.On<string, string>("AddMessage", (name, message) =>                                
                FormClient.Invoke((Action)(() =>
                    FormClient.GetRichTextBoxConsole.AppendText(String.Format("{0}: {1}" + Environment.NewLine, name, message))
                ))
            );

            //Updates dataGriedView on client form to display new bets.
            HubProxy.On("UpdateBetTable", () =>
                FormClient.Invoke((Action)(() =>
                    FormClient.UpdateDataGriedView())
            ));

            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                formLogin.labelStatusText.Text = "Unable to connect to server: Game server is not responding.";
                return;
            }

            if (successfulConnection)   //prevents opening client form when client wasn't able to establish connection.
                formLogin.StartGameWindowClient(this);  //This function is placed here because it MUST trigger after the try-catch formula is passed.
        }

        /// <summary>
        /// Function is used to send message <paramref name="message"/> from one player to all connected users.
        /// Simply invokes specific method on server which automatically sends it to all connected clients.
        /// </summary>
        /// <param name="message">The message which should be sent to other players.</param>
        public void SendMessageToAllPlayers(string message)
        {
            HubProxy.Invoke("Send", userName, message);
        }

        /// <summary>
        /// This method sends a request to server to place bet in the current caller object.
        /// Method invoked on server places bet in client object and adds a row in data base to properly display placed values.
        /// </summary>
        /// <param name="betValue"> The value of the bet which should be placed.</param>
        /// <param name="dogToWin">Number of the dog on which bet is placed.</param>
        /// <param name="isStandardBet">Specification of bet which is used to properly create bet object on server.</param>
        public void PlaceMyBetOnServer(decimal betValue,int dogToWin, bool isStandardBet)
        {
            HubProxy.Invoke("PlaceBetOfTheCurrentCaller", Connection.ConnectionId,betValue,dogToWin, isStandardBet);
        }

        /// <summary>
        /// Function invokes on server method wich is responisible for adding cash to user account in database and his object on server.
        /// </summary>
        /// <param name="moneyTransfer">Amount of cash which should be added to user account.</param>
        public void AddCashToMyAccountOnServer(decimal moneyTransfer)
        {
            HubProxy.Invoke("AddCashToCurrentCallerAccount",Connection.ConnectionId,moneyTransfer); 
        }

        /// <summary>
        /// Function sends request to server to receive back the current saldo of client which needs to update his label.
        /// Invokes method on server which updates label on user form who requested the update.
        /// </summary>
        public void UpdateMyLabelOnTheForm()
        {
            HubProxy.Invoke("UpdateCurrentCallerLabel", Connection.ConnectionId,userName);
        }

        /// <summary>
        /// Function is used to close connection after client signs out.
        /// Ensures that the connection is properly closed, by using SignalR functions which handle the dispose of client connection.
        /// </summary>
        /// <remarks>
        /// For more information how Stop and Dispose functions are implemented see SignalR documentation.
        /// </remarks>
        public void Disconnect()
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }
    }
}
