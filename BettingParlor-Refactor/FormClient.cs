using System;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Represents a window which is the base graphic interface for each client who managed to connect to server.
    /// Calls methods by the use of controllers after client interacts with the form.
    /// </summary>
    public partial class FormClient : Form
    {
        /// <summary>
        /// Initializes <paramref name="currentClient"/> object with current client and loads up the form.
        /// </summary>
        /// <param name="currentClient">Object which stores current logged in client information.</param>
        public FormClient(Client currentClient)
        {
            InitializeComponent();
            InitializeDogs();
            this.currentClient = currentClient;
            this.currentClient.FormClient = this;
 
        }

        /// <summary>
        /// Property used to get access to logging window after the client signs out.
        /// </summary>
        public Form RefToFormLogin { get; set; }

        /// <summary>
        /// Used to access chat console in <see cref="Client"/> class to add new messages on server response.
        /// </summary>
        public RichTextBox GetRichTextBoxConsole => richTextBoxConsole;

        /// <summary>
        /// Array of four dog objects.
        /// </summary>
        /// <remarks>Contains dog objects which are responsible for moving pictureBoxes on the form.</remarks>
        GreyHound[] DogArray = new GreyHound[4];     

        /// <summary>
        /// Stores currently logged in client object.
        /// </summary>
        /// <remarks>Contains Client data and methods which are user to perform basic operation.</remarks>
        Client currentClient;

        /// <summary>
        /// Form used to get input from user - dog on which bet is placed and value of bet.
        /// </summary>
        FormPlaceBet formPlaceBet = new FormPlaceBet(); 

        #region DogPictureBoxs initialization
        /// <summary>
        /// Function assigns dog objects to their controls on the form.
        /// </summary>
        private void InitializeDogs()
        {
            Random randomizer = new Random();
            int raceTrackLenght = pictureBoxRaceTrack.Width - pictureBoxDog1.Width;

            DogArray[0] = new GreyHound(raceTrackLenght, pictureBoxDog1, randomizer);
            DogArray[1] = new GreyHound(raceTrackLenght, pictureBoxDog2, randomizer);
            DogArray[2] = new GreyHound(raceTrackLenght, pictureBoxDog3, randomizer);
            DogArray[3] = new GreyHound(raceTrackLenght, pictureBoxDog4, randomizer);
        }
        #endregion

        /// <summary>
        /// Sends request to server to place bet in current user object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPlaceBet_Click(object sender, EventArgs e)
        {    
            DialogResult dialogResult = formPlaceBet.ShowDialog();  //show form as dialog to get user input.

            if (dialogResult == DialogResult.OK)
            {
                decimal betValue = formPlaceBet.NumericUpDownBetValue.Value;
                int dogToWin = (int)formPlaceBet.NumericUpDownDogNumber.Value;

                currentClient.PlaceMyBetOnServer(betValue, dogToWin, true);
                currentClient.UpdateMyLabelOnTheForm();
            }
            else if (dialogResult == DialogResult.Cancel)
                formPlaceBet.Hide();
        }

        /// <summary>
        /// Function is responsible for placing a handicap which is sent to server and shows equivalent result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHandicap_Click(object sender, EventArgs e)
        {
            decimal handicapValue = numericUpDownHandiCapValue.Value;
            int dogToWin = (int)numericUpDownDogToWin.Value;

            currentClient.PlaceMyBetOnServer(handicapValue, dogToWin, false);
            currentClient.UpdateMyLabelOnTheForm();
        }

        /// <summary>
        /// Called on client side in <see cref="Client"/> class when he receives information whether his bet has been placed or not.
        /// </summary>
        /// <param name="result">Result whether the bet has been placed or not.</param>
        /// <remarks> Must be public because it's called in client Class on server response.</remarks>
        public void ShowResultBet(bool result)
        {
            formPlaceBet.ShowResultMessageBet(result);
        }

        /// <summary>
        /// Sends request to server to add cash to current calling client object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Sends request to server and on response in <see cref="Client"/> class updates label on form.</remarks>
        private void ButtonAddCash_Click(object sender, EventArgs e)
        {             
            using (FormAddCash formAddCash = new FormAddCash())             //Form used to add cash to user account.
            {
                DialogResult dialogResult = formAddCash.ShowDialog();       //show form as dialog to get user input.
                if (dialogResult == DialogResult.Cancel)
                {
                    formAddCash.Close();
                }
                else if (dialogResult == DialogResult.OK)
                {
                    decimal moneyTransfer = formAddCash.NumericUpDown.Value;
                    currentClient.AddCashToMyAccountOnServer(moneyTransfer);
                    currentClient.UpdateMyLabelOnTheForm();
                }
            }
        }

        /// <summary>
        /// Closes gamewindow and opens login form again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Calls <see cref="Client.Disconnect"/> method to properly close the connection.</remarks>
        private void ButtonSignOut_Click(object sender, EventArgs e)
        {
            currentClient.Disconnect();
            this.Close();                
            this.RefToFormLogin.Show();
        }

        /// <summary>
        /// Sends message to all connected clients.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Sends the message to server which passess received data to all connected players.</remarks>
        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxMessage.Text))
            {
                currentClient.SendMessageToAllPlayers(textBoxMessage.Text);
                textBoxMessage.Text = String.Empty;
            }
        }

        /// <summary>
        /// Updates dataGriedView on the form to display changes which were made to dataBase - new bets were added or table was reseted.
        /// </summary>
        /// <remarks>Uses LINQ adapter which has basic SQL queries.
        /// For more inforamtion check LINGQ TO SQL documentation.</remarks>
        public void UpdateDataGriedView()
        {
            currentBetsTableAdapter.Fill(bettingParlorDataSet.CurrentBets);
        }

        /// <summary>
        /// Gets the current account balance from server and updates the label.
        /// </summary>
        /// <param name="saldo"> Amount of cash which client has returned by server.</param>
        /// <remarks>.ToString("F") is used to display money value correctly. For more information check Microsoft standard Numeric Format String documentation.</remarks>
        public void UpdateCurrentAccountBalanceLabel(decimal saldo)
        {
            labelPlayerCurrentAccountBalance.Text = "Your saldo \n" + saldo.ToString("F") + "$";
        }

        /// <summary>
        /// Displays message which informs client which dog won and resets the UI to display proper buttons.
        /// Updates client label on the form to display his account balance after the race.
        /// Resets dogs position.
        /// </summary>
        /// <param name="dogWinner">Number of dog which won the race.</param>
        /// <remarks>
        /// Function is public because it's called on client side on server response.
        /// </remarks>
        public void HandleControlsAfterRaceHasFinished(int dogWinner)
        {
            MessageBox.Show("Dog number #" + dogWinner + "has won the race !", " RESULTS ! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            currentClient.UpdateMyLabelOnTheForm();
            UpdateDataGriedView();                  //table in SQL is reseted so update dataGriedView to display blank table.
            panelHandicap.Visible = false;
            panelHandicap.Enabled = true;
            buttonPlaceBet.Enabled = true;
            buttonSignOut.Enabled = true;
            labelRaceStatus.Visible = false;

            //Resets the position of each dog to default.
            foreach (var dog in DogArray)
            {
                dog.TakeStartingPosition();
            }
        }

        /// <summary>
        /// Called on client side to prepare the GUI for the race.
        /// </summary>
        /// <remarks> Must be public because function is called on server response to prepare the GUI for race.</remarks>
        public void EnableControlsOnRaceStart()
        {
            panelHandicap.Visible = true;
            buttonPlaceBet.Enabled = false;
            buttonSignOut.Enabled = false;
        }

        /// <summary>
        /// Disables handicap related buttons to prevent placing bets by users.
        /// Called on server response in <see cref="Client"/> class.
        /// </summary>
        public void DisableHandicapPanel()
        {
            panelHandicap.Enabled = false;
        }

        /// <summary>
        /// Moves dogs on clientApplication (Called from client side when server sends information about current location of each dog).
        /// </summary>
        /// <param name="dogNumber">Number of dog which Run method should be executed.</param>
        /// <param name="location">Location of dog pictureBox on server passed to move equivalent dog to same location on client form.</param>
        /// <remarks> Must be public because it's called in <see cref="Client"/> class.
        /// Movement is not random !
        /// </remarks>
        public void MoveDogsOnClientForm(int dogNumber, int location)
        {
            DogArray[dogNumber].RunOnClientForm(location);
        }

        /// <summary>
        /// Disables option to log out after client has placed bet.
        /// Shows label on form which informs client to wait until race ends to be able to sign out.
        /// </summary>
        public void DisableSignOutOptionAfterPlacingStandardBet()
        {
            buttonPlaceBet.Enabled = false;
            buttonSignOut.Enabled = false;
            labelRaceStatus.Visible = true;
        }

        /// <summary>
        /// Function is executed shortly after form is created.
        /// Ensures that label shows current account balance of player which signed in and updates dataGriedView to display other clients bets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClient_Load(object sender, EventArgs e)
        {
            currentClient.UpdateMyLabelOnTheForm();
            UpdateDataGriedView();
        }
    }
}
