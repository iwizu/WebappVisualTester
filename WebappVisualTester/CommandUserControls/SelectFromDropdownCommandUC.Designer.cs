namespace WebappVisualTester
{
    partial class SelectFromDropdownCommandUC
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSelectedValue = new System.Windows.Forms.TextBox();
            this.selectElementuc1 = new WebappVisualTester.CommandUserControls.SelectElementUC();
            this.cmbByTextValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select from dropdown list";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Location = new System.Drawing.Point(532, 289);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 244);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(516, 28);
            this.comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Belongs to Command:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Selected Value:";
            // 
            // txtSelectedValue
            // 
            this.txtSelectedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedValue.Location = new System.Drawing.Point(113, 187);
            this.txtSelectedValue.Name = "txtSelectedValue";
            this.txtSelectedValue.Size = new System.Drawing.Size(516, 27);
            this.txtSelectedValue.TabIndex = 3;
            // 
            // selectElementuc1
            // 
            this.selectElementuc1.Location = new System.Drawing.Point(6, 40);
            this.selectElementuc1.MaximumSize = new System.Drawing.Size(623, 123);
            this.selectElementuc1.Name = "selectElementuc1";
            this.selectElementuc1.Size = new System.Drawing.Size(623, 123);
            this.selectElementuc1.TabIndex = 5;
            // 
            // cmbByTextValue
            // 
            this.cmbByTextValue.FormattingEnabled = true;
            this.cmbByTextValue.Items.AddRange(new object[] {
            "By Text",
            "By Value"});
            this.cmbByTextValue.Location = new System.Drawing.Point(6, 189);
            this.cmbByTextValue.Name = "cmbByTextValue";
            this.cmbByTextValue.Size = new System.Drawing.Size(101, 28);
            this.cmbByTextValue.TabIndex = 4;
            this.cmbByTextValue.Text = "By Text";
            // 
            // SelectFromDropdownCommandUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbByTextValue);
            this.Controls.Add(this.selectElementuc1);
            this.Controls.Add(this.txtSelectedValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Name = "SelectFromDropdownCommandUC";
            this.Size = new System.Drawing.Size(638, 342);
            this.Load += new System.EventHandler(this.NavigateToUrlCommandUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSelectedValue;
        private CommandUserControls.SelectElementUC selectElementuc1;
        private System.Windows.Forms.ComboBox cmbByTextValue;
    }
}

