namespace WebappVisualTester
{
    partial class EditTest
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgrCommands = new System.Windows.Forms.DataGridView();
            this.btnDownOrder = new System.Windows.Forms.Button();
            this.btnUpOrder = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreateCommand = new System.Windows.Forms.Button();
            this.btnRemoveCommand = new System.Windows.Forms.Button();
            this.btnExecuteTest = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnVisualNavigation = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCommands)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title: ";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(29, 68);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(635, 27);
            this.txtTitle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Commands:";
            // 
            // dgrCommands
            // 
            this.dgrCommands.AllowUserToAddRows = false;
            this.dgrCommands.AllowUserToDeleteRows = false;
            this.dgrCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrCommands.Location = new System.Drawing.Point(3, 38);
            this.dgrCommands.Name = "dgrCommands";
            this.dgrCommands.ReadOnly = true;
            this.dgrCommands.RowHeadersWidth = 51;
            this.dgrCommands.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrCommands.Size = new System.Drawing.Size(624, 301);
            this.dgrCommands.TabIndex = 4;
            this.dgrCommands.Text = "dataGridView1";
            this.dgrCommands.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrCommands_CellContentDoubleClick);
            this.dgrCommands.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrCommands_CellValueChanged);
            this.dgrCommands.Resize += new System.EventHandler(this.dgrCommands_Resize);
            // 
            // btnDownOrder
            // 
            this.btnDownOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnDownOrder.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnDownOrder.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDownOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownOrder.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDownOrder.ForeColor = System.Drawing.Color.Blue;
            this.btnDownOrder.Location = new System.Drawing.Point(633, 71);
            this.btnDownOrder.Name = "btnDownOrder";
            this.btnDownOrder.Size = new System.Drawing.Size(26, 27);
            this.btnDownOrder.TabIndex = 1;
            this.btnDownOrder.Text = "▼";
            this.btnDownOrder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDownOrder.UseVisualStyleBackColor = false;
            this.btnDownOrder.Click += new System.EventHandler(this.btnDownOrder_Click);
            // 
            // btnUpOrder
            // 
            this.btnUpOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnUpOrder.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnUpOrder.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnUpOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpOrder.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpOrder.ForeColor = System.Drawing.Color.Blue;
            this.btnUpOrder.Location = new System.Drawing.Point(633, 38);
            this.btnUpOrder.Name = "btnUpOrder";
            this.btnUpOrder.Size = new System.Drawing.Size(26, 27);
            this.btnUpOrder.TabIndex = 1;
            this.btnUpOrder.Text = "▲";
            this.btnUpOrder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpOrder.UseVisualStyleBackColor = false;
            this.btnUpOrder.Click += new System.EventHandler(this.btnUpOrder_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Location = new System.Drawing.Point(567, 482);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreateCommand
            // 
            this.btnCreateCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCommand.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateCommand.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCreateCommand.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCreateCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCommand.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateCommand.ForeColor = System.Drawing.Color.Blue;
            this.btnCreateCommand.Location = new System.Drawing.Point(633, 278);
            this.btnCreateCommand.Name = "btnCreateCommand";
            this.btnCreateCommand.Size = new System.Drawing.Size(26, 27);
            this.btnCreateCommand.TabIndex = 1;
            this.btnCreateCommand.Text = "✎";
            this.btnCreateCommand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCreateCommand.UseVisualStyleBackColor = false;
            this.btnCreateCommand.Click += new System.EventHandler(this.btnCreateCommand_Click);
            // 
            // btnRemoveCommand
            // 
            this.btnRemoveCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCommand.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveCommand.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnRemoveCommand.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRemoveCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCommand.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveCommand.ForeColor = System.Drawing.Color.Red;
            this.btnRemoveCommand.Location = new System.Drawing.Point(633, 311);
            this.btnRemoveCommand.Name = "btnRemoveCommand";
            this.btnRemoveCommand.Size = new System.Drawing.Size(26, 27);
            this.btnRemoveCommand.TabIndex = 1;
            this.btnRemoveCommand.Text = "X";
            this.btnRemoveCommand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveCommand.UseVisualStyleBackColor = false;
            this.btnRemoveCommand.Click += new System.EventHandler(this.btnRemoveCommand_Click);
            // 
            // btnExecuteTest
            // 
            this.btnExecuteTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecuteTest.BackColor = System.Drawing.Color.Transparent;
            this.btnExecuteTest.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnExecuteTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExecuteTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecuteTest.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExecuteTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExecuteTest.Location = new System.Drawing.Point(670, 68);
            this.btnExecuteTest.Name = "btnExecuteTest";
            this.btnExecuteTest.Size = new System.Drawing.Size(26, 27);
            this.btnExecuteTest.TabIndex = 1;
            this.btnExecuteTest.Text = "▶";
            this.btnExecuteTest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExecuteTest.UseVisualStyleBackColor = false;
            this.btnExecuteTest.Click += new System.EventHandler(this.btnExecuteTest_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(685, 375);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnVisualNavigation);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dgrCommands);
            this.tabPage1.Controls.Add(this.btnDownOrder);
            this.tabPage1.Controls.Add(this.btnUpOrder);
            this.tabPage1.Controls.Add(this.btnCreateCommand);
            this.tabPage1.Controls.Add(this.btnRemoveCommand);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(677, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Commands";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnVisualNavigation
            // 
            this.btnVisualNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualNavigation.BackColor = System.Drawing.Color.Transparent;
            this.btnVisualNavigation.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnVisualNavigation.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnVisualNavigation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualNavigation.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVisualNavigation.ForeColor = System.Drawing.Color.Blue;
            this.btnVisualNavigation.Location = new System.Drawing.Point(446, 6);
            this.btnVisualNavigation.Name = "btnVisualNavigation";
            this.btnVisualNavigation.Size = new System.Drawing.Size(181, 27);
            this.btnVisualNavigation.TabIndex = 1;
            this.btnVisualNavigation.Text = "Visual Navigation";
            this.btnVisualNavigation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVisualNavigation.UseVisualStyleBackColor = false;
            this.btnVisualNavigation.Click += new System.EventHandler(this.btnVisualNavigation_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(677, 342);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Execution Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Execution result:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(671, 309);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // EditTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExecuteTest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditTest";
            this.Size = new System.Drawing.Size(711, 513);
            this.Load += new System.EventHandler(this.EditTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrCommands)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgrCommands;
        private System.Windows.Forms.Button btnDownOrder;
        private System.Windows.Forms.Button btnUpOrder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreateCommand;
        private System.Windows.Forms.Button btnRemoveCommand;
        private System.Windows.Forms.Button btnExecuteTest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnVisualNavigation;
    }
}

