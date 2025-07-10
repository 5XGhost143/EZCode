using System;
using System.Threading;

public static class Misc
{
    public static void HandleKeypress(string keyName)
    {
        keyName = keyName.Trim().ToLower();
        if (!Console.KeyAvailable)
        {
            Variables.SetValue("keypressed", "false");
            return;
        }
        var key = Console.ReadKey(true).Key.ToString().ToLower();
        Variables.SetValue("keypressed", key == keyName ? "true" : "false");
    }

    public static void HandleWait(string arg)
    {
        if (int.TryParse(arg.Trim(), out int ms))
            Thread.Sleep(ms);
    }
}