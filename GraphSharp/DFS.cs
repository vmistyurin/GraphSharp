using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSharp
{
    public class DFS
    {
        List<Edge> Edges;
        List<int> ConComp;
        public static int VCount;
        public static int Big;
       // public Summator s;
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
            Dfs(0);
        }

        private void Dfs(int n = 0)
        {
            ConComp[n] = 1;
            foreach (var e in Edges)
            {
                if (e.v1 == n && ConComp[e.v2] == 0)
                    Dfs(e.v2);
                if (e.v2 == n && ConComp[e.v1] == 0)
                    Dfs(e.v1);
            }
        }

        public bool sv()
        {
            for(int i = 0; i < Big;i++)
            {
                if (ConComp[i] == 0)
                    return false;
            }
            return true;
        }
    }
}
