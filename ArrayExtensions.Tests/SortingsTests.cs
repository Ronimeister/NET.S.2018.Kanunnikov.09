using System;
using NUnit.Framework;

namespace ArrayExtensions.Tests
{
    [TestFixture]
    public class SortingsTests
    {
        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortByDefault(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr4, arr2, arr1, arr3 };

            actual.BubbleSort();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41, int.MaxValue }, new int[] { int.MinValue, int.MaxValue })]
        public void SortBySumArrayRowIncComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr4, arr2, arr1, arr3 };

            actual.BubbleSort(new Comparators.SumArrayRowIncComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortBySumArrayRowDecComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr3, arr1, arr2, arr4 };

            actual.BubbleSort(new Comparators.SumArrayRowDecComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortByMaxValueInRowIncComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr2, arr1, arr4, arr3 };

            actual.BubbleSort(new Comparators.MaxValueInRowIncComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortByMaxValueInRowDecComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr3, arr4, arr1, arr2 };

            actual.BubbleSort(new Comparators.MaxValueInRowDecComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortByMinValueInRowIncComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr4, arr3, arr2, arr1 };

            actual.BubbleSort(new Comparators.MinValueInRowIncComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void SortByMinValueInRowDecComparer(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr1, arr2, arr3, arr4 };

            actual.BubbleSort(new Comparators.MinValueInRowDecComparer());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase()]
        public void Sort_NullArray_ArgumentNullException()
        {
            int[][] array = null;
            Assert.Throws<ArgumentNullException>(() => array.BubbleSort());
        }

        [TestCase()]
        public void Sort_WithComparer_NullArray_ArgumentNullException()
        {
            int[][] array = null;
            Assert.Throws<ArgumentNullException>(() => array.BubbleSort(new Comparators.SumArrayRowIncComparer()));
        }

        [TestCase()]
        public void Sort_NullArray_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new int[0][].BubbleSort());

        [TestCase()]
        public void Sort_WithComparer_NullArray_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new int[0][].BubbleSort(new Comparators.SumArrayRowIncComparer()));

        [TestCase()]
        public void Sort_NullComparer_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new int[1][].BubbleSort(null));

        [TestCase()]
        public void Print_NullArray_ArgumentNullException()
        {
            int[][] array = null;
            Assert.Throws<ArgumentNullException>(() => array.Print());
        }

        [TestCase()]
        public void Print_NullArray_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new int[0][].Print());
    }
}
