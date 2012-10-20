using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace BingoWords
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            Mutex m = new Mutex(true, "Bingo Card Designer", out createdNew);

            if (!createdNew)
            {
                // app is already running...
                MessageBox.Show("A copy of Bingo Card Designer is already open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BingoWords());

            // keep the mutex reference alive until the normal termination of the program
            GC.KeepAlive(m);
        }
    }
}
