namespace BingoWords
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.purchaseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            this.bingoCardDesignerLabel = new System.Windows.Forms.Label();
            this.bingoWordsGroupBox = new System.Windows.Forms.GroupBox();
            this.licenceInfoLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.bingoWordsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // purchaseLinkLabel
            // 
            this.purchaseLinkLabel.AutoSize = true;
            this.purchaseLinkLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseLinkLabel.Location = new System.Drawing.Point(6, 116);
            this.purchaseLinkLabel.Name = "purchaseLinkLabel";
            this.purchaseLinkLabel.Size = new System.Drawing.Size(293, 16);
            this.purchaseLinkLabel.TabIndex = 0;
            this.purchaseLinkLabel.TabStop = true;
            this.purchaseLinkLabel.Text = "Click Here to Purchase Bingo Card Designer";
            this.purchaseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.purchaseLinkLabel_LinkClicked);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(506, 203);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Close";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // bingoCardDesignerLabel
            // 
            this.bingoCardDesignerLabel.AutoSize = true;
            this.bingoCardDesignerLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bingoCardDesignerLabel.ForeColor = System.Drawing.Color.Black;
            this.bingoCardDesignerLabel.Location = new System.Drawing.Point(6, 31);
            this.bingoCardDesignerLabel.Name = "bingoCardDesignerLabel";
            this.bingoCardDesignerLabel.Size = new System.Drawing.Size(187, 18);
            this.bingoCardDesignerLabel.TabIndex = 3;
            this.bingoCardDesignerLabel.Text = "Bingo Card Designer";
            // 
            // bingoWordsGroupBox
            // 
            this.bingoWordsGroupBox.Controls.Add(this.licenceInfoLabel);
            this.bingoWordsGroupBox.Controls.Add(this.bingoCardDesignerLabel);
            this.bingoWordsGroupBox.Controls.Add(this.purchaseLinkLabel);
            this.bingoWordsGroupBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bingoWordsGroupBox.ForeColor = System.Drawing.Color.Red;
            this.bingoWordsGroupBox.Location = new System.Drawing.Point(231, 12);
            this.bingoWordsGroupBox.Name = "bingoWordsGroupBox";
            this.bingoWordsGroupBox.Size = new System.Drawing.Size(340, 150);
            this.bingoWordsGroupBox.TabIndex = 4;
            this.bingoWordsGroupBox.TabStop = false;
            this.bingoWordsGroupBox.Text = "Bingo Words";
            // 
            // licenceInfoLabel
            // 
            this.licenceInfoLabel.AutoSize = true;
            this.licenceInfoLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenceInfoLabel.ForeColor = System.Drawing.Color.Black;
            this.licenceInfoLabel.Location = new System.Drawing.Point(6, 73);
            this.licenceInfoLabel.Name = "licenceInfoLabel";
            this.licenceInfoLabel.Size = new System.Drawing.Size(236, 32);
            this.licenceInfoLabel.TabIndex = 4;
            this.licenceInfoLabel.Text = "This Copy of Bingo Word Designer \r\nis not licensed.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(12, 207);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 14);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "xyzio.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 235);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.bingoWordsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "About";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.bingoWordsGroupBox.ResumeLayout(false);
            this.bingoWordsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel purchaseLinkLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label bingoCardDesignerLabel;
        private System.Windows.Forms.GroupBox bingoWordsGroupBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label licenceInfoLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}