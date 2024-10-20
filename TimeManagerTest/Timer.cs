
using System;
using System.Diagnostics;
namespace TimeManagerTest
{
    public class Timer
    {
        public readonly Stopwatch stopWatch1 = new Stopwatch();
        public readonly Stopwatch stopWatch2 = new Stopwatch();
        public readonly Stopwatch stopWatch3 = new Stopwatch();
        public readonly Stopwatch stopWatch4 = new Stopwatch();
        public readonly Stopwatch stopWatch5 = new Stopwatch();
        public readonly Stopwatch stopWatch6 = new Stopwatch();
        public readonly Stopwatch stopWatch7 = new Stopwatch();
        public readonly Stopwatch stopWatch8 = new Stopwatch();
        public readonly Stopwatch stopWatch9 = new Stopwatch();
        public void Activity(User user, Stopwatch stopWatch, string yourActivity)
        {
            stopWatch.Start();
            int timerLoopCheck = 1;
            Console.WriteLine(
                "1 - end of this activity, 2 - pause timer, enter - check how much time do you spend doing this activity by now");
            while (timerLoopCheck != 0)
            {
                Console.WriteLine("{0:hh\\:mm\\:ss\\.ff} ", stopWatch.Elapsed);
                int.TryParse(Console.ReadLine(), out int pauseResult);
                if (pauseResult == 1)
                {
                    stopWatch.Stop();
                    timerLoopCheck = 0;
                }
                else if (pauseResult == 2)
                {
                    int continueTimerResult = 0;
                    stopWatch.Stop();
                    while (continueTimerResult != 1)
                    {
                        Console.WriteLine("1 - continue timer");
                        var continueTimer = Console.ReadLine();
                        int.TryParse(continueTimer, out continueTimerResult);
                        if (continueTimerResult == 1)
                        {
                            stopWatch.Start();
                        }
                    }
                }
            }
        }
    }

}