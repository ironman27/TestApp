using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.Event
{
    public interface IMailManager
    {
        event EventHandler<CustomEventArgs> Notify ;
    }
}
