using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BingoWords
{
    public partial class SplashScreen : Form
    {
			bool showCloseButton = false;
            private BackgroundWorker splashBackgroundWorker = new BackgroundWorker();
            string displayText;
            BingoLinks links = new BingoLinks();

            public SplashScreen(bool showCloseButton, string displayText, bool isLicensed)
            {

                this.showCloseButton = showCloseButton;
                this.displayText = displayText;
                InitializeComponent();
                licenceInfoLabel.Text = displayText;
                purchaseLinkLabel.Visible = !isLicensed;
            }

				public SplashScreen() {
					InitializeComponent();
				}

				private void SplashScreen_Load(object sender, EventArgs e) {

					if (showCloseButton == true) {
						this.closeButton.Show();
						return;
					} 

                    this.TopMost = true;
                    this.splashBackgroundWorker.DoWork += new DoWorkEventHandler(splashBackgroundWorker_DoWork);
                    this.splashBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.splashBackgroundWorker_RunWorkerCompleted);
                    this.splashBackgroundWorker.RunWorkerAsync();
				    this.closeButton.Hide();
				}

                void splashBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
                {
                    System.Threading.Thread.Sleep(3000);
                }

                private void splashBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
                {
                    this.Close();
                    return;
                }

				private void closeButton_Click(object sender, EventArgs e) {
					this.Close();
				}

                private void purchaseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                    ProcessStartInfo sInfo = new ProcessStartInfo(links.purchaseSiteLink);
                    Process.Start(sInfo);
                    this.Close();
                }

                private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                    ProcessStartInfo sInfo = new ProcessStartInfo(links.mainSiteLink);
                    Process.Start(sInfo);
                    this.Close();
                }
    }
}
