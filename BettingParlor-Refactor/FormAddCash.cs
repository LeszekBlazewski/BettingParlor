using System;
using System.Windows.Forms;

namespace BettingParlor_Refactor
{
     /// <summary>
     /// Represents a dialogbox which is used to get the amount of cash which player wants to tranfer to his account.
     /// </summary>
    public partial class FormAddCash : Form
    {
        /// <summary>
        /// Initializes the form properly.
        /// </summary>
        public FormAddCash()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Getter used to access the control in formClient and formServer to get the amount of money which should be transfered.
        /// </summary>
        public NumericUpDown NumericUpDown { get => numericUpDownAddCash;}

        /// <summary>
        /// Displays information to user about the progress of cash transfer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Operation succeded", "Transfer...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// Closes the form when user cancels his transfer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
