using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // �����̓��ӂȌ����
        // Let's �`�������W�I�I
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