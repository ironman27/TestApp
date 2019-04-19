using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.Thread
{
    public class ThreadExample
    {
        public static void ThreadMain()
        {

            Console.WriteLine("Create new thread!");
            System.Threading.Thread thread = new System.Threading.Thread(OtherTread);

            Console.WriteLine("Start new thread!");
            thread.Start(5);


            Console.WriteLine("Working current thread!");
            System.Threading.Thread.Sleep(10000);

            thread.Join();

            Console.WriteLine("End current thread!");
        }

        public static void OtherTread(object o)
        {

            Console.WriteLine("Working new thread!");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("End new thread!");
        }
    }
}
