using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace Sekuntikello
{
    public partial class Form1 : Form
    {
        // member variables
        // background thread
        private Thread thread;
        // background thread information
        private WorkerThread worker;

        public Form1()
        {
            InitializeComponent();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            // create an object of the delegate. Give the UI update method as a parameter
            OutputMessage om = new OutputMessage(updateSecs);
            worker = new WorkerThread(this, om);
            thread = new Thread(new ThreadStart(worker.ThreadProc));
            thread.Name = "Timer";
            thread.Start();
            buttonStop.Enabled = true;
        }

        private void updateSecs(int sec)
        {   // the seconds are updated here
            // the worker thread must not call this directly
            Debug.Assert(this.InvokeRequired == false);
            textBox1.Text = sec.ToString();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            worker.StopThread();
            // wait the worker thread to stop
            thread.Join();
            buttonStart.Enabled = true;

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker != null)
          {
            if (thread.IsAlive)
            {
                worker.StopThread();
              thread.Join();
            }
          }
        }
    }
}