using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.BoxingUnboxing
{
    public static class BoxingUnboxing
    {
        public static void BoxingUnboxingTest()
        {
            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i);
            Console.WriteLine(obj);
            Console.WriteLine((short)obj);//InvalidCastException
        }
    }
}
