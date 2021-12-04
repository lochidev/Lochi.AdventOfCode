using System.Reflection;

namespace Lochi.AdventOfCode.Helpers;

public static class Common
{
    public static ISolver GetSolver(int year, int day)
    {
        var name = $"Lochi.AdventOfCode.Y{year}.Day{day}";
        var q = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.IsClass && t.FullName == name
            select t;
        return (ISolver) Activator.CreateInstance(q.FirstOrDefault());
    }

    public static string GetInput(int year, int day)
    {
        var filename = $"Inputs\\{year}\\day{day}.txt";
        return File.ReadAllText(filename);
    }
}