using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace TimeManagerTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var user = new User("/");
            var watch = new Timer();
            var listOfActs = new List<string>();
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
                        user.StreamRead(listOfActs);
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
                        user.StreamWrite(listOfActs);
                        fileCheck = 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        fileCheck = 1;
                    }
                }
            }
            var loopMainDecision2 = 1;
            string currentActivity;
            var currentListOfActs = new List<string>();
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
                    else
                    {
                        try
                        {
                            currentActivity = listOfActs[--resultMainDecision];
                            currentListOfActs.Add(currentActivity);
                            watch.Activity(user, currentActivity);
                            loopMainDecision1 = 1;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("You don't have this count of activities");
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
                        var repeatList = new List<string>();
                        int index = 0;
                        for (int i = 0; i < currentListOfActs.Count; i++)
                        {
                            var repeat = false;
                            foreach (var item in repeatList)
                            {
                                if (item == currentListOfActs[i])
                                {
                                    repeat = true;
                                }
                                else if (repeat == true)
                                {

                                }
                                else
                                    repeat = false;
                            }
                            repeatList.Add(currentListOfActs[i]);
                            if (repeat == false)
                            {
                                Console.WriteLine($"By {currentListOfActs[index]} you have spent {Timer.listOfWatches[index].Elapsed:hh\\:mm\\:ss\\.ff}");
                                index++;
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