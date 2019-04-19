using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Classes.String
{
    class CompareString
    {
        public static void Compare()
        {
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";

            Console.WriteLine(s1 == s2);
            Console.WriteLine((object)s1 == (object)s2);
            Console.WriteLine(s2 == s3);
            Console.WriteLine((object)s2 == (object)s3);

            //если две строки имеют одинаковый набор символов и создаются во время компиляции, то они фактически указывают на один и тот же объект.
            //строка s1 создается в процессе выполнения, поэтому она будет указывать на другой объект, отличный от s2 и s3.
            //А так как при сравнении объектов сравниваются ссылки, то поэтому мы получим false, так как s1 и s2 разные объекты.
        }
    }
}
