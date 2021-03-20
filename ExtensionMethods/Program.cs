using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main()
        {
            var sampleText = "Hello World...";
            sampleText.Excite().Print();

            var person = new Person();
            person.Fill().Print();

            Console.WriteLine(8.12.Add(4).Subtract(2).MultiplyBy(5).DivideBy(6.6));

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
