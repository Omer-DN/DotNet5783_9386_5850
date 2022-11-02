
using System;
namespace Targil0
{
    partial class Program5850
    {
        static void Main(string[] args)
        {
            Welcome9386();
            Welcome5850();
            Console.ReadKey();
        }

        private static void Welcome9386()
        {
            Console.WriteLine("Enter your name");
            string userName = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", userName);
        }
        static partial void Welcome5850();
    }
}
