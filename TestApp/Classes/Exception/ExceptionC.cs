using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.Exception
{
    public static class ExceptionC
    {
        private class Test
        {
            public void Print()
            {
                try
                {
                    throw new System.Exception();
                }
                catch (System.Exception)
                {
                    Console.Write("9");
                    throw new System.Exception();
                }
                finally
                {
                    Console.Write("2");
                }
            }
        }
        public static void TestException()
        {
            var test = new Test();
            try
            {
                test.Print();
            }
            catch (System.Exception)
            {
                Console.Write("5");
            }
            finally
            {
                Console.Write("4");
            }
            //9254
            Console.ReadLine();
        }
    }
}
