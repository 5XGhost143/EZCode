using System;
using System.Collections.Generic;

public static class ControlFlow
{
    public static void HandleIf(string condition, Action<bool> setSkip)
    {
        if (!ConditionEvaluator.Evaluate(condition))
            setSkip(true);
    }

    public static void HandleWhile(string condition, Stack<int> stack, int currentLine, string[] lines, Action<bool> setSkip)
    {
        stack.Push(currentLine - 1);
        if (!ConditionEvaluator.Evaluate(condition))
        {
            int depth = 1;
            while (++currentLine < lines.Length && depth > 0)
            {
                string l = lines[currentLine].Trim().ToLower();
                if (l.StartsWith("while")) depth++;
                else if (l.StartsWith("endwhile")) depth--;
            }
            stack.Pop();
        }
    }

    public static void HandleEndWhile(Stack<int> stack, ref int currentLine)
    {
        if (stack.Count > 0)
            currentLine = stack.Peek();
    }

    public static void HandleGoto(string label, Dictionary<string, int> labels, ref int currentLine)
    {
        label = label.Trim().ToLower();
        if (labels.ContainsKey(label))
            currentLine = labels[label];
        else
            Console.WriteLine("❌ Label not found: " + label);
    }
}