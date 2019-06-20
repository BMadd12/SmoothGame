using System;

namespace EmpireProceduralGenerationDemo.Grid
{
    internal class Forest : Tile
    {
        public Forest(int xPos, int yPos) : base(xPos, yPos)
        {
            Random rand = new Random();

            food = rand.Next(2, 8);
            stone = rand.Next(1, 3);
            gold = rand.Next(1, 2);
            wood = rand.Next(6, 11);

            foodMod = 0.4;
            stoneMod = -0.2;
            goldMod = 0.0;
            woodMod = 0.7;
        }
    }
}