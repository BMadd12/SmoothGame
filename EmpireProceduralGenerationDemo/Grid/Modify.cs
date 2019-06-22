using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireProceduralGenerationDemo.Grid
{
    public static class Modify
    {

        public static int[] Desert() {

            int[] desert = new int[] { -6, 3, 6, -3 };

            return desert;
        }

        public static int[] Forest()
        {
            int[] forest = new int[] { 2, -2, -3, 4 };

            return forest;
        }

        public static int[] Water()
        {
            int[] water = new int[] { 4, -3, -1, 1 };

            return water;
        }

        public static int[] Grasslands()
        {
            int[] grass = new int[] { 2, -1, 1, -5 };

            return grass;
        }

        public static int[] Mountain()
        {
            int[] mountain = new int[] { -5, 7, 7, -3 };

            return mountain;
        }

        public static int[] Plain()
        {
            int[] plain = new int[] { 1, 1, 1, 1 };

            return plain;
        }

    }
}
