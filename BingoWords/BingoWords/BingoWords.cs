using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace BingoWords
{
    public partial class BingoWords : Form
    {

        BingoTable TableBingo = new BingoTable(5, 5);
        SplashScreen splash;
        BingoLicense licenseInfo;
        Thread printProcess;

        public BingoWords()
        {
            InitializeComponent();

            //Read and verify licence if it exists
            printProcess = new Thread(new ThreadStart(BingoPrintDocument));
           

        }

        private void BingoWords_Load(object sender, EventArgs e)
        {
            licenseInfo = new BingoLicense();
            splash = new SplashScreen(false, licenseInfo.licenseText, licenseInfo.isLicensed);
            Thread splashThread = new Thread(new ThreadStart(showSplashScreen));
            splashThread.Start();
            refreshItemsListBox();

            //Hide the registration menu if the app is already registered
            licenseInfo = new BingoLicense();
            if (licenseInfo.isLicensed == true)
            {
                registerToolStripMenuItem.Visible = false;
            }
        }

        private void showSplashScreen()
        {
            splash.ShowDialog();
        }


        private void BingoWords_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphicsObj;

            graphicsObj = e.Graphics;

            //Hardcode is bad.  I'm fixing it now.
            //Idea, start table right under the sampleCardLabel, make it 10 px shorter than the itemsListBox and it has to be square.

            //Put it 5 px under the sampleCardLabel
            TableBingo.previewSizeX = sampleCardLabel.Location.X + 4;
            TableBingo.previewSizeY = sampleCardLabel.Location.Y + sampleCardLabel.Size.Height + 5;

            Point pt = new Point(TableBingo.previewSizeX, TableBingo.previewSizeY);
            TableBingo.previewHeight = (itemsListBox.Location.Y + itemsListBox.Size.Height - TableBingo.previewSizeY) - 8;
            TableBingo.previewWidth = TableBingo.previewHeight;

            //Adjust the height and column size so they divide evenly into table.row and table.column
            //This is done because we use integer sizes and we want everything to line up correctly.
            //Otherwise, there will be badness.
            int rowSize = TableBingo.rowSize;
            if (TableBingo.printTitle == true)
            {
                rowSize += 1;
            }
            int remainder = TableBingo.previewHeight % rowSize;
            while (remainder != 0)
            {
                TableBingo.previewHeight += 1;
                remainder = TableBingo.previewHeight % rowSize;
            }

            int colSize = TableBingo.colSize;
            remainder = TableBingo.previewWidth % colSize;
            while (remainder != 0)
            {
                TableBingo.previewWidth += 1;
                remainder = TableBingo.previewWidth % colSize;
            }
            //End resize

            if ((TableBingo.previewHeight <= 0) || (TableBingo.previewWidth <= 0))
            {
                return;
            } //Avoid badness

            Size sz = new Size(TableBingo.previewWidth, TableBingo.previewHeight);

            TableBingo.PrintBingo.DrawBingoCard(pt, sz, TableBingo, System.Drawing.Color.Red, ref graphicsObj);

        }


        private void BingoWords_SizeChanged(object sender, EventArgs e)
        {
            //If the refresh button location x, y are inside the image, make the refresh button disappear.
            //	if ((refreshButton.Location.X < (TableBingo.previewSizeX + TableBingo.previewWidth)) && (refreshButton.Location.Y < (TableBingo.previewSizeY + TableBingo.previewHeight))) {

            //		refreshButton.Hide();
            //	}
            //	else {
            //		refreshButton.Show();
            //	}

            this.Refresh();
        }

        private void freeSpaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Add a check so you cannot select this if the row and/or col size are even.
            //Finding median to print free space of even row/col involves badness.

            if (freeSpaceTextBox.Text == "")
            {
                freeSpaceTextBox.Text = "Free Space!";
            }
            updateFreeSpaceTextBox(freeSpaceTextBox.Text, freeSpaceCheckBox.Checked);
        }

        private void updateFreeSpaceTextBox(string title, bool enabled)
        {

            freeSpaceTextBox.Enabled = enabled;
            TableBingo.freeSpaceText = title;
            TableBingo.printFreeSpace = enabled;
            this.Refresh();
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            TableBingo.items.Add(addNewItemTextBox.Text);
            refreshItemsListBox();
            addNewItemTextBox.Clear();
            addNewItemTextBox.Focus();
        }

        private void refreshItemsListBox()
        {
            licenseInfo = new BingoLicense();
/*            if (licenseInfo.isLicensed == false)
            {
                if (TableBingo.items.Count > licenseInfo.maxItems)
                {
                    splash = new SplashScreen(true, "Sorry, the trial version of Bingo Card Designer\nis limited to 25 words.", licenseInfo.isLicensed);
                    using (splash)
                    {
                        splash.ShowDialog();
                    }

                    while (TableBingo.items.Count > licenseInfo.maxItems)
                    {
                        TableBingo.items.RemoveAt(TableBingo.items.Count - 1);
                    }
                }
            } //This is ugliness!*/  //Commented out 25 word limit

            itemsListBox.Items.Clear();
            Regex spaces = new Regex("^ *$");
            foreach (string item in TableBingo.items)
            {
                if (spaces.Match(item) == Match.Empty)
                {
                    itemsListBox.Items.Add(item);
                }
                else
                {
                    itemsListBox.Items.Add("' '");
                }

            }
            NumItemstoolStripStatusLabel.Text = TableBingo.items.Count + " items";
            this.Refresh();
            return;
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            deleteSelectedItem();
            refreshItemsListBox();
        }

        private void addNewItemTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TableBingo.items.Add(addNewItemTextBox.Text);
                refreshItemsListBox();
                addNewItemTextBox.Clear();
                addNewItemTextBox.Focus();
            }
        }

        private void titleCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (titleTextBox.Text == "")
            {
                titleTextBox.Text = "BINGO";

            }
            updateTitleTextBox(titleTextBox.Text, titleCheckBox.Checked);
        }

        private void updateTitleTextBox(string title, bool enabled)
        {
            titleTextBox.Enabled = enabled;
            TableBingo.titleText = title;
            TableBingo.printTitle = enabled;
            this.Refresh();
        }

        private void titleTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateTitleTextBox(titleTextBox.Text, titleCheckBox.Checked);
            }
        }

        private void freeSpaceTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateFreeSpaceTextBox(freeSpaceTextBox.Text, freeSpaceCheckBox.Checked);
            }
        }

        private void cardSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //3x3, 3x5, 5x3 5x5
            checkCardSize();
            string[] rowCol = cardSizeComboBox.Text.Split('x');
            TableBingo.rowSize = int.Parse(rowCol[0]);
            TableBingo.colSize = int.Parse(rowCol[1]);
            this.Refresh();
        }

        private void checkCardSize()
        {
            if (cardSizeComboBox.Text != "3x3" && cardSizeComboBox.Text != "3x5" && cardSizeComboBox.Text != "5x3" && cardSizeComboBox.Text != "5x5")
            {
                cardSizeComboBox.Text = "5x5";
            }
        }

        private void cardsPerPageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cardsPerPage = 1;
            try
            {
                cardsPerPage = int.Parse(cardsPerPageComboBox.Text);
            }
            catch
            {
                cardsPerPageComboBox.Text = "1";
                cardsPerPage = int.Parse(cardsPerPageComboBox.Text);
            }

            if (cardsPerPage == 1)
            {
                TableBingo.numCardsPerPage = 1;
                return;
            }
            else if ((cardsPerPage % 2) != 0)
            {
                cardsPerPageComboBox.Text = "1";
                cardsPerPage = 1;
                TableBingo.numCardsPerPage = 1;
                return;
            }
            TableBingo.numCardsPerPage = cardsPerPage;
        }

        private void numberCardsToPrintTextBox_TextChanged(object sender, EventArgs e)
        {
            numberOfCardsToPrintWarningLabel.Visible = false;
            try
            {
                int numcards = int.Parse(numberCardsToPrintTextBox.Text);

                TableBingo.numCardsToPrint = numcards;

            }
            catch
            {
                numberOfCardsToPrintWarningLabel.Visible = true;
            }

        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printToolStripMenuItem_Click(sender, e);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Verify data then print
            //Verify card size
            checkCardSize();

            //verify number of cards to print
            try
            {
                int numcards = int.Parse(numberCardsToPrintTextBox.Text);
                TableBingo.numCardsToPrint = numcards;
            }
            catch
            {
                MessageBox.Show("Cannot Print: Number of cards to Print must be a number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Here we can do a license check and pop up a message if we are going to print more than allowed cards
            verifyNumCardsToPrint();
            printProcess = new Thread(new ThreadStart(BingoPrintDocument));
            printProcess.Start();
        }

        private void BingoPrintDocument()
        {
            bool printPerformed = TableBingo.PrintBingo.BingoPrintDocument(TableBingo);
            if (printPerformed == true)
            {
                licenseInfo = new BingoLicense();
                if (licenseInfo.isLicensed == false)
                {
                    FeatureList features = new FeatureList();
                    //splash = new SplashScreen(true, "Thank you for trying Bingo Card Designer.\nThis version will print the same cards for the same word list.\nPurchasing Bingo Card Designer will allow you to print unique cards every time.", licenseInfo.isLicensed);
                    using (features)
                    {
                        features.ShowDialog();
                    }
                }
            }
        }

        private void verifyNumCardsToPrint()
        {
            licenseInfo = new BingoLicense();
            if (licenseInfo.isLicensed == false)
            {
                if (TableBingo.numCardsToPrint > licenseInfo.maxNumCardsToPrint)
                {
                    splash = new SplashScreen(true, "Sorry, the trial version of Bingo Card Designer\nis limited to printing 15 bingo cards.", licenseInfo.isLicensed);
                    using (splash)
                    {
                        splash.ShowDialog();
                    }
                    numberCardsToPrintTextBox.Text = licenseInfo.maxNumCardsToPrint.ToString();
                    TableBingo.numCardsToPrint = licenseInfo.maxNumCardsToPrint;
                }
            }
        }
        private void deleteSelectedItem()
        {
            if (itemsListBox.SelectedItem != null)
            {
                string item = itemsListBox.SelectedItem.ToString();
                if (item != null)
                {
                    Regex spaces = new Regex("^' '$");
                    if (spaces.Match(item) != Match.Empty)
                    {
                        item = "";
                    }
                    if (TableBingo.items.Contains(item) == true)
                    {
                        TableBingo.items.Remove(item);
                    }
                }
            }
        }

        private void itemsListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteSelectedItem();
                addNewItemTextBox.Focus();
                refreshItemsListBox();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void refreshButton_Click_1(object sender, EventArgs e)
        {
            Random rand = new Random();
            TableBingo.RandSeed = rand.Next() % 9999;
            this.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            updateTitleTextBox(titleTextBox.Text, titleCheckBox.Checked);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            updateFreeSpaceTextBox(freeSpaceTextBox.Text, freeSpaceCheckBox.Checked);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitButton_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AskSaveChanges(false);
        }

        private void saveAsNewFile()
        {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Bingo Word Files|*.bwf";
            dialog.AddExtension = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                BingoWordFile file = new BingoWordFile(dialog.FileName, TableBingo.items, TableBingo.titleText, TableBingo.freeSpaceText, TableBingo.rowSize, TableBingo.colSize, TableBingo.numCardsToPrint, TableBingo.numCardsPerPage, TableBingo.printTitle, TableBingo.printFreeSpace);
                TableBingo.DB.writeFile(file);
            }
        }

        private void refreshAfterFileOpen()
        {
            refreshItemsListBox();
            numberCardsToPrintTextBox.Text = TableBingo.numCardsToPrint.ToString();

            cardsPerPageComboBox.Text = TableBingo.numCardsPerPage.ToString();

            cardSizeComboBox.Text = TableBingo.rowSize + "x" + TableBingo.colSize;
            checkCardSize();

            titleCheckBox.Checked = TableBingo.printTitle;
            titleTextBox.Text = TableBingo.titleText;

            freeSpaceCheckBox.Checked = TableBingo.printFreeSpace;
            freeSpaceTextBox.Text = TableBingo.freeSpaceText;
            //freeSpaceCheckBox.Text = TableBingo.freeSpaceText;

            this.Refresh();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AskSaveChanges();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            
            dialog.Filter = "Bingo Word Files|*.bwf";
            dialog.Title = "Select a Bingo Word File to open ...";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                TableBingo = new BingoTable(fileName);
                refreshAfterFileOpen();

            }

        }

        private void AskSaveChanges(bool askToSave)
        {
            DialogResult save = new DialogResult();
            save = DialogResult.Yes;

            if (askToSave == true) {
                save = MessageBox.Show("Do you want to save your changes?", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (save == DialogResult.Yes)
            {
                if ((TableBingo.filePath != null) && (TableBingo.filePath != ""))
                {
                    BingoWordFile file = new BingoWordFile(TableBingo.filePath, TableBingo.items, TableBingo.titleText, TableBingo.freeSpaceText, TableBingo.rowSize, TableBingo.colSize, TableBingo.numCardsToPrint, TableBingo.numCardsPerPage, TableBingo.printTitle, TableBingo.printFreeSpace);
                    TableBingo.DB.writeFile(file);
                }
                else
                {
                    saveAsNewFile();
                }
            }
        }



        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsNewFile();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //AskSaveChanges();  
            openToolStripMenuItem_Click(sender, e);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            AskSaveChanges(true);
            TableBingo = new BingoTable(5, 5);
            refreshAfterFileOpen();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton_Click(sender, e);
        }

        private void BingoWords_FormClosing(object sender, FormClosingEventArgs e)
        {
            AskSaveChanges(true);
            //exitButton_Click(sender, e);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            licenseInfo = new BingoLicense();
            //splash = new SplashScreen(false, licenseInfo.licenseText, licenseInfo.isLicensed);
            using (About aboutBox = new About(licenseInfo.licenseText, licenseInfo.isLicensed))
            {
                aboutBox.ShowDialog();
            }
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RegistrationScreen register = new RegistrationScreen())
            {
                register.ShowDialog();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hide the registration menu if the app is already registered
            licenseInfo = new BingoLicense();
            if (licenseInfo.isLicensed == true)
            {
                registerToolStripMenuItem.Visible = false;
            }
        }

        private void BingoWords_Click(object sender, EventArgs e)
        {
            verifyNumCardsToPrint();
        }

        private void numberCardsToPrintTextBox_Leave(object sender, EventArgs e)
        {
            verifyNumCardsToPrint();
        }

        private void wordWizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WordWizard wordWizard = new WordWizard();

            using (wordWizard)
            {
                wordWizard.ShowDialog();
            }
            if (wordWizard.DialogResult == DialogResult.OK)
            {
                if (wordWizard.words.Count > 0)
                {
                    TableBingo = new BingoTable(wordWizard.words);
                }
                refreshAfterFileOpen();
            }
        }

        private void wordWizardToolStripMenu_Click(object sender, EventArgs e)
        {
            wordWizardToolStripMenuItem_Click(sender, e);
        }

        private void callListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TableBingo.printCallList = callListCheckBox.Checked;
        }

        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
