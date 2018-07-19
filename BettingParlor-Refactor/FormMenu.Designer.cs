namespace BettingParlor_Refactor
{
    partial class FormMenu
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonGameStart = new System.Windows.Forms.Button();
            this.buttonRules = new System.Windows.Forms.Button();
            this.labelWelcomeText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.Color.Yellow;
            this.buttonExit.Location = new System.Drawing.Point(320, 282);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 74);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonGameStart
            // 
            this.buttonGameStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonGameStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGameStart.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.buttonGameStart.ForeColor = System.Drawing.Color.Yellow;
            this.buttonGameStart.Location = new System.Drawing.Point(320, 154);
            this.buttonGameStart.Name = "buttonGameStart";
            this.buttonGameStart.Size = new System.Drawing.Size(100, 74);
            this.buttonGameStart.TabIndex = 6;
            this.buttonGameStart.Text = "Play";
            this.buttonGameStart.UseVisualStyleBackColor = false;
            this.buttonGameStart.Click += new System.EventHandler(this.buttonGameStart_Click);
            // 
            // buttonRules
            // 
            this.buttonRules.BackColor = System.Drawing.Color.Transparent;
            this.buttonRules.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRules.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.buttonRules.ForeColor = System.Drawing.Color.Yellow;
            this.buttonRules.Location = new System.Drawing.Point(320, 52);
            this.buttonRules.Name = "buttonRules";
            this.buttonRules.Size = new System.Drawing.Size(100, 74);
            this.buttonRules.TabIndex = 4;
            this.buttonRules.Text = "Rules";
            this.buttonRules.UseVisualStyleBackColor = false;
            this.buttonRules.Click += new System.EventHandler(this.buttonRules_Click);
            // 
            // labelWelcomeText
            // 
            this.labelWelcomeText.AutoSize = true;
            this.labelWelcomeText.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcomeText.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelWelcomeText.ForeColor = System.Drawing.Color.Yellow;
            this.labelWelcomeText.Location = new System.Drawing.Point(198, 11);
            this.labelWelcomeText.Name = "labelWelcomeText";
            this.labelWelcomeText.Size = new System.Drawing.Size(363, 38);
            this.labelWelcomeText.TabIndex = 3;
            this.labelWelcomeText.Text = "Welcome to betting parlor";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BettingParlor_Refactor.Properties.Resources.betting;
            this.ClientSize = new System.Drawing.Size(759, 368);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonGameStart);
            this.Controls.Add(this.buttonRules);
            this.Controls.Add(this.labelWelcomeText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(775, 407);
            this.MinimumSize = new System.Drawing.Size(775, 407);
            this.Name = "FormMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonGameStart;
        private System.Windows.Forms.Button buttonRules;
        private System.Windows.Forms.Label labelWelcomeText;
    }
}

