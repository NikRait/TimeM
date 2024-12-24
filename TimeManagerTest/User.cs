
using System;
using System.Collections.Generic;
using System.IO;

namespace TimeManagerTest
{
    public class User
    {
        public string name { get; set; }

        public User (string name) { this.name = name; }

        public void StreamRead(List<string> listOfActs)
        {
            String line;
            try
            {
                int loopCheck = 1;
                int i = 0;
                using (StreamReader sr = new StreamReader("User.txt"))
                {
                    listOfActs.Clear();
                    while (loopCheck != 0)
                    {
                        line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line))
                        {
                            loopCheck = 0;
                        }
                        else if (i == 0)
                        {
                            name = line;
                            Console.WriteLine(name);
                        }
                        else
                        {
                            
                            listOfActs.Add(line);
                            Console.WriteLine($"{i} - {line}");
                        }
                        i++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public void StreamWrite(List<string> listOfActs)
        {
            try
            {
                int loop = 1;
                int i = 0;
                using (var sw = new StreamWriter("User.txt", false))
                {
                    if(name == "/")
                    {

                        Console.WriteLine("Please enter your user Name");
                        int userNameLoop = 0;
                        while (userNameLoop != 1)
                        {
                            name = Console.ReadLine();
                            if (name == "" || name == " " || name.Length == 1)
                            {
                                Console.WriteLine("Please enter correct user Name. It should be longer than one character");
                            }
                            else
                            {
                                sw.WriteLine(name);
                                userNameLoop = 1;
                            }
                        }
                        Console.WriteLine("Please write the activities that you usually do.\nExample: 1 - ???");
                        Console.WriteLine(
                            "If you enter empty line, that mean you don't have any activities that you usually do. Because of this, please enter your activities wisely.");
                        //Write a line of text
                        while (loop != 0)
                        {
                            i++;
                            string sentence = Console.ReadLine();
                            if (string.IsNullOrEmpty(sentence))
                            {
                                Console.WriteLine("I think that's it");
                                break;
                            }
                            else
                            {
                                listOfActs.Add(sentence);
                                sw.WriteLine(sentence);
                            }

                        }
                    }
                    else
                    {
                        sw.WriteLine(name);
                        Console.WriteLine(name);
                        foreach (var act in listOfActs)
                        {
                            sw.WriteLine(act);
                        }
                    }
                }
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public void BeforeActivities(ref bool fileCheck, List<string> listOfActs, User user)
        {
            while (fileCheck)
            {
                Console.SetCursorPosition(37, 0);
                Console.WriteLine("Memento Mori");
                Console.WriteLine("Do you have saved user Name?");
                Console.WriteLine("1 - Log in; 2 - Sign up; 3 - Add new activity; 4 - Edit activity, 5 - Delete activity");
                int answerAboutAccount = 0;
                answerAboutAccount = answerAboutAccount.TryParse(Console.ReadLine(), 1, 5);
                switch (answerAboutAccount)
                {
                    case 1:
                        try
                        {
                            user.StreamRead(listOfActs);
                            fileCheck = false;
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("You don't have an account yet. Please sign in before.");
                            fileCheck = true;
                        }
                        break;
                    case 2:
                        try
                        {
                            user.StreamWrite(listOfActs);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            fileCheck = true;
                        }
                        break;
                    case 3:
                        user.StreamRead(listOfActs);
                        AddAct(listOfActs, user);
                        //fileCheck = false;
                        break;
                    case 4:
                        user.StreamRead(listOfActs);
                        EditActs(listOfActs, user);
                        break;
                    default:
                        user.StreamRead(listOfActs);
                        DeleteAct(listOfActs, user);
                        //fileCheck = false;
                        break;
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
                choice = choice.TryParse(Console.ReadLine(), 1, listOfActs.Count);
                Console.Write("Write down new activity: ");
                listOfActs[--choice] = Console.ReadLine();
                Console.WriteLine("Is it over? 1 - yes, 2 - no");
                string answer = Console.ReadLine();
                bool isValidValue = true;
                IsValidValue(ref isValidValue, ref isItOver, ref answer);
            }
            user.StreamWrite(listOfActs);
            Console.Clear();
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
                IsValidValue(ref isValidValue, ref isItNotOver, ref answer);
            } while (isItNotOver);
            user.StreamWrite(listOfActs);
            Console.Clear();
        }
        private static void DeleteAct(List<string> listOfActs, User user)
        {
            bool isItNotOver = true;
            while (isItNotOver)
            {
                Console.WriteLine("Which activity do you want to delete");
                int numberOfAct = 0;
                numberOfAct = numberOfAct.TryParse(Console.ReadLine(), 1, listOfActs.Count);
                listOfActs.RemoveAt(--numberOfAct);
                Console.WriteLine("Is it over? 1 - yes, 2 - no");
                string answer = Console.ReadLine();
                bool isValidValue = true;
                IsValidValue(ref isValidValue, ref isItNotOver, ref answer);
            }
            user.StreamWrite(listOfActs);
            Console.Clear();
        }
        private static void IsValidValue(ref bool isValidValue, ref bool isItNotOver, ref string answer)
        {
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
        }
    }
}
