using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSharp
{
    public class Summator
    {
        public Queue<Tuple<double, int>> Sum;
        public bool end;
        public double answer;
        public double probability;
        public int Count;
        public static int max;
        public Summator()
        {
            Sum = new Queue<Tuple<double, int>>();
            end = false;
            answer = 0;
            probability = 0;
            Task.Factory.StartNew(() => Listener());
            Count = 0;
        }

        public void Add(double probability, int index)
        {
            lock (Sum)
            {
                Sum.Enqueue(new Tuple<double, int>(probability, index));
            }
        }

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
                            Count++;
                            //   Console.WriteLine($"Обновлено, теперь {probability}, индекс {answer}");
                        }
                        if (Count == max)
                        {
                            end = true;
                            return;
                        }
                    }
                }
            }
        }
    }
}

