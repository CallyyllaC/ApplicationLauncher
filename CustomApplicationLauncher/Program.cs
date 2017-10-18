using System;
using System.Diagnostics;

namespace CustomApplicationLauncher
{
    class Program
    {
        static string Openfile = null;
        static int TimeToOpen = 10; //minutes
        static int TimeBetweenOpen = 10; //minutes

        static private void kill(int id)
        {
            var p = Process.GetProcessById(id);
            p.Kill();
            Console.WriteLine($"Closesd id: {id}");
        }

        static private void Start(string file, string arg)
        {
            var p = new Process();
            p.StartInfo.FileName = file;
            p.StartInfo.Arguments = arg;
            p.Start();
            var id = p.Id;
            Console.WriteLine($"File: {file}");
            Console.WriteLine($"ID: {id}");
            System.Threading.Thread.Sleep(TimeToOpen * 60 * 1000);
            kill(id);
        }

        static void Main()
        {
            bool run = true;
            while (run == true)
            {
                Console.WriteLine("Opening Program");
                Start(Openfile, $"");
                System.Threading.Thread.Sleep(TimeBetweenOpen * 60 * 1000);
            }
            Console.WriteLine("Completly finished");
            Console.ReadLine();
        }
    }
}
