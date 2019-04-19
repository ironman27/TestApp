using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Classes;
using TestApp.Classes.BoxingUnboxing;
using TestApp.Classes.Event;
using TestApp.Classes.Exception;
using TestApp.Classes.lambda;
using TestApp.Classes.Lock;
using TestApp.Classes.NewOverride;
using TestApp.Classes.structure;
using TestApp.Classes.Static;
using TestApp.Classes.String;
using TestApp.Classes.Thread;
using Console = System.Console;

namespace TestApp
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //    }
    //}


    #region event

    // a class to hold the information about the event
    // in this case it will hold only information
    // available in the clock class, but could hold
    // additional state information
    public class TimeInfoEventArgs : EventArgs
    {
        public int hour;
        public int minute;
        public int second;

        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }

    // The publisher: the class that other classes
    // will observe. This class publishes one delegate:
    // SecondChangeHandler.
    public class Clock
    {
        private int hour;
        private int minute;
        private int second;

        // the delegate the subscribers must implement
        public delegate void SecondChangeHandler(object clock,
                             TimeInfoEventArgs timeInformation);

        // an instance of the delegate
        public event SecondChangeHandler SecondChanged;

        // set the clock running
        // it will raise an event for each new second
        public void Run()
        {
            for (; ; )
            {
                // sleep 100 milliseconds
                Thread.Sleep(100);
                // get the current time
                System.DateTime dt = System.DateTime.Now;
                // if the second has changed
                // notify the subscribers
                if (dt.Second != second)
                {
                    // create the TimeInfoEventArgs object
                    // to pass to the subscriber
                    TimeInfoEventArgs timeInformation =
                         new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);

                    // if anyone has subscribed, notify them
                    if (SecondChanged != null)
                    {
                        SecondChanged(this, timeInformation);
                    }
                }

                // update the state
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
    }

    // A subscriber: DisplayClock subscribes to the
    // clock's events. The job of DisplayClock is
    // to display the current time
    public class DisplayClock
    {
        // given a clock, subscribe to
        // its SecondChangeHandler event
        public void Subscribe(Clock theClock)
        {
            theClock.SecondChanged += TimeHasChanged;
        }

        // the method that implements the
        // delegated functionality
        public void TimeHasChanged(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Current Time: {0}:{1}:{2}",
              ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
        }
    }
    // a second subscriber whose job is to write to a file
    public class LogCurrentTime
    {
        public void Subscribe(Clock theClock)
        {
            //theClock.SecondChanged +=
            //      new Clock.SecondChangeHandler(WriteLogEntry);
            
            theClock.SecondChanged += (object o, TimeInfoEventArgs ti) => 
            {
                                Console.WriteLine("Logging to file: {0}:{1}:{2}",
                ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
            };
        }

        // this method should write to a file
        // we write to the console to see the effect
        // this object keeps no state
        //public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
        //{
        //    Console.WriteLine("Logging to file: {0}:{1}:{2}",
        //       ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
        //}
    }

    public class Tester
    {
        public void Run()
        {
            // create a new clock
            Clock theClock = new Clock();

            // create the display and tell it to
            // subscribe to the clock just created
            DisplayClock dc = new DisplayClock();
            dc.Subscribe(theClock);

            // create a Log object and tell it
            // to subscribe to the clock
            LogCurrentTime lct = new LogCurrentTime();
            lct.Subscribe(theClock);

            // Get the clock started
            theClock.Run();
        }
    }

    public class Program
    {
        public static void Main()
        {
            //Tester t = new Tester();
            //t.Run();

            #region yield

            //var integers = TestIterator();

            //var i = TestIterator();
            //Console.WriteLine(i.ToString());
            //Console.WriteLine(TestIterator());
            //Console.WriteLine(TestIterator());
            //Console.WriteLine(TestIterator());

            //Console.WriteLine("foreach");
            //foreach (var integer in integers)
            //{
            //    Console.WriteLine(integer);
            //}
            //foreach (var integer in TestIterator())
            //{
            //    Console.WriteLine(integer);
            //}

            #endregion yield

            #region Boxing/Unboxing

            //Point p = new Point();
            //p.x = 1;
            //Object o = p;
            //p.x = 2;
            //Console.WriteLine(((Point)o).x.ToString());

            #endregion Boxing/Unboxing

            #region lambda

            //Account account = new Account(100);
            //account.Added += (sender, e) =>
            //{
            //    Console.WriteLine($"Сумма транзакции: {e.Sum}");
            //    Console.WriteLine(e.Message);
            //};
            //account.Withdrawn += (sender, e) =>
            //{
            //    Console.WriteLine(e.Message);          };

            //account.Put(200);
            //account.Put(109);
            //account.Withdraw(500);

            //VariableScopeWithLambdas.Execute();

            //1-10
            //VariableLambdaCapture.vc();

            //10-10
            //VariableLambdaCapture.vcRange();
            #endregion lambda

            #region event

            //EventMain.EventMainExecute();

            #endregion event

            //StructTest.Exec();

            //BoxingUnboxing.BoxingUnboxingTest();

            //CompareString.Compare();

            //LockTest.Test();
            //LockTestTreads.Test();

            //NewOverride.Test();

            //StaticTest.Test();

            #region Exception

            //MyCustomExceptionTest.Test();
            //IndexOutOfRangeExceptionBase.Test();
            //ExceptionC.TestException();

            #endregion Exception



            //Action a1 = () => Console.Write(1); Action a2 = () => Console.Write(2); Action a3 = () => Console.Write(3);
            //((a1 + a2 + a3) - (a1 + a2))();
            //((a1 + a2 + a3) - (a1 + a3))();

            ThreadExample.ThreadMain();

            Console.ReadKey();
        }

        private static IEnumerable<int> TestIterator()
        {
            yield return 11;
            yield return 2;
            yield return 3;
        }
    }

    public struct Point
    {
        public int x;
        public int y;
    }

    #endregion event

    #region delegate

    //public class MediaStorage
    //{
    //    public delegate int PlayMedia();

    //    public void ReportResult(PlayMedia playerDelegate)
    //    {
    //        if (playerDelegate() == 0)
    //        {
    //            Console.WriteLine("Media played successfully.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Media did not play successfully.");
    //        }
    //    }
    //}

    //public class AudioPlayer
    //{
    //    private int audioPlayerStatus;

    //    public int PlayAudioFile()
    //    {
    //        Console.WriteLine("Simulating playing an audio file here.");
    //        audioPlayerStatus = 0;
    //        return audioPlayerStatus;
    //    }
    //}

    //public class VideoPlayer
    //{
    //    private int videoPlayerStatus;

    //    public int PlayVideoFile()
    //    {
    //        Console.WriteLine("Simulating a failed video file here.");
    //        videoPlayerStatus = -1;
    //        return videoPlayerStatus;
    //    }
    //}

    //public class Tester
    //{
    //    public void Run()
    //    {
    //        MediaStorage myMediaStorage = new MediaStorage();

    //        // instantiate the two media players
    //        AudioPlayer myAudioPlayer = new AudioPlayer();
    //        VideoPlayer myVideoPlayer = new VideoPlayer();

    //        // instantiate the delegates
    //        MediaStorage.PlayMedia audioPlayerDelegate = new
    //               MediaStorage.PlayMedia(myAudioPlayer.PlayAudioFile);
    //        MediaStorage.PlayMedia videoPlayerDelegate = new
    //               MediaStorage.PlayMedia(myVideoPlayer.PlayVideoFile);

    //        // call the delegates
    //        myMediaStorage.ReportResult(audioPlayerDelegate);
    //        myMediaStorage.ReportResult(videoPlayerDelegate);

    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Tester t = new Tester();
    //        t.Run();
    //    }
    //}

    #endregion delegae

    #region captureLambdaVariables

    //public static class VariableScopeWithLambdas
    //{
    //    public class VariableCaptureGame
    //    {
    //        internal Action<int> updateCapturedLocalVariable;
    //        internal Func<int, bool> isEqualToCapturedLocalVariable;

    //        public void Run(int input)
    //        {
    //            int j = 0;

    //            updateCapturedLocalVariable = x =>
    //            {
    //                j = x;
    //                bool result = j > input;
    //                Console.WriteLine($"{j} is greater than {input}: {result}");
    //            };

    //            isEqualToCapturedLocalVariable = x => x == j;

    //            Console.WriteLine($"Local variable before lambda invocation: {j}");
    //            updateCapturedLocalVariable(10);
    //            Console.WriteLine($"Local variable after lambda invocation: {j}");
    //        }
    //    }

    //    public static void Main()
    //    {
    //        var game = new VariableCaptureGame();

    //        int gameInput = 5;
    //        game.Run(gameInput);

    //        int jTry = 10;
    //        bool result = game.isEqualToCapturedLocalVariable(jTry);
    //        Console.WriteLine($"Captured local variable is equal to {jTry}: {result}");

    //        int anotherJ = 3;
    //        game.updateCapturedLocalVariable(anotherJ);

    //        bool equalToAnother = game.isEqualToCapturedLocalVariable(anotherJ);
    //        Console.WriteLine($"Another lambda observes a new value of captured variable: {equalToAnother}");
    //    }
    //    // Output:
    //    // Local variable before lambda invocation: 0
    //    // 10 is greater than 5: True
    //    // Local variable after lambda invocation: 10
    //    // Captured local variable is equal to 10: True
    //    // 3 is greater than 5: False
    //    // Another lambda observes a new value of captured variable: True
    //}

    #endregion
}
