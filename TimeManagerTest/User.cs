
using System;
using System.Collections.Generic;
using System.IO;

namespace TimeManagerTest
{
    public class User
    {
        public string name { get; set; }
        public string firstActivity { get; set; }
        public string secondActivity { get; set; }
        public string thirdActivity { get; set; }
        public string fourthActivity { get; set; }
        public string fifthActivity { get; set; }
        public string sixthActivity { get; set; }
        public string seventhActivity { get; set; }
        public string eighthActivity { get; set; }
        public string ninthActivity { get; set; }

        public User(string Name, string FirstActivity, string SecondActivity, string ThirdActivity,
            string FourthActivity, string FifthActivity, string SixthActivity, string SeventhActivity,
            string EighthActivity, string NinthActivity)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(FirstActivity))
            {
                throw new ArgumentException(nameof(firstActivity));
            }
            if (string.IsNullOrWhiteSpace(SecondActivity))
            {
                throw new ArgumentException(nameof(secondActivity));
            }
            if (string.IsNullOrWhiteSpace(ThirdActivity))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrWhiteSpace(FourthActivity))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrWhiteSpace(FifthActivity))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrWhiteSpace(SixthActivity))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrWhiteSpace(SeventhActivity))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrWhiteSpace(EighthActivity))
            {
                throw new ArgumentException();
            }
            if (string.IsNullOrWhiteSpace(NinthActivity))
            {
                throw new ArgumentException();
            }

            name = Name;
            firstActivity = FirstActivity;
            secondActivity = SecondActivity;
            thirdActivity = ThirdActivity;
            fourthActivity = FourthActivity;
            fifthActivity = FifthActivity;
            sixthActivity = SixthActivity;
            seventhActivity = SeventhActivity;
            eighthActivity = EighthActivity;
            ninthActivity = NinthActivity;
        }

        public void StreamRead()
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
                        switch (i)
                        {
                            case 0:
                                name = line;
                                Console.WriteLine($"User Name - {line}");
                                break;
                            case 1:
                                firstActivity = line;
                                Console.WriteLine($"{i} - {line}");
                                break;
                            case 2 when !string.IsNullOrWhiteSpace(line):
                                secondActivity = line;
                                Console.WriteLine($"{i}  - {line}");
                                break;
                            case 3 when !string.IsNullOrWhiteSpace(line):
                                thirdActivity = line;
                                Console.WriteLine($"{i}  - {line}");
                                break;
                            case 4 when !string.IsNullOrWhiteSpace(line):
                                fourthActivity = line;
                                Console.WriteLine($"{i}  - {line}");
                                break;
                            case 5 when !string.IsNullOrWhiteSpace(line):
                                fifthActivity = line;
                                Console.WriteLine($"{i}  - {line}");
                                break;
                            case 6 when !string.IsNullOrWhiteSpace(line):
                                sixthActivity = line;
                                Console.WriteLine($"{i}   - {line}");
                                break;
                            case 7 when !string.IsNullOrWhiteSpace(line):
                                seventhActivity = line;
                                Console.WriteLine($"{i}   - {line}");
                                break;
                            case 8 when !string.IsNullOrWhiteSpace(line):
                                eighthActivity = line;
                                Console.WriteLine($"{i}   - {line}");
                                break;
                            case 9 when !string.IsNullOrWhiteSpace(line):
                                ninthActivity = line;
                                Console.WriteLine($"{i}   - {line}");
                                break;
                        }
                        i++;
                        if (i == 9)
                        {
                            loopCheck = 0;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public void StreamWrite()
        {
            try
            {
                int loop = 1;
                int i = 0;
                if (name == "/")
                {
                    using (StreamWriter sw = new StreamWriter("User.txt"))
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
                        Console.WriteLine("Please write the activities that you usually do. Max - 9 activities");
                        Console.WriteLine("Example: 1 - ???");
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
                            switch (i)
                            {
                                case 1:
                                    firstActivity = sentence;
                                    sw.WriteLine(firstActivity);
                                    break;
                                case 2:
                                    secondActivity = sentence;
                                    sw.WriteLine(secondActivity);
                                    break;
                                case 3:
                                    thirdActivity = sentence;
                                    sw.WriteLine(thirdActivity);
                                    break;
                                case 4:
                                    fourthActivity = sentence;
                                    sw.WriteLine(fourthActivity);
                                    break;
                                case 5:
                                    fifthActivity = sentence;
                                    sw.WriteLine(fifthActivity);
                                    break;
                                case 6:
                                    sixthActivity = sentence;
                                    sw.WriteLine(sixthActivity);
                                    break;
                                case 7:
                                    seventhActivity = sentence;
                                    sw.WriteLine(seventhActivity);
                                    break;
                                case 8:
                                    eighthActivity = sentence;
                                    sw.WriteLine(eighthActivity);
                                    break;
                                case 9:
                                    ninthActivity = sentence;
                                    sw.WriteLine(ninthActivity);
                                    break;
                            }
                            if (i == 9)
                            {
                                loop = 0;
                            }
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
