using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4_Csh
{
    internal class Adversary
    {

        // Number of servers
        protected int M { get; private set; }

        // Period time T (expressed days)
        protected int T { get; private set; }

        // N
        protected int N { get; private set; }

        // Subinterval lenght
        protected float subintervalLenght { get; private set; }

        // P
        protected float P { get; private set; }

        // Probability of success at time T/N
        protected float LAMBDA { get; private set; }

        // This list represents the history of all N attacks for all M systems
        protected List<List<int>> lineChartValuesChart2 { get; private set; }


        // Constructor
        public Adversary(int m, int n, float lambda, int t)
        {
            M = m;
            N = n;
            LAMBDA = lambda;
            T = t;
            subintervalLenght = (float)t/n;
            P = lambda*subintervalLenght;
            lineChartValuesChart2 = new List<List<int>>();
        }

        // Method to generate attacks
        public bool generateAttacks()
        {
            Random random = new Random();

            for (int i = 0; i < M; i++)
            {
                List<int> valuesChart2 = new List<int>();


                for (int j = 0; j < N; j++)
                {
                    // Generate random from (0, 1]
                    float randomNumber = (float)random.NextDouble();

                    if (randomNumber > P)
                    {
                        // Attacck failed
                        valuesChart2.Add(0);
                    }
                    else
                    {
                        // Attacc success
                        valuesChart2.Add(1);
                    }
                }

                lineChartValuesChart2.Add(valuesChart2);
            }

            return true;
        }


        public Dictionary<int, int> createHistoDistrib(List<List<int>> values, int k)
        {

            Dictionary<int, int> finalValues = new Dictionary<int, int>();

            for (int i = 0; i < values.Count; i++)
            {
                int sum = 0;
                for (int s = 0; s < values[i].Count; s++)
                {
                    sum += values[i][s];
                }
                //Debug.WriteLine("   System" + i + " final value = " + sum);
                finalValues.Add(i, sum);
            }

            return finalValues;
        }
        public Dictionary<int, int> createHistoDistribToN(List<List<int>> values, int k, int pointOfInterest)
        {

            Dictionary<int, int> finalValues = new Dictionary<int, int>();

            for (int i = 0; i < values.Count; i++)
            {
                int sum = 0;
                for (int s = 0; s < pointOfInterest; s++)
                {
                    sum += values[i][s];
                }
                //Debug.WriteLine("   System" + i + " " + pointOfInterest + "value = " + sum);
                finalValues.Add(i, sum);
            }

            return finalValues;
        }

        public List<List<int>> GetLineChart2AttackList()
        {
            return lineChartValuesChart2;
        }

    }

}
