using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.Event
{
    public class MailManager: IMailManager
    {
        public event EventHandler<CustomEventArgs> Notify;

        public virtual void OnNotify(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = Notify;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SendNotify(string msg)
        {
            CustomEventArgs e = new CustomEventArgs(msg);
            OnNotify(e);
        }
    }
}
