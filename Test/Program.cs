using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> lst = new List<string>();

        for(int i = 0; i<=3000000; i++)
        {
            lst.Add(i.ToString());
        }

        Stopwatch sw2 = Stopwatch.StartNew();
        lst.Contains("3000000");
        sw2.Stop();
        Console.WriteLine("Last " + sw2.Elapsed.ToString());

        Stopwatch sw = Stopwatch.StartNew();
        lst.Contains("100000000000000");
        sw.Stop();

        Console.WriteLine("Not " + sw.Elapsed.ToString());

        Console.WriteLine(Unsafe.SizeOf<string>());
    }
}
