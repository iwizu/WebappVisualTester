namespace WebappVisualTester.CommandUserControls
{
    partial class SelectElementUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFindBy = new System.Windows.Forms.ComboBox();
            this.lblSelType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtWait = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkScrollToElement = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find by";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbFindBy
            // 
            this.cmbFindBy.FormattingEnabled = true;
            this.cmbFindBy.Items.AddRange(new object[] {
            "Class",
            "Css selector",
            "Id",
            "LinkText",
            "Name",
            "PartialLinkText",
            "TagName",
            "XPath"});
            this.cmbFindBy.Location = new System.Drawing.Point(110, 4);
            this.cmbFindBy.Name = "cmbFindBy";
            this.cmbFindBy.Size = new System.Drawing.Size(390, 28);
            this.cmbFindBy.TabIndex = 4;
            this.cmbFindBy.Text = "Id";
            this.cmbFindBy.SelectedIndexChanged += new System.EventHandler(this.cmbFindBy_SelectedIndexChanged);
            // 
            // lblSelType
            // 
            this.lblSelType.Location = new System.Drawing.Point(6, 41);
            this.lblSelType.Name = "lblSelType";
            this.lblSelType.Size = new System.Drawing.Size(107, 20);
            this.lblSelType.TabIndex = 2;
            this.lblSelType.Text = "Id";
            this.lblSelType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(110, 38);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(390, 27);
            this.txtType.TabIndex = 3;
            // 
            // txtWait
            // 
            this.txtWait.Location = new System.Drawing.Point(110, 69);
            this.txtWait.Name = "txtWait";
            this.txtWait.Size = new System.Drawing.Size(78, 27);
            this.txtWait.TabIndex = 3;
            this.txtWait.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "sec";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Wait";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkScrollToElement
            // 
            this.chkScrollToElement.AutoSize = true;
            this.chkScrollToElement.Location = new System.Drawing.Point(356, 71);
            this.chkScrollToElement.Name = "chkScrollToElement";
            this.chkScrollToElement.Size = new System.Drawing.Size(144, 24);
            this.chkScrollToElement.TabIndex = 5;
            this.chkScrollToElement.Text = "Scroll to element";
            this.chkScrollToElement.UseVisualStyleBackColor = true;
            // 
            // SelectElementUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkScrollToElement);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWait);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblSelType);
            this.Controls.Add(this.cmbFindBy);
            this.Controls.Add(this.label1);
            this.Name = "SelectElementUC";
            this.Size = new System.Drawing.Size(509, 99);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFindBy;
        private System.Windows.Forms.Label lblSelType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtWait;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkScrollToElement;
    }
}
