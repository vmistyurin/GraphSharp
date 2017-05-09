using System.Threading;

namespace GraphSharp
{
    public class Summator
    {
        public int Count;
        public int Max;
        public double answer;
        public bool IsReady { get; private set; }
        public Summator(int max)
        {
            Count = 0;
            Max = max;
            answer = 0;
            IsReady = false;
        }

        private readonly object locker = new object();
        public void Add(double probability, int index)
        {
            lock (locker)
            {
                Count++;
                answer += probability * index;
                if (Count == Max)
                    IsReady = true;
            }
        }
        /*
        public void Listener()
        {
            while (true)
            {
                if (Sum.Count > 0)
                {
                    lock (Sum)
                    {
                        while (Sum.Count > 0)
                        {
                            var r = Sum.Dequeue();
                            answer += r.Item1 * r.Item2;
                            probability += r.Item1;
                            count++;
                            //   Console.WriteLine($"Обновлено, теперь {probability}, индекс {answer}");
                        }
                        if (count == Max)
                        {
                            end = true;
                            return;
                        }
                    }
                }
            }
        }*/
    }
}

