using System;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Represents a window which allows each user to sign in into his account or create new one.
    /// All loggin and registration functions are called from this form.
    /// </summary>
    public partial class FormLogin : Form
    {
        /// <summary>
        /// Initializes properly the form.
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Controller which handles login and registration process to database.
        /// </summary>
        /// <remarks> All connections to database related to loggin and registration process are established in this object.</remarks>
        Login login = new Login();         

        /// <summary>
        /// Property used by FormClient to get a reference to this form. Allows displaying this window again when client signs out.
        /// </summary>
        public Form RefToFormMain { get; set; }

        /// <summary>
        /// Enum used to manage easily the process of showing information to client about operation he requested.
        /// </summary>
        public enum Result
        {
            /// <summary>
            /// Specifies that registration process was successful.
            /// </summary>
            /// <remarks> Client created account successful.</remarks>
            RegistrationSuccessful,

            /// <summary>
            /// Specifies that registration process failed.
            /// </summary>
            /// <remarks> Client tried to create account with username which is already used by another player.</remarks>
            RegistrationFailed,

            /// <summary>
            /// Specifies that login process was successful.
            /// </summary>
            /// <remarks> User inserted validate credentials and logged into his account.</remarks>
            LoginToDataBaseSuccessful,

            /// <summary>
            /// Specifies that login process failed.
            /// </summary>
            /// <remarks> User inserted wrong credentials and his loggin was aborted.</remarks>
            LoginToDataBaseFailed,
        }

        /// <summary>
        /// Clears textboxes with username and password to protect client privacy.
        /// </summary>
        /// <remarks>
        /// Called whenever client connectes to server or client enters wrong credentials.
        /// </remarks>
        private void ClearControls()
        {
            labelStatusText.Text = String.Empty;
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }

        /// <summary>
        /// Enables player to log into his account.
        /// Verification of credentials is handled in <see cref="Login"/> class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> When verification passes window with game opens.</remarks>
        private void ButtonLogin_Click(object sender, EventArgs e)

        {
            if(login.LogInToExistingAccount(textBoxUsername.Text, textBoxPassword.Text,this))
            {
                string userName = textBoxUsername.Text;

                if (userName == "admin")            //check if admin signed in 
                {
                    Server server = new Server(userName);
                    server.StartServer(this);
                }
                else
                {
                    Client client = new Client(userName);
                    client.ConnectToServer(this);
                }
            }
            else
                ClearControls();
        }

        /// <summary>
        /// Enables player to create new account.
        /// Creating new account in database is handle in <see cref="Login"/> class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            login.RegisterNewPlayer(textBoxUsername.Text, textBoxPassword.Text,this);
            ClearControls();
        }

        /// <summary>
        /// Creates new game window and initializes it with object of current client.
        /// </summary>
        /// <param name="client">Object of client which connects to the server.</param>
        /// <remarks>
        /// Must be executed after try-catch statement in <see cref="Client"/> class.
        /// </remarks>
        public void StartGameWindowClient(Client client)
        { 
            ClearControls();
            this.Hide();
            FormClient formClient = new FormClient(client)
            {
                RefToFormLogin = this
            };
            formClient.Show(); 
        }

        /// <summary>
        /// Creates new game window and initializes it with object of server which stores admin data.
        /// </summary>
        /// <param name="server"></param>
        /// <remarks>
        /// Must be executed after try-catch statement in <see cref="Server"/> class.
        /// </remarks>
        public void StartGameWindowServer(Server server)
        {
            ClearControls();
            this.Hide();
            FormServer formServer = new FormServer(server)
            {
                RefToFormLogin = this
            };
            formServer.Show();
        }

        /// <summary>
        /// Checks whether textBoxes are empty to avoid checking client credentials when he didn't input anything.
        /// </summary>
        /// <returns>
        /// True if one of textBoxes is empty.
        /// False if both are filled with data.
        /// </returns>
        public bool CheckIfTextBoxesAreEmpty()
        {
            if (string.IsNullOrEmpty(textBoxUsername.Text))
            {
                MessageBox.Show("Please enter a valid Username!", "Error");
                return true;
            }
            else if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter a valid password!", "Error");
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Shows appropiate messageBox to client based on the parameter which is passed in <see cref="Client"/> class durining the registration or loggin process.
        /// </summary>
        /// <param name="result">Result of the operation performed in <see cref="Login"/> class.</param>
        public void ShowResult(Result result)
        {
            switch (result)
            {
                case Result.RegistrationSuccessful:
                    MessageBox.Show("Your account has been created successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Result.RegistrationFailed:
                    MessageBox.Show("This Username is already taken please choose another one  !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case Result.LoginToDataBaseSuccessful:
                    MessageBox.Show("Checking server connection...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case Result.LoginToDataBaseFailed:
                    MessageBox.Show("Invalid login, please check your username and password or register a new account", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    break;
            }
        }

        /// <summary>
        /// Closes the whole application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> Application.Exit() ensures that all windows are closed properly.</remarks>
        private void ButtonExitTheApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Shows again the menu window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> Uses reference to formMain.</remarks>
        private void ButtonBackToMainMenu_Click(object sender, EventArgs e)
        {
            this.RefToFormMain.Show();
            this.Close();
        }
    }
}