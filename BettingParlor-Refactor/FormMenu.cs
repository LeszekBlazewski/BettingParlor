using System;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Menu where user decides what other forms he wants to see.
    /// Contains button which direct to specific forms.
    /// </summary>
    /// <seealso cref="FormRules"/>
    public partial class FormMenu : Form
    {
        /// <summary>
        ///Iinitializes the form properly.
        /// </summary>
        public FormMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates new form witch allows user to sign in into his account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGameStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.RefToFormMain = this;
            formLogin.Show();
        }

        /// <summary>
        /// Closes whole application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Application.Exit() ensures that all forms are closed properly.</remarks>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Opens new window with rules of the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRules_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRules formRules = new FormRules();
            formRules.RefToFormMain = this;
            formRules.Show();
        }
    }
}
