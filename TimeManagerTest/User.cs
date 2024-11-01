
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
                using (var sw = new StreamWriter("User.txt"))
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
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
