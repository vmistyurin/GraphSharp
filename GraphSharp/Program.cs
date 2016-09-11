using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace GraphSharp
{
    class Edge
    {
        public int v1, v2;
        public Edge(int _v1, int _v2)
        {
            v1 = _v1;
            v2 = _v2;
        }
    }
    /*class Graph
    {
        static List<Edge> E;

    }*/

            
      class DFS
    {
        List<Edge> Edges;
        List<int> ConComp;
        int NumberOfDfs = 0;
        public static int VCount;
        public static List<int> Big;
        public DFS(List<Edge> _l, List<bool> _exist)
        {
            Edges = new List<Edge>(_l);
            ConComp = new List<int>(VCount);
            for (int i = 0; i < VCount; i++)
            {
                ConComp.Add(0);
            }
            Edges.RemoveAll(edge => (!_exist[edge.v1] || !_exist[edge.v2]) ? true : false);
        }
        public void StartDfs(int n = 0)
        {
            while (ConComp.Contains(0))
            {
                NumberOfDfs++;
                Dfs(ConComp.IndexOf(0));
            }
        }
        private void Dfs(int n = 0)
        {
            ConComp[n] = NumberOfDfs;
            foreach (var e in Edges)
            {
                if (e.v1 == n && ConComp[e.v2] == 0)
                {
                    Dfs(e.v2);
                }
                if (e.v2 == n && ConComp[e.v1] == 0)
                {
                    Dfs(e.v1);
                }
            }
        }
        public bool sv()
        {
            int c = ConComp[Big[0]];
            foreach (var u in Big)
            {
                if (c != ConComp[u])
                    return false;
            }
            return true;
        }
    }
    class Program
    {
        static double probab = 1.0 / 2;
        static int N, M;
        static List<int> Big;
       // static List<List<int>> graph;
        static List<Edge> E;
        static List<double> Vertex;
        static void Main(string[] args)
        {
            if (File.Exists("input.txt"))
            {
                using (StreamReader reader = new StreamReader(File.Open("input.txt", FileMode.Open)))
                {
                    N = Convert.ToInt32(reader.ReadLine()); //читаем количество вершин
                    DFS.VCount = N;
                    Vertex = new List<double>(reader.ReadLine().Split(' ').Select(q => Double.Parse(q)).ToArray());//читаем вероятности вершин
                    Big = new List<int>(reader.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray()); //читаем номера важных вершин
                    DFS.Big = Big;

                    M = Convert.ToInt32(reader.ReadLine()); //читаем количество ребер
                    E = new List<Edge>(M); 
                    for (int i = 0; i < M; i++)
                    {
                        string Str = reader.ReadLine();
                        E.Add(new Edge(Convert.ToInt32(Str.Split(' ')[0]),
                                       Convert.ToInt32(Str.Split(' ')[1])));
                    }
                }
            }

            List<bool> us = new List<bool>(N);
            for (int i = 0; i < N; i++)
                us.Add(true);

            probab = Prob(us);

            using (StreamWriter writer = new StreamWriter(File.Open("output.txt", FileMode.Create)))
            {
                writer.Write(probab);
            }
            Console.WriteLine("Готово");
            Console.WriteLine(probab);
            Console.ReadKey();
        }
        static double Prob(List<bool> used, int n = 0, int deep = 0)
        {
            if (n == N)
            {
                DFS d = new DFS(E, used);
                d.StartDfs();
                return d.sv() ? 1 : 0;
            }
            used[n] = true;
            var v1 = Vertex[n] * Prob(used, n + 1, deep + 1);
            used[n] = false;
            var v2 = (1 - Vertex[n]) * Prob(used, n + 1,deep + 1);
            return v1 + v2;
        }
    }
}
   /* class ProbGraph
    {
        private int _numbervertex;
        public int vertex { get { return _numbervertex; } }
        public List<List<bool>> edge;
        public ProbGraph(int _numbofvertex, List<List<bool>> _edge)
        {
            edge = _edge;
            _numbofvertex = _numbervertex;
        }

    }
}*/
