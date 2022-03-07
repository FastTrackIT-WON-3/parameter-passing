using System;

namespace ParametersPassing
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Print()
        {
            Console.WriteLine($"My name is {FirstName} {LastName}");
        }
    }
}
