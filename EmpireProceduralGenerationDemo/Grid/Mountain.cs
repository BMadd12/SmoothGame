using System;

namespace EmpireProceduralGenerationDemo.Grid
{
    internal class Mountain : Tile
    {
        public Mountain(int xPos, int yPos) : base(xPos, yPos)
        {
            Random rand = new Random();

            food = rand.Next(1, 4);
            stone = rand.Next(5, 9);
            gold = rand.Next(3, 7);
            wood = rand.Next(1, 5);

            foodMod = -0.3;
            stoneMod = 0.6;
            goldMod = 0.4;
            woodMod = 0.1;
        }
    }
}