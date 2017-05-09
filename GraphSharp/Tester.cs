﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace GraphSharp
{
    /*public class Tester
    {
        private readonly StreamWriter _outStream;
        private readonly StreamWriter _logStream;
        private readonly string _pathToAnswers;
        //private readonly Type _graphType;
        public Tester(StreamWriter outStream, StreamWriter logStream, string pathToAnswers)
        {
            _outStream = outStream;
            _logStream = logStream;
            _pathToAnswers = pathToAnswers;
        }

        public void LoadTestsFromDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach (var d in directory.GetDirectories())
            {
                LoadFromSubDirectory(d);
            }
        }

        private void LoadFromSubDirectory(DirectoryInfo currentDirectory)
        {
            Tuple<int, int> dimension = GetDimension(currentDirectory.Name);
            double averageTime = 0;
            int numberOfTests = currentDirectory.GetFiles().Length;
            int successfullTests = 0;
            StreamReader answers = new StreamReader(File.Open(_pathToAnswers, FileMode.Open));
            _logStream.WriteLine($"Тесты для {dimension.Item1},{dimension.Item2} начались!");
            foreach (var test in currentDirectory.GetFiles())
            {
                ProbGraph<MatrixGraph> graph = LoadFromFile(new StreamReader(File.Open(test.FullName, FileMode.Open)));
                Stopwatch timer = new Stopwatch();
                timer.Start();
                double answer = -1;
                try
                {
                    answer = graph.RelIndex();
                }
                catch (Exception e)
                {
                    _outStream.WriteLine($"Произошла ошибка! {e.Message} в тесте {test.Name}");
                }
                finally
                {
                    int expectedAnswer = Convert.ToInt32(answers.ReadLine());
                    if (Math.Abs(expectedAnswer - answer) < 0.000001)
                        successfullTests++;
                    averageTime += timer.ElapsedMilliseconds / (1000.0 * numberOfTests);
                }
            }
            string toOut = $"Тесты для {dimension.Item1},{dimension.Item2} завершены! Среднее время - {averageTime}";
            _outStream.WriteLine(toOut);
            _logStream.WriteLine(toOut);
            _outStream.WriteLine($"Прошло тестов: {successfullTests} из {numberOfTests}");
        }

        private Tuple<int, int> GetDimension(string directoryName)
        {
            string[] s = directoryName.Skip(5).ToString().Split(',');
            int V = Convert.ToInt32(s[0]);
            int E = Convert.ToInt32(s[1]);
            return new Tuple<int, int>(V, E);
        }

        public static ProbGraph<MatrixGraph> LoadFromFile(StreamReader test)
        {
            string[] dimension = test.ReadLine().Split(' ');
            int V = Convert.ToInt32(dimension[0]);
            int E = Convert.ToInt32(dimension[1]);
            int important = Convert.ToInt32(dimension[2]);

            string[] stringProbabilities = test.ReadLine().Trim().Split(' ');
            List<double> probabilities = new List<double>();
            foreach (var s in stringProbabilities)
                probabilities.Add(Convert.ToDouble(s));

            List<Edge> listOfEdges = new List<Edge>();
            for (int i = 0; i < E; i++)
            {
                string[] s = test.ReadLine().Split(' ');
                listOfEdges.Add(new Edge(Convert.ToInt32(s[0]), Convert.ToInt32(s[1])));
            }

            MatrixGraph graph = new MatrixGraph(V, listOfEdges);
            ProbGraph<MatrixGraph> p = new ProbGraph<MatrixGraph>(graph, important, probabilities);
            return p;
        }
    }*/
}
