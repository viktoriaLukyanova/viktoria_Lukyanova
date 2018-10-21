using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {
        static public void PrintSeries(ISeries series)
        {
            series.Reset();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }
        }

        public interface ISeries
        {
            double GetCurrent();
            bool MoveNext();
            void Reset();
        }

        public class GeoProgression : ISeries
        {
            double start, step;
            int currentIndex;

            public GeoProgression(double start, double step)
            {
                this.start = start;
                this.step = step;
                this.currentIndex = 1;
            }

            public double GetCurrent()
            {
                return start * Math.Pow(step, currentIndex - 1);
            }

            public bool MoveNext()
            {
                currentIndex++;
                return true;
            }

            public void Reset()
            {
                currentIndex = 1;
            }

            static void Main(string[] args)
            {
                GeoProgression progression = new GeoProgression(2,2);
                Console.WriteLine("Progression:");
                PrintSeries(progression);
            }
        }
    }
}
