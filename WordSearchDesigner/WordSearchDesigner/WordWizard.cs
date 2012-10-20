using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wizard;

namespace WordSearchDesigner
{
    public partial class WordWizard : Form
    {
        BingoWordWizard wordWizard = new BingoWordWizard();
        public List<string> words = new List<string>();

        public WordWizard()
        {
            InitializeComponent();
        }

        private void WordWizard_Load(object sender, EventArgs e)
        {
            foreach (string cat in wordWizard.categories.Keys)
            {
                categoryListBox.Items.Add(cat);
            }
        }

        private void categoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wordListListBox.Items.Clear();
            listNameListBox.Items.Clear();
            string currentItem = categoryListBox.Text;

            if (currentItem == "")
            {
                return;
            }

            foreach (Wizard.WordList list in wordWizard.categories[currentItem])
            {
                listNameListBox.Items.Add(list.name);
            }
            // categoryLabel.Location = new Point(listNameListBox.Location.X, listNameListBox.Location.Y - categoryLabel.Size.Height - 5);
            // categoryLabel.Text = "Select a Word List ...";
        }

        private void listNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wordListListBox.Items.Clear();
            string currentCategory = categoryListBox.Text;
            string listName = listNameListBox.Text;

            if (currentCategory == "")
            {
                return;
            }

            foreach (Wizard.WordList list in wordWizard.categories[currentCategory])
            {
                if (list.name == listName)
                {
                    foreach (string word in list.words)
                    {
                        wordListListBox.Items.Add(word);
                    }
                }
            }
            // categoryLabel.Location = new Point(categoryListBox.Location.X, categoryListBox.Location.Y - categoryLabel.Size.Height - 5);
            //categoryLabel.Text = "Select a Category ...";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void addToNewCardButton_Click(object sender, EventArgs e)
        {
            foreach (string item in wordListListBox.Items)
            {
                words.Add(item);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void dynamicHelpLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
