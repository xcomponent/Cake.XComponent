using System;
using System.Linq;

namespace Cake.XComponent.Test.FakeExe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.Out.WriteLine($"Argument reacevied : {arg}");
            }

            if (args.Any(arg => arg.Contains("fail")))
            {
                Console.Error.WriteLine("This App is going to crash !!!");
                Environment.ExitCode = 1;
            }
            else
            {
                Environment.ExitCode = 0;
            }
        }
    }
}
