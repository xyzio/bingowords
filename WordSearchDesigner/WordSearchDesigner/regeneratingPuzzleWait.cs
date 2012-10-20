using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace WordSearchDesigner
{
    public partial class regeneratingPuzzleWait : Form
    {
        WordListData data;
        Thread generatePuzzle;
        System.Windows.Forms.Timer progressBarTimer;

        public regeneratingPuzzleWait(ref WordListData incomingData)
        {
            data = incomingData;
            generatePuzzle = new Thread(new ThreadStart(data.regeneratePuzzle));
            InitializeComponent();
        }

        private void regeneratingPuzzleWait_Load(object sender, EventArgs e)
        {
            //Start telnet run
            generatePuzzle.Start();

            //Set up progress bar
            calculatingPuzzleProgressBar.Step = 1;
            calculatingPuzzleProgressBar.Minimum = 0;
            calculatingPuzzleProgressBar.Maximum = 200;

            //Set up progress bar timer
            progressBarTimer = new System.Windows.Forms.Timer();
            progressBarTimer.Tick += new EventHandler(progressBarTimer_Tick);
            progressBarTimer.Interval = 500;
            progressBarTimer.Start();
        }

        private void progressBarTimer_Tick(object sender, System.EventArgs e)
        {
            if (generatePuzzle.IsAlive == false)
            {
                generatePuzzle.Abort();
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            if (calculatingPuzzleProgressBar.Value >= 200)
            {
                calculatingPuzzleProgressBar.Value = 0;
                return;
            }
            calculatingPuzzleProgressBar.Value += 10;
        }

    }
}
