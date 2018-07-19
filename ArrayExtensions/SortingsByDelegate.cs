using System;
using System.Collections.Generic;

namespace ArrayExtensions
{
    /// <summary>
    /// Provides sorting functionality to int[][] using <see cref="Comparison{int[]}"/> comparison delegate
    /// </summary>
    public static class SortingsByDelegate
    {
        #region Public API
        /// <summary>
        /// Do BubbleSort to the <paramref name="array"/>
        /// </summary>
        /// <param name="array">Int[][] array needed to be sorted</param>
        /// <param name="comparer"><see cref="Comparison{int[]}"/> comparison delegate</param>
        /// <exception cref="ArgumentException">Throws when <paramref name="array"/> is empty</exception>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="array"/> or <paramref name="comparison"/> is equal to null</exception>
        public static void BubbleSort(this int[][] array, Comparison<int[]> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null!");
            }

            if (comparison == null)
            {
                throw new ArgumentNullException($"{nameof(comparison)} can't be equal to null!");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} can't be empty!");
            }

            Sort(array, Comparer<int[]>.Create(comparison));
        }
        #endregion

        #region Private methods
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
        #endregion
    }
}
