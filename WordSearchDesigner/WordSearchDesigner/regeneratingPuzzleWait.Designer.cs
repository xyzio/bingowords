namespace WordSearchDesigner
{
    partial class regeneratingPuzzleWait
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(regeneratingPuzzleWait));
            this.calculatingPuzzleProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // calculatingPuzzleProgressBar
            // 
            this.calculatingPuzzleProgressBar.ForeColor = System.Drawing.Color.DarkOrange;
            this.calculatingPuzzleProgressBar.Location = new System.Drawing.Point(56, 83);
            this.calculatingPuzzleProgressBar.Name = "calculatingPuzzleProgressBar";
            this.calculatingPuzzleProgressBar.Size = new System.Drawing.Size(410, 23);
            this.calculatingPuzzleProgressBar.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 122);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculating New Puzzle ...";
            // 
            // regeneratingPuzzleWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 193);
            this.ControlBox = false;
            this.Controls.Add(this.calculatingPuzzleProgressBar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "regeneratingPuzzleWait";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Please Wait ...";
            this.Load += new System.EventHandler(this.regeneratingPuzzleWait_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar calculatingPuzzleProgressBar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}