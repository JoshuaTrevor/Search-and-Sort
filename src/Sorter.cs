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
        List<int> greenCols = new List<int>();
        public List<(int, int, Color)> colourInCoords = new List<(int, int, Color)>();
        public void Init(int squareLength)
        {
            list = new int[squareLength];
            Random r = new Random();
            for(int i = 0; i < list.Length; i++)
            {
                list[i] = r.Next(1+squareLength/6, squareLength-squareLength/4);
            }
            setColouredSquares(new int[0] { }, new int[0] { }, new List<int>());
        }


        public void setColouredSquares(int[] targets, int[] pointers, List<int> greenColumns)
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
                    
                    else if (greenColumns.Contains<int>(i))
                        c = Color.PaleVioletRed;
                    if (j > 10000)
                    {
                        Console.WriteLine(list[i]);
                        return;
                    }
                    colourInCoords.Add((i, list.Length - j - 1, c));
                }
            }
            refreshSemaphore = true;
        }


        public void bubbleSort()
        {
            int n = list.Length;
            greenCols.Clear();
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
                    setColouredSquares(new int[2] { j, j + 1 }, new int[0] { }, greenCols);
                }
                greenCols.Add(list.Length - i - 1);

            }
            greenCols.Add(0);
            greenCols.Add(1);
            setColouredSquares(new int[0] { }, new int[0] { }, greenCols);
        }


        public void selectionSort()
        {
            int n = list.Length;
            greenCols.Clear();
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
                    setColouredSquares(new int[1] { j }, new int[1] { smallestNumberIndex }, greenCols);
                }
                //Move the value to the right hand side of the green columns
                int temp = list[i];
                if (smallestNumber == int.MaxValue)
                {
                    setColouredSquares(new int[0] { }, new int[0] { }, greenCols);
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
                setColouredSquares(new int[0] { }, new int[0] { }, greenCols);
            }
        }


        public void mergeSort()
        {
            hasRun = false;
            greenCols.Clear(); // move this to init and take out of these
            mergeSort(list, 0, list.Length - 1);
            setColouredSquares(new int[] { }, new int[] { }, greenCols);
        }

        bool hasRun = false;
        /* l is for left index and r is right index of the 
           sub-array of arr to be sorted */
        void mergeSort(int[] arr, int l, int r)
        {
            bool first = false;
            if (!hasRun)
            {
                first = true;
                hasRun = true;
                Console.WriteLine("called");
            }
            if (l < r)
            {
                // Same as (l+r)/2, but avoids overflow for 
                // large l and h 
                int m = l + (r - l) / 2;

                // Sort first and second halves 
                mergeSort(arr, l, m);
                mergeSort(arr, m + 1, r);

                Thread.Sleep(waitTime);
                setColouredSquares(new int[] { }, new int[] { }, greenCols);
                Console.WriteLine(first);
                merge(arr, l, m, r, first);
                
            }
        }

        void merge(int[] arr, int l, int m, int r, bool first)
        {
            Thread.Sleep(waitTime);
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            /* create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /* Copy data to temp arrays L[] and R[] */
            for (i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[m + 1 + j];

            /* Merge the temp arrays back into arr[l..r]*/
            i = 0; // Initial index of first subarray 
            j = 0; // Initial index of second subarray 
            k = l; // Initial index of merged subarray 
            while (i < n1 && j < n2)
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
                if(first)
                {
                    greenCols.Add(k-1);
                }
                Thread.Sleep(waitTime);
                setColouredSquares(new int[] { }, new int[] { i + l, j + m }, greenCols);
            }

            /* Copy the remaining elements of L[], if there 
               are any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
                if (first)
                {
                    Thread.Sleep(waitTime);
                    greenCols.Add(k - 1);
                    setColouredSquares(new int[] { }, new int[] { i + l, j + m }, greenCols);
                }
            }

            /* Copy the remaining elements of R[], if there 
               are any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
                if (first)
                {
                    Thread.Sleep(waitTime);
                    greenCols.Add(k - 1);
                    setColouredSquares(new int[] { }, new int[] { i + l, j + m }, greenCols);
                }
            }
        }
    }
}
