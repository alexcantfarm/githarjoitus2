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
        // jäsenmuuttujat
        // säie
        private Thread thread;
        // luokka, jonka sisällä on worker threadiin liittyvä toiminta
        private WorkerThread sekuntiKello;

        public Form1()
        {
            InitializeComponent();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            OutputMessage om = new OutputMessage(updateSecs);
            sekuntiKello = new WorkerThread(this, om);
            thread = new Thread(new ThreadStart(sekuntiKello.ThreadProc));
            thread.Name = "Sekuntikello";
            thread.Start();
            buttonStop.Enabled = true;
        }

        private void updateSecs(int sec)
        {
            Debug.Assert(this.InvokeRequired == false);
            textBox1.Text = sec.ToString();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop.Enabled = false;
            sekuntiKello.StopThread();
            thread.Join();
            buttonStart.Enabled = true;

        }
    }
}