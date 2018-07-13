using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ArrayExtensions;

namespace ArrayExtensions.Tests
{
    [TestFixture]
    public class SortingsTests
    {
        [TestCase(new int[] { 35, 74, 67, 512 }, null, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] {  int.MinValue, int.MaxValue })]
        public void SortByDefault(int[] arr1, int[] arr2, int[] arr3, int[] arr4, int[] arr5)
        {
            int[][] actual = new int[5][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;
            actual[4] = arr5;

            int[][] expected = new int[5][];
            expected[0] = arr5;
            expected[1] = arr3;
            expected[2] = arr1;
            expected[3] = arr4;
            expected[4] = arr2;

            actual.BubbleSort();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, null, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] {  int.MinValue, int.MaxValue })]
        public void SortBySumArrayRowIncComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4, int[] arr5)
        {
            int[][] actual = new int[5][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;
            actual[4] = arr5;

            int[][] expected = new int[5][];
            expected[0] = arr5;
            expected[1] = arr3;
            expected[2] = arr1;
            expected[3] = arr4;
            expected[4] = arr2;

            actual.BubbleSort(new Comparators.SumArrayRowIncComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, null, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortBySumArrayRowDecComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4, int[] arr5)
        {
            int[][] actual = new int[5][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;
            actual[4] = arr5;

            int[][] expected = new int[5][];
            expected[0] = arr2;
            expected[1] = arr4;
            expected[2] = arr1;
            expected[3] = arr3;
            expected[4] = arr5;

            actual.BubbleSort(new Comparators.SumArrayRowDecComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, null, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortByMaxValueInRowIncComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4, int[] arr5)
        {
            int[][] actual = new int[5][];
            actual[0] = arr1;
            actual[1] = arr2;
            actual[2] = arr3;
            actual[3] = arr4;
            actual[4] = arr5;

            int[][] expected = new int[5][];
            expected[0] = arr3;
            expected[1] = arr1;
            expected[2] = arr4;
            expected[3] = arr5;
            expected[4] = arr2;

            actual.BubbleSort(new Comparators.MaxValueInRowIncComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, null, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortByMaxValueInRowDecComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4, int[] arr5)
        {
            int[][] actual = { arr1, arr2, arr3, arr4, arr5 };

            int[][] expected = { arr2, arr4, arr5, arr1, arr3 };

            actual.BubbleSort(new Comparators.MaxValueInRowDecComparer());
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
