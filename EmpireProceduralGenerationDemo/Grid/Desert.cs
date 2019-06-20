using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireProceduralGenerationDemo.Grid
{
    internal class Desert : Tile
    {
        public Desert(int xPos, int yPos) : base(xPos, yPos)
        {
            Random rand = new Random();

            food = rand.Next(1, 4);
            stone = rand.Next(1, 6);
            gold = rand.Next(1, 8);
            wood = rand.Next(1, 5);

            foodMod = -0.5;
            stoneMod = 0.2;
            goldMod = 0.4;
            woodMod = -0.1;
    }
    }
}
