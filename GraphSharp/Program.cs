using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace GraphSharp
{

    class Program
    {
        static double probab = 1.0 / 2;
        static int N, M;
        static List<Edge> E;
        static List<double> Vertex = new List<double>();

        private static string DirectoryPath =
            @"C:\Users\beave\Documents\Visual Studio 2015\Projects\GraphSharp\GraphSharp\bin\Debug\Tests";


        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter(File.Open("results1.txt", FileMode.Create)))
            {
                Tester t = new Tester(writer, Console.Out, @"C:\Users\beave\Documents\Visual Studio 2015\Projects\GraphSh\GraphSh\bin\Debug\results.txt");
                t.LoadTestsFromDirectory(@"C:\Users\beave\Documents\Visual Studio 2015\Projects\GraphSharp\GraphSharp\bin\Debug\Tests");
            }
            Console.ReadLine();
        }
    }
}