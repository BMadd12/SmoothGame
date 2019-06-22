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

        protected int food;
        protected int stone;
        protected int gold;
        protected int wood;

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


        public Tile(int xPos, int yPos, Random rand)
        {

            this.xPos = xPos;
            this.yPos = yPos;

            food = rand.Next(0, 21);
            stone = rand.Next(0, 21);
            gold = rand.Next(0, 21);
            wood = rand.Next(0, 21);

            setType();

        }

        private void setType() {

            if (food < 8)
            {
                if (wood < 10 && stone < 12)
                {
                    tags.Add(Type.Desert);
                }
                else
                {
                    tags.Add(Type.Mountain);
                }
            }
            else {
                if (wood < 10 && stone < 5 && gold < 8)
                {
                    tags.Add(Type.Water);
                }
                else if (gold < 10 && wood < 15) {
                    tags.Add(Type.Grasslands);
                }
            }

            if (wood >= 18) {
                tags.Add(Type.Forest);
            }

            if (gold >= 15 && stone >= 12) {
                tags.Add(Type.Mountain);
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
        public int[] getMods() {

            List<int[]> modifiers = new List<int[]>();

            //Hardcoded for the time being. May be unreasonable depending on the number of stats.
            int[] mods = new int[] { 0, 0, 0, 0 };

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
            foreach (int[] mod in modifiers) {

                for (int i = 0; i < 4; i++) {
                    mods[i] += mod[i];
                }
            }

            return mods;
        }


        /// <summary>
        /// Applies the modifies of all the neighbours
        /// </summary>
        /// <param name="modifiers">An array of modifiers, generated from neighbouring getMods()</param>
        public void applyMods(int[] modifiers)
        {
            //Modify values
            int modifiedFood = food + modifiers[0];

            if (modifiedFood > 20) {
                food = 20;
            } else if (modifiedFood < 0)
            {
                food = 0;
            } else
            {
                food = modifiedFood;
            }

            int modifiedStone = stone + modifiers[1];

            if (modifiedStone > 20)
            {
                stone = 20;
            }
            else if (modifiedStone < 0)
            {
                stone = 0;
            }
            else
            {
                stone = modifiedStone;
            }

            int modifiedGold = gold + modifiers[2];

            if (modifiedGold > 20)
            {
                gold = 20;
            }
            else if (modifiedGold < 0)
            {
                gold = 0;
            }
            else
            {
                gold = modifiedGold;
            }

            int modifiedWood = wood + modifiers[3];

            if (modifiedWood > 20)
            {
                wood = 20;
            }
            else if (modifiedWood < 0)
            {
                wood = 0;
            }
            else
            {
                wood = modifiedWood;
            }

            //clear tags
            tags.Clear();

            //Reset tags
            setType();
        }

        public List<string> Tags {
            get {
                List<string> tgs = new List<string>();

                foreach (Type t in tags)
                {
                    tgs.Add(t.ToString());
                }

                return tgs;
            }
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

        public int Food {
            get {
                return food;
            }

            set {
                food = value;
            }

        }

        public int Stone {
            get {
                return stone;
            }

            set {
                stone = value;
            }

        }

        public int Gold {
            get {
                return gold;
            }

            set {
                gold = value;
            }

        }

        public int Wood {
            get {
                return wood;
            }

            set {
                wood = value;
            }

        }

    }
}
