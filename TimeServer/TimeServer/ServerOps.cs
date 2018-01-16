using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeServer
{
    class ServerOps
    {
        private int count = 0;
        public string getTime()
        {
            count++;
            return DateTime.Now.ToShortTimeString();

        }

        public int getCount()
        {
            count++;
            return this.count;
        }

      

    
    }
}
