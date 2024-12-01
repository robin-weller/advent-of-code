using FluentAssertions;

var lines = File.ReadAllLines("input.txt");

var a = new List<int>();
var b = new List<int>();

foreach (var line in lines)
{
    var split = line.Split("  ");
    a.Add(int.Parse(split[0]));
    b.Add(int.Parse(split[1]));
}

var taskOneResult = TaskOne(a, b);
var taskTwoResult = TaskTwo(a, b);
Console.WriteLine(taskOneResult);
Console.WriteLine(taskTwoResult);
taskOneResult.Should().Be(1223326);
taskTwoResult.Should().Be(21070419);
return;

int TaskOne(List<int> listA, List<int> listB)
{
    listA.Sort();
    listB.Sort();

    return listA.Select((t, i) => t > listB[i] ? t - listB[i] : listB[i] - t).Sum();
}

int TaskTwo(List<int> listA, List<int> listB) => 
    (from numA in listA let count = listB.Count(numB => numA == numB) select numA * count).Sum();