using System;
using System.Collections.Generic;

public static class Variables
{
    private static Dictionary<string, string> variables = new();

    public static void HandleSet(string args)
    {
        var parts = args.Split(new[] { " to " }, 2, StringSplitOptions.None);
        if (parts.Length != 2) return;

        string varName = parts[0].Trim().ToLower();
        string value = parts[1].Trim();

        if (value.StartsWith("\"") && value.EndsWith("\""))
        {
            value = value[1..^1];
        }

        var ops = new[] { " plus ", " minus ", " times ", " divided " };
        foreach (var op in ops)
        {
            if (value.Contains(op))
            {
                var operands = value.Split(new[] { op }, 2, StringSplitOptions.None);
                if (operands.Length == 2
                    && int.TryParse(operands[0].Trim(), out int left)
                    && int.TryParse(operands[1].Trim(), out int right))
                {
                    int result = op.Trim() switch
                    {
                        "plus" => left + right,
                        "minus" => left - right,
                        "times" => left * right,
                        "divided" => right != 0 ? left / right : 0,
                        _ => 0
                    };
                    value = result.ToString();
                    break;
                }
            }
        }

        variables[varName] = value;
    }

    public static void HandleAdd(string varName)
    {
        varName = varName.Trim().ToLower();
        if (variables.ContainsKey(varName) && int.TryParse(variables[varName], out int val))
            variables[varName] = (val + 1).ToString();
        else
            variables[varName] = "1";
    }

    public static void HandleSubtract(string varName)
    {
        varName = varName.Trim().ToLower();
        if (variables.ContainsKey(varName) && int.TryParse(variables[varName], out int val))
            variables[varName] = (val - 1).ToString();
        else
            variables[varName] = "-1";
    }

    public static void HandleInput(string varName)
    {
        Console.Write("> ");
        string input = Console.ReadLine() ?? "";
        variables[varName.Trim().ToLower()] = input.Trim();
    }

    public static string GetValue(string key)
    {
        return variables.TryGetValue(key.ToLower(), out string val) ? val : "";
    }

    public static void SetValue(string key, string value)
    {
        variables[key.ToLower()] = value;
    }
}