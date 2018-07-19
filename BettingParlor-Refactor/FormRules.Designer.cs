namespace BettingParlor_Refactor
{
    partial class FormRules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRules));
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelRules = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(-5, 51);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(1304, 874);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = resources.GetString("labelDescription.Text");
            // 
            // labelRules
            // 
            this.labelRules.AutoSize = true;
            this.labelRules.BackColor = System.Drawing.Color.Transparent;
            this.labelRules.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold);
            this.labelRules.Location = new System.Drawing.Point(539, -6);
            this.labelRules.Name = "labelRules";
            this.labelRules.Size = new System.Drawing.Size(148, 67);
            this.labelRules.TabIndex = 2;
            this.labelRules.Text = "Rules";
            // 
            // FormRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 896);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelRules);
            this.MaximumSize = new System.Drawing.Size(1313, 935);
            this.MinimumSize = new System.Drawing.Size(1313, 935);
            this.Name = "FormRules";
            this.Text = "Rules";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRules_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelRules;
    }
}