
using System;

[SoftUniAttribute("Ventsi")]
public class StartUp
{
    [SoftUniAttribute("Gosho")]
    public static void Main()
    {
        var tracker = new Tracker();
        Tracker.PrintMethodsByAuthor();
    }
}