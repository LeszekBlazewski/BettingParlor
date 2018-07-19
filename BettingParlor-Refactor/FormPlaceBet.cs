using System;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Shown to player only when he wants to place a bet.
    /// Used to get dog number and value of the bet which should be placed.
    /// </summary>
    /// <seealso cref="FormAddCash"/>
    public partial class FormPlaceBet : Form
    {
        /// <summary>
        /// Initializes the form properly.
        /// </summary>
        public FormPlaceBet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the value of the bet which should be placed.
        /// </summary>
        /// <remarks>Used in <see cref="FormClient"/> and <see cref="FormServer"/> to place bet with valid amount.</remarks>
        public NumericUpDown NumericUpDownBetValue => numericUpDownBetValue;

        /// <summary>
        /// Returns dog number on which bet should be placed.
        /// </summary>
        /// <remarks>Used in <see cref="FormClient"/> and <see cref="FormServer"/> to place bet with valid dog number.</remarks>
        public NumericUpDown NumericUpDownDogNumber => numericUpDownDogNumber;

        /// <summary>
        /// Hides the form from user.
        /// Process of placing bet is mantained on server in <see cref="ManageUserData"/> class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlaceBet_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Shows result to player whether he is able to place bet which he requested or not.
        /// </summary>
        /// <param name="result"> Result whether user can place bet he requested or not.</param>
        public void ShowResultMessageBet(bool result)
        {
            if(result)
                MessageBox.Show("Your bet has been placed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Sorry, you do not have enough cash to make this operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
