using System;

public static class Output
{
    public static void HandlePrint(string arg)
    {
        arg = arg.Trim();
        if (arg.StartsWith("\"") && arg.EndsWith("\""))
            Console.WriteLine(arg[1..^1]);
        else
            Console.WriteLine(Variables.GetValue(arg));
    }

    public static void HandleClear() => Console.Clear();
    public static void HandleClose() => Environment.Exit(0);
}