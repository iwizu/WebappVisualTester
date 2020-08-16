namespace WebappVisualTester
{
    partial class ProjectSettingsForm
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
            this.chkEnableCookies = new System.Windows.Forms.CheckBox();
            this.lblStorePlace = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkEnableCookies
            // 
            this.chkEnableCookies.AutoSize = true;
            this.chkEnableCookies.Location = new System.Drawing.Point(36, 45);
            this.chkEnableCookies.Name = "chkEnableCookies";
            this.chkEnableCookies.Size = new System.Drawing.Size(132, 24);
            this.chkEnableCookies.TabIndex = 5;
            this.chkEnableCookies.Text = "Enable Cookies";
            this.chkEnableCookies.UseVisualStyleBackColor = true;
            // 
            // lblStorePlace
            // 
            this.lblStorePlace.AutoSize = true;
            this.lblStorePlace.Location = new System.Drawing.Point(36, 105);
            this.lblStorePlace.Name = "lblStorePlace";
            this.lblStorePlace.Size = new System.Drawing.Size(15, 20);
            this.lblStorePlace.TabIndex = 2;
            this.lblStorePlace.Text = "-";
            this.lblStorePlace.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(29, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(286, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select where to store the Cookies";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnVisualNavigation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(29, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project Settings";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(661, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ProjectSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 181);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStorePlace);
            this.Controls.Add(this.chkEnableCookies);
            this.Name = "ProjectSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Settings ";
            this.Load += new System.EventHandler(this.ProjectSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnableCookies;
        private System.Windows.Forms.Label lblStorePlace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}