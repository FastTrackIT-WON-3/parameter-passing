using System;

namespace ParametersPassing
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int i = 10;
            Console.WriteLine($"Before calling Increment: {i}");
            Increment(i, out i);
            Console.WriteLine($"After calling Increment: {i}");
            */

            /*
            Person p = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };

            Console.Write($"Before calling ChangeName: ");
            p.Print();

            ChangeName(ref p);

            Console.Write($"After calling ChangeName: ");
            p.Print();
            */
        }

        private static void CalculateAverage(in int a, in int b)
        {
            float avg = ((float)(a + b)) / 2;
            Console.WriteLine(avg);
        }

        private static void Increment(int initial, out int incremented)
        {
            Console.WriteLine($"Before increment: {initial}");
            incremented = initial + 1;
            Console.WriteLine($"After increment: {incremented}");
        }

        private static bool TryParsePoint(string encoded, out Point p)
        {
            p = null;
            if (string.IsNullOrWhiteSpace(encoded))
            {
                return false;
            }

            bool isCorrectlyFormatted = 
                   encoded.StartsWith("(", StringComparison.OrdinalIgnoreCase) &&
                   encoded.EndsWith(")", StringComparison.OrdinalIgnoreCase) &&
                   encoded.Contains(",");

            if (!isCorrectlyFormatted)
            {
                return false;
            }

            string[] parts = encoded.Replace("(", string.Empty, StringComparison.OrdinalIgnoreCase)
                                    .Replace(")", string.Empty, StringComparison.OrdinalIgnoreCase)
                                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                return false;
            }

            bool canConvertX = int.TryParse(parts[0], out int x);
            bool canConvertY = int.TryParse(parts[1], out int y);

            if (canConvertX && canConvertY)
            {
                p = new Point { X = x, Y = y };
                return true;
            }

            return false;
        }

        private static void ChangeName(in Person p)
        {
            Console.Write($"Before change name: ");
            p.Print();

            p.FirstName = "Changed FirstName";
            //p = new Person
            //{
            //    FirstName = "Changed FirstName",
            //    LastName = "Doe"
            //};
            
            Console.Write($"After change name: ");
            p.Print();
        }
    }
}
