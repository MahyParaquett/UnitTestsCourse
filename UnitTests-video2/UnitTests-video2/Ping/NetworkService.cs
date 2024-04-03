using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests_video2.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            return "Success: Ping Sent !";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
    }
}
