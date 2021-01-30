using System;

namespace DateAndTime
{
    public static class Program
    {
        public static void Main()
        {
            DateAndTimeHelper.GetDate();
            DateAndTimeHelper.GetTime();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
