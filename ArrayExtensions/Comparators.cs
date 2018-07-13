using System.Collections.Generic;
using System.Linq;

namespace ArrayExtensions
{
    public class Comparators
    {
        public class SumArrayRowIncComparer : IComparer<int[]>
        {
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

                return lhs.Sum() - rhs.Sum();
            }
        }

        public class SumArrayRowDecComparer : IComparer<int[]>
        {
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

                return rhs.Sum() - lhs.Sum();
            }
        }

        public class MaxValueInRowIncComparer : IComparer<int[]>
        {
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

                return FindMax(lhs) - FindMax(rhs);
            }

            private int FindMax(int[] array)
            {
                int maxValue = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if(array[i] > maxValue)
                    {
                        maxValue = array[i];
                    }
                }

                return maxValue;
            }
        }

        public class MaxValueInRowDecComparer : IComparer<int[]>
        {
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

                return FindMax(rhs) - FindMax(lhs);
            }

            private int FindMax(int[] array)
            {
                int maxValue = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > maxValue)
                    {
                        maxValue = array[i];
                    }
                }

                return maxValue;
            }
        }

        public class MinValueInRowIncComparer : IComparer<int[]>
        {
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

                return FindMin(lhs) - FindMin(rhs);
            }

            private int FindMin(int[] array)
            {
                int minValue = int.MaxValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < minValue)
                    {
                        minValue = array[i];
                    }
                }

                return minValue;
            }
        }

        public class MinValueInRowDecComparer : IComparer<int[]>
        {
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

                return FindMin(rhs) - FindMin(lhs);
            }

            private int FindMin(int[] array)
            {
                int minValue = int.MaxValue;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < minValue)
                    {
                        minValue = array[i];
                    }
                }

                return minValue;
            }
        }
    }
}
