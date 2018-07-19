using System;
using NUnit.Framework;
using static ArrayExtensions.Tests.Comparators;

namespace ArrayExtensions.Tests
{
    [TestFixture]
    public class SortingsTests
    {
        #region SumArrayRowIncComparer tests
        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void ComparerSort_SumArrayRowIncComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr4, arr2, arr1, arr3 };

            actual.BubbleSort(new SumArrayRowIncComparer());

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void DelegateSort_SumArrayRowIncComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr4, arr2, arr1, arr3 };

            int Comparison(int[] lhs, int[] rhs) => new SumArrayRowIncComparer().Compare(lhs, rhs);

            actual.BubbleSort(Comparison);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region SumArrayRowDecComparer tests
        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void ComparerSort_SumArrayRowDecComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr3, arr1, arr2, arr4 };

            actual.BubbleSort(new SumArrayRowDecComparer());

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void DelegateSort_SumArrayRowDecComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr3, arr1, arr2, arr4 };

            int Comparison(int[] lhs, int[] rhs) => new SumArrayRowDecComparer().Compare(lhs, rhs);

            actual.BubbleSort(Comparison);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region MaxValueInRowIncComparer tests
        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void ComparerSort_MaxValueInRowIncComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr2, arr1, arr4, arr3 };

            actual.BubbleSort(new MaxValueInRowIncComparer());

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void DelegateSort_MaxValueInRowIncComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr2, arr1, arr4, arr3 };

            int Comparison(int[] lhs, int[] rhs) => new MaxValueInRowIncComparer().Compare(lhs, rhs);

            actual.BubbleSort(Comparison);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region MaxValueInRowDecComparer tests
        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void ComparerSort_MaxValueInRowDecComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr3, arr4, arr1, arr2 };

            actual.BubbleSort(new MaxValueInRowDecComparer());

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void DelegateSort_MaxValueInRowDecComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr3, arr4, arr1, arr2 };

            int Comparison(int[] lhs, int[] rhs) => new MaxValueInRowDecComparer().Compare(lhs, rhs);

            actual.BubbleSort(Comparison);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region MinValueInRowIncComparer tests
        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void ComparerSort_MinValueInRowIncComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr4, arr3, arr2, arr1 };

            actual.BubbleSort(new MinValueInRowIncComparer());

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void DelegateSort_MinValueInRowIncComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr4, arr3, arr2, arr1 };

            int Comparison(int[] lhs, int[] rhs) => new MinValueInRowIncComparer().Compare(lhs, rhs);

            actual.BubbleSort(Comparison);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region MinValueInRowDecComparer tests
        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void ComparerSort_MinValueInRowDecComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr1, arr2, arr3, arr4 };

            actual.BubbleSort(new MinValueInRowDecComparer());

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 35, 74, 67, 512 }, new int[] { 0, -6, 7 }, new int[] { int.MaxValue, -20, -41 }, new int[] { int.MinValue, int.MaxValue })]
        public void DelegateSort_MinValueInRowDecComparer_IsCorrect(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            int[][] actual = { arr1, arr2, arr3, arr4 };

            int[][] expected = { arr1, arr2, arr3, arr4 };

            int Comparison(int[] lhs, int[] rhs) => new MinValueInRowDecComparer().Compare(lhs, rhs);

            actual.BubbleSort(Comparison);

            CollectionAssert.AreEqual(expected, actual);
        }
        #endregion

        #region Exceptions tests
        [Test]
        public void ComparerSort_NullArray_ArgumentNullException()
        {
            int[][] array = null;
            Assert.Throws<ArgumentNullException>(() => array.BubbleSort(new SumArrayRowIncComparer()));
        }

        [Test]
        public void DelegateSort_NullArray_ArgumentNullException()
        {
            int[][] array = null;
            int Comparison(int[] lhs, int[] rhs) => new SumArrayRowIncComparer().Compare(lhs, rhs);
            Assert.Throws<ArgumentNullException>(() => array.BubbleSort(Comparison));
        }

        [Test]
        public void ComparerSort_NullArray_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new int[0][].BubbleSort(new SumArrayRowIncComparer()));

        [Test]
        public void DelegateSort_NullArray_ArgumentException()
        {
            int Comparison(int[] lhs, int[] rhs) => new SumArrayRowIncComparer().Compare(lhs, rhs);
            Assert.Throws<ArgumentException>(() => new int[0][].BubbleSort(new SumArrayRowIncComparer()));
        }

        [Test]
        public void Sort_NullComparer_ArgumentNullException()
        {
            SumArrayRowIncComparer comparer = null;
            Assert.Throws<ArgumentNullException>(() => new int[1][].BubbleSort(comparer));
        }
        #endregion
    }
}
