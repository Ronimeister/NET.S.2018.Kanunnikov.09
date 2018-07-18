using System;
using System.Collections.Generic;

namespace ArrayExtensions
{
    /// <summary>
    /// Class with extensions methods for "jagged arrays"
    /// </summary>
    public static class Sortings
    {
        #region Fields
        private static IComparer<int[]> _defaultComparer;
        #endregion

        #region Public API
        /// <summary>
        /// Extension method for "jagged array" that sort this array using BubbleSort
        /// </summary>
        /// <param name="array">The array needed to be sorted</param>
        /// <exception cref="ArgumentException">Throws when <paramref name="array"/> is empty</exception>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="array"/> is equal to null</exception>
        public static void BubbleSort(this int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null!");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty!");
            }

            _defaultComparer = new Comparators.SumArrayRowIncComparer();
            Sort(array, _defaultComparer);
        }

        /// <summary>
        /// Extension method for "jagged array" that sort this array using BubbleSort and some <see cref="IComparer{T}"/> comparer
        /// </summary>
        /// <param name="array">The array needed to be sorted</param>
        /// <param name="comparer">Some <see cref="IComparer{T}"/> comparer that indicates the way <paramref name="array"/> need to be sorted</param>
        /// <exception cref="ArgumentException">Throws when <paramref name="array"/> is empty</exception>
        /// /// <exception cref="ArgumentNullException">Throws when <paramref name="array"/> or <paramref name="comparer"/> is equal to null</exception>
        public static void BubbleSort(this int[][] array, IComparer<int[]> comparer)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null!");
            }

            if (comparer is null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be equal to null!");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty!");
            }

            Sort(array, comparer);
        }

        /// <summary>
        /// Extension method for "jagged array" that print this array on the screen using <see cref="Console.WriteLine()"/> and <see cref="Console.Write(int)"/> methods
        /// </summary>
        /// <param name="array">The array needed to be printed</param>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="array"/> is equal to null</exception>
        public static void Print(this int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null!");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty!");
            }

            PrintArray(array);
        }
        #endregion

        #region Private API
        private static void Sort(int[][] array, IComparer<int[]> comparer)
        {
            bool isDone = true;
            int rank = array.Length - 1;

            while (isDone)
            {
                isDone = false;
                for (int j = 0; j < rank; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        isDone = true;
                    }
                }

                rank--;
            }
        }

        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private static void PrintArray(int[][] array)
        {
            foreach (int[] row in array)
            {
                foreach (int i in row)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
