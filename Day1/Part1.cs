namespace Day1;

public class Part1
{
    public int Solve()
    {
        var input = File.ReadAllLines("C:\\Projects\\AdventOfCodes\\AdventOfCode2024\\Day1\\input.txt");

        var listA = new List<int>();
        var listB = new List<int>();

        var distance = 0;

        foreach (var item in input)
        {
            var split = item.Split("   ");
            listA.Add(int.Parse(split[0]));
            listB.Add(int.Parse(split[1]));
        }

        while (listA.Any() && listB.Any())
        {
            var itemA = listA.Min();
            var itemB = listB.Min();
            
            distance += Math.Abs(itemA - itemB);
            
            listA.Remove(itemA);
            listB.Remove(itemB);
        }

        return distance;
    }
}
