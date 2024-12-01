namespace Day1;

public class Part2
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

        foreach (var item in listA)
        {
            distance += listB.FindAll(x => x == item).Count * item;
        }

        return distance;
    }
}
