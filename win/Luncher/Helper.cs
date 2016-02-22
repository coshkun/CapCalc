using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luncher
{
    public static class Helper
    {
        #region QuickSort
        /// <summary>
        /// QuickSort algorithym needs the references of your Array.
        /// If you sort a string[], it only consider the first leter of the members. 
        /// </summary>
        /// <param name="x"></param>
        public static void QuickSort(ref int[] x)
        {
            qs(x, 0, x.Length - 1);
        }
        public static void QuickSort(ref float[] x)
        {
            qs(x, 0, x.Length - 1);
        }
        public static void QuickSort(ref decimal[] x)
        {
            qs(x, 0, x.Length - 1);
        }
        public static void QuickSort(ref double[] x)
        {
            qs(x, 0, x.Length - 1);
        }
        public static void QuickSort(ref char[] x)
        {
            qs(x, 0, x.Length - 1);
        }
        public static void QuickSort(ref string[] x)
        {
            qs(x, 0, x.Length - 1);
        }

        private static void qs(int[] x, int left, int right)
        {
            int i, j;
            int pivot, temp;

            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i] < pivot) && (i < right)) i++;
                while ((pivot < x[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) qs(x, left, j);
            if (i < right) qs(x, i, right);
        }
        private static void qs(char[] x, int left, int right)
        {
            int i, j;
            char pivot, temp;

            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i] < pivot) && (i < right)) i++;
                while ((pivot < x[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) qs(x, left, j);
            if (i < right) qs(x, i, right);
        }
        private static void qs(float[] x, int left, int right)
        {
            int i, j;
            float pivot, temp;

            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i] < pivot) && (i < right)) i++;
                while ((pivot < x[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) qs(x, left, j);
            if (i < right) qs(x, i, right);
        }
        private static void qs(decimal[] x, int left, int right)
        {
            int i, j;
            decimal pivot, temp;

            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i] < pivot) && (i < right)) i++;
                while ((pivot < x[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) qs(x, left, j);
            if (i < right) qs(x, i, right);
        }
        private static void qs(double[] x, int left, int right)
        {
            int i, j;
            double pivot, temp;

            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i] < pivot) && (i < right)) i++;
                while ((pivot < x[j]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) qs(x, left, j);
            if (i < right) qs(x, i, right);
        }
        private static void qs(string[] x, int left, int right)
        {
            int i, j;
            string pivot, temp;
            
            i = left;
            j = right;
            pivot = x[(left + right) / 2];

            do
            {
                while ((x[i].Substring(0,1)[0] < pivot[0]) && (i < right)) i++;
                while ((pivot[0] < x[j].Substring(0,1)[0]) && (j > left)) j--;

                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++; j--;
                }
            } while (i <= j);

            if (left < j) qs(x, left, j);
            if (i < right) qs(x, i, right);
        }
        #endregion

        #region Bubble Sorts
        public static void bubbleSort(ref int[] x)
        {
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < x.Length - 1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        // Exchange elements
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        exchanges = true;
                    }
                }
            } while (exchanges);
        }
        #endregion
        #region Cocktail Sort
        public static void CocktailSort(ref int[] x)
        {
            for (int k = x.Length - 1; k > 0; k--)
            {
                bool swapped = false;
                for (int i = k; i > 0; i--)
                    if (x[i] < x[i - 1])
                    {
                        // swap
                        int temp = x[i];
                        x[i] = x[i - 1];
                        x[i - 1] = temp;
                        swapped = true;
                    }

                for (int i = 0; i < k; i++)
                    if (x[i] > x[i + 1])
                    {
                        // swap
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        swapped = true;
                    }

                if (!swapped)
                    break;
            }
        }
        #endregion
        #region Odd Even Sort
        public static void OddEvenSort(ref int[] x)
        {
            int temp;
            for (int i = 0; i < x.Length / 2; ++i)
            {
                for (int j = 0; j < x.Length - 1; j += 2)
                {
                    if (x[j] > x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }

                for (int j = 1; j < x.Length - 1; j += 2)
                {
                    if (x[j] > x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }
            }
        }
        #endregion
        #region Comb Sort
        private static int newGap(int gap)
        {
            gap = gap * 10 / 13;
            if (gap == 9 || gap == 10)
                gap = 11;
            if (gap < 1)
                return 1;
            return gap;
        }

        public static void CombSort(ref int[] x)
        {
            int gap = x.Length;
            bool swapped;
            do
            {
                swapped = false;
                gap = newGap(gap);
                for (int i = 0; i < (x.Length - gap); i++)
                {
                    if (x[i] > x[i + gap])
                    {
                        swapped = true;
                        int temp = x[i];
                        x[i] = x[i + gap];
                        x[i + gap] = temp;
                    }
                }
            } while (gap > 1 || swapped);
        }
        #endregion
        #region Gnome Sort
        public static void GnomeSort(ref int[] x)
        {
            int i = 0;
            while (i < x.Length)
            {
                if (i == 0 || x[i - 1] <= x[i]) i++;
                else
                {
                    int temp = x[i];
                    x[i] = x[i - 1];
                    x[--i] = temp;
                }
            }
        }
        #endregion
        #region Insertion Sort
        public static void InsertionSort(ref int[] x)
        {
            int n = x.Length - 1;
            int i, j, temp;

            for (i = 1; i <= n; ++i)
            {
                temp = x[i];
                for (j = i - 1; j >= 0; --j)
                {
                    if (temp < x[j]) x[j + 1] = x[j];
                    else break;
                }
                x[j + 1] = temp;
            }
        }
        #endregion
        #region Shell Sort
        public static void ShellSort(ref int[] x)
        {
            int i, j, temp;
            int increment = 3;

            while (increment > 0)
            {
                for (i = 0; i < x.Length; i++)
                {
                    j = i;
                    temp = x[i];

                    while ((j >= increment) && (x[j - increment] > temp))
                    {
                        x[j] = x[j - increment];
                        j = j - increment;
                    }

                    x[j] = temp;
                }

                if (increment / 2 != 0)
                {
                    increment = increment / 2;
                }
                else if (increment == 1)
                {
                    increment = 0;
                }
                else
                {
                    increment = 1;
                }
            }
        }
        #endregion
        #region Selection Sort
        public static void SelectionSort(ref int[] x)
        {
            int i, j;
            int min, temp;

            for (i = 0; i < x.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < x.Length; j++)
                {
                    if (x[j] < x[min])
                    {
                        min = j;
                    }
                }
                temp = x[i];
                x[i] = x[min];
                x[min] = temp;
            }
        }
        #endregion
        #region Merge Sort
        /// <summary>
        /// Usage similar like QuickSort. LEFT is Start index, RIGTH is end index of your array.
        /// </summary>
        /// <param name="x">Referance of your array to be sorted inside of itself.</param>
        /// <param name="left">is Start index like '0' on Aray[0]</param>
        /// <param name="right">is End index like 'Aray.Lenght - 1' on Aray[Aray.Lenght - 1]</param>
        public static void MergeSort(ref int[] x, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(ref x, left, middle);
                MergeSort(ref x, middle + 1, right);
                Merge(ref x, left, middle, middle + 1, right);
            }
        }

        private static void Merge(ref int[] x, int left, int middle, int middle1, int right)
        {
            int oldPosition = left;
            int size = right - left + 1;
            int[] temp = new int[size];
            int i = 0;

            while (left <= middle && middle1 <= right)
            {
                if (x[left] <= x[middle1])
                    temp[i++] = x[left++];
                else
                    temp[i++] = x[middle1++];
            }
            if (left > middle)
                for (int j = middle1; j <= right; j++)
                    temp[i++] = x[middle1++];
            else
                for (int j = left; j <= middle; j++)
                    temp[i++] = x[left++];
            Array.Copy(temp, 0, x, oldPosition, size);
        }
        #endregion
        #region Bucket Sort
        public static void BucketSort(ref int[] x)
        {
            //Verify input
            if (x == null || x.Length <= 1)
                return;

            //Find the maximum and minimum values in the array
            int maxValue = x[0];
            int minValue = x[0];

            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] > maxValue)
                    maxValue = x[i];

                if (x[i] < minValue)
                    minValue = x[i];
            }

            //Create a temporary "bucket" to store the values in order
            //each value will be stored in its corresponding index
            //scooting everything over to the left as much as possible (minValue)
            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            //Move items to bucket
            for (int i = 0; i < x.Length; i++)
            {
                if (bucket[x[i] - minValue] == null)
                    bucket[x[i] - minValue] = new LinkedList<int>();

                bucket[x[i] - minValue].AddLast(x[i]);
            }

            //Move items in the bucket back to the original array in order
            int k = 0; //index for original array
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First; //start add head of linked list

                    while (node != null)
                    {
                        x[k] = node.Value; //get value of current linked node
                        node = node.Next; //move to next linked node
                        k++;
                    }
                }
            }
        }
        #endregion
        #region Heap Sort
        public static void Heapsort(ref int[] x)
        {
            int i;
            int temp;
            int n = x.Length;

            for (i = (n / 2) - 1; i >= 0; i--)
            {
                siftDown(ref x, i, n);
            }

            for (i = n - 1; i >= 1; i--)
            {
                temp = x[0];
                x[0] = x[i];
                x[i] = temp;
                siftDown(ref x, 0, i - 1);
            }
        }

        private static void siftDown(ref int[] x, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            int temp;

            while ((root * 2 <= bottom) && (!done))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (x[root * 2] > x[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (x[root] < x[maxChild])
                {
                    temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
        #endregion
        #region Count Sort
        public static void Count_Sort(ref int[] x)
        {
            int i = 0;
            int k = FindMax(x); //Finds max value of input array

            // output array holds the sorted output
            int[] output = new int[x.Length];

            // provides temperarory storage 
            int[] temp = new int[k + 1];
            for (i = 0; i < k + 1; i++)
            {
                temp[i] = 0;
            }

            for (i = 0; i < x.Length; i++)
            {
                temp[x[i]] = temp[x[i]] + 1;
            }

            for (i = 1; i < k + 1; i++)
            {
                temp[i] = temp[i] + temp[i - 1];
            }

            for (i = x.Length - 1; i >= 0; i--)
            {
                output[temp[x[i]] - 1] = x[i];
                temp[x[i]] = temp[x[i]] - 1;
            }

            for (i = 0; i < x.Length; i++)
            {
                x[i] = output[i];
            }
        }
        #endregion
        #region Radix Sort
        /// <summary>
        ///  RadixSort takes an array and the number of bits used as 
        ///  the key in each iteration.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="bits"></param>
        public static void RadixSort(ref int[] x, int bits)
        {
            //Use an array of the same size as the original array 
            //to store the result of each iteration.
            int[] b = new int[x.Length];
            int[] b_orig = b;

            //Mask is the bitmask used to extract the sort key. 
            //We start with the bits least significant bits and
            //left-shift it the same amount at each iteration. 
            //When all the bits are shifted out of the word, we are done.
            int rshift = 0;
            for (int mask = ~(-1 << bits); mask != 0; mask <<= bits, rshift += bits)
            {
                //An array is needed to store the count for each key value.
                int[] cntarray = new int[1 << bits];

                //Count each key value
                for (int p = 0; p < x.Length; ++p)
                {
                    int key = (x[p] & mask) >> rshift;
                    ++cntarray[key];
                }

                //Sum up how many elements there are with lower 
                //key values, for each key.
                for (int i = 1; i < cntarray.Length; ++i)
                    cntarray[i] += cntarray[i - 1];

                //The values in cntarray are used as indexes 
                //for storing the values in b. b will then be
                //completely sorted on this iteration's key. 
                //Elements with the same key value are stored 
                //in their original internal order.
                for (int p = x.Length - 1; p >= 0; --p)
                {
                    int key = (x[p] & mask) >> rshift;
                    --cntarray[key];
                    b[cntarray[key]] = x[p];
                }

                //Swap the a and b references, so that the 
                //next iteration works on the current b, 
                //which is now partially sorted.
                int[] temp = b; b = x; x = temp;
            }
        }
        #endregion
        // All Searching Algorythims below wants the sorted data.
        // Only Linear Search can accept randomized data, 
        // who has the most primitive strategy and the lowest performance.
        #region Linear Search
        public static int LinearSearch(ref int[] x, int valueToFind)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (valueToFind == x[i])
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
        #region Binary Search
        public static int BinSearch(ref int[] x, int searchValue)
        {
            // Returns index of searchValue in sorted array x, or -1 if not found
            int left = 0;
            int right = x.Length;
            return binarySearch(ref x, searchValue, left, right);
        }
        private static int binarySearch(ref int[] x, int searchValue, int left, int right)
        {
            if (right < left)
            {
                return -1;
            }
            int mid = (left + right) >> 1;
            if (searchValue > x[mid])
            {
                return binarySearch(ref x, searchValue, mid + 1, right);
            }
            else if (searchValue < x[mid])
            {
                return binarySearch(ref x, searchValue, left, mid - 1);
            }
            else
            {
                return mid;
            }
        }
        #endregion
        #region Interpolation Search
        public static int InterpolationSearch(ref int[] x, int searchValue)
        {
            // Returns index of searchValue in sorted input data
            // array x, or -1 if searchValue is not found
            int low = 0;
            int high = x.Length - 1;
            int mid;

            while (x[low] < searchValue && x[high] >= searchValue)
            {
                mid = low + ((searchValue - x[low]) * (high - low)) / (x[high] - x[low]);

                if (x[mid] < searchValue)
                    low = mid + 1;
                else if (x[mid] > searchValue)
                    high = mid - 1;
                else
                    return mid;
            }

            if (x[low] == searchValue)
                return low;
            else
                return -1; // Not found
        }
        #endregion


        #region Miscellaneous Utilities
        public static int FindMax(int[] x)
        {
            int max = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] > max) max = x[i];
            }
            return max;
        }
        public static int FindMin(int[] x)
        {
            int min = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] < min) min = x[i];
            }
            return min;
        }
        public static void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }
        /// <summary>
        /// Determines if int array is sorted from 0 -> Max
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Determines if int array is sorted from Max -> 0
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool IsSortedDescending(int[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] < arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Determines if string array is sorted from A -> Z
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool IsSorted(string[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].CompareTo(arr[i]) > 0) // If previous is bigger, return false
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Determines if string array is sorted from Z -> A
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool IsSortedDescending(string[] arr)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i].CompareTo(arr[i + 1]) < 0) // If previous is smaller, return false
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Generates some random values on a single vector Array for testing purpose.
        /// 
        /// Usage :
        /// 
        ///     Random rdn = new Random(nItems);
        ///     int[] xdata = new int[nItems];
        ///     MixDataUp(ref xdata, rdn); //Randomize data to be searched
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="rdn"></param>
        public static void MixDataUp(ref int[] x, Random rdn)
        {
            for (int i = 0; i <= x.Length - 1; i++)
            {
                x[i] = (int)(rdn.NextDouble() * x.Length);
            }
        }
        /// <summary>
        /// Generate Random Color in 8-bit with full Alpha
        /// </summary>
        /// <returns></returns>
        public static System.Drawing.Color GetRandomColor()
        {
            Random randonGen = new Random();
            return System.Drawing.Color.FromArgb(randonGen.Next(255), randonGen.Next(255),
            randonGen.Next(255));
        }
        #endregion
    }
}
