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
        static Summator sum;

        private static string DirectoryPath =
            @"C:\Users\beave\Documents\Visual Studio 2015\Projects\GraphSharp\GraphSharp\bin\Debug\Tests";

        private static int steps = 0;


        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(DirectoryPath);
            using (StreamWriter writer = new StreamWriter(File.Open("results.txt", FileMode.Create)))
            {
                foreach (var dir in directory.GetDirectories())
                {
                    double AverageTime = 0;
                    var files = dir.GetFiles();
                    int[] m = new int[3];

                    foreach (var f in files)
                    {
                        Stopwatch stop = new Stopwatch();
                        stop.Start();
                        sum = new Summator();
                        String TestFile = f.FullName;
                        if (File.Exists(TestFile))
                        {
                            using (StreamReader reader = new StreamReader(File.Open(TestFile, FileMode.Open)))
                            {
                                String s = reader.ReadLine();
                                m[0] = Convert.ToInt32(s.Split(' ')[0]);
                                m[1] = Convert.ToInt32(s.Split(' ')[1]);
                                m[2] = Convert.ToInt32(s.Split(' ')[2]);
                                N = m[0]; //читаем количество вершин
                                DFS.VCount = N;
                                String vertex = reader.ReadLine();
                                String[] splited = vertex.Split(' ');
                                Vertex = new List<double>();
                                for (int i = 0; i < splited.Length - 1; i++)
                                    Vertex.Add(Convert.ToDouble(splited[i]));
                                DFS.Big = m[2];

                                M = m[1]; //читаем количество ребер
                                E = new List<Edge>(M);
                                for (int i = 0; i < M; i++)
                                {
                                    string Str = reader.ReadLine();
                                    E.Add(new Edge(Convert.ToInt32(Str.Split(' ')[0]),
                                        Convert.ToInt32(Str.Split(' ')[1])));
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не найден файл!");
                            Console.ReadKey();
                        }
                        Summator.max = (int)Math.Pow(2.0,(double) m[0] - m[2]);

                        List <bool> us = new List<bool>();
                        for (int i = 0; i < DFS.Big; i++)
                            us.Add(true);
                        Prob(us, 1, DFS.Big);

                        while (sum.end == false)
                        {

                        }
                        AverageTime += stop.ElapsedMilliseconds / (20.0 * 1000.0);
                        Console.WriteLine($"{TestFile.Split('\\').Last()} файл обработан");
                        writer.WriteLine(sum.answer);
                        //Console.WriteLine($"Ответ для {TestFile.Split('\\').Last()} - {sum.answer}");
                    }
                    writer.WriteLine($"Среднее время расчёта для графа на {m[0]} вершинах и {m[1]} рёбрах было {AverageTime} секунд");
                    Console.WriteLine($"Расчёт директории {dir.Name} окончен");
                    // Console.WriteLine();
                    //Console.WriteLine(
                    //$"Среднее время расчёта для графа на {m[0]} вершинах и {m[1]} рёбрах было {AverageTime}");
                }
                Console.WriteLine("все");
            }
            Console.ReadKey();

        }

        static void Prob(List<bool> used, double probability, int n)
        {
            if (n == N)
            {
                // Console.WriteLine(n);
                DFS d = new DFS(E, used);
                d.StartDfs();
                bool ssv = d.sv();
                sum.Add(probability, (ssv ? 1 : 0));
                return;
            }
            Task.Factory.StartNew(() => Prob(Reliable(used, true), probability * Vertex[n], n + 1));
            Task.Factory.StartNew(() => Prob(Reliable(used, false), probability * (1 - Vertex[n]), n + 1));
        }

        static List<bool> Reliable(List<bool> list, bool b)
        {
            List<bool> l = new List<bool>(list);
            l.Add(b);
            return l;
        }
    }
}