namespace Day2;

public class Part1
{
    public int Solve()
    {
        var result = 0;
        var reports = new List<List<int>>();

        foreach (var line in File.ReadLines("C:\\Projects\\AdventOfCodes\\AdventOfCode2024\\Day2\\input.txt"))
        {
            var numbers = Array.ConvertAll(line.Split(" "), int.Parse);
            reports.Add(new List<int>(numbers));
        }

        foreach (var report in reports)
        {
            var temp = new List<char>();
            
            for (var i = 0; i < report.Count - 1; i++)
            {
                var first = report[i];
                var second = report[i + 1];

                var sum = second - first;

                if (Math.Abs(sum) >= 1 && Math.Abs(sum) <= 3 && int.IsNegative(sum))
                {
                    temp.Add('-');
                }
                else if (Math.Abs(sum) >= 1 && Math.Abs(sum) <= 3 && int.IsPositive(sum))
                {
                    temp.Add('+');
                }
                else
                {
                    temp.Add('#');
                }
            }
            
            if(temp.All(x => x == '-') || temp.All(x => x == '+'))
            {
                result++;
            }
        }

        return result;
    }
}
