using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp.Classes.lambda
{
    class VariableLambdaCapture
    {
        public static void vc()
        {

            Console.WriteLine("foreach");
            var listActions = new List<Action>();
            foreach (int i in Enumerable.Range(1, 10))
            {
                listActions.Add(() => Console.WriteLine(i));
            }

            foreach (Action action in listActions)
            {
                action();
            }

            Console.WriteLine("for");
            List<Action> actions = new List<Action>();
            for (var count = 0; count < 10; count++)
            {
                actions.Add(() => Console.WriteLine(count));
            }
            foreach (var action in actions)
            {
                action();
            }
        }

        public static void vcRange()
        {
            var listActions = new List<Action>();

            int temp;
            foreach (int i in Enumerable.Range(1, 10))
            {
                temp = i;
                listActions.Add(() => Console.WriteLine(temp));
            }

            foreach (Action action in listActions)
            {
                action();
            }
        }

        public static void Count(Func<int> counter)
        {
            for (int i = 0; i < 10; ++i)
                Console.WriteLine("{0}, ", counter());
        }
    }
}
