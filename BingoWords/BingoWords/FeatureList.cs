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
    public partial class FeatureList : Form
    {
        BingoLinks links = new BingoLinks();

        public FeatureList()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void purchaseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(links.purchaseSiteLink);
            Process.Start(sInfo);
            this.Close();
        }

        private void mainSiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(links.mainSiteLink);
            Process.Start(sInfo);
            this.Close();
        }

        private void FeatureList_Load(object sender, EventArgs e)
        {

        }

    }
}
