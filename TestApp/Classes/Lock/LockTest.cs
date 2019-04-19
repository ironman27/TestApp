using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp.Classes.Lock
{
    public class LockTestTreads
    {
        public static void Test()
        {
            //while (true)
            //{
            //}
            object sync = new object();
            var thread = new System.Threading.Thread(() =>
            {
                try
                {
                    Work();
                }
                finally
                {
                    lock (sync)
                    {
                        Monitor.PulseAll(sync);
                    }
                }
            });
            thread.Start();
            lock (sync)
            {
                Monitor.Wait(sync);
            }
            Console.WriteLine("test");
        }
        private static void Work()
        {
            System.Threading.Thread.Sleep(1000);
        }
    }
}
