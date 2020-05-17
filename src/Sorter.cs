using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaterialUIDemo
{
    class Sorter
    {
        int[] list;
        public bool refreshSemaphore;
        public int waitTime = 10;
        public List<(int, int, Color)> colourInCoords = new List<(int, int, Color)>();
        public void Init(int squareLength)
        {
            list = new int[squareLength];
            Random r = new Random();
            for(int i = 0; i < list.Length; i++)
            {
                list[i] = r.Next(1+squareLength/6, squareLength-squareLength/4);
            }
            setColouredSquares(new int[0] { }, new List<int>());
        }

        public void setColouredSquares(int[] redColumns, List<int> greenColumns)
        {
            refreshSemaphore = false;
            colourInCoords.Clear();
            for(int i = 0; i < list.Length; i++)
            {
                for(int j = 0; j < list[i]; j++)
                {
                    Color c = Color.Blue;
                    if (redColumns.Contains<int>(i))
                        c = Color.DarkViolet;
                    else if (greenColumns.Contains<int>(i))
                        c = Color.PaleVioletRed;
                    colourInCoords.Add((i, list.Length - j - 1, c));
                }
            }
            refreshSemaphore = true;
        }

        public void bubbleSort()
        {
            int n = list.Length;
            List<int> greenCols = new List<int>();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    Thread.Sleep(waitTime);
                    if (list[j] > list[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;

                    }
                    setColouredSquares(new int[2] { j, j + 1 }, greenCols);
                }
                greenCols.Add(list.Length - i - 1);

            }
            greenCols.Add(0);
            greenCols.Add(1);
            setColouredSquares(new int[0] { }, greenCols);
        }
    }
}
