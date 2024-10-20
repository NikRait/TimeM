using System;

namespace TimeManagerTest
{
    public class NoMoreActException: Exception
    {
        public NoMoreActException() : base("You don't have this count of activities")
        {
            
        }
        public NoMoreActException(string message) : base (message)
        {
            
        }
    }
}