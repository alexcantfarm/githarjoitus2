using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sekuntikello
{
    // delegate is needed
    public delegate void OutputMessage(int sec);

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
            int i = 0;
            while (bContinue)
            {
                // "call" the UI to update the textbox indirectly
                form.BeginInvoke(outMsg, new object[] { i });
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
