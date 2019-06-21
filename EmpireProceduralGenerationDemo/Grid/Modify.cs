using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireProceduralGenerationDemo.Grid
{
    public static class Modify
    {

        public static double[] Desert() {

            double[] desert = new double[] { -0.5, 0.3, 0.5, -0.4};

            return desert;
        }

        public static double[] Forest()
        {
            double[] forest = new double[] { 0.6, -0.2, -0.7, 0.8 };

            return forest;
        }

        public static double[] Water()
        {
            double[] water = new double[] { 0.9, -0.7, -0.7, 0.1 };

            return water;
        }

        public static double[] Grasslands()
        {
            double[] grass = new double[] { 0.4, 0.2, -0.2, -0.6 };

            return grass;
        }

        public static double[] Mountain()
        {
            double[] mountain = new double[] { -0.4, 0.7, 0.4, -0.2 };

            return mountain;
        }

        public static double[] Plain()
        {
            double[] plain = new double[] { 0.0, 0.0, 0.0, 0.0 };

            return plain;
        }

    }
}
