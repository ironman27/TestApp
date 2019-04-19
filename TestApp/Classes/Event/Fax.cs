using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.Event
{
    public class Fax
    {
        private IMailManager _mailManager;
        public Fax(IMailManager mailManager)
        {
            _mailManager = mailManager;
            mailManager.Notify += MailManagerOnNotify;
        }

        private void MailManagerOnNotify(object sender, CustomEventArgs e)
        {
            Console.WriteLine(this.GetType().Name + " " + e.Message);
        }
    }
}
