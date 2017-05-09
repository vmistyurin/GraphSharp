using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSharp
{
    public class ProbGraph<T> where T : GraphBase
    {
        private readonly T _graph;
        private readonly int _impNumber;
        public readonly List<double> _probabilities;
        private Summator sum;

        public ProbGraph(T graph, int impNumber, List<double> probabilities)
        {
            _graph = graph;
            this._impNumber = impNumber;
            this._probabilities = probabilities;
        }

        public double RelIndex()
        {
            int max = (int) Math.Pow(2.0, (double) _graph.Dimension - _impNumber);
            sum = new Summator(max);

            List<bool> us = new List<bool>();
            for (int i = 0; i < _impNumber; i++)
                us.Add(true);
            Prob(us, 1, _impNumber);

            while (sum.IsReady == false)
            {

            }

            return sum.answer;
        }

        private void Prob(List<bool> used, double probability, int n)
        {
            if (n == _graph.Dimension)
            {
                MatrixGraph m = (MatrixGraph)_graph.Clone();
                List<int> toDelete = new List<int>();
                for(int i = 0; i < used.Count; i++)
                    if(!used[i])
                        toDelete.Add(i);
                m.DeleteVertexes(toDelete.ToArray());
                var component = m.GetConnectedComponent(0);
                sum.Add(probability, isConnected(component));
                return;
            }
            Prob(Reliable(used, true), probability * _probabilities[n], n + 1);
            Prob(Reliable(used, false), probability * (1 - _probabilities[n]), n + 1);
        }

        private int isConnected(int[] component)
        {
            for(int i = 0; i < _impNumber; i++)
                if (!component.Contains(i))
                    return 0;
            return 1;
        }

        private List<bool> Reliable(List<bool> list, bool b)
        {
            List<bool> l = new List<bool>(list);
            l.Add(b);
            return l;
        }
    }
}
