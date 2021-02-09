using System.Collections.Generic;
using System.Diagnostics;

namespace ProcessKillerTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            var processesToKill = new List<Process>();

            foreach (var arg in args)
            {
                processesToKill.AddRange(Process.GetProcessesByName(arg));
            }

            foreach (var process in processesToKill)
            {
                process.Kill();
            }
        }
    }
}
