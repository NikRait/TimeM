using System;
using System.IO;


namespace TimeManagerTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var user = new User("/", "/", "/", "/", "/", "/", "/", "/", "/", "/");
            var watch = new Timer();
            Console.WriteLine("Do you have saved user Name?");
            Console.WriteLine("1 - Yes, I wanna Log in; 2 - No I wanna Sign in");
            int answerAboutAccount = 0;
            int fileCheck = 1;
            while (fileCheck != 0)
            {
                bool checkAccount = int.TryParse(Console.ReadLine(), out answerAboutAccount);
                while (answerAboutAccount != 1 && answerAboutAccount != 2)
                {
                    if (checkAccount == false)
                    {
                        Console.WriteLine("Please enter correct value");
                    }
                    else
                    {
                        if (answerAboutAccount <= 0 || answerAboutAccount >= 3)
                        {
                            Console.WriteLine("Please enter correct value");
                        }
                    }
                }
                if (answerAboutAccount == 1)
                {
                    try
                    {
                        user.StreamRead();
                        fileCheck = 0;
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("You don't have an account yet. Please sign in before.");
                        fileCheck = 1;
                    }
                    
                }
                else
                {
                    try
                    {
                        user.StreamWrite();
                        fileCheck = 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        fileCheck = 1;
                    }
                }
            }
            var count = "";
            var loopMainDecision2 = 1;
            string yourActivity;
            while (loopMainDecision2 != 0)
            {
                var loopMainDecision1 = 0;
                Console.WriteLine("What kind of activity do you wanna do now?");
                while (loopMainDecision1 != 1)
                {
                    string mainDecision = Console.ReadLine();
                    bool checkInTimer = int.TryParse(mainDecision, out var resultMainDecision);
                    if (checkInTimer == false)
                    {
                        Console.WriteLine("Please enter the correct value.");
                    }
                    else if (resultMainDecision < 0 || resultMainDecision > 9)
                    {
                        Console.WriteLine("Please enter the correct value.");
                    }
                    else
                    {
                        try
                        {
                            
                            switch (resultMainDecision)
                            {
                                case 1:
                                    yourActivity = user.firstActivity;
                                    count += "1";
                                    watch.Activity(user, watch.stopWatch1, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                case 2 when user.secondActivity != "/":
                                    yourActivity = user.secondActivity;
                                    count += "2";
                                    watch.Activity(user, watch.stopWatch2, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                case 3 when user.thirdActivity != "/":
                                    yourActivity = user.thirdActivity;
                                    count += "3";
                                    watch.Activity(user, watch.stopWatch3, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                case 4 when user.fourthActivity != "/":
                                    yourActivity = user.fourthActivity;
                                    count += "4";
                                    watch.Activity(user, watch.stopWatch4, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                case 5 when user.fifthActivity != "/":
                                    yourActivity = user.fifthActivity;
                                    count += "5";
                                    watch.Activity(user, watch.stopWatch5, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                case 6 when user.sixthActivity != "/":
                                    yourActivity = user.sixthActivity;
                                    count += "6";
                                    watch.Activity(user, watch.stopWatch6, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                case 7 when user.seventhActivity != "/":
                                    yourActivity = user.seventhActivity;
                                    count += "7";
                                    watch.Activity(user, watch.stopWatch7, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                case 8 when user.eighthActivity != "/":
                                    yourActivity = user.eighthActivity;
                                    count += "8";
                                    watch.Activity(user, watch.stopWatch8, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                case 9 when user.ninthActivity != "/":
                                    yourActivity = user.ninthActivity;
                                    count += "9";
                                    watch.Activity(user, watch.stopWatch9, yourActivity);
                                    loopMainDecision1 = 1;
                                    break;
                                default:
                                    throw new NoMoreActException("You don't have this count of activities");
                            }
                        }
                        catch (NoMoreActException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                Console.WriteLine("Another activity - 1, Sum up - 0");
                int result = 10;
                while (result != 1)
                {
                    var decisionAfterEndOfActivity = int.TryParse(Console.ReadLine(), out result);
                    if (decisionAfterEndOfActivity == false)
                    {
                        Console.WriteLine("Please enter the correct value");
                        result = 10;
                    }
                    else if (result < 0 || result > 1)
                    {
                        Console.WriteLine("Please enter the correct value");
                    }
                    else if (result == 1)
                    {
                    }
                    else
                    {
                        string actCount = "";
                        char[] realCount = new char[count.Length];
                        var number = 0;
                        foreach (var item in count)
                        {
                            realCount[number] = item;
                            number++;
                        }
                        for (int k = 0; k < realCount.Length; k++)
                        {
                            var repeatCheck = false;
                            foreach (var item in actCount)
                            {
                                if (item == realCount[k])
                                {
                                    repeatCheck = true;
                                }
                                else if (repeatCheck == true)
                                {

                                }
                                else
                                    repeatCheck = false;
                            }
                            if (repeatCheck == false)
                            {
                                switch (realCount[k])
                                {
                                    case '1':
                                        Console.WriteLine($"By doing {user.firstActivity} you have spent {watch.stopWatch1.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "1";
                                        break;
                                    case '2':
                                        Console.WriteLine($"By doing {user.secondActivity} you have spent {watch.stopWatch2.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "2";
                                        break;
                                    case '3':
                                        Console.WriteLine($"By doing {user.thirdActivity} you have spent {watch.stopWatch3.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "3";
                                        break;
                                    case '4':
                                        Console.WriteLine($"By doing {user.fourthActivity} you have spent {watch.stopWatch4.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "4";
                                        break;
                                    case '5':
                                        Console.WriteLine($"By doing {user.fifthActivity} you have spent {watch.stopWatch5.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "5";
                                        break;
                                    case '6':
                                        Console.WriteLine($"By doing {user.sixthActivity} you have spent {watch.stopWatch6.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "6";
                                        break;
                                    case '7':
                                        Console.WriteLine($"By doing {user.seventhActivity} you have spent {watch.stopWatch7.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "7";
                                        break;
                                    case '8':
                                        Console.WriteLine($"By doing {user.eighthActivity} you have spent {watch.stopWatch8.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "8";
                                        break;
                                    case '9':
                                        Console.WriteLine($"By doing {user.ninthActivity} you have spent {watch.stopWatch9.Elapsed:hh\\:mm\\:ss\\.ff}");
                                        actCount += "9";
                                        break;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        Console.ReadLine();
                        loopMainDecision2 = 0;
                        break;
                    }
                }
            }
        }
    }
}