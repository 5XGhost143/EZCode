using System;
using System.Collections.Generic;

public static class ListOperations
{
    private static Dictionary<string, List<string>> lists = new();

    public static void HandleList(string args)
    {
        var parts = args.Split(' ', 3);
        if (parts.Length < 2) return;

        string action = parts[0].ToLower();
        string listName = parts[1].ToLower();

        switch (action)
        {
            case "create":
                lists[listName] = new List<string>();
                break;
            case "add":
                if (parts.Length < 3) return;
                string value = parts[2];
                if (value.StartsWith("\"") && value.EndsWith("\""))
                    value = value[1..^1];
                if (!lists.ContainsKey(listName))
                    lists[listName] = new List<string>();
                lists[listName].Add(value);
                break;
            case "remove":
                if (parts.Length < 3 || !int.TryParse(parts[2], out int index)) return;
                if (lists.ContainsKey(listName) && index >= 0 && index < lists[listName].Count)
                    lists[listName].RemoveAt(index);
                break;
            case "get":
                var tokens = args.Split(' ');
                if (tokens.Length < 4 || !int.TryParse(tokens[2], out int idx)) return;
                string varName = tokens[3].ToLower();
                if (lists.ContainsKey(tokens[1].ToLower()) && idx >= 0 && idx < lists[tokens[1].ToLower()].Count)
                    Variables.SetValue(varName, lists[tokens[1].ToLower()][idx]);
                break;
        }
    }

    public static void HandleSplit(string args)
    {
        var parts = args.Split(' ');
        if (parts.Length != 4) return;

        string varName = parts[0].ToLower();
        string delimiter = parts[1];
        if (!int.TryParse(parts[2], out int index)) return;
        string newVar = parts[3].ToLower();

        string val = Variables.GetValue(varName);
        var splits = val.Split(new string[] { delimiter }, StringSplitOptions.None);
        if (index >= 0 && index < splits.Length)
            Variables.SetValue(newVar, splits[index]);
    }
}