using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WordSearchDesigner {
	public partial class RegistrationScreen : Form {
		BingoLicense licenseInfo;
		BingoLinks links = new BingoLinks();

		public RegistrationScreen() {
			InitializeComponent();
			licenseInfo = new BingoLicense();
		}

		private void RegistrationScreen_Load(object sender, EventArgs e) {
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
		}

		private void okButton_Click(object sender, EventArgs e) {

			if ((textBox1.Text == "") || (textBox1.Text == null)) {
				MessageBox.Show("Invalid license key.  Did you enter all the digits?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;

			}
			if ((textBox2.Text == "") || (textBox2.Text == null)) {
				MessageBox.Show("Invalid license key.  Did you enter all the digits?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;

			}
			if ((textBox3.Text == "") || (textBox3.Text == null)) {
				MessageBox.Show("Invalid license key.  Did you enter all the digits?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;

			}
			if ((textBox2.Text.Length < 4)) {
				MessageBox.Show("Invalid license key. Did you enter all 4 digits into the 2nd box?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if ((textBox3.Text.Length < 4)) {
				MessageBox.Show("Invalid license key. Did you enter all 4 digits into the 3nd box?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			licenseInfo.writeToLicenceFile("license.txt", textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text); //We made it through the gauntlet. Let us now write the license file
			if (false == readLicenceFile()) {
				MessageBox.Show("Invalid license key!  Please contact support@xyzio.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DialogResult = DialogResult.OK;
		}

		private bool readLicenceFile() {
			licenseInfo = new BingoLicense();
			return (licenseInfo.isLicensed);
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			ProcessStartInfo sInfo = new ProcessStartInfo(links.mainSiteLink);
			Process.Start(sInfo);
		}
	}
}
