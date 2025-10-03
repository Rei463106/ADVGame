using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 自分の得意な言語で
        // Let's チャレンジ！！
        var line = Console.ReadLine();
        var w = "Monday, Tuesday, Wednesday, Thursday";
        var f = "Friday";
        string[] Week = w.Split(", ");
        foreach (string s in Week.Where(s => s == line))
        {
            Console.WriteLine("Still " + s);
        }
        if (f == line)
        {
            Console.WriteLine("TGIF");
        }
    }
}