using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data.SQLite;


namespace WordSearchDesigner
{
    public partial class WordList : Form
    {
        WordListData data = new WordListData(15);
        PrintWordList screenDraw = new PrintWordList();
        SplashScreen splash;
				BingoLicense licenseInfo;
				Thread printProcess;

        //Thread redrawThread = new Thread(new ThreadStart(data.regeneratePuzzle));

        public WordList()
        {
            InitializeComponent();
            gridSizeTextBox.Text = data.gridSize.ToString();
            
            //System.Threading.Thread.Sleep(3000);
           // splashThread.Abort();

            
            refreshItemsListBox();
            //this.WindowState = FormWindowState.Normal;

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

        private void WordList_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphicsObj;

            graphicsObj = e.Graphics;

            //Idea, start table right under the sampleCardLabel, make it 10 px shorter than the itemsListBox and it has to be square.

            //Put it 5 px under the sampleCardLabel
            int previewSizeX = sampleCardLabel.Location.X + 4;
            int previewSizeY = sampleCardLabel.Location.Y + sampleCardLabel.Size.Height + 5;

            //Start point
            Point pt = new Point(previewSizeX, previewSizeY);
            int previewHeight = (itemsListBox.Location.Y + itemsListBox.Size.Height - previewSizeY) - 8 + 50; //Need to figureo out why have to add 50 to get it to match bottom of itemsListBox
            int previewWidth = previewHeight;


            //Adjust the height and column size so they divide evenly into gridSize
            //This is done because we use integer sizes and we want everything to line up correctly.
            //Otherwise, there will be badness.
            int gridSize = data.gridSize;

            int remainder = previewHeight % gridSize;
            while (remainder != 0)
            {
                previewHeight += 1;
                remainder = previewHeight % gridSize;
            }

            gridSize = data.gridSize;
            remainder = previewWidth % gridSize; //Width doesn't have a title in it
            while (remainder != 0)
            {
                previewWidth += 1;
                remainder = previewWidth % gridSize;
            }
            //End resize

            if ((previewHeight <= 0) || (previewWidth <= 0))
            {
                return;
            } //Avoid badness

            Size sz = new Size(previewWidth, previewHeight);

            screenDraw.drawWordList(pt, sz, data, Color.Red, data.showSolution, ref graphicsObj);
            //TableBingo.PrintBingo.DrawBingoCard(pt, sz, TableBingo, System.Drawing.Color.Red, ref graphicsObj);

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            exitProgram();
        }

        private void titleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (titleTextBox.Text == "")
            {
                titleTextBox.Text = "Word Search";

            }
            updateTitleTextBox(titleTextBox.Text, titleCheckBox.Checked);
        }

        private void updateTitleTextBox(string title, bool enabled)
        {
            titleTextBox.Enabled = enabled;
            data.titleText = title;
            data.printTitle = enabled;
        }

        private void WordList_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

				private void gridSizeTextBox_TextChanged(object sender, EventArgs e) {
			
				}

        private void gridSizeOk_Click(object sender, EventArgs e)
        {
            regeneratePuzzleAndGrid();
        }

        private void titleTextBoxOk_Click(object sender, EventArgs e)
        {
            titleCheckBox_CheckedChanged(sender, e);
        }

        private void showSolutionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            data.showSolution = showSolutionCheckBox.Checked;
            this.Refresh();
        }

        private void regeneratePuzzleAndGrid()
        {
					int temp;
					try {
						temp = int.Parse(gridSizeTextBox.Text);
					}
					catch {
						MessageBox.Show("Grid Size Must be a Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					licenseInfo = new BingoLicense();
					if (licenseInfo.isLicensed == false) {
						if (temp > licenseInfo.gridSize) {
							temp = licenseInfo.gridSize;
							gridSizeTextBox.Text = temp.ToString();
							splash = new SplashScreen(true, "Sorry, the trial version of Word Search Designer\nis limited to a grid size of 15.", licenseInfo.isLicensed);
							using (splash) {
								splash.ShowDialog();
							}
						}
					}

					data.gridSize = temp;
						
						regeneratingPuzzleWait wait = new regeneratingPuzzleWait(ref data);
            using (wait)
            {
                wait.ShowDialog();
                //				data.gridSize = int.Parse(gridSizeTextBox.Text);
            }
            this.Refresh();

        }

        private void gridSizeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                regeneratePuzzleAndGrid();
            }
        }

        private void printGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            data.printGrid = printGridCheckBox.Checked;
            this.Refresh();
        }

        private void printSolutionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            data.printSolution = printSolutionCheckBox.Checked;
        }

        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshItemsListBox()
        {
            itemsListBox.Items.Clear();
            Regex spaces = new Regex("^ *$");
            foreach (string item in data.words)
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
            NumItemstoolStripStatusLabel.Text = data.words.Count + " items";
            return;
        }

				private void addItemButton_Click(object sender, EventArgs e) {
							addWord();
							addNewItemTextBox.Clear();
							addNewItemTextBox.Focus();
				}

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            deleteSelectedItem();
            refreshItemsListBox();
        }

				private void addWord() {
					licenseInfo = new BingoLicense();
					if (licenseInfo.isLicensed == false) {
						if (data.words.Count >= licenseInfo.maxWordSearchWords) {
							splash = new SplashScreen(true, "Sorry, the trial version of Word Search Designer\nis limited to " + licenseInfo.maxWordSearchWords + " words at a time.", licenseInfo.isLicensed);
							using (splash) {
								splash.ShowDialog();
								return;
							}
						}
					}
					data.words.Add(addNewItemTextBox.Text);
					refreshItemsListBox();

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
                    if (data.words.Contains(item) == true)
                    {
                        data.words.Remove(item);
                    }
                }
            }
        }

        private void addNewItemTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addWord();
                addNewItemTextBox.Clear();
                addNewItemTextBox.Focus();

            }
        }

        private void itemsListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int nextIndex = itemsListBox.SelectedIndex;
                deleteSelectedItem();
                refreshItemsListBox();
                try
                {
                    itemsListBox.SelectedIndex = nextIndex;
                }
                catch
                {
                    try
                    {
                        itemsListBox.SelectedIndex = nextIndex - 1;
                    }

                    catch
                    {

                        //do nothing
                    }

                    //Do nothing
                }
            }
        }

        private void refreshGridButton_Click(object sender, EventArgs e)
        {
            regeneratePuzzleAndGrid();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            regeneratePuzzleAndGrid();
        }

        private void allowVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allowVerticalToolStripMenuItem.Checked == true)
            {
                allowVerticalToolStripMenuItem.Checked = false;
            }
            else
            {
                allowVerticalToolStripMenuItem.Checked = true;
            }
            data.allowedDirections.vertical = allowVerticalToolStripMenuItem.Checked;

        }

        private void allowDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allowDiagonalToolStripMenuItem.Checked == true)
            {
                allowDiagonalToolStripMenuItem.Checked = false;
            }
            else
            {
                allowDiagonalToolStripMenuItem.Checked = true;
            }
            data.allowedDirections.Diagonal = allowDiagonalToolStripMenuItem.Checked;
        }

        private void allowHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allowHorizontalToolStripMenuItem.Checked == true)
            {
                allowHorizontalToolStripMenuItem.Checked = false;
            }
            else
            {
                allowHorizontalToolStripMenuItem.Checked = true;
            }
            data.allowedDirections.Horizontal = allowHorizontalToolStripMenuItem.Checked;
        }

        private void allowBackwardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allowBackwardsToolStripMenuItem.Checked == true)
            {
                allowBackwardsToolStripMenuItem.Checked = false;
            }
            else
            {
                allowBackwardsToolStripMenuItem.Checked = true;
            }
            data.allowedDirections.Backwards = allowBackwardsToolStripMenuItem.Checked;
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printToolStripMenuItem_Click(sender, e);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
					if (printProcess != null) {
						if (printProcess.IsAlive == true) {
							printProcess.Abort();
						}
					}

					printProcess = new Thread(new ThreadStart(WordSearchPrintDocument));
					printProcess.Start();

        }

				private void WordSearchPrintDocument() {

					bool printPerformed = screenDraw.PrintWordSearchDocument(ref this.data);

					if (printPerformed == true) {
						licenseInfo = new BingoLicense();
						if (licenseInfo.isLicensed == false) {
							FeatureList features = new FeatureList();
							//splash = new SplashScreen(true, "Thank you for trying Bingo Card Designer.\nThis version will print the same cards for the same word list.\nPurchasing Bingo Card Designer will allow you to print unique cards every time.", licenseInfo.isLicensed);
							using (features) {
								if (features.ShowDialog() == DialogResult.OK) {
									this.WindowState = FormWindowState.Minimized;
								}
							}
						}

					}


				}

        private void itemsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

            //
            // Draw the background of the ListBox control for each item.
            // Create a new Brush and initialize to a Black colored brush
            // by default.
            //
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            //
            // Determine the color of the brush to draw each item based on 
            // the index of the item to draw.
            //
            if (e.Index < 0)
            {
                return;
            }
            string item = ((ListBox)sender).Items[e.Index].ToString();
            item = item.Replace(" ", "");
            if (data.puzzle.unableToPlace.Contains(item))
            {
                myBrush = Brushes.Red;
            }
            else
            {
                myBrush = Brushes.Black;
            }

            //
            // Draw the current item text based on the current 
            // Font and the custom brush settings.
            //
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            //
            // If the ListBox has focus, draw a focus rectangle 
            // around the selected item.
            //
            e.DrawFocusRectangle();

        }

        private void itemsListBox_MouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";

            //Get the item
            int nIdx = itemsListBox.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < itemsListBox.Items.Count))
                strTip = itemsListBox.Items[nIdx].ToString();
            strTip = strTip.Replace(" ", "");
            if (data.puzzle.unableToPlace.Contains(strTip))
            {
                itemsListBoxToolTip.ToolTipTitle = strTip;
                itemsListBoxToolTip.Active = true;
            }
            else
            {
                itemsListBoxToolTip.Active = false;
            }

            //					itemsListBox.SetToolTip(itemsListBox, strTip);
        }



        private void WordList_Load(object sender, EventArgs e)
        {
            itemsListBoxToolTip.SetToolTip(this.itemsListBox, "Word will not fit. Try refreshing \nor a larger grid size.");

            licenseInfo = new BingoLicense();
            splash = new SplashScreen(false, licenseInfo.licenseText, licenseInfo.isLicensed);

            Thread splashThread = new Thread(new ThreadStart(showSplashScreen));
            splashThread.Start();

        }

				private void numberCardsToPrintTextBox_TextChanged(object sender, EventArgs e) {
					int numCardsToPrint = -1;
					if (numberCardsToPrintTextBox.Text == "") {
						data.numCardsToPrint = 1;
						return;
					} //If they clear it out, set it to 1 by default

					try {
						numCardsToPrint = int.Parse(numberCardsToPrintTextBox.Text);
					}
					catch {
						numberCardsToPrintTextBox.Text = data.numCardsToPrint.ToString();
						numCardsToPrint = data.numCardsToPrint;
						//data.numCardsToPrint = int.Parse(numberCardsToPrintTextBox.Text);
					}
					finally {
						licenseInfo = new BingoLicense();
						if (licenseInfo.isLicensed == false) {
							if (numCardsToPrint > licenseInfo.maxWordSearchCardsToPrint) {
								numCardsToPrint = licenseInfo.maxWordSearchCardsToPrint;
								splash = new SplashScreen(true, "Sorry, the trial version of Word Search Designer\nis limited to printing " + licenseInfo.maxWordSearchCardsToPrint + " puzzles at a time.", licenseInfo.isLicensed);
								using (splash) {
									splash.ShowDialog();
								}
							}
							data.numCardsToPrint = numCardsToPrint;
							numberCardsToPrintTextBox.Text = data.numCardsToPrint.ToString();
						}
					}
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
                saveFile(dialog.FileName);
                //BingoWordFile file = new BingoWordFile(dialog.FileName, TableBingo.items, TableBingo.titleText, TableBingo.freeSpaceText, TableBingo.rowSize, TableBingo.colSize, TableBingo.numCardsToPrint, TableBingo.numCardsPerPage, TableBingo.printTitle, TableBingo.printFreeSpace);
                //TableBingo.DB.writeFile(file);
            }
        }

        public bool saveFile(string filePath)
        {
            try
            {
                puzzleDataFile file = new puzzleDataFile(data.words, data.printTitle, data.titleText, data.titleTextFont, data.titleFontSize, data.titleTextBuffer, data.gridSize, data.cardsPerPage, data.numCardsToPrint, data.printGrid, data.printSolution, data.printWordList, data.showSolution, data.allowedDirections.convertToString(), filePath);
                data.fileFuncs.writeFile(file);
            }
            catch
            {
                return (false);
            }
            return (true);
        }

        private void AskSaveChanges(bool askToSave)
        {
            DialogResult save = new DialogResult();
            save = DialogResult.Yes;

            if (askToSave == true)
            {
                save = MessageBox.Show("Do you want to save your changes?", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (save == DialogResult.Yes)
            {
                if ((data.filePath != null) && (data.filePath != ""))
                {
                    saveFile(data.filePath);

                    //BingoWordFile file = new BingoWordFile(TableBingo.filePath, TableBingo.items, TableBingo.titleText, TableBingo.freeSpaceText, TableBingo.rowSize, TableBingo.colSize, TableBingo.numCardsToPrint, TableBingo.numCardsPerPage, TableBingo.printTitle, TableBingo.printFreeSpace);
                    //TableBingo.DB.writeFile(file);
                }
                else
                {
                    saveAsNewFile();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitProgram();
        }

        private void exitProgram()
        {
            DialogResult = DialogResult.OK;
            this.Close();
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
                if (data.openFile(fileName) == false)
                {
                    MessageBox.Show("Unable to open file " + fileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                refreshAfterFileOpen();

            }
        }

        private void refreshAfterFileOpen()
        {
            titleCheckBox.Checked = data.printTitle;
            titleTextBox.Text = data.titleText;

            gridSizeTextBox.Text = data.gridSize.ToString();

            showSolutionCheckBox.Checked = data.showSolution;

            printGridCheckBox.Checked = data.printGrid;
            printSolutionCheckBox.Checked = data.printSolution;
            wordListCheckBox.Checked = data.printWordList;
            numberCardsToPrintTextBox.Text = data.numCardsToPrint.ToString();

            allowVerticalToolStripMenuItem.Checked = data.allowedDirections.vertical;
            allowHorizontalToolStripMenuItem.Checked = data.allowedDirections.Horizontal;
            allowDiagonalToolStripMenuItem.Checked = data.allowedDirections.Diagonal;
            allowBackwardsToolStripMenuItem.Checked = data.allowedDirections.Backwards;

            //regeneratePuzzleAndGrid();
            this.Refresh();
            refreshItemsListBox();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsNewFile();
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
                    data = new WordListData(wordWizard.words);
                    //TableBingo = new BingoTable(wordWizard.words);
                }
                refreshAfterFileOpen();
            }
        }

        private void wordWizardToolStripMenuButton_Click(object sender, EventArgs e)
        {
            wordWizardToolStripMenuItem_Click(sender, e);
        }

				private void registerToolStripMenuItem_Click(object sender, EventArgs e) {
					using (RegistrationScreen register = new RegistrationScreen()) {
						register.ShowDialog();
					}
				}

				private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
					//Hide the registration menu if the app is already registered
					licenseInfo = new BingoLicense();
					if (licenseInfo.isLicensed == true) {
						registerToolStripMenuItem.Visible = false;
					}
				}

				private void aboutToolStripMenuItem1_Click(object sender, EventArgs e) {
					licenseInfo = new BingoLicense();
					//splash = new SplashScreen(false, licenseInfo.licenseText, licenseInfo.isLicensed);
					using (About aboutBox = new About(licenseInfo.licenseText, licenseInfo.isLicensed)) {
						if (aboutBox.ShowDialog() == DialogResult.OK) {
							this.WindowState = FormWindowState.Minimized;
						}
					}
				}

				private void WordList_FormClosing(object sender, FormClosingEventArgs e) {
					AskSaveChanges(true);
				}

				private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            AskSaveChanges(true);
						data = new WordListData(15);
            refreshAfterFileOpen();
        }

                private void newToolStripButton_Click(object sender, EventArgs e)
                {
                    newToolStripMenuItem_Click(sender, e);
                }

    }
}