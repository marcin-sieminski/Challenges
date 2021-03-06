using System;
using System.Collections.Generic;
using System.IO;

namespace TuringMachine
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Error.WriteLine("Invalid arguments. Please provide program path and tape path.");
                return;
            }

            var programPath = args[0];
            if (!File.Exists(programPath))
            {
                Console.Error.WriteLine($"Invalid program path: {programPath}");
                return;
            }

            Console.WriteLine($"Program file path: {programPath}");

            var programInput = File.ReadAllLines(programPath);

            var tapePath = args[1];
            if (!File.Exists(tapePath))
            {
                Console.Error.WriteLine($"Invalid tape path: {tapePath}");
                return;
            }

            Console.WriteLine($"Tape file path: {tapePath}");

            var tapeInput = File.ReadAllText(tapePath);

            Console.WriteLine($"Initial machine state: {tapeInput}");
            Console.WriteLine("Program: ");
            foreach (var line in programInput)
            {
                Console.WriteLine(line);
            }

            try
            {
                var machineState = TuringMachine.AnalyzeMachineStateDescription(tapeInput);
                Console.WriteLine("Head state: " + machineState.headState);
                Console.WriteLine("Head position: " + machineState.headPosition);
                Console.WriteLine("Tape: " + new string(machineState.tape));

                var program = TuringMachine.parseProgram(programInput);
                Console.WriteLine("\nProgram execution...");
                var history = TuringMachine.ExecuteProgram(machineState, program);
                Console.WriteLine("\nMachine state change:");
                foreach (var line in history)
                {
                    Console.WriteLine(line); 
                }
            }
            catch (Exception e)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Error.WriteLine(e.Message);
                Console.ForegroundColor = color;
            }

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}
