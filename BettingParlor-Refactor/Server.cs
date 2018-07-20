using Microsoft.Owin.Hosting;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Contains all methods which are used to host and close the server properly.
    /// </summary>
    /// <remarks>
    /// All methods are implemented with the use of SignalR framework.
    /// For more information check SignalR documentation.</remarks>
    /// <seealso cref="ClientServerConnectionsHub"/>
    public class Server
    {
        /// <summary>
        /// Returns the name od administrator which starts the server, when he loggs in.
        /// </summary>
        public string GetAdminName => adminName;

        /// <summary>
        /// Returns the URL on which server is hosted.
        /// </summary>
        public string GetServerUrl => ServerURI;

        /// <summary>
        /// Used to close and dispose server properly.
        /// </summary>
        public IDisposable SignalR { get; set; }

        /// <summary>
        /// Stores URL on which server is hosted.
        /// <note type="note">
        /// The adress provided is used to test the database locally.
        /// </note>
        /// </summary>
        const string ServerURI = "http://localhost:8080";

        /// <summary>
        /// Stores administrator name.
        /// </summary>
        string adminName;

        /// <summary>
        /// Initializes the fields properly.
        /// </summary>
        /// <param name="adminName">Name of the administrator which hosts the server.</param>
        public Server(string adminName)
        {
            this.adminName = adminName;
        }

        /// <summary>
        /// Starts the server on specified URL and checks whether error is thrown when another server is already hosted on same URL.
        /// </summary>
        /// <remarks>
        /// Implemented by the use of SignalR framework.
        /// Form more information check SignalR documentation.</remarks>
        public void StartServer(FormLogin formLogin)
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);
            }
            catch (TargetInvocationException)
            {
                formLogin.labelStatusText.Invoke(new MethodInvoker(delegate { formLogin.labelStatusText.Text = "Server failed to start.\nA server is already running on " + ServerURI; }));
                return;
            }
            formLogin.StartGameWindowServer(this);  //Starts the game window for administrator.
        }

        /// <summary>
        /// Checks whether server is up. If so then disposes the signal to prevent other users from connecting to server.
        /// </summary>
        /// <remarks>Function is fired when administrator signs out of his account.
        /// Than all connection are stopped.</remarks>
        public void CloseServer()
        {
            if (SignalR != null)
                SignalR.Dispose();
        }
    }
}
