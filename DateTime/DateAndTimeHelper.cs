using System;

namespace DateAndTime
{
    public static class DateAndTimeHelper
    {
        public static void GetTime()
        {
            Console.Write("\nChoose a time format: \n1. h:mm tt\n2. H:mm\n");
            var timeFormat = Console.ReadKey().KeyChar switch
            {
                '1' => "h:mm tt",
                '2' => "H:mm",
                _ => "H:mm"
            };

            Console.Write($"\n\nEnter a time in format {timeFormat}: ");
            var inputTime = Console.ReadLine();
            var timeToProcess = DateTime.ParseExact(inputTime, timeFormat, null);
            var timeSpanAgo = DateTime.Now.Subtract(timeToProcess);

            if (timeSpanAgo.Ticks < 0)
            {
                timeSpanAgo = timeSpanAgo.Add(TimeSpan.FromHours(24));
            }

            Console.WriteLine($"\nYour time: {inputTime} was {timeSpanAgo.Hours} hours and {timeSpanAgo.Minutes} minutes ago.");
        }

        public static void GetDate()
        {
            Console.WriteLine("Choose a date format:\n1. M/d/yy\n2. d/M/yy");

            var dateFormat = Console.ReadKey().KeyChar switch
            {
                '1' => "M/d/yy",
                '2' => "d/M/yy",
                _ => "d/m/yy"
            };

            Console.Write($"\n\nEnter a date in a format {dateFormat}: ");
            var inputDate = Console.ReadLine();
            var dateToProcess = DateTime.ParseExact(inputDate, dateFormat, null);

            var daysAgo = DateTime.Now.Subtract(dateToProcess);

            if (daysAgo.Ticks < 0)
            {
                Console.WriteLine(
                    $"\nYour date: {dateToProcess.ToLongDateString()} is {Math.Round(-daysAgo.TotalDays, MidpointRounding.AwayFromZero)} day(s) in the future.");
            }
            else
            {
                Console.WriteLine(
                    $"\nYour date: {dateToProcess.ToLongDateString()} was {Math.Round(daysAgo.TotalDays, 0, MidpointRounding.AwayFromZero)} day(s) ago.");
            }
        }
    }
}