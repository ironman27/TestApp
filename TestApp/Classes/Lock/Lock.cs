using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.Lock
{
    public static class LockTest
    {
        private static Object syncObject = new Object();
        private static void Write()
        {
            lock (syncObject)
            {
                Console.WriteLine("test");
            }
        }
        public static void Test()
        {
            //два lock'а не приведут к взаимоблокировке в данном случае, поскольку дело происходит в одном и том же потоке.
            lock (syncObject)
            {
                Write();
            }
        }
    }
}
