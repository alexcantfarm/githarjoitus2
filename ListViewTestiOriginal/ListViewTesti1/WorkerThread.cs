using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewTesti1
{
    // delegate is needed
    public delegate void OutputMessage(Measurement mes);

    class WorkerThread
    {
        private volatile bool bContinue = true;
        private OutputMessage outMsg;
        private Form form;
        // constructor
        public WorkerThread(Form form, OutputMessage outMsg)
        {
            // We need to know the form which contains the textbox to be updated
            this.form = form;
            // The method, which updates the textbox in UI thread is given through delegate OutputMessage
            this.outMsg = outMsg;
        }

        // run-metodi
        public void ThreadProc()
        {
            Random rnd = new Random();
            Measurement mes = new ListViewTesti1.Measurement();
            int i = 0;
            while (bContinue)
            {
                mes.Time = i;
                mes.Pressure = 1024 + 10* rnd.NextDouble() + Math.Sin(i);
                mes.Temp = 273 + 2 * rnd.NextDouble() * Math.Cos(i / 5);
                if(i%5 == 0){
                    mes.Temp -= 50;
                    mes.Pressure -= 500;
                }
                // "call" the UI to update the textbox indirectly
                form.BeginInvoke(outMsg, new object[] { mes });
                Thread.Sleep(1000);
                i++;
            }
        }

        public void StopThread()
        {
            bContinue = false;
        }
    }
}
