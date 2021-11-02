using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithClases
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintManager printer1 = new PrintManager();
            ArrayManager manager1 = new ArrayManager();

            int[,] array1 = manager1.Create(5, 5);
            printer1.Print(array1);
            Console.WriteLine();
            int[,] array2 = manager1.AddRow(array1);
            printer1.Print(array2);
            Console.WriteLine();
            int[,] array3 = manager1.AddColoumn(array1);
            printer1.Print(array3);
            Console.WriteLine();
            int[,] array4 = manager1.DeleteRow(array1);
            printer1.Print(array4);
            Console.WriteLine();
            int[,] array5 = manager1.DeleteColoumn(array1);
            printer1.Print(array5);
            Console.WriteLine();
            int maxValue = manager1.GetMax(array1);
            printer1.Print(maxValue);
            Console.WriteLine();
            int[] diagonal1 = manager1.GetDiagonal(array1, 0);
            printer1.Print(diagonal1);
            Console.WriteLine();
            int[] diagonal2 = manager1.GetDiagonal(array1, 5);
            printer1.Print(diagonal2);
        }
    }

    public class ArrayManager
    {
        public int _height;
        public int _width;

        /// <summary>
        /// Creates array with given sizes of random numbers from 0 to 10 
        /// </summary>
        /// <param name="height">given any Int32 value</param>
        /// <param name="width">given any Int32 value </param>
        /// <returns>Returnes two-diimensional array of Int32 values</returns>
        public int[,] Create(int width, int height = 1)
        {
            Random rnd = new Random();
            int[,] arr = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr[i, j] = rnd.Next(10);
                }
            }
            return arr;
        }
        /// <summary>
        /// Adds new row (in given index )in given array of random numbers from 1-10
        /// </summary>
        /// <param name="array">Given any Int32 array</param>
        /// <param name="index">Given any Int32 value</param>
        /// <returns>Returnes array of Int32 values</returns>
        public int[,] AddRow(int[,] array, int index = 0)
        {
            Random rnd = new Random();
            int[,] newArr = new int[array.GetLength(0) + 1, array.GetLength(1)];
            int temp = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (temp == index)
                {
                    temp++;
                }
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    newArr[temp, j] = array[i, j];
                }
                temp++;
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                newArr[index, i] = rnd.Next(9);
            }
            return newArr;
        }
        /// <summary>
        /// Adds new coloumn (in given index )in given array of random numbers from 1-10
        /// </summary>
        /// <param name="array">Given any Int32 array</param>
        /// <param name="index">Given any Int32 value</param>
        /// <returns>Returnes array of Int32 values</returns>
        public int[,] AddColoumn(int[,] array, int index = 0)
        {
            Random rnd = new Random();
            int[,] newArr = new int[array.GetLength(0), array.GetLength(1) + 1];
            int temp;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                temp = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (temp == index)
                    {
                        temp++;
                    }
                    newArr[i, temp] = array[i, j];
                    temp++;
                }

            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                newArr[i, index] = rnd.Next(9);
            }
            return newArr;
        }
        /// <summary>
        /// Removes the row in given index of array Int32
        /// </summary>
        /// <param name="array">Given any Int32 array</param>
        /// <param name="index">Given any Int32 value</param>
        /// <returns>Returns Int32 array </returns>
        public int[,] DeleteRow(int[,] array, int index = 0)
        {
            int[,] newArr = new int[array.GetLength(0) - 1, array.GetLength(1)];
            int temp = 0;
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                if (temp == index - 1)
                {
                    temp++;
                }
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    newArr[i, j] = array[temp, j];
                }
                temp++;
            }
            return newArr;
        }
        /// <summary>
        /// Removes the coloumn in given index of array Int32
        /// </summary>
        /// <param name="array">Given any Int32 array</param>
        /// <param name="index">Given any Int32 value</param>
        /// <returns>Returns Int32 array </returns>
        public int[,] DeleteColoumn(int[,] array, int index = 0)
        {
            int[,] newArr = new int[array.GetLength(0), array.GetLength(1) - 1];
            int temp;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                temp = 0;
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (temp == index - 1)
                    {
                        temp++;
                    }
                    newArr[i, j] = array[i, temp];
                    temp++;
                }
            }
            return newArr;
        }
        /// <summary>
        /// findes maximum  element of given  array
        /// </summary>
        /// <param name="arr">given any array of Int32</param>
        /// <returns>Returns max element of given array</returns>
        public int GetMax(int[,] arr)
        {
            int max = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max)
                        max = arr[i, j];
                }
            }
            return max;
        }
        /// <summary>
        /// findes maximum  element of given  array
        /// </summary>
        /// <param name="arr">given any array of Int32</param>
        /// <returns>Returnes maximum element of given array</returns>
        public int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
        /// <summary>
        /// Findes minmum element of given  Two-Dimensional array
        /// </summary>
        /// <param name="arr">given any array of Int32</param>
        /// <returns>Returnes min  element of given array</returns>
        public int GetMin(int[,] arr)
        {
            int min = arr[0, 0];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min)
                        min = arr[i, j];
                }
            }
            return min;
        }
        /// <summary>
        /// FInds minimum element of given array
        /// </summary>
        /// <param name="arr">given any array of Int32</param>
        /// <returns>Returnes minimum element of given array</returns>
        public int GetMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
        /// <summary>
        /// Findes diagonal from given coloumn index from given array
        /// </summary>
        /// <param name="arr">Given any array of Int32</param>
        /// <returns>Returnes Int32 value</returns>
        public int[] GetDiagonal(int[,] arr, int startCol)
        {
            int[] diagonal = new int[arr.GetLength(0)];
            if (startCol == 0)
            {
                if (arr.GetLength(0) == arr.GetLength(1))
                {
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        diagonal[i] = arr[i, i];
                    }
                }
            }
            else if (startCol == arr.GetLength(1))
            {
                {
                    int j = arr.GetLength(0) - 1;
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        diagonal[i] = arr[i, j];
                        j--;
                    }
                }
            }
            return diagonal;
        }
        /// <summary>
        ///  Swaps given two elements of given  array
        /// </summary>
        /// <param name="arr">given  arary of Int32</param>
        /// <param name="coord1">given arary for first  element coordinates (length is 2)</param>
        /// <param name="coord2">given arary for second element coordinates (length is 2)</param>
        /// <returns>Returnes Int32 array</returns>
        public int[,] Swap(int[,] arr, int[] coord1, int[] coord2)
        {
            int[,] newArray = new int[arr.GetLength(0), arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    newArray[i, j] = arr[i, j];
                }
            }
            int temp;
            temp = newArray[coord1[0], coord1[1]];
            newArray[coord1[0], coord1[1]] = newArray[coord2[0], coord2[1]];
            newArray[coord2[0], coord2[1]] = temp;
            return newArray;
        }
    }
    public class PrintManager
    {
        /// <summary>
        /// Prints given two-dimensional array elements
        /// </summary>
        /// <param name="array">Given any array of Int32</param>
        public void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Prints given array elements
        /// </summary>
        /// <param name="arr">Given any array of Int32</param>
        public void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

        }
        /// <summary>
        /// Prints given value
        /// </summary>
        /// <param name="value">Given Int32 value</param>
        public void Print(int value)
        {
            Console.WriteLine(value);
        }
    }

}
