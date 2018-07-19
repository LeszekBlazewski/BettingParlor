using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingParlor_Refactor.UnitTests
{
    /// <summary>
    /// Contains test related to <see cref="Server"/> class.
    /// </summary>
    /// <remarks>
    /// Checks whether server is hosted properly.
    /// </remarks>
    [TestClass]
    public class ServerTests
    {
        /// <summary>
        /// Test whether server can be hosted on specified URL.
        /// </summary>
        [TestMethod]
        public void StartServer_NoOtherServerOnTheSameUrlIsRunning_ServerIsStarted()
        {
            //Arrange
            var server = new Server("admin");
            var formLogin = new FormLogin();

            //Action
            server.StartServer(formLogin);

            //Assert
            Assert.IsNotNull(server.SignalR);

            //Close server to avoid conflict with other tests
            server.CloseServer();
        }

        /// <summary>
        /// Test whether server can be hosted on URL where other server is already running.
        /// </summary>
        [TestMethod]
        public void StartServer_ServerIsAlreadyRunningOnSpecifiedUrl_ServerDoesNotStart()
        {
            //Arrange
            var serverWhichIsRun = new Server("admin");
            var serverWhichTriesToRunOnSameUrl = new Server("admin2");
            var formLogin = new FormLogin();

            //Action
            //Showing form is neccessary to create window handle which is used in changing labelStatus
            //on formlogin when second server tries to run on same url.
            formLogin.Show();
            serverWhichIsRun.StartServer(formLogin);
            serverWhichTriesToRunOnSameUrl.StartServer(formLogin);

            //Assert
            Assert.AreEqual("Server failed to start.\nA server is already running on " + serverWhichTriesToRunOnSameUrl.GetServerUrl, formLogin.labelStatusText.Text);
        }
    }
}
