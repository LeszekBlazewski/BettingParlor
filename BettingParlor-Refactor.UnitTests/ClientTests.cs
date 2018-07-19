using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingParlor_Refactor.UnitTests
{
    /// <summary>
    /// Contains unit test related to <see cref="Client"/> class.
    /// </summary>
    /// <remarks>
    /// Checks client methods related to connecting and disconnecting to server.
    /// 
    /// Every test which needs client in conneced state must have the WriteToAdminConsole function disabled
    /// in ClientServerConnectionsHub class. Otherwise client is always in connecting state because
    /// WriteToAdminConsole can't accesss the GUI of server, which is not created in connection tests to simplify them and make them faster.
    /// To run connection tests simply comment this line in <see cref="ClientServerConnectionsHub"/> class:
    /// WriteToAdminConsole("Client connected: " + Context.ConnectionId);
    /// </remarks>
    [TestClass]
    public class ClientTests
    {
        /*
         * Every test which needs client in conneced state must have the WriteToAdminConsole function disabled
         * in ClientServerConnectionsHub class. Otherwise client is always in connecting state because
         * WriteToAdminConsole can't accesss the GUI of server, which is not created in connection tests to simplify them and make them faster.
         * To run connection tests simply comment this line in ClienServerConnectionsHub class:
         * WriteToAdminConsole("Client connected: " + Context.ConnectionId);
         */

        /// <summary>
        /// Test whether client can connect when server is down.
        /// </summary>
        [TestMethod]
        public void ConnectToServer_ServerIsDown_ClientCanNotConnectToServer()
        {
            //Arrange
            var client = new Client("a");
            var formLogin = new FormLogin();

            //Action
            client.ConnectToServer(formLogin);
            //Pause the test for 10 seconds to be sure that client receives response from server.
            Thread.Sleep(10000);

            //Assert
            Assert.AreEqual(Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected, client.Connection.State);
        }

        /// <summary>
        /// Test whether client can connect when server is hosted.
        /// </summary>
        [TestMethod]
        public void ConnectToServer_ServerIsUp_ClientConnectsToServerAsync()
        {
            //Arrange 
            var client = new Client("a");
            var server = new Server("admin");
            var formLogin = new FormLogin();

            //Action
            server.StartServer(formLogin);
            client.ConnectToServer(formLogin);
            //Wait for server response.
            Thread.Sleep(10000);

            //Assert
            Assert.AreEqual(Microsoft.AspNet.SignalR.Client.ConnectionState.Connected, client.Connection.State);
            
            //Close server to avoid conflict with other tests.
            server.CloseServer();
        }

        /// <summary>
        /// Test whether client can disconnect from server properly.
        /// </summary>
        [TestMethod]
        public void Disconnect_ServerIsUp_ClientProperlyClosesConnection()
        {
            //Arrange
            var client = new Client("a");
            var server = new Server("admin");
            var formLogin = new FormLogin();

            //Action
            server.StartServer(formLogin);
            client.ConnectToServer(formLogin);
            //Wait for server response.
            Thread.Sleep(10000);
            client.Disconnect();

            //Assert
            Assert.AreEqual(Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected, client.Connection.State);

            //Close server to avoid conflict with other tests.
            server.CloseServer();
        }

        /// <summary>
        /// Test whether client behaves properly when disconnecting without making previous connection.
        /// </summary>
        [TestMethod]
        public void Disconnect_ServerIsDown_ClientImmediatelyClosesConnectionWhichIsInConnectingState()
        {
            //Arrange
            var client = new Client("a");
            var formLogin = new FormLogin();

            //Action
            client.ConnectToServer(formLogin);
            client.Disconnect();

            //Assert
            Assert.AreEqual(Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected, client.Connection.State);
        }
    }
}
