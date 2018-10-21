using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Program
    {
        static void PrintSeries(ISeries series)
        {
            series.Reset();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }
        static void PrintIIndex(IIndexable indexable)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(indexable[i]);
            }
        }

        public interface ISeries
        {
            double GetCurrent();
            bool MoveNext();
            void Reset();
        }

        public class ArithmeticalProgression : IIndexable, ISeries
        {
            double start, step;
            int currentIndex;

            public ArithmeticalProgression(double start, double step)
            {
                this.start = start;
                this.step = step;
                this.currentIndex = 0;
            }

            public double GetCurrent()
            {
                return start + step * currentIndex;
            }

            public bool MoveNext()
            {
                currentIndex++;
                return true;
            }

            public void Reset()
            {
                currentIndex = 0;
            }

            public double this[int index]
            {
                get
                {
                    return start + step * index;
                }
            }
        }

        public class List : IIndexable, ISeries
        {
            private double[] series;
            private int currentIndex;

            public List(double[] series)
            {
                this.series = series;
                currentIndex = 0;
            }

            public double GetCurrent()
            {
                return series[currentIndex];
            }

            public bool MoveNext()
            {
                currentIndex = currentIndex < series.Length - 1 ? currentIndex + 1 : 0;
                return true;
            }

            public void Reset()
            {
                currentIndex = 0;
            }

            public double this[int index]
            {
                get { return series[index]; }

            }
        }

        public interface IIndexable
        {
            double this[int index] { get; }
        }   
        
        static void Main(string[] args)
        {
            ArithmeticalProgression progression = new ArithmeticalProgression(2, 2);
            Console.WriteLine("Progression(Series):");
            PrintSeries(progression);
            Console.WriteLine("Progression(IIndexable):");
            PrintIIndex(progression);

            List list = new List(new double[] { 5, 8, 6, 3, 1 });
            Console.WriteLine("List(Series):");
            PrintSeries(list);
            Console.WriteLine("List(Indexable):");
            PrintIIndex(list);
        }
    }
}

