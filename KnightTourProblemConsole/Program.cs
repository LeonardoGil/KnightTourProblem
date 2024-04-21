using System.Diagnostics;
using KnightTourProblemApplication;

namespace KnightTourProblemConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var table = new Table(8);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            table.Start();

            stopWatch.Stop();

            Console.WriteLine($"Status: {table.Result}. Time: {stopWatch.Elapsed.TotalSeconds}s");
        }
    }
}
