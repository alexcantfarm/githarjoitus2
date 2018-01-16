using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ListViewTesti1
{
    public partial class Form1 : Form
    {
        WorkerThread worker;
        Thread thread;
        public Form1()
        {
            InitializeComponent();

            chart.Series.Add("pressure");
            chart.Series.Add("temperature");


        }

        private void buttonLisaa_Click(object sender, EventArgs e)
        {


        }

        private void updateMeasurements(Measurement mes)
        {   // the seconds are updated here
            // the worker thread must not call this directly
            Debug.Assert(this.InvokeRequired == false);
            

            int rivi = listView1.Items.Count;

            // new row and first colomn
            listView1.Items.Add(mes.Time + " s");

            

            
            


            // second and third columns
            listView1.Items[rivi].SubItems.Add(mes.Pressure + " bar");
            chart.Series["pressure"].Points.AddXY(mes.Time, mes.Pressure);

            listView1.Items[rivi].SubItems.Add(mes.Temp + " C");
            chart.Series["temperature"].Points.AddXY(mes.Time, mes.Temp);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            

           
            
            chart.Series["pressure"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["pressure"].ChartArea = "ChartArea1";

            chart.Series["temperature"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series["temperature"].ChartArea = "ChartArea1";

            OutputMessage om = new OutputMessage(updateMeasurements);
            this.worker = new WorkerThread(this, om);
            thread = new Thread(new ThreadStart(worker.ThreadProc));
            thread.Name = "measurizer";
            thread.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            worker.StopThread();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread.IsAlive)
            {
                worker.StopThread();
                thread.Join();
            }
        }
    }
}