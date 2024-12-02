var lines = File.ReadAllLines("input.txt");

var taskOneCount = lines.Select(line => line.Split(" ")).Select(reportStrings => reportStrings.Select(int.Parse))
    .Count(reportNumbers => IsSafe(reportNumbers.ToArray()));

var taskTwoCount = lines.Select(line => line.Split(" ")).Select(reportStrings => reportStrings.Select(int.Parse))
    .Count(reportNumbers => IsSafeWithRemoval(reportNumbers.ToArray()));

Console.WriteLine(taskOneCount);
Console.WriteLine(taskTwoCount);

return;

bool IsSafe(int[] reports)
{
    if (reports[0] >= reports[1])
    {
        for (var i = 0; i < reports.Length - 1; i++)
        {
            if (reports[i] <= reports[i+1])
                return false;
            if (reports[i] > reports[i + 1] + 3)
                return false;
        }
    }
    else if (reports[0] <= reports[1])
    {
        for (var i = 0; i < reports.Length - 1; i++)
        {
            if (reports[i] >= reports[i+1])
                return false;
            if (reports[i] < reports[i + 1] - 3)
                return false;
        }
    }
    return true;
}

bool IsSafeWithRemoval(int[] reports)
{
    return reports.Select((t, i) => GetReportLevelRemoved(reports, i)).Any(IsSafe);
}

int[] GetReportLevelRemoved(int[] reports, int level)
{
    var asList = reports.ToList();
    asList.RemoveAt(level);
    return asList.ToArray();
}