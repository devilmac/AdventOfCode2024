namespace Day2;

public class Part2
{
    public int Solve()
    {
        var plusChar = '+';
        var minusChar = '-';
        var hashChar = '#';
        
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

            var counter1 = 0;
            var counter2 = 1;

            while (counter1 < report.Count - 1 && counter2 < report.Count - 1)
            {
                var first = report[counter1];
                var second = report[counter2];

                var sum = second - first;

                if (Math.Abs(sum) >= 1 && Math.Abs(sum) <= 3 && int.IsNegative(sum))
                {
                    if (!temp.Any())
                    {
                        temp.Add(minusChar);
                        counter1++;
                        counter2++;
                    }
                    else
                    {
                        if (temp.First() == minusChar)
                        {
                            temp.Add(minusChar);
                            counter1++;
                            counter2++;
                        }
                        else
                        {
                            report.RemoveAt(counter1);
                            counter2++;
                        }
                    }
                }
                else if (Math.Abs(sum) >= 1 && Math.Abs(sum) <= 3 && int.IsPositive(sum))
                {
                    if (!temp.Any())
                    {
                        temp.Add(plusChar);
                        counter1++;
                        counter2++;
                    }
                    else
                    {
                        if (temp.First() == plusChar)
                        {
                            temp.Add(plusChar);
                            counter1++;
                            counter2++;
                        }
                        else
                        {
                            report.RemoveAt(counter1);
                            counter2++;
                        }
                    }
                }
                else
                {
                    if (int.IsNegative(sum))
                    {
                        report.RemoveAt(counter1);
                    }
                    else
                    {
                        report.RemoveAt(counter1);
                    }
                    temp.Add(hashChar);
                    continue;
                }
            }

            if (temp.All(x => x == '-') || temp.All(x => x == '+'))
            {
                result++;
            }
        }

        return result;
    }

    private static void HandleReportAdjustments(List<char> temp, List<int> report, int counter, char reference)
    {
        if (!temp.Any())
        {
            temp.Add(reference);
        }
        else
        {
            if (temp.First() == reference)
            {
                temp.Add(reference);
            }
            else
            {
                report.RemoveAt(counter);
            }
        }
    }
}
