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

        protected double foodMod;
        protected double stoneMod;
        protected double goldMod;
        protected double woodMod;


        public Tile(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
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

        public double FoodMod {
            get {
                return food;
            }

        }

        public double StoneMod {
            get {
                return stoneMod;
            }

        }

        public double GoldMod {
            get {
                return goldMod;
            }

        }

        public double WoodMod {
            get {
                return woodMod;
            }

        }

    }
}
