using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Program
    {
        static public void PrintSeries(ISeries series)
        {
            
            for (int i = 0; i < 10; i++)
            {                
                Console.WriteLine(series.GetCurrent());
            }
        }

        public interface ISeries
        {
            double GetCurrent();
        }

        public class GeoProgression : ISeries
        {
            double start, step, b = 0;            

            public GeoProgression(double start, double step)
            {
                this.start = start;
                this.step = step;                
            }

            public double GetCurrent()
            {
                if (b==0)
                {
                    return b = start;
                }
                else
                {
                    return b *= step;
                }
            }

            static void Main(string[] args)
            {
                ISeries progression = new GeoProgression(2,2);
                Console.WriteLine("Progression:");
                PrintSeries(progression);
            }
        }
    }
}
