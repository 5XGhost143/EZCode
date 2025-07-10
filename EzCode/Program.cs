using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0 || !File.Exists(args[0]) || !args[0].EndsWith(".ezc"))
        {
            Console.WriteLine("⚠ Please execute the program with a .ezc file.");
            return;
        }

        var lines = File.ReadAllLines(args[0]);
        var interpreter = new EzInterpreter(lines);
        interpreter.Run();
    }
}