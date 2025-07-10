using System;

public static class ConditionEvaluator
{
    public static bool Evaluate(string condition)
    {
        string[] ops = { " not ", " equals ", " greater ", " less " };
        foreach (string op in ops)
        {
            if (condition.Contains(op))
            {
                var parts = condition.Split(new[] { op }, 2, StringSplitOptions.None);
                if (parts.Length != 2) continue;
                string left = Variables.GetValue(parts[0].Trim());
                string right = Variables.GetValue(parts[1].Trim());

                if (int.TryParse(left, out int lNum) && int.TryParse(right, out int rNum))
                {
                    return op.Trim() switch
                    {
                        "equals" => lNum == rNum,
                        "not" => lNum != rNum,
                        "greater" => lNum > rNum,
                        "less" => lNum < rNum,
                        _ => false
                    };
                }
                else
                {
                    return op.Trim() switch
                    {
                        "equals" => left == right,
                        "not" => left != right,
                        "greater" => string.Compare(left, right) > 0,
                        "less" => string.Compare(left, right) < 0,
                        _ => false
                    };
                }
            }
        }
        return false;
    }
}
