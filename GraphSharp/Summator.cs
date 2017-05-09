using System.Threading;

namespace GraphSharp
{
    public class Summator
    {
        public int Count;
        public int Max;
        public double Answer;
        public bool IsReady { get; private set; }

        public Summator(int max)
        {
            Count = 0;
            Max = max;
            Answer = 0;
            IsReady = false;
        }

        private readonly object locker = new object();

        public void Add(double probability, int index)
        {
            lock (locker)
            {
                Count++;
                Answer += probability * index;
                if (Count == Max)
                    IsReady = true;
            }
        }
    }
}
