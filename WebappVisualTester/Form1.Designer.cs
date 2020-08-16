namespace WebappVisualTester
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnNewProject = new System.Windows.Forms.Button();
            this.btnOpenProject = new System.Windows.Forms.Button();
            this.txtProjectTitle = new System.Windows.Forms.TextBox();
            this.btnSaveProject = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgrTests = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDuplicateTest = new System.Windows.Forms.Button();
            this.btnNewTest = new System.Windows.Forms.Button();
            this.btnTestDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestUp = new System.Windows.Forms.Button();
            this.btnTestDown = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblPath = new System.Windows.Forms.Label();
            this.lblProjectPath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTests)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewProject
            // 
            this.btnNewProject.BackColor = System.Drawing.Color.Transparent;
            this.btnNewProject.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnNewProject.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnNewProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewProject.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewProject.ForeColor = System.Drawing.Color.Blue;
            this.btnNewProject.Location = new System.Drawing.Point(12, 15);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(94, 27);
            this.btnNewProject.TabIndex = 1;
            this.btnNewProject.Text = "New Project";
            this.btnNewProject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnNewProject, "New Project");
            this.btnNewProject.UseVisualStyleBackColor = false;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenProject.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnOpenProject.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnOpenProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenProject.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenProject.ForeColor = System.Drawing.Color.Blue;
            this.btnOpenProject.Location = new System.Drawing.Point(112, 15);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(114, 27);
            this.btnOpenProject.TabIndex = 1;
            this.btnOpenProject.Text = "Open Project";
            this.btnOpenProject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnOpenProject, "Open Project");
            this.btnOpenProject.UseVisualStyleBackColor = false;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // txtProjectTitle
            // 
            this.txtProjectTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectTitle.Location = new System.Drawing.Point(275, 15);
            this.txtProjectTitle.Name = "txtProjectTitle";
            this.txtProjectTitle.Size = new System.Drawing.Size(891, 27);
            this.txtProjectTitle.TabIndex = 2;
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProject.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveProject.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnSaveProject.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSaveProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProject.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveProject.ForeColor = System.Drawing.Color.Blue;
            this.btnSaveProject.Location = new System.Drawing.Point(1172, 15);
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(97, 27);
            this.btnSaveProject.TabIndex = 1;
            this.btnSaveProject.Text = "Save";
            this.btnSaveProject.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnSaveProject, "Save Project");
            this.btnSaveProject.UseVisualStyleBackColor = false;
            this.btnSaveProject.Click += new System.EventHandler(this.btnSaveProject_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 62);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1257, 621);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgrTests);
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 556);
            this.panel2.TabIndex = 1;
            // 
            // dgrTests
            // 
            this.dgrTests.AllowUserToAddRows = false;
            this.dgrTests.AllowUserToDeleteRows = false;
            this.dgrTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrTests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrTests.Location = new System.Drawing.Point(0, 0);
            this.dgrTests.Name = "dgrTests";
            this.dgrTests.ReadOnly = true;
            this.dgrTests.RowHeadersWidth = 51;
            this.dgrTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrTests.Size = new System.Drawing.Size(223, 553);
            this.dgrTests.TabIndex = 0;
            this.dgrTests.Text = "dataGridView1";
            this.toolTip1.SetToolTip(this.dgrTests, "Double click to edit Test");
            this.dgrTests.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrTests_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnDuplicateTest);
            this.panel1.Controls.Add(this.btnNewTest);
            this.panel1.Controls.Add(this.btnTestDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnTestUp);
            this.panel1.Controls.Add(this.btnTestDown);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 56);
            this.panel1.TabIndex = 0;
            // 
            // btnDuplicateTest
            // 
            this.btnDuplicateTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuplicateTest.BackColor = System.Drawing.Color.Transparent;
            this.btnDuplicateTest.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnDuplicateTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDuplicateTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuplicateTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDuplicateTest.ForeColor = System.Drawing.Color.Blue;
            this.btnDuplicateTest.Location = new System.Drawing.Point(97, 27);
            this.btnDuplicateTest.Name = "btnDuplicateTest";
            this.btnDuplicateTest.Size = new System.Drawing.Size(26, 27);
            this.btnDuplicateTest.TabIndex = 1;
            this.btnDuplicateTest.Text = "⎘";
            this.btnDuplicateTest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnDuplicateTest, "Duplicate Test");
            this.btnDuplicateTest.UseVisualStyleBackColor = false;
            this.btnDuplicateTest.Click += new System.EventHandler(this.btnDuplicateTest_Click);
            // 
            // btnNewTest
            // 
            this.btnNewTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewTest.BackColor = System.Drawing.Color.Transparent;
            this.btnNewTest.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnNewTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnNewTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTest.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewTest.ForeColor = System.Drawing.Color.Blue;
            this.btnNewTest.Location = new System.Drawing.Point(5, 27);
            this.btnNewTest.Name = "btnNewTest";
            this.btnNewTest.Size = new System.Drawing.Size(26, 27);
            this.btnNewTest.TabIndex = 1;
            this.btnNewTest.Text = "✎";
            this.btnNewTest.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnNewTest, "Create Test");
            this.btnNewTest.UseVisualStyleBackColor = false;
            this.btnNewTest.Click += new System.EventHandler(this.btnNewTest_Click);
            // 
            // btnTestDelete
            // 
            this.btnTestDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnTestDelete.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnTestDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnTestDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestDelete.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTestDelete.ForeColor = System.Drawing.Color.Red;
            this.btnTestDelete.Location = new System.Drawing.Point(33, 27);
            this.btnTestDelete.Name = "btnTestDelete";
            this.btnTestDelete.Size = new System.Drawing.Size(26, 27);
            this.btnTestDelete.TabIndex = 1;
            this.btnTestDelete.Text = "X";
            this.btnTestDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnTestDelete, "Remove selected Test");
            this.btnTestDelete.UseVisualStyleBackColor = false;
            this.btnTestDelete.Click += new System.EventHandler(this.btnTestDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(82, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tests";
            // 
            // btnTestUp
            // 
            this.btnTestUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestUp.BackColor = System.Drawing.Color.Transparent;
            this.btnTestUp.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnTestUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnTestUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestUp.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTestUp.ForeColor = System.Drawing.Color.Blue;
            this.btnTestUp.Location = new System.Drawing.Point(169, 27);
            this.btnTestUp.Name = "btnTestUp";
            this.btnTestUp.Size = new System.Drawing.Size(26, 27);
            this.btnTestUp.TabIndex = 1;
            this.btnTestUp.Text = "▲";
            this.btnTestUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnTestUp, "Move Test one place up");
            this.btnTestUp.UseVisualStyleBackColor = false;
            this.btnTestUp.Click += new System.EventHandler(this.btnTestUp_Click);
            // 
            // btnTestDown
            // 
            this.btnTestDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestDown.BackColor = System.Drawing.Color.Transparent;
            this.btnTestDown.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnTestDown.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnTestDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestDown.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTestDown.ForeColor = System.Drawing.Color.Blue;
            this.btnTestDown.Location = new System.Drawing.Point(197, 27);
            this.btnTestDown.Name = "btnTestDown";
            this.btnTestDown.Size = new System.Drawing.Size(26, 27);
            this.btnTestDown.TabIndex = 1;
            this.btnTestDown.Text = "▼";
            this.btnTestDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnTestDown, "Move Test one place down");
            this.btnTestDown.UseVisualStyleBackColor = false;
            this.btnTestDown.Click += new System.EventHandler(this.btnTestDown_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(233, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title:";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPath.ForeColor = System.Drawing.Color.Gray;
            this.lblPath.Location = new System.Drawing.Point(236, 41);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(40, 17);
            this.lblPath.TabIndex = 4;
            this.lblPath.Text = "Path :";
            // 
            // lblProjectPath
            // 
            this.lblProjectPath.AutoSize = true;
            this.lblProjectPath.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProjectPath.ForeColor = System.Drawing.Color.Gray;
            this.lblProjectPath.Location = new System.Drawing.Point(275, 42);
            this.lblProjectPath.Name = "lblProjectPath";
            this.lblProjectPath.Size = new System.Drawing.Size(13, 17);
            this.lblProjectPath.TabIndex = 4;
            this.lblProjectPath.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1281, 695);
            this.Controls.Add(this.lblProjectPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtProjectTitle);
            this.Controls.Add(this.btnSaveProject);
            this.Controls.Add(this.btnOpenProject);
            this.Controls.Add(this.btnNewProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebAppUITest - Step by step UI Test!";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrTests)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNewProject;
        private System.Windows.Forms.Button btnOpenProject;
        private System.Windows.Forms.TextBox txtProjectTitle;
        private System.Windows.Forms.Button btnSaveProject;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgrTests;
        private System.Windows.Forms.Button btnTestUp;
        private System.Windows.Forms.Button btnTestDown;
        private System.Windows.Forms.Button btnTestDelete;
        private System.Windows.Forms.Button btnNewTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblProjectPath;
        private System.Windows.Forms.Button btnDuplicateTest;
    }
}

