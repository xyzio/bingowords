namespace BingoWords
{
    partial class WordWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordWizard));
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.listNameListBox = new System.Windows.Forms.ListBox();
            this.wordListListBox = new System.Windows.Forms.ListBox();
            this.addToNewCardButton = new System.Windows.Forms.Button();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.guideGroupBox = new System.Windows.Forms.GroupBox();
            this.helpLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wordsLabel = new System.Windows.Forms.Label();
            this.guideGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoryListBox
            // 
            this.categoryListBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.Location = new System.Drawing.Point(30, 129);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.Size = new System.Drawing.Size(156, 342);
            this.categoryListBox.TabIndex = 0;
            this.categoryListBox.SelectedIndexChanged += new System.EventHandler(this.categoryListBox_SelectedIndexChanged);
            // 
            // listNameListBox
            // 
            this.listNameListBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNameListBox.FormattingEnabled = true;
            this.listNameListBox.Location = new System.Drawing.Point(241, 129);
            this.listNameListBox.Name = "listNameListBox";
            this.listNameListBox.Size = new System.Drawing.Size(156, 342);
            this.listNameListBox.TabIndex = 1;
            this.listNameListBox.SelectedIndexChanged += new System.EventHandler(this.listNameListBox_SelectedIndexChanged);
            // 
            // wordListListBox
            // 
            this.wordListListBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordListListBox.FormattingEnabled = true;
            this.wordListListBox.Location = new System.Drawing.Point(453, 129);
            this.wordListListBox.Name = "wordListListBox";
            this.wordListListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.wordListListBox.Size = new System.Drawing.Size(156, 342);
            this.wordListListBox.TabIndex = 2;
            // 
            // addToNewCardButton
            // 
            this.addToNewCardButton.Location = new System.Drawing.Point(168, 495);
            this.addToNewCardButton.Name = "addToNewCardButton";
            this.addToNewCardButton.Size = new System.Drawing.Size(96, 40);
            this.addToNewCardButton.TabIndex = 3;
            this.addToNewCardButton.Text = "Add To New Card";
            this.addToNewCardButton.UseVisualStyleBackColor = true;
            this.addToNewCardButton.Click += new System.EventHandler(this.addToNewCardButton_Click);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.Location = new System.Drawing.Point(27, 112);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(65, 14);
            this.categoryLabel.TabIndex = 5;
            this.categoryLabel.Text = "Category";
            this.categoryLabel.Click += new System.EventHandler(this.dynamicHelpLabel_Click);
            // 
            // guideGroupBox
            // 
            this.guideGroupBox.Controls.Add(this.helpLabel);
            this.guideGroupBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guideGroupBox.ForeColor = System.Drawing.Color.Red;
            this.guideGroupBox.Location = new System.Drawing.Point(12, 21);
            this.guideGroupBox.Name = "guideGroupBox";
            this.guideGroupBox.Size = new System.Drawing.Size(609, 70);
            this.guideGroupBox.TabIndex = 6;
            this.guideGroupBox.TabStop = false;
            this.guideGroupBox.Text = "Help";
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.ForeColor = System.Drawing.Color.Black;
            this.helpLabel.Location = new System.Drawing.Point(15, 19);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(515, 32);
            this.helpLabel.TabIndex = 0;
            this.helpLabel.Text = "1) Select a category, then click on the list name to display a list of words.  \r\n" +
                "2) Click \'Add To New Card\' create a new card with these words";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(331, 495);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(96, 40);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit Word Wizard";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(202, 295);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(413, 295);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wordsLabel);
            this.groupBox1.Controls.Add(this.listLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 368);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // listLabel
            // 
            this.listLabel.AutoSize = true;
            this.listLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLabel.Location = new System.Drawing.Point(226, 0);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(29, 14);
            this.listLabel.TabIndex = 13;
            this.listLabel.Text = "List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(272, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 14;
            this.label2.Text = "Category";
            // 
            // wordsLabel
            // 
            this.wordsLabel.AutoSize = true;
            this.wordsLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordsLabel.Location = new System.Drawing.Point(438, 0);
            this.wordsLabel.Name = "wordsLabel";
            this.wordsLabel.Size = new System.Drawing.Size(48, 14);
            this.wordsLabel.TabIndex = 14;
            this.wordsLabel.Text = "Words";
            // 
            // WordWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 545);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.guideGroupBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.addToNewCardButton);
            this.Controls.Add(this.wordListListBox);
            this.Controls.Add(this.listNameListBox);
            this.Controls.Add(this.categoryListBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WordWizard";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Bingo Card Designer - Word Wizard";
            this.Load += new System.EventHandler(this.WordWizard_Load);
            this.guideGroupBox.ResumeLayout(false);
            this.guideGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.ListBox listNameListBox;
        private System.Windows.Forms.ListBox wordListListBox;
        private System.Windows.Forms.Button addToNewCardButton;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.GroupBox guideGroupBox;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label wordsLabel;
        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.Label label2;
    }
}