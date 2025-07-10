using System.Collections.Generic;

public class EzInterpreter
{
    private string[] lines;
    private int currentLine = 0;
    private bool skipBlock = false;
    private readonly Dictionary<string, int> labels = new();
    private readonly Stack<int> whileStack = new();
    private readonly CommandDispatcher dispatcher;

    public EzInterpreter(string[] lines)
    {
        this.lines = lines;
        dispatcher = new CommandDispatcher(lines, labels, whileStack, () => skipBlock, val => skipBlock = val);
        IndexLabels();
    }

    public void Run()
    {
        while (currentLine < lines.Length)
        {
            string line = lines[currentLine].Trim();
            currentLine++;

            if (string.IsNullOrWhiteSpace(line)) continue;
            if (skipBlock && !line.StartsWith("end")) continue;

            dispatcher.Execute(line, ref currentLine);
        }
    }

    private void IndexLabels()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (line.StartsWith("label "))
            {
                string label = line.Substring(6).Trim().ToLower();
                labels[label] = i;
            }
        }
    }
}