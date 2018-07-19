using System.Windows.Forms;

namespace BettingParlor_Refactor
{
    /// <summary>
    /// Contains only one label which describes the rules of the game.
    /// </summary>
    /// <see cref="FormMenu"/>
    public partial class FormRules : Form
    {
        /// <summary>
        /// Initializes the form properly.
        /// </summary>
        public FormRules()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reference to FormMain used to display menu again after rules are closed.
        /// </summary>
        public Form RefToFormMain { get; set; }

        /// <summary>
        /// Event triggered when user hits close button. 
        /// Displays again the menu window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRules_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.RefToFormMain.Show();
        }
    }
}
