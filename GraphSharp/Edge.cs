using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSharp
{
    public sealed class Edge
    {
        public int v1 { get; }
        public int v2 { get; }

        public Edge(int firstV, int secondV)
        {
            if (firstV < secondV)
            {
                v1 = firstV;
                v2 = secondV;
            }
            else
            {
                v1 = secondV;
                v2 = firstV;
            }
        }
        public override bool Equals(object obj)
        {
            var e = (Edge)obj;
            return (e?.v1 == this.v1 && e?.v2 == this.v2) ? true : false;
        }

        public override int GetHashCode()
        {
            return (int)(Math.Pow(2.0, v1) * Math.Pow(3.0, v2));
        }
    }
}
