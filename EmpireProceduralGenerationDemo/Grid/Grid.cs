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
        public Grid(int length, int width) {
            grid = new Tile[length * width];

            this.length = length;
            this.width = width;

            generateTiles(length, width);
        }

        /// <summary>
        /// Generates the tiles, using a really basic random to determine the type.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        private void generateTiles(int length, int width) {

            //initialize coords
            int xPos = 0;
            int yPos = 0;

            Random rand = new Random();

            for (int i = 0; i < grid.Length; i++) {

                grid[i] = new Tile(xPos, yPos);

                xPos++;

                if (xPos > width) {
                    yPos++;
                    xPos = 0;
                }
            }
        }

        /// <summary>
        /// Sets the modifiers for each tile based on its neighbours
        /// </summary>
        private void setMods() {

        }

        /// <summary>
        /// Grabs the set of neighbours which influence the stats for each tile.
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <returns></returns>
        private Tile[] getNeighbours(int xPos, int yPos) {
            List<int[]> neighbourList = neighbouringCoords(xPos, yPos);

            //Filter out coords that cannot exist on the map
            foreach (int[] neighbour in neighbourList) {

                if (neighbour[0] < 0 || neighbour[1] < 0 || neighbour[0] > width || neighbour[1] > length) {
                    neighbourList.Remove(neighbour);
                }

            }

            return null;
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
