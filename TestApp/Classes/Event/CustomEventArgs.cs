using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.Event
{
    public class CustomEventArgs:EventArgs
    {
        public string Message;

        public CustomEventArgs(string msg)
        {
            Message = msg;
        }
    }
}
