using System.Collections.Generic;
using System.Linq;

namespace ArrayExtensions.Tests
{
    public class Comparators
    {
        /// <summary>
        /// Class that describe special comparer for incremention of max sum in the array
        /// </summary>
        public class SumArrayRowIncComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method that compare two arrays by the incremention of max sum in those arrays
            /// </summary>
            /// <param name="lhs">First array to compare</param>
            /// <param name="rhs">Second array to compare</param>
            /// <returns>Int value representing comparisson</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (ReferenceEquals(lhs, rhs))
                {
                    return 0;
                }

                if (lhs == null)
                {
                    return 1;
                }

                if (rhs == null)
                {
                    return -1;
                }

                if (GetSum(lhs) <= GetSum(rhs))
                {
                    return -1;
                }

                return 1;
            }

            private long GetSum(int[] array)
            {
                long result = 0;

                foreach(int i in array)
                {
                    result += i;
                }

                return result;
            }
        }

        /// <summary>
        /// Class that describe special comparer for decremention of max sum in the array
        /// </summary>
        public class SumArrayRowDecComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method that compare two arrays by the decremention of max sum in those arrays
            /// </summary>
            /// <param name="lhs">First array to compare</param>
            /// <param name="rhs">Second array to compare</param>
            /// <returns>Int value representing comparisson</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (ReferenceEquals(lhs, rhs))
                {
                    return 0;
                }

                if (lhs == null)
                {
                    return -1;
                }

                if (rhs == null)
                {
                    return 1;
                }

                if (GetSum(rhs) <= GetSum(lhs))
                {
                    return -1;
                }

                return 1;
            }

            private long GetSum(int[] array)
            {
                long result = 0;

                foreach (int i in array)
                {
                    result += i;
                }

                return result;
            }
        }

        /// <summary>
        /// Class that describe special comparer for incremention of max value in the array
        /// </summary>
        public class MaxValueInRowIncComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method that compare two arrays by the incremention of max value in those arrays
            /// </summary>
            /// <param name="lhs">First array to compare</param>
            /// <param name="rhs">Second array to compare</param>
            /// <returns>Int value representing comparisson</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (ReferenceEquals(lhs, rhs))
                {
                    return 0;
                }

                if(lhs == null)
                {
                    return 1;
                }

                if (rhs == null)
                {
                    return -1;
                }
                
                int lhsMax = FindMax(lhs);
                int rhsMax = FindMax(rhs);

                if (lhsMax == rhsMax)
                {
                    return Compare(DeleteFromArray(lhsMax, lhs), DeleteFromArray(rhsMax, rhs));
                }

                if (lhsMax < rhsMax)
                {
                    return -1;
                }              

                return 1;
            }

            private int FindMax(int[] array)
            {
                int maxValue = int.MinValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if(array[i] > maxValue && array[i] != int.MinValue)
                    {
                        maxValue = array[i];
                    }
                }

                return maxValue;
            }

            private int[] DeleteFromArray(int deleted, int[] array)
                => array.Where(val => val != deleted).ToArray();
        }

        /// <summary>
        /// Class that describe special comparer for decremention of max value in the array
        /// </summary>
        public class MaxValueInRowDecComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method that compare two arrays by the decremention of max value in those arrays
            /// </summary>
            /// <param name="lhs">First array to compare</param>
            /// <param name="rhs">Second array to compare</param>
            /// <returns>Int value representing comparisson</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (ReferenceEquals(lhs, rhs))
                {
                    return 0;
                }

                if (lhs == null)
                {
                    return -1;
                }

                if (rhs == null)
                {
                    return 1;
                }

                int lhsMax = FindMax(lhs);
                int rhsMax = FindMax(rhs);

                if (rhsMax == lhsMax)
                {
                    return Compare(DeleteFromArray(lhsMax, lhs), DeleteFromArray(rhsMax, rhs));
                }

                if (rhsMax < lhsMax)
                {
                    return -1;
                }

                return 1;
            }

            private int FindMax(int[] array)
            {
                int maxValue = int.MinValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > maxValue && array[i] != int.MinValue)
                    {
                        maxValue = array[i];
                    }
                }

                return maxValue;
            }

            private int[] DeleteFromArray(int deleted, int[] array)
                => array.Where(val => val != deleted).ToArray();
        }

        /// <summary>
        /// Class that describe special comparer for incremention of min value in the array
        /// </summary>
        public class MinValueInRowIncComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method that compare two arrays by the incremention of min value in those arrays
            /// </summary>
            /// <param name="lhs">First array to compare</param>
            /// <param name="rhs">Second array to compare</param>
            /// <returns>Int value representing comparisson</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (ReferenceEquals(lhs, rhs))
                {
                    return 0;
                }

                if (lhs == null)
                {
                    return 1;
                }

                if (rhs == null)
                {
                    return -1;
                }

                int lhsMin = FindMin(lhs);
                int rhsMin = FindMin(rhs);                

                if (lhsMin == rhsMin)
                {
                    return Compare(DeleteFromArray(lhsMin, lhs), DeleteFromArray(rhsMin, rhs));
                }

                if (lhsMin < rhsMin)
                {
                    return -1;
                }

                return 1;
            }

            private int FindMin(int[] array)
            {
                int minValue = int.MaxValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < minValue && array[i] != int.MaxValue)
                    {
                        minValue = array[i];
                    }
                }

                return minValue;
            }

            private int[] DeleteFromArray(int deleted, int[] array)
                => array.Where(val => val != deleted).ToArray();
        }

        /// <summary>
        /// Class that describe special comparer for decremention of min value in the array
        /// </summary>
        public class MinValueInRowDecComparer : IComparer<int[]>
        {
            /// <summary>
            /// Method that compare two arrays by the decremention of min value in those arrays
            /// </summary>
            /// <param name="lhs">First array to compare</param>
            /// <param name="rhs">Second array to compare</param>
            /// <returns>Int value representing comparisson</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (ReferenceEquals(lhs, rhs))
                {
                    return 0;
                }

                if (lhs == null)
                {
                    return -1;
                }

                if (rhs == null)
                {
                    return 1;
                }

                int lhsMin = FindMin(lhs);
                int rhsMin = FindMin(rhs);                

                if (rhsMin == lhsMin)
                {
                    return Compare(DeleteFromArray(lhsMin, lhs), DeleteFromArray(rhsMin, rhs));
                }

                if (rhsMin < lhsMin)
                {
                    return -1;
                }

                return 1;
            }

            private int FindMin(int[] array)
            {
                int minValue = int.MaxValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < minValue && array[i] != int.MaxValue)
                    {
                        minValue = array[i];
                    }
                }

                return minValue;
            }

            private int[] DeleteFromArray(int deleted, int[] array)
                => array.Where(val => val != deleted).ToArray();
        }
    }
}
