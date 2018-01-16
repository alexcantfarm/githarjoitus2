using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sekuntikello
{
    public delegate void OutputMessage(int sec);

    class WorkerThread
    {
        private volatile bool bContinue = true;
        private OutputMessage outMsg;
        private Form form;
        // konstruktori
        public WorkerThread(Form form, OutputMessage outMsg)
        {
            this.form = form;
            this.outMsg = outMsg;
        }

        // run-metodi
        public void ThreadProc()
        {
            int i = 0;
            while (bContinue)
            {
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
