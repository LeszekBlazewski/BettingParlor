namespace BettingParlor_Refactor
{
    partial class FormLogin
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonExitTheApplication = new System.Windows.Forms.Button();
            this.buttonBackToMainMenu = new System.Windows.Forms.Button();
            this.labelStatusText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(123, 9);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(110, 27);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(238, 16);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(123, 42);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(102, 27);
            this.labelPassword.TabIndex = 0;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(238, 42);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonLogin.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.Location = new System.Drawing.Point(71, 144);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 37);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonRegister.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonRegister.Location = new System.Drawing.Point(357, 144);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(100, 37);
            this.buttonRegister.TabIndex = 4;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // buttonExitTheApplication
            // 
            this.buttonExitTheApplication.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonExitTheApplication.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonExitTheApplication.Location = new System.Drawing.Point(357, 197);
            this.buttonExitTheApplication.Name = "buttonExitTheApplication";
            this.buttonExitTheApplication.Size = new System.Drawing.Size(100, 37);
            this.buttonExitTheApplication.TabIndex = 5;
            this.buttonExitTheApplication.Text = "Exit";
            this.buttonExitTheApplication.UseVisualStyleBackColor = false;
            this.buttonExitTheApplication.Click += new System.EventHandler(this.ButtonExitTheApplication_Click);
            // 
            // buttonBackToMainMenu
            // 
            this.buttonBackToMainMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonBackToMainMenu.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonBackToMainMenu.Location = new System.Drawing.Point(71, 197);
            this.buttonBackToMainMenu.Name = "buttonBackToMainMenu";
            this.buttonBackToMainMenu.Size = new System.Drawing.Size(100, 37);
            this.buttonBackToMainMenu.TabIndex = 6;
            this.buttonBackToMainMenu.Text = "Back";
            this.buttonBackToMainMenu.UseVisualStyleBackColor = false;
            this.buttonBackToMainMenu.Click += new System.EventHandler(this.ButtonBackToMainMenu_Click);
            // 
            // labelStatusText
            // 
            this.labelStatusText.AutoSize = true;
            this.labelStatusText.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusText.Location = new System.Drawing.Point(12, 90);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(0, 23);
            this.labelStatusText.TabIndex = 7;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(526, 276);
            this.ControlBox = false;
            this.Controls.Add(this.labelStatusText);
            this.Controls.Add(this.buttonBackToMainMenu);
            this.Controls.Add(this.buttonExitTheApplication);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.MaximumSize = new System.Drawing.Size(542, 315);
            this.MinimumSize = new System.Drawing.Size(542, 315);
            this.Name = "FormLogin";
            this.Text = "Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonExitTheApplication;
        private System.Windows.Forms.Button buttonBackToMainMenu;
        /// <summary>
        /// Publicy visible because is accessed from another form to display message about connection state.
        /// </summary>
        public System.Windows.Forms.Label labelStatusText;
        internal System.Windows.Forms.TextBox textBoxUsername;
        internal System.Windows.Forms.TextBox textBoxPassword;
    }
}