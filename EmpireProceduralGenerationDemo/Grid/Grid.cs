using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpireProceduralGenerationDemo.Grid
{
    public class Grid
    {

        private Tile[] grid;
        private int length;
        private int width;

        /// <summary>
        /// Constructor. Generates the grid with a size equal to the length and width provided
        /// </summary>
        /// <param name="length">Integer describing the length of the grid</param>
        /// <param name="width">Integer describing the width of the grid</param>
        public Grid(int length, int width, int parses) {
            grid = new Tile[length * width];

            this.length = length;
            this.width = width;

            generateTiles(length, width, parses);
        }

        /// <summary>
        /// Generates the tiles, using a really basic random to determine the type.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        private void generateTiles(int length, int width, int parses) {

            //initialize coords
            int xPos = 0;
            int yPos = 0;

            Random rand = new Random();

            for (int i = 0; i < grid.Length; i++) {

                grid[i] = new Tile(xPos, yPos, rand);

                xPos++;

                if (xPos > width) {
                    yPos++;
                    xPos = 0;
                }
            }

            printTileData();

            //Parse the modifier set
            for (int i = 0; i < parses; i++) {
                setMods();
                printTileData();
            }

        }

        public void printTileData() {

            Console.WriteLine(grid.Length);

            Console.WriteLine("================================ \n" +
                "Grid Data \n" +
                "================================ \n");

            for (int i = 0; i < grid.Length; i++)
            {
                Console.WriteLine("\n\n __________________________");
                Console.WriteLine("Coords: {0},{1}", grid[i].XPOS, grid[i].YPOS);
                Console.WriteLine("-----------------");
                Console.WriteLine("Tags: ");
                grid[i].Tags.ForEach(Console.WriteLine);
                Console.WriteLine("-----------------");

                Console.WriteLine("Food: {0}", grid[i].Food);
                Console.WriteLine("Stone: {0}", grid[i].Stone);
                Console.WriteLine("Gold: {0}", grid[i].Gold);
                Console.WriteLine("Wood: {0}", grid[i].Wood);
            }

        }

        /// <summary>
        /// Sets the modifiers for each tile based on its neighbours
        /// </summary>
        private void setMods() { 

            //cycle through all tiles in the grid
            foreach(Tile tile in grid)
            {

                //initialize modifiers
                int[] modifiers = new int[] { 0, 0, 0, 0 };

                //find neighbours
                List<Tile> neighbours = getNeighbours(tile.XPOS, tile.YPOS);

                //extract modifiers from neighbours
                foreach (Tile neighbour in neighbours) {
                    int[] neighbourMods = neighbour.getMods();

                    for (int i = 0; i < modifiers.Length; i++) {
                        modifiers[i] += neighbourMods[i];
                    }
                }

                //Average the modifiers
                for (int i = 0; i < modifiers.Length; i++) {
                    modifiers[i] = modifiers[i] / neighbours.Count;
                }

                //apply modifiers
                tile.applyMods(modifiers);

            }

        }

        /// <summary>
        /// Grabs the set of neighbours which influence the stats for each tile.
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <returns></returns>
        private List<Tile> getNeighbours(int xPos, int yPos) {
            List<int[]> neighbourList = neighbouringCoords(xPos, yPos);
            List<int[]> neighbourReference = neighbouringCoords(xPos, yPos);

            List<Tile> neighbours = new List<Tile>();

            //Filter out coords that cannot exist on the map
            foreach (int[] neighbour in neighbourReference) {

                if (neighbour[0] < 0 || neighbour[1] < 0 || neighbour[0] > width || neighbour[1] > length) {
                    neighbourList.Remove(neighbour);
                }

            }

            foreach (int[] neighbour in neighbourList) {
                foreach(Tile tile in grid)
                {
                    int[] coords = tile.Coords();

                    if (coords[0] == neighbour[0] && coords[1] == neighbour[1])
                    {
                        neighbours.Add(tile);
                    }
                }
            }

            return neighbours;
        }

        /// <summary>
        /// Returns a list of all neighbouring coordinates surrounding the hex tile
        /// </summary>
        /// <param name="xPos">xPositon (along the width) of the coordinate</param>
        /// <param name="yPos">yPosition (along the width) of the coordinate</param>
        /// <returns>A list of integer arrays made up of the x and y coords of the neighbours</returns>
        private List<int[]> neighbouringCoords(int xPos, int yPos) {
            List<int[]> neighbourCoords = new List<int[]>
            {
                new int[] { xPos - 1, yPos - 1 },
                new int[] { xPos - 1, yPos },
                new int[] { xPos, yPos - 1 },
                new int[] { xPos + 1, yPos - 1 },
                new int[] { xPos + 1, yPos },
                new int[] { xPos, yPos + 1 }
            };

            return neighbourCoords;
        }

        /// <summary>
        /// Returns the grid array
        /// </summary>
        /// <returns></returns>
        public Tile[] Get {

            get {
                return grid;
            }
            
        }


    }
}
