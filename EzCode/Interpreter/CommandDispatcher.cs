using System;
using System.Collections.Generic;

public class CommandDispatcher
{
    private readonly string[] lines;
    private readonly Dictionary<string, int> labels;
    private readonly Stack<int> whileStack;
    private readonly Func<bool> getSkipBlock;
    private readonly Action<bool> setSkipBlock;

    public CommandDispatcher(string[] lines,
        Dictionary<string, int> labels,
        Stack<int> whileStack,
        Func<bool> getSkipBlock,
        Action<bool> setSkipBlock)
    {
        this.lines = lines;
        this.labels = labels;
        this.whileStack = whileStack;
        this.getSkipBlock = getSkipBlock;
        this.setSkipBlock = setSkipBlock;
    }

    public void Execute(string line, ref int currentLine)
    {
        string[] parts = line.Split(new[] { ' ' }, 2);
        string command = parts[0].ToLower();
        string args = parts.Length > 1 ? parts[1] : "";

        switch (command)
        {
            case "set": Variables.HandleSet(args); break;
            case "add": Variables.HandleAdd(args); break;
            case "subtract": Variables.HandleSubtract(args); break;
            case "input": Variables.HandleInput(args); break;
            case "say": Output.HandlePrint(args); break;
            case "clean": Output.HandleClear(); break;
            case "close": Output.HandleClose(); break;
            case "if": ControlFlow.HandleIf(args, setSkipBlock); break;
            case "end": setSkipBlock(false); break;
            case "while": ControlFlow.HandleWhile(args, whileStack, currentLine, lines, setSkipBlock); break;
            case "endwhile": ControlFlow.HandleEndWhile(whileStack, ref currentLine); break;
            case "goto": ControlFlow.HandleGoto(args, labels, ref currentLine); break;
            case "label": break;
            case "list": ListOperations.HandleList(args); break;
            case "split": ListOperations.HandleSplit(args); break;
            case "keypress": Misc.HandleKeypress(args); break;
            case "wait": Misc.HandleWait(args); break;
            default: Console.WriteLine("❓ Unknown command: " + command); break;
        }
    }
}