namespace BettingParlor_Refactor
{
    partial class FormClient
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
            this.components = new System.ComponentModel.Container();
            this.labelChat = new System.Windows.Forms.Label();
            this.buttonHandicap = new System.Windows.Forms.Button();
            this.labelPlaceHandicap = new System.Windows.Forms.Label();
            this.labelRules = new System.Windows.Forms.Label();
            this.numericUpDownDogToWin = new System.Windows.Forms.NumericUpDown();
            this.labelDogNumber = new System.Windows.Forms.Label();
            this.labelSignDolar = new System.Windows.Forms.Label();
            this.numericUpDownHandiCapValue = new System.Windows.Forms.NumericUpDown();
            this.labelRaceStatus = new System.Windows.Forms.Label();
            this.richTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.panelHandicap = new System.Windows.Forms.Panel();
            this.dataGridViewCurrentBetts = new System.Windows.Forms.DataGridView();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bettorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountBetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dogToWinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentBetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bettingParlorDataSet = new BettingParlor_Refactor.BettingParlorDataSet();
            this.buttonSignOut = new System.Windows.Forms.Button();
            this.buttonPlaceBet = new System.Windows.Forms.Button();
            this.labelCurrentBets = new System.Windows.Forms.Label();
            this.labelPlayerCurrentAccountBalance = new System.Windows.Forms.Label();
            this.buttonAddCash = new System.Windows.Forms.Button();
            this.pictureBoxDog4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDog3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDog2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDog1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxRaceTrack = new System.Windows.Forms.PictureBox();
            this.currentBetsTableAdapter = new BettingParlor_Refactor.BettingParlorDataSetTableAdapters.CurrentBetsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDogToWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHandiCapValue)).BeginInit();
            this.panelHandicap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentBetts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentBetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bettingParlorDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDog4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDog3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDog2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRaceTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // labelChat
            // 
            this.labelChat.AutoSize = true;
            this.labelChat.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelChat.Location = new System.Drawing.Point(267, 664);
            this.labelChat.Name = "labelChat";
            this.labelChat.Size = new System.Drawing.Size(78, 38);
            this.labelChat.TabIndex = 39;
            this.labelChat.Text = "Chat";
            // 
            // buttonHandicap
            // 
            this.buttonHandicap.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.buttonHandicap.Location = new System.Drawing.Point(290, 16);
            this.buttonHandicap.Name = "buttonHandicap";
            this.buttonHandicap.Size = new System.Drawing.Size(102, 44);
            this.buttonHandicap.TabIndex = 9;
            this.buttonHandicap.Text = "Handicap";
            this.buttonHandicap.UseVisualStyleBackColor = true;
            this.buttonHandicap.Click += new System.EventHandler(this.ButtonHandicap_Click);
            // 
            // labelPlaceHandicap
            // 
            this.labelPlaceHandicap.AutoSize = true;
            this.labelPlaceHandicap.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.labelPlaceHandicap.Location = new System.Drawing.Point(3, 27);
            this.labelPlaceHandicap.Name = "labelPlaceHandicap";
            this.labelPlaceHandicap.Size = new System.Drawing.Size(49, 23);
            this.labelPlaceHandicap.TabIndex = 11;
            this.labelPlaceHandicap.Text = "Place";
            // 
            // labelRules
            // 
            this.labelRules.AutoSize = true;
            this.labelRules.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.labelRules.Location = new System.Drawing.Point(49, 63);
            this.labelRules.Name = "labelRules";
            this.labelRules.Size = new System.Drawing.Size(307, 23);
            this.labelRules.TabIndex = 16;
            this.labelRules.Text = "Read rules before placing a handicap !";
            // 
            // numericUpDownDogToWin
            // 
            this.numericUpDownDogToWin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownDogToWin.Location = new System.Drawing.Point(226, 23);
            this.numericUpDownDogToWin.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownDogToWin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDogToWin.Name = "numericUpDownDogToWin";
            this.numericUpDownDogToWin.Size = new System.Drawing.Size(58, 30);
            this.numericUpDownDogToWin.TabIndex = 14;
            this.numericUpDownDogToWin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelDogNumber
            // 
            this.labelDogNumber.AutoSize = true;
            this.labelDogNumber.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.labelDogNumber.Location = new System.Drawing.Point(161, 25);
            this.labelDogNumber.Name = "labelDogNumber";
            this.labelDogNumber.Size = new System.Drawing.Size(59, 23);
            this.labelDogNumber.TabIndex = 13;
            this.labelDogNumber.Text = "on dog";
            // 
            // labelSignDolar
            // 
            this.labelSignDolar.AutoSize = true;
            this.labelSignDolar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.labelSignDolar.Location = new System.Drawing.Point(134, 25);
            this.labelSignDolar.Name = "labelSignDolar";
            this.labelSignDolar.Size = new System.Drawing.Size(21, 23);
            this.labelSignDolar.TabIndex = 12;
            this.labelSignDolar.Text = "$";
            // 
            // numericUpDownHandiCapValue
            // 
            this.numericUpDownHandiCapValue.DecimalPlaces = 2;
            this.numericUpDownHandiCapValue.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownHandiCapValue.Location = new System.Drawing.Point(58, 23);
            this.numericUpDownHandiCapValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownHandiCapValue.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownHandiCapValue.Name = "numericUpDownHandiCapValue";
            this.numericUpDownHandiCapValue.Size = new System.Drawing.Size(70, 30);
            this.numericUpDownHandiCapValue.TabIndex = 10;
            this.numericUpDownHandiCapValue.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // labelRaceStatus
            // 
            this.labelRaceStatus.AutoSize = true;
            this.labelRaceStatus.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.labelRaceStatus.Location = new System.Drawing.Point(147, 621);
            this.labelRaceStatus.Name = "labelRaceStatus";
            this.labelRaceStatus.Size = new System.Drawing.Size(336, 23);
            this.labelRaceStatus.TabIndex = 40;
            this.labelRaceStatus.Text = "Please wait till the race ends to sign out.";
            this.labelRaceStatus.Visible = false;
            // 
            // richTextBoxConsole
            // 
            this.richTextBoxConsole.Location = new System.Drawing.Point(109, 731);
            this.richTextBoxConsole.Name = "richTextBoxConsole";
            this.richTextBoxConsole.ReadOnly = true;
            this.richTextBoxConsole.Size = new System.Drawing.Size(403, 115);
            this.richTextBoxConsole.TabIndex = 38;
            this.richTextBoxConsole.Text = "";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(437, 702);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 37;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(109, 705);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(322, 20);
            this.textBoxMessage.TabIndex = 36;
            // 
            // panelHandicap
            // 
            this.panelHandicap.Controls.Add(this.labelRules);
            this.panelHandicap.Controls.Add(this.buttonHandicap);
            this.panelHandicap.Controls.Add(this.labelPlaceHandicap);
            this.panelHandicap.Controls.Add(this.numericUpDownDogToWin);
            this.panelHandicap.Controls.Add(this.numericUpDownHandiCapValue);
            this.panelHandicap.Controls.Add(this.labelDogNumber);
            this.panelHandicap.Controls.Add(this.labelSignDolar);
            this.panelHandicap.Location = new System.Drawing.Point(109, 409);
            this.panelHandicap.Name = "panelHandicap";
            this.panelHandicap.Size = new System.Drawing.Size(403, 100);
            this.panelHandicap.TabIndex = 34;
            this.panelHandicap.Visible = false;
            // 
            // dataGridViewCurrentBetts
            // 
            this.dataGridViewCurrentBetts.AllowUserToAddRows = false;
            this.dataGridViewCurrentBetts.AllowUserToDeleteRows = false;
            this.dataGridViewCurrentBetts.AutoGenerateColumns = false;
            this.dataGridViewCurrentBetts.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridViewCurrentBetts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCurrentBetts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.bettorNameDataGridViewTextBoxColumn,
            this.amountBetDataGridViewTextBoxColumn,
            this.dogToWinDataGridViewTextBoxColumn});
            this.dataGridViewCurrentBetts.DataSource = this.currentBetsBindingSource;
            this.dataGridViewCurrentBetts.Location = new System.Drawing.Point(109, 253);
            this.dataGridViewCurrentBetts.Name = "dataGridViewCurrentBetts";
            this.dataGridViewCurrentBetts.ReadOnly = true;
            this.dataGridViewCurrentBetts.RowHeadersVisible = false;
            this.dataGridViewCurrentBetts.Size = new System.Drawing.Size(403, 150);
            this.dataGridViewCurrentBetts.TabIndex = 28;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bettorNameDataGridViewTextBoxColumn
            // 
            this.bettorNameDataGridViewTextBoxColumn.DataPropertyName = "Bettor name";
            this.bettorNameDataGridViewTextBoxColumn.HeaderText = "Bettor name";
            this.bettorNameDataGridViewTextBoxColumn.Name = "bettorNameDataGridViewTextBoxColumn";
            this.bettorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountBetDataGridViewTextBoxColumn
            // 
            this.amountBetDataGridViewTextBoxColumn.DataPropertyName = "Amount bet";
            this.amountBetDataGridViewTextBoxColumn.HeaderText = "Amount bet";
            this.amountBetDataGridViewTextBoxColumn.Name = "amountBetDataGridViewTextBoxColumn";
            this.amountBetDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dogToWinDataGridViewTextBoxColumn
            // 
            this.dogToWinDataGridViewTextBoxColumn.DataPropertyName = "Dog to win";
            this.dogToWinDataGridViewTextBoxColumn.HeaderText = "Dog to win";
            this.dogToWinDataGridViewTextBoxColumn.Name = "dogToWinDataGridViewTextBoxColumn";
            this.dogToWinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentBetsBindingSource
            // 
            this.currentBetsBindingSource.DataMember = "CurrentBets";
            this.currentBetsBindingSource.DataSource = this.bettingParlorDataSet;
            // 
            // bettingParlorDataSet
            // 
            this.bettingParlorDataSet.DataSetName = "BettingParlorDataSet";
            this.bettingParlorDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonSignOut
            // 
            this.buttonSignOut.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignOut.Location = new System.Drawing.Point(486, 541);
            this.buttonSignOut.Name = "buttonSignOut";
            this.buttonSignOut.Size = new System.Drawing.Size(102, 44);
            this.buttonSignOut.TabIndex = 32;
            this.buttonSignOut.Text = "Sign out";
            this.buttonSignOut.UseVisualStyleBackColor = true;
            this.buttonSignOut.Click += new System.EventHandler(this.ButtonSignOut_Click);
            // 
            // buttonPlaceBet
            // 
            this.buttonPlaceBet.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlaceBet.Location = new System.Drawing.Point(222, 541);
            this.buttonPlaceBet.Name = "buttonPlaceBet";
            this.buttonPlaceBet.Size = new System.Drawing.Size(102, 44);
            this.buttonPlaceBet.TabIndex = 31;
            this.buttonPlaceBet.Text = "Place bet";
            this.buttonPlaceBet.UseVisualStyleBackColor = true;
            this.buttonPlaceBet.Click += new System.EventHandler(this.ButtonPlaceBet_Click);
            // 
            // labelCurrentBets
            // 
            this.labelCurrentBets.AutoSize = true;
            this.labelCurrentBets.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelCurrentBets.Location = new System.Drawing.Point(215, 212);
            this.labelCurrentBets.Name = "labelCurrentBets";
            this.labelCurrentBets.Size = new System.Drawing.Size(185, 38);
            this.labelCurrentBets.TabIndex = 30;
            this.labelCurrentBets.Text = "Current bets";
            // 
            // labelPlayerCurrentAccountBalance
            // 
            this.labelPlayerCurrentAccountBalance.AutoSize = true;
            this.labelPlayerCurrentAccountBalance.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelPlayerCurrentAccountBalance.Location = new System.Drawing.Point(6, 521);
            this.labelPlayerCurrentAccountBalance.Name = "labelPlayerCurrentAccountBalance";
            this.labelPlayerCurrentAccountBalance.Size = new System.Drawing.Size(0, 38);
            this.labelPlayerCurrentAccountBalance.TabIndex = 29;
            this.labelPlayerCurrentAccountBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddCash
            // 
            this.buttonAddCash.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.buttonAddCash.Location = new System.Drawing.Point(363, 541);
            this.buttonAddCash.Name = "buttonAddCash";
            this.buttonAddCash.Size = new System.Drawing.Size(102, 44);
            this.buttonAddCash.TabIndex = 33;
            this.buttonAddCash.Text = "Add cash";
            this.buttonAddCash.UseVisualStyleBackColor = true;
            this.buttonAddCash.Click += new System.EventHandler(this.ButtonAddCash_Click);
            // 
            // pictureBoxDog4
            // 
            this.pictureBoxDog4.Image = global::BettingParlor_Refactor.Properties.Resources.dog;
            this.pictureBoxDog4.Location = new System.Drawing.Point(13, 161);
            this.pictureBoxDog4.Name = "pictureBoxDog4";
            this.pictureBoxDog4.Size = new System.Drawing.Size(76, 22);
            this.pictureBoxDog4.TabIndex = 24;
            this.pictureBoxDog4.TabStop = false;
            // 
            // pictureBoxDog3
            // 
            this.pictureBoxDog3.Image = global::BettingParlor_Refactor.Properties.Resources.dog;
            this.pictureBoxDog3.Location = new System.Drawing.Point(13, 107);
            this.pictureBoxDog3.Name = "pictureBoxDog3";
            this.pictureBoxDog3.Size = new System.Drawing.Size(76, 22);
            this.pictureBoxDog3.TabIndex = 25;
            this.pictureBoxDog3.TabStop = false;
            // 
            // pictureBoxDog2
            // 
            this.pictureBoxDog2.Image = global::BettingParlor_Refactor.Properties.Resources.dog;
            this.pictureBoxDog2.Location = new System.Drawing.Point(13, 54);
            this.pictureBoxDog2.Name = "pictureBoxDog2";
            this.pictureBoxDog2.Size = new System.Drawing.Size(76, 22);
            this.pictureBoxDog2.TabIndex = 26;
            this.pictureBoxDog2.TabStop = false;
            // 
            // pictureBoxDog1
            // 
            this.pictureBoxDog1.Image = global::BettingParlor_Refactor.Properties.Resources.dog;
            this.pictureBoxDog1.Location = new System.Drawing.Point(13, 12);
            this.pictureBoxDog1.Name = "pictureBoxDog1";
            this.pictureBoxDog1.Size = new System.Drawing.Size(76, 22);
            this.pictureBoxDog1.TabIndex = 27;
            this.pictureBoxDog1.TabStop = false;
            // 
            // pictureBoxRaceTrack
            // 
            this.pictureBoxRaceTrack.Image = global::BettingParlor_Refactor.Properties.Resources.racetrack;
            this.pictureBoxRaceTrack.Location = new System.Drawing.Point(-2, -5);
            this.pictureBoxRaceTrack.Name = "pictureBoxRaceTrack";
            this.pictureBoxRaceTrack.Size = new System.Drawing.Size(599, 202);
            this.pictureBoxRaceTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRaceTrack.TabIndex = 23;
            this.pictureBoxRaceTrack.TabStop = false;
            // 
            // currentBetsTableAdapter
            // 
            this.currentBetsTableAdapter.ClearBeforeFill = true;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 852);
            this.ControlBox = false;
            this.Controls.Add(this.labelChat);
            this.Controls.Add(this.labelRaceStatus);
            this.Controls.Add(this.richTextBoxConsole);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.panelHandicap);
            this.Controls.Add(this.dataGridViewCurrentBetts);
            this.Controls.Add(this.pictureBoxDog4);
            this.Controls.Add(this.pictureBoxDog3);
            this.Controls.Add(this.pictureBoxDog2);
            this.Controls.Add(this.pictureBoxDog1);
            this.Controls.Add(this.pictureBoxRaceTrack);
            this.Controls.Add(this.buttonSignOut);
            this.Controls.Add(this.buttonPlaceBet);
            this.Controls.Add(this.labelCurrentBets);
            this.Controls.Add(this.labelPlayerCurrentAccountBalance);
            this.Controls.Add(this.buttonAddCash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(615, 891);
            this.MinimumSize = new System.Drawing.Size(615, 891);
            this.Name = "FormClient";
            this.Text = "Betting parlor";
            this.Load += new System.EventHandler(this.FormClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDogToWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHandiCapValue)).EndInit();
            this.panelHandicap.ResumeLayout(false);
            this.panelHandicap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentBetts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentBetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bettingParlorDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDog4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDog3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDog2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRaceTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.Button buttonHandicap;
        private System.Windows.Forms.Label labelPlaceHandicap;
        private System.Windows.Forms.Label labelRules;
        private System.Windows.Forms.NumericUpDown numericUpDownDogToWin;
        private System.Windows.Forms.Label labelDogNumber;
        private System.Windows.Forms.Label labelSignDolar;
        private System.Windows.Forms.NumericUpDown numericUpDownHandiCapValue;
        private System.Windows.Forms.Label labelRaceStatus;
        private System.Windows.Forms.RichTextBox richTextBoxConsole;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Panel panelHandicap;
        private System.Windows.Forms.DataGridView dataGridViewCurrentBetts;
        private System.Windows.Forms.PictureBox pictureBoxDog4;
        private System.Windows.Forms.PictureBox pictureBoxDog3;
        private System.Windows.Forms.PictureBox pictureBoxDog2;
        private System.Windows.Forms.PictureBox pictureBoxDog1;
        private System.Windows.Forms.PictureBox pictureBoxRaceTrack;
        private System.Windows.Forms.Button buttonSignOut;
        private System.Windows.Forms.Label labelCurrentBets;
        private System.Windows.Forms.Label labelPlayerCurrentAccountBalance;
        private System.Windows.Forms.Button buttonAddCash;
        private BettingParlorDataSet bettingParlorDataSet;
        private System.Windows.Forms.BindingSource currentBetsBindingSource;
        private BettingParlorDataSetTableAdapters.CurrentBetsTableAdapter currentBetsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bettorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountBetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dogToWinDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonPlaceBet;
    }
}