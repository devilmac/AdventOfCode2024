using System.Text.RegularExpressions;

namespace Day3;

public class Part2
{
    public int Solve()
    {
        var result = 0;
        var input = File.ReadAllLines("C:\\Projects\\AdventOfCodes\\AdventOfCode2024\\Day3\\input.txt");

        var multiplyRegexPattern = @"(do\(\)|don't\(\))|(mul\([0-9]{1,3},[0-9]{1,3}\))";
        var extractNumbersRegexPattern = @"\b[0-9]{1,3},[0-9]{1,3}\b";
        var doString = @"do()";
        var dontString = @"don't()";

        var enableMultiply = true;

        foreach (var item in input)
        {
            var validMultiply = Regex.Matches(item, multiplyRegexPattern).ToList();
            
            while (validMultiply.Count > 0)
            {
                var match = validMultiply[0];

                if (match.Value == dontString)
                {
                    enableMultiply = false;
                    validMultiply.RemoveAt(0);
                    continue;
                }
                if(match.Value == doString)
                {
                    enableMultiply = true;
                    validMultiply.RemoveAt(0);
                    continue;
                }

                if (enableMultiply)
                {
                    if (Regex.Match(match.Value, extractNumbersRegexPattern).Success)
                    {
                        var value = Regex.Match(match.Value, extractNumbersRegexPattern).Value.Split(",");

                        result += int.Parse(value[0]) * int.Parse(value[1]);
                    }
                    
                    validMultiply.RemoveAt(0);
                }
                else
                {
                    validMultiply.RemoveAt(0);
                }
            }
        }

        return result;
    }
}
