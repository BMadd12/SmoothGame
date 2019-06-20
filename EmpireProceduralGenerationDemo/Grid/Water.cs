using System;

namespace EmpireProceduralGenerationDemo.Grid
{
    internal class Water : Tile
    {
        public Water(int xPos, int yPos) : base(xPos, yPos)
        {
            Random rand = new Random();

            food = rand.Next(4, 11);
            stone = rand.Next(1, 2);
            gold = rand.Next(1, 2);
            wood = rand.Next(2, 5);

            foodMod = 0.7;
            stoneMod = 0.0;
            goldMod = 0.0;
            woodMod = 0.1;
        }
    }
}