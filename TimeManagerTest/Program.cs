using System;
using System.Collections.Generic;
using System.IO;

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
            Console.WriteLine("1 - Yes, I wanna Log in; 2 - No I wanna Sign in; 3 - I wanna add new activity; 4 - I wanna edit activity");
            int answerAboutAccount = 0;
            int fileCheck = 1;
            while (fileCheck != 0)
            {
                bool checkAccount = int.TryParse(Console.ReadLine(), out answerAboutAccount);
                while (answerAboutAccount != 1 && answerAboutAccount != 2 && answerAboutAccount != 3 && answerAboutAccount != 4)
                {
                    if (checkAccount == false)
                    {
                        Console.WriteLine("Please enter correct value");
                    }
                    else
                    {
                        if (answerAboutAccount <= 0 || answerAboutAccount >= 5)
                        {
                            Console.WriteLine("Please enter correct value");
                        }
                    }
                }
                switch (answerAboutAccount)
                {
                    case 1:
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
                        break;
                    case 2:
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
                        break;
                    case 3:
                        user.StreamRead(listOfActs);
                        AddAct(listOfActs, user);
                        fileCheck = 0;
                        break;
                    default:
                        user.StreamRead(listOfActs);
                        EditActs(listOfActs, user);
                        fileCheck = 0;
                        break;
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
        private static void EditActs(List<string> listOfActs, User user)
        {
            bool isItOver = true;
            while (isItOver)
            {
                Console.WriteLine("Which activity do you wanna change?");
                int choice = 1;
                while (choice > 0 && choice < listOfActs.Count)
                {
                    choice = TryParse(Console.ReadLine());
                    if (choice > listOfActs.Count || choice < 0)
                    {
                        Console.WriteLine("You dumbass. I will fuck you in your asshole, faggot. Because of you I need to do another test, nigga. I hate you. And now, be a good boy and write CORRECT VALUE.");
                        choice = 1;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Write("Write down new activity: ");
                listOfActs[--choice] = Console.ReadLine();
                Console.WriteLine("Is it over? 1 - yes, 2 - no");
                string answer = Console.ReadLine();
                bool isValidValue = true;
                while (isValidValue)
                {
                    if (int.TryParse(answer, out choice))
                    {
                        if (choice == 1)
                        {
                            isItOver = false;
                            isValidValue = false;
                        }
                        else if (choice == 2)
                        {
                            isItOver = true;
                            isValidValue = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter Correct value");
                            answer = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Correct value");
                        answer = Console.ReadLine();
                    }
                }
            }
            user.StreamWrite(listOfActs);
            Console.Clear();
            int i = 1;
            foreach (string act in listOfActs)
            {
                Console.WriteLine($"{i} - {act}");
                i++;
            }
        }
        private static void AddAct(List<string> listOfActs, User user)
        {
            bool isItNotOver = true;
            do
            {
                Console.Write("Write new activity: ");
                using (var sw = new StreamWriter("User.txt"))
                {
                    string newAct = Console.ReadLine();
                    listOfActs.Add(newAct);
                    sw.WriteLine(newAct);
                }
                Console.WriteLine("Is it over? 1 - yes, 2 - no");
                string answer = Console.ReadLine();
                bool isValidValue = true;
                while (isValidValue)
                {
                    if (int.TryParse(answer, out int choice))
                    {
                        if (choice == 1)
                        {
                            isItNotOver = false;
                            isValidValue = false;
                        }
                        else if (choice == 2)
                        {
                            isItNotOver = true;
                            isValidValue = false;
                        }
                        else
                        {
                            Console.WriteLine("Enter Correct value");
                            answer = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Correct value");
                        answer = Console.ReadLine();
                    }
                }
            } while (isItNotOver);
            user.StreamWrite(listOfActs);
            Console.Clear();
            int i = 1;
            foreach (string act in listOfActs)
            {
                Console.WriteLine($"{i} - {act}");
                i++;
            }
        }
        private static int TryParse(string input)
        {
            int result = 0;
            bool isValid = true;
            do
            {
                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Enter correct value");
                    input = Console.ReadLine();
                }
                else
                {
                    isValid = false;
                }
            } while (isValid);
            return result;
        }
    }
}