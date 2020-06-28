using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace MaterialUIDemo
{
    class Sorter
    {
        int[] list;
        public bool refreshSemaphore;
        public int waitTime = 10;
        SortedSet<int> greenCols = new SortedSet<int>();
        public List<(int, int, Color)> colourInCoords = new List<(int, int, Color)>();
        public bool sorted = false;
        public void Init(int squareLength)
        {
            sorted = false;
            list = new int[squareLength];
            Random r = new Random();
            greenCols.Clear();
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = r.Next(1+squareLength/6, squareLength-squareLength/4);
            }
            setColouredSquares(new int[0] { }, new int[0] { });
        }


        public void setColouredSquares(int[] targets, int[] pointers)
        {
            refreshSemaphore = false;
            colourInCoords.Clear();
            for (int i = 0; i < list.Length; i++)
            {
                for(int j = 0; j < list[i]; j++)
                {
                    Color c = Color.Blue;
                    if (pointers.Contains<int>(i))
                        c = Color.Red;
                    else if (targets.Contains<int>(i))
                        c = Color.LightGreen;
                    
                    else if (greenCols.Contains<int>(i))
                        c = Color.PaleVioletRed;
                    colourInCoords.Add((i, list.Length - j - 1, c));
                }
            }
            refreshSemaphore = true;
        }

        ////
        // Bubble sort
        ////
        public void bubbleSort()
        {
            int n = list.Length;
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
                    setColouredSquares(new int[2] { j, j + 1 }, new int[0] { });
                }
                greenCols.Add(list.Length - i - 1);

            }
            greenCols.Add(0);
            greenCols.Add(1);
            setColouredSquares(new int[0] { }, new int[0] { });
            sorted = true;
        }

        ////
        // Selection sort
        ////
        public void selectionSort()
        {
            int n = list.Length;
            int smallestNumber;
            int smallestNumberIndex = -1;
            for (int i = 0; i < n; i++)
            {
                smallestNumber = int.MaxValue;
                for (int j = i; j < n; j++)
                {
                    Thread.Sleep(waitTime);
                    if (list[j] < smallestNumber)
                    {
                        smallestNumber = list[j];
                        smallestNumberIndex = j;
                    }
                    setColouredSquares(new int[1] { j }, new int[1] { smallestNumberIndex });
                }
                //Move the value to the right hand side of the green columns
                int temp = list[i];
                if (smallestNumber == int.MaxValue)
                {
                    setColouredSquares(new int[0] { }, new int[0] { });
                    return;
                }
                list[i] = smallestNumber;
                //Now remove the old number and shuffle left to fill the gap
                for (int j = smallestNumberIndex; j > i; j--)
                {
                    list[j] = list[j - 1];
                }

                //Re-add the overwritten number
                if (i != smallestNumberIndex && i + 1 < n)
                    list[i + 1] = temp;
                
                greenCols.Add(i);
                setColouredSquares(new int[0] { }, new int[0] { });
            }
            sorted = true;
        }

        ////
        // Merge sort
        ////
        public void mergeSort()
        {
            hasRun = false;
            mergeSort(list, 0, list.Length - 1);
            setColouredSquares(new int[] { }, new int[] { });
            sorted = true;
        }

        bool hasRun = false;
        void mergeSort(int[] arr, int l, int r)
        {
            bool first = false;
            if (!hasRun)
            {
                first = true;
                hasRun = true;
            }
            if (l < r)
            {
                int m = l + (r - l) / 2;

                mergeSort(arr, l, m);
                mergeSort(arr, m + 1, r);

                Thread.Sleep(waitTime);
                setColouredSquares(new int[] { }, new int[] { });
                merge(arr, l, m, r, first);
            }
        }

        // Merge two sorted lists
        void merge(int[] arr, int l, int m, int r, bool first)
        {
            int i, j, k;
            int l1 = m - l + 1;
            int r1 = r - m;

            int[] L = new int[l1];
            int[] R = new int[r1];

            //Copy into temporary arrays
            for (i = 0; i < l1; i++)
            {
                L[i] = arr[l + i];
            }

            for (j = 0; j < r1; j++)
            {
                R[j] = arr[m + 1 + j];
            }

            i = j = 0;
            k = l;
            while (i < l1 && j < r1)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
                setupDrawingForMerge(i, j, k, l, m, first);
            }

            //Copy leftovers
            while (i < l1)
            {
                arr[k] = L[i];
                i++;
                k++;
                setupDrawingForMerge(i, j, k, l, m, first);
            }

            while (j < r1)
            {
                arr[k] = R[j];
                j++;
                k++;
                setupDrawingForMerge(i, j, k, l, m, first);
            }
        }

        public void setupDrawingForMerge(int i, int j, int k, int l, int m, bool first)
        {
            if (first)
                greenCols.Add(k - 1);
            Thread.Sleep(waitTime);
            setColouredSquares(new int[] { i + l, j + m }, new int[] { });
        }

        ////
        // Quick sort
        ////
        public void quickSort()
        {
            hasRun = false;
            quickSort(list, 0, list.Length - 1);
            setColouredSquares(new int[] { }, new int[] { });
            sorted = true;
        }

        private int Partition(int[] arr, int start, int end)
        {
            int key = arr[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                int z = 1;
                //Anything prior to a number which is definitely sorted must also be sorted since the sort works left>right
                //This doesn't perfectly represent the order in which numbers are processed but is close enough to be visually clean
                while (!greenCols.Contains<int>(start - z) && start - z > -1)
                {
                    greenCols.Add(start - z);
                    z++;
                }
                if (arr[j] <= key)
                {
                    Swap(ref arr[++i], ref arr[j]);
                }
                Thread.Sleep(waitTime);
                setColouredSquares(new int[] {j}, new int[] {end, start});
                
            }
            Swap(ref arr[i++], ref arr[end]);
            Thread.Sleep(waitTime);
            setColouredSquares(new int[] { }, new int[] { end, start });
            return i;
        }

        public void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public void quickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int key = Partition(arr, start, end);
                quickSort(arr, start, key - 1);
                quickSort(arr, key + 1, end);
            } 
            else
            {
                //These two numbers, at least, must be sorted
                greenCols.Add(start);
                greenCols.Add(end);
                int i = 1;
                //Anything prior to a number which is definitely sorted must also be sorted since the sort works left>right
                //This doesn't perfectly represent the order in which numbers are processed but is close enough to be visually clean
                while (!greenCols.Contains<int>(start - i) && start - i > -1)
                {
                    greenCols.Add(start - i);
                    i++;
                }
                setColouredSquares(new int[] { }, new int[] { end, start });
            }    
        }
    }
}
