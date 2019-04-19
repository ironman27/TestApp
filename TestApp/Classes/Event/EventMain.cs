using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.Event
{
    public static class EventMain
    {
        public static void EventMainExecute()
        {
            MailManager mailManager = new MailManager();
            Fax fax = new Fax(mailManager);
            Sms sms = new Sms(mailManager);

            mailManager.SendNotify("hello!");
            
            Console.ReadKey();
        }
    }
}
