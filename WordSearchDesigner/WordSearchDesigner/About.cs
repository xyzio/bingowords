using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WordSearchDesigner
{
    public partial class About : Form
    {
			BingoLinks links = new BingoLinks();

			public About(string licenceText, bool isLicenced) {
				InitializeComponent();
				licenceInfoLabel.Text = licenceText;
				purchaseLinkLabel.Visible = !isLicenced;
			}

			private void okButton_Click(object sender, EventArgs e) {
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}

			private void About_Load(object sender, EventArgs e) {
				okButton.Focus();
			}

			private void purchaseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

				ProcessStartInfo sInfo = new ProcessStartInfo(links.purchaseSiteLink);
				Process.Start(sInfo);
				this.DialogResult = DialogResult.OK;

			}

			private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
				ProcessStartInfo sInfo = new ProcessStartInfo(links.mainSiteLink);
				Process.Start(sInfo);
				this.DialogResult = DialogResult.OK;
			}

		}
	}