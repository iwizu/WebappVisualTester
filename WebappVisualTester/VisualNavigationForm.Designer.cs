namespace WebappVisualTester
{
    partial class VisualNavigationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualNavigationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtTileSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.btnCopyImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(1, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1158, 617);
            this.panel1.TabIndex = 1;
            // 
            // txtTileSize
            // 
            this.txtTileSize.Location = new System.Drawing.Point(71, 2);
            this.txtTileSize.Name = "txtTileSize";
            this.txtTileSize.Size = new System.Drawing.Size(96, 27);
            this.txtTileSize.TabIndex = 2;
            this.txtTileSize.Text = "1295";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tile size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rows:";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(226, 2);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(96, 27);
            this.txtRows.TabIndex = 2;
            this.txtRows.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Margin:";
            // 
            // txtMargin
            // 
            this.txtMargin.Location = new System.Drawing.Point(398, 1);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(75, 27);
            this.txtMargin.TabIndex = 2;
            this.txtMargin.Text = "256";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnRefresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.Blue;
            this.btnRefresh.Location = new System.Drawing.Point(490, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 27);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // picWait
            // 
            this.picWait.Image = ((System.Drawing.Image)(resources.GetObject("picWait.Image")));
            this.picWait.Location = new System.Drawing.Point(593, 3);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(25, 23);
            this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWait.TabIndex = 3;
            this.picWait.TabStop = false;
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenshot.BackColor = System.Drawing.Color.Transparent;
            this.btnScreenshot.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnScreenshot.FlatAppearance.BorderSize = 0;
            this.btnScreenshot.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreenshot.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnScreenshot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("btnScreenshot.Image")));
            this.btnScreenshot.Location = new System.Drawing.Point(1056, 2);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(103, 27);
            this.btnScreenshot.TabIndex = 1;
            this.btnScreenshot.Text = "Screenshot";
            this.btnScreenshot.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnScreenshot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnScreenshot.UseVisualStyleBackColor = false;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyImage.BackColor = System.Drawing.Color.Transparent;
            this.btnCopyImage.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCopyImage.FlatAppearance.BorderSize = 0;
            this.btnCopyImage.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCopyImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyImage.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCopyImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCopyImage.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyImage.Image")));
            this.btnCopyImage.Location = new System.Drawing.Point(971, 3);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(79, 27);
            this.btnCopyImage.TabIndex = 1;
            this.btnCopyImage.Text = "Copy";
            this.btnCopyImage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyImage.UseVisualStyleBackColor = false;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // VisualNavigationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1161, 649);
            this.Controls.Add(this.btnCopyImage);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtMargin);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTileSize);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picWait);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisualNavigationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisualNavigationForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtTileSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMargin;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox picWait;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Button btnCopyImage;
    }
}