using System;

namespace EmpireProceduralGenerationDemo.Grid
{
    internal class Grass : Tile
    {
        public Grass(int xPos, int yPos) : base(xPos, yPos)
        {
            Random rand = new Random();

            food = rand.Next(3, 8);
            stone = rand.Next(1, 6);
            gold = rand.Next(1, 3);
            wood = rand.Next(1, 4);

            foodMod = 0.6;
            stoneMod = 0.1;
            goldMod = -0.2;
            woodMod = -0.4;
        }
    }
}