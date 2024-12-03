using System.Text.RegularExpressions;

namespace Day3;

public class Part1
{
    public int Solve()
    {
        var result = 0;
        var input = File.ReadAllLines("C:\\Projects\\AdventOfCodes\\AdventOfCode2024\\Day3\\input.txt");

        var multiplyRegexPattern = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
        var extractNumbersRegexPattern = @"\b[0-9]{1,3},[0-9]{1,3}\b";

        foreach (var item in input)
        {
            var validMultiply = Regex.Matches(item, multiplyRegexPattern);

            foreach (Match match in validMultiply)
            {
                var value = Regex.Match(match.Value, extractNumbersRegexPattern).Value.Split(",");
                
                result += int.Parse(value[0]) * int.Parse(value[1]);
            }
        }

        return result;
    }
}
