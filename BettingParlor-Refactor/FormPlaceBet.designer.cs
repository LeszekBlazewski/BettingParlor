namespace BettingParlor_Refactor
{
    partial class FormPlaceBet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPlaceBet = new System.Windows.Forms.Button();
            this.labelBet = new System.Windows.Forms.Label();
            this.numericUpDownBetValue = new System.Windows.Forms.NumericUpDown();
            this.labelBetDog = new System.Windows.Forms.Label();
            this.numericUpDownDogNumber = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBetValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDogNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlaceBet
            // 
            this.buttonPlaceBet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPlaceBet.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonPlaceBet.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlaceBet.Location = new System.Drawing.Point(122, 80);
            this.buttonPlaceBet.Name = "buttonPlaceBet";
            this.buttonPlaceBet.Size = new System.Drawing.Size(110, 40);
            this.buttonPlaceBet.TabIndex = 0;
            this.buttonPlaceBet.Text = "Place Bet";
            this.buttonPlaceBet.UseVisualStyleBackColor = false;
            this.buttonPlaceBet.Click += new System.EventHandler(this.buttonPlaceBet_Click);
            // 
            // labelBet
            // 
            this.labelBet.AutoSize = true;
            this.labelBet.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelBet.Location = new System.Drawing.Point(12, 9);
            this.labelBet.Name = "labelBet";
            this.labelBet.Size = new System.Drawing.Size(62, 38);
            this.labelBet.TabIndex = 1;
            this.labelBet.Text = "Bet";
            // 
            // numericUpDownBetValue
            // 
            this.numericUpDownBetValue.DecimalPlaces = 2;
            this.numericUpDownBetValue.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.numericUpDownBetValue.Location = new System.Drawing.Point(80, 7);
            this.numericUpDownBetValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownBetValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBetValue.Name = "numericUpDownBetValue";
            this.numericUpDownBetValue.Size = new System.Drawing.Size(100, 45);
            this.numericUpDownBetValue.TabIndex = 2;
            this.numericUpDownBetValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelBetDog
            // 
            this.labelBetDog.AutoSize = true;
            this.labelBetDog.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelBetDog.Location = new System.Drawing.Point(186, 9);
            this.labelBetDog.Name = "labelBetDog";
            this.labelBetDog.Size = new System.Drawing.Size(249, 38);
            this.labelBetDog.TabIndex = 3;
            this.labelBetDog.Text = "$ on dog number:";
            // 
            // numericUpDownDogNumber
            // 
            this.numericUpDownDogNumber.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.numericUpDownDogNumber.Location = new System.Drawing.Point(440, 7);
            this.numericUpDownDogNumber.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownDogNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDogNumber.Name = "numericUpDownDogNumber";
            this.numericUpDownDogNumber.Size = new System.Drawing.Size(100, 45);
            this.numericUpDownDogNumber.TabIndex = 0;
            this.numericUpDownDogNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(285, 80);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 40);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonPlaceBet_Click);
            // 
            // FormPlaceBet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(552, 236);
            this.ControlBox = false;
            this.Controls.Add(this.labelBetDog);
            this.Controls.Add(this.numericUpDownDogNumber);
            this.Controls.Add(this.numericUpDownBetValue);
            this.Controls.Add(this.labelBet);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPlaceBet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(568, 275);
            this.MinimumSize = new System.Drawing.Size(568, 275);
            this.Name = "FormPlaceBet";
            this.Text = "Place a bet";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBetValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDogNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlaceBet;
        private System.Windows.Forms.Label labelBet;
        private System.Windows.Forms.NumericUpDown numericUpDownBetValue;
        private System.Windows.Forms.Label labelBetDog;
        private System.Windows.Forms.NumericUpDown numericUpDownDogNumber;
        private System.Windows.Forms.Button buttonCancel;
    }
}