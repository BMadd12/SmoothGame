using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireProceduralGenerationDemo.Grid
{
    public class Tile
    {
        protected int xPos;
        protected int yPos;

        protected float food;
        protected float stone;
        protected float gold;
        protected float wood;

        private List<Type> tags = new List<Type>();


        //Generate enum of tile types
        private enum Type
        {
            Water,
            Grasslands,
            Desert,
            Mountain,
            Forest,
            Plains
        }


        public Tile(int xPos, int yPos)
        {

            Random rand = new Random();

            this.xPos = xPos;
            this.yPos = yPos;

            food = rand.Next(1, 101);
            stone = rand.Next(1, 101);
            gold = rand.Next(1, 101);
            wood = rand.Next(1, 101);

            setType();

        }

        private void setType() {

            if (food < 25.0)
            {
                if (wood < 45.0 && stone < 60.0)
                {
                    tags.Add(Type.Desert);
                }
                else
                {
                    tags.Add(Type.Mountain);
                }
            }
            else {
                if (wood < 25.0 && stone < 10.0 && gold < 15.0)
                {
                    tags.Add(Type.Water);
                }
                else if (gold < 20.0 && wood < 25.0) {
                    tags.Add(Type.Grasslands);
                }
            }

            if (wood > 70.0) {
                tags.Add(Type.Forest);
            }


            //If no match, set to plain
            if (tags.Count == 0) {
                tags.Add(Type.Plains);
            }

        }

        /// <summary>
        /// Generates the modifiers the tile applies to its neighbours based on its tags
        /// </summary>
        /// <returns>Returns an array containing doubles that act as modifiers</returns>
        public double[] getMods() {

            List<double[]> modifiers = new List<double[]>();

            //Hardcoded for the time being. May be unreasonable depending on the number of stats.
            double[] mods = new double[] { 0.0, 0.0, 0.0, 0.0 };

            //Gather modifiers based on tags
            foreach (Type tag in tags) {

                switch (tag) {
                    case Type.Desert:
                        modifiers.Add(Modify.Desert());
                        break;
                    case Type.Forest:
                        modifiers.Add(Modify.Forest());
                        break;
                    case Type.Grasslands:
                        modifiers.Add(Modify.Grasslands());
                        break;
                    case Type.Mountain:
                        modifiers.Add(Modify.Grasslands());
                        break;
                    case Type.Plains:
                        modifiers.Add(Modify.Plain());
                        break;
                    case Type.Water:
                        modifiers.Add(Modify.Plain());
                        break;
                }
            }

            //Average the modifiers
            foreach (double[] mod in modifiers) {

                for (int i = 0; i < 4; i++) {
                    mods[i] += mod[i];
                }
            }


            for (int i = 0; i < mods.Length; i++)
            {
                mods[i] = mods[i] % tags.Count();
            }

            return mods;
        }


        /// <summary>
        /// Applies the modifies of all the neighbours
        /// </summary>
        /// <param name="modifiers">An array of modifiers, generated from neighbouring getMods()</param>
        public void applyMods(double[] modifiers)
        {
            //Modify values
            food += (food * (float)modifiers[0]);
            stone += (stone * (float)modifiers[1]);
            gold += (gold * (float)modifiers[2]);
            wood += (wood * (float)modifiers[3]);

            //clear tags
            tags.Clear();

            //Reset tags
            setType();
        }

        public int XPOS {
            get {
                return xPos;
            }
        }

        public int YPOS {
            get {
                return yPos;
            }
        }

        public int[] Coords() {
            int[] coords = new int[] { xPos, yPos };

            return coords;
        }

        public float Food {
            get {
                return food;
            }

            set {
                food = value;
            }

        }

        public float Stone {
            get {
                return stone;
            }

            set {
                stone = value;
            }

        }

        public float Gold {
            get {
                return gold;
            }

            set {
                gold = value;
            }

        }

        public float Wood {
            get {
                return wood;
            }

            set {
                wood = value;
            }

        }

    }
}
