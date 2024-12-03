using System.Text.RegularExpressions;

var lines = File.ReadAllText("input.txt");

const string pattern = @"mul\(\d{1,3},\d{1,3}\)";

var matches = Regex.Matches(lines, pattern);

var list = new List<string>();

foreach (var match in matches)
{
    list.Add(match.ToString()!);
}

var taskOneSum = list.Sum(Multiply);
var taskTwoSum = MultiplyIfEnabled(lines);

Console.WriteLine(taskOneSum);
Console.WriteLine(taskTwoSum);

return;

int Multiply(string input)
{
    input = input.Replace("mul(", "").Replace(")", "");
    var values = input.Split(",");
    return int.Parse(values[0]) * int.Parse(values[1]);
}

int MultiplyIfEnabled(string input)
{
    var total = 0;
    var enabled = true;
    var charArray = input.ToCharArray();
    for (var i = 0; i < charArray.Length-12; i++)
    {
        switch (charArray[i])
        {
            case 'd' when input.Substring(i, 7).Equals("don't()"):
                enabled = false;
                break;
            case 'd':
            {
                if (input.Substring(i, 4).Equals("do()"))
                    enabled = true;
                break;
            }
            case 'm' when enabled:
            {
                const string regexPattern = @"mul\(\d{1,3},\d{1,3}\)";
                var substring = input.Substring(i, 12);
                var matchCollection = Regex.Matches(substring, regexPattern);
                if (matchCollection.Count == 0) continue;
                total += Multiply(matchCollection.First().ToString());
                break;
            }
        }
    }
    return total;
}