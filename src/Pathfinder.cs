using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialUIDemo
{
    //The pathfinder functions are not yet implemented. I will add Djikstra's algorithm soon.
    class Pathfinder
    {
        int[] list;
        public bool refreshSemaphore;
        public int waitTime = 10;
        int squareLength;
        SortedSet<int> selectedPathSq = new SortedSet<int>();
        public List<(int, int, Color)> colourInCoords = new List<(int, int, Color)>();

        public void Init(int squareLength)
        {
            this.squareLength = squareLength;
        }

        //Use inheritance for this method? Maybe take some of init and put it as super method as well

        //Todo: Change data types
        public void setColouredSquares(int[] exploringSq, int[] exploredSq)
        {
            refreshSemaphore = false;
            colourInCoords.Clear();
            for (int i = 0; i < squareLength; i++)
            {
                for (int j = 0; j < squareLength; j++)
                {
                    
                }
            }
            refreshSemaphore = true;
        }
    }
}
