using System;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Represents a window which is the base graphic interface for administrator who handles all the operations.
    /// </summary>
    /// <seealso cref="FormClient"/>
    public partial class FormServer : Form
    {
        /// <summary>
        /// Initializes the form and the server object.
        /// </summary>
        /// <param name="server">Object which stores admin data.</param>
        /// <remarks>Server object is necessary to close server properly.</remarks>
        public FormServer(Server server)
        {
            InitializeComponent();
            InitializeDogs();
            this.server = server;
            ClientServerConnectionsHub.FormServer = this;      //Pass formserver to access admin console on server form (update chat log).
            administrator = new Parlor(server.GetAdminName, ClientServerConnectionsHub.GetAdminAccountBalance(server.GetAdminName));
        }

        /// <summary>
        /// Reference to form login.
        /// </summary>
        /// <remarks>Used to show logging form again after admin signs out.</remarks>
        public Form RefToFormLogin { get; set; }                       

        /// <summary>
        ///  Used to access chat log in <see cref="ClientServerConnectionsHub"/> class to add client information to admin console whenever client connects.
        /// </summary>
        public RichTextBox GetRichTextBoxConsole => richTextBoxConsole;

        /// <summary>
        /// Form used to get input from administrator - dog on which bet is placed and value of bet.
        /// </summary>
        FormPlaceBet formPlaceBet = new FormPlaceBet();

        /// <summary>
        /// Array of four dog objects.
        /// </summary>
        /// <remarks>Contains dog objects which are responsible for moving pictureBoxes on the form.</remarks>
        GreyHound[] DogArray = new GreyHound[4];

        int counterHandicapPanelDeactivate;       //stores the amount of time which passed from the beginning of the race ( to be able to disable handicap panel on time).

        /// <summary>
        /// Responisble for calling all methods to interact with clients.
        /// </summary>
        Parlor administrator;

        /// <summary>
        /// Used to shut down server properly when administrator signs out.
        /// </summary>
        Server server;        

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
        /// Updates dataGriedView on the form to display changes which were made to dataBase - new bets were added or table was reseted.
        /// </summary>
        /// <remarks>Uses LINQ adapter which has basic SQL queries.
        /// For more inforamtion check LINGQ documentation.</remarks>
        public void UpdateDataGriedView()
        {
            currentBetsTableAdapter.Fill(bettingParlorDataSet.CurrentBets);
        }


        /// <summary>
        /// Gets the current account balance of administrator and updates his label to show current account balance.
        /// </summary>
        /// <remarks>.ToString("F") is used to display money value correctly. For more information check Microsoft standard Numeric Format String documentation.</remarks>
        public void UpdateCurrentAccountBalanceLabel()
        {
            labelPlayerCurrentAccountBalance.Text = "Your saldo \n" + administrator.UpdateAdminCashLabel().ToString("F") + "$";
        }

        /// <summary>
        /// Responsible for calling dog run method on each tick to move dogs on the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerRaceTime_Tick(object sender, EventArgs e)
        {
            counterHandicapPanelDeactivate++;                       //counter is increased with every tick to disable handicap after certain amount of time.

            if (counterHandicapPanelDeactivate >= 300)
            {
                administrator.SendNotificationAboutTheRace("disable handicap");     //send notification to all clients that handicap panel must be disabled.
                panelHandicap.Enabled = false;                                      //disable handicap on administrator form.
            }

            for (int i = 0; i < DogArray.Length; i++)
            {
                if (DogArray[i].Run())
                {
                    timerRaceTime.Stop();
                    MessageBox.Show("Dog number #" + (i + 1) + "has won the race !", " RESULTS ! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    administrator.CollectBet(i+1);
                    administrator.UpdateUserFormOnRaceEnd(i + 1);

                    UpdateCurrentAccountBalanceLabel();
                    DisableControlsOnRaceEnd();
                }
                else
                {
                    administrator.SendDogsLocationToUsers(i,DogArray[i].GetLocation);
                }
            }
        }

        /// <summary>
        /// Sets the GUI for race and resets the counter for each race.
        /// </summary>
        private void EnableControlsOnRaceStart()
        {
            counterHandicapPanelDeactivate = timerRaceTime.Interval;    //set counter value before race starts to interval of timer (reset value before each race).
            panelHandicap.Visible = true;
            buttonPlaceBet.Enabled = false;
            buttonSignOut.Enabled = false;
        }

        /// <summary>
        /// Starts the race on the server form and sends notification to clients to prepare their forms for the race.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartRace_Click(object sender, EventArgs e)
        {
            administrator.SendNotificationAboutTheRace("race begins");
            EnableControlsOnRaceStart();
            timerRaceTime.Start();
        }

        /// <summary>
        /// Mantains GUI after the race has been finished.
        /// </summary>
        private void DisableControlsOnRaceEnd()
        {
            UpdateDataGriedView();
            panelHandicap.Visible = false;
            panelHandicap.Enabled = true;
            buttonPlaceBet.Enabled = true;
            buttonSignOut.Enabled = true;

            foreach (var dog in DogArray)
            {
                dog.TakeStartingPosition();         //Resets the position of each dog to default.
            }
        }

        /// <summary>
        /// Places bet in admin object and sends it to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPlaceBet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = formPlaceBet.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                decimal betValue = formPlaceBet.NumericUpDownBetValue.Value;
                int dogToWin = (int)formPlaceBet.NumericUpDownDogNumber.Value;

                if (administrator.Cash >= betValue)
                {
                    administrator.PlaceBet(BetFactory.BetSort.standartBet, betValue, dogToWin);
                    UpdateDataGriedView();
                    UpdateCurrentAccountBalanceLabel();
                    formPlaceBet.ShowResultMessageBet(true);
                    buttonPlaceBet.Enabled = false;
                }
                else
                    formPlaceBet.ShowResultMessageBet(false);
            }
            else if (dialogResult == DialogResult.Cancel)
                formPlaceBet.Hide();          
        }

        /// <summary>
        /// Allows administrator to place handicap bet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHandicap_Click(object sender, EventArgs e)
        {
            decimal handicapValue = numericUpDownHandiCapValue.Value;
            int dogToWin = (int)numericUpDownDogToWin.Value;

            if (administrator.Cash >= handicapValue)
            {
                administrator.PlaceBet(BetFactory.BetSort.handicapBet, handicapValue, dogToWin);
                UpdateDataGriedView();
                UpdateCurrentAccountBalanceLabel();
                panelHandicap.Enabled = false;             
                formPlaceBet.ShowResultMessageBet(true);
            }
            else
                formPlaceBet.ShowResultMessageBet(false);
        }

        /// <summary>
        /// Allows administrator to add cash to his account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddCash_Click(object sender, EventArgs e)
        {
            using (FormAddCash formAddCash = new FormAddCash())
            {
                DialogResult dialogResult = formAddCash.ShowDialog();

                if (dialogResult == DialogResult.Cancel)
                {
                    formAddCash.Close();
                }
                else if (dialogResult == DialogResult.OK)
                {
                    decimal moneyTransfer = formAddCash.NumericUpDown.Value;

                    administrator.AddCashToMyAccount(moneyTransfer);
                    UpdateCurrentAccountBalanceLabel();
                }
            }
        }

        /// <summary>
        /// Ensures that server is closed properly after administrator signs out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <seealso cref="Server.CloseServer"/>
        private void ButtonSignOut_Click(object sender, EventArgs e)
        {
            server.CloseServer();
            this.Close();                
            this.RefToFormLogin.Show();
        }

        /// <summary>
        /// Function is executed shortly after form is created.
        /// Ensures that label shows current account balance of administrator and updates dataGriedView to display client bets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormServer_Load(object sender, EventArgs e)
        {
            administrator.PlaceBet(BetFactory.BetSort.dummyBet, 0, 0);          //Admin signs in only ONCE because he runs the server, place dummy bet to prevent null exception when collecting bets.
            UpdateCurrentAccountBalanceLabel();                                 //used to display current account balance in label for administrator.
            UpdateDataGriedView();                                              //In case some bets are stored in dataBase display them to admin to allow him to clear them before other clients connect.
        }

        /// <summary>
        /// Function is called in <see cref="ClientServerConnectionsHub"/> class whenever client is connecting to server to check if race is on.
        /// </summary>
        /// <returns>
        /// True if race is in progress.
        /// False when administrator has not started the race yet.
        /// </returns>
        /// <remarks> There shouldn't be situation where client joins the game and the race has been already started.
        /// Returend result is used to specify whether client connection should be blocked or not.</remarks>
        public bool CheckIfRaceIsOn()
        {
            if (timerRaceTime.Enabled)
                return true;

            return false;
        }
    }
}
