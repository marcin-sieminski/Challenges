using System;
using System.Collections.Generic;

namespace TuringMachine
{
    public static class TuringMachine
    {
        public static (char[] tape, char headState, int headPosition) AnalyzeMachineStateDescription(
            string machineStateDescription)
        {
            var initialHeadState = ' ';
            var initialHeadPosition = -1;
            for (var i = 0; i < machineStateDescription.Length; i++)
            {
                var c = machineStateDescription[i];
                if (c == 'L' || c == 'R')
                {
                    throw new Exception("L or R values are not allowed on the tape");
                }

                if (char.IsLower(c))
                {
                    if (initialHeadPosition != -1)
                    {
                        throw new Exception("More than one head char value found");
                    }

                    initialHeadState = c;
                    initialHeadPosition = i;
                    machineStateDescription = machineStateDescription.Remove(initialHeadPosition, 1);
                }
                else
                {
                    if (c < 'A' || c > 'Z')
                    {
                        throw new Exception($"Invalid tape value ({c}) on position {i}");
                    }
                }
            }

            if (initialHeadPosition < 0)
            {
                throw new Exception("Head value not found");
            }

            return (machineStateDescription.ToCharArray(), initialHeadState, initialHeadPosition);
        }

        private static string GetMachineStateDescription((char[] tape, char headState, int headPosition) machineState)
        {
            var s = new string(machineState.tape);
            s = s.Insert(machineState.headPosition, machineState.headState.ToString());
            return s;
        }

        private static bool IsFourValid(string line)
        {
            static bool IsLowerLetter(char c) => c >= 'a' && c <= 'z';
            static bool IsUpperLetter(char c) => c >= 'A' && c <= 'Z';
            return IsLowerLetter(line[0]) && IsUpperLetter(line[1]) && IsUpperLetter(line[2]) && IsLowerLetter(line[3]);
        }

        public static SortedList<(char headState, char valueOnTape), (char newHeadState, char newValueOnTape)> parseProgram(string[] code)
        {
            var fours = new SortedList<(char headState, char valueOnTape), (char newHeadState, char newValueOnTape)>();
            foreach (var line in code)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (!IsFourValid(line))
                {
                    throw new Exception("Invalid code line: ");
                }

                var currentState = (line[0], line[1]);
                var newState = (line[3], line[2]);
                if (fours.ContainsKey(currentState))
                {
                    throw new Exception(
                        "Program cannot contain two statements with the same head state and value on the tape");
                }

                fours.Add(currentState, newState);
            }

            return fours;
        }

        private static (char newHeadState, char newValueOrStatement)? findStatement(char headState, char valueOnTape,
            SortedList<(char headState, char valueOnTape), (char newHeadState, char newValueOnTape)> program)
        {
            var currentState = (headState, valueOnTape);
            if (program.ContainsKey(currentState))
            {
                return program[currentState];
            }

            return null;
        }

        public static List<string> ExecuteProgram((char[] tape, char headState, int headPosition) machineState, SortedList<(char headState, char valueOnTape), (char newHeadState, char newValueOnTape)> program)
        {
            var history = new List<string>();
            (char newHeadState, char newValueOrStatement)? statement;
            while ((statement = findStatement(machineState.headState, machineState.tape[machineState.headPosition],program)) != null)
            {
                machineState.headState = statement.Value.newHeadState;
                switch (statement.Value.newValueOrStatement)
                {
                    case 'L':
                        machineState.headPosition--;
                        break;
                    case 'R':
                        machineState.headPosition++;
                        break;
                    default:
                        machineState.tape[machineState.headPosition] = statement.Value.newValueOrStatement;
                        break;
                }
                history.Add(GetMachineStateDescription(machineState));
            }

            return history;
        }
    }
}