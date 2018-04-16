using System;
using Matrix;
using Matrix.Extentions;
using NUnit.Framework;

namespace MatrixTests.NUnitTests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void MatrixAdd_Square_Matrix()
        {
            int[,] matrixIn1 =
            {
                { 1, 3, 5, 7 },
                { 3, 5, 7, 9 }, 
                { 5, 7, 9, 11 },
                { 7, 9, 11, 13 }
            };

            int[,] matrixIn2 =
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };

            var matrix1 = new SquareMatrix<int>(matrixIn1);
            var matrix2 = new SquareMatrix<int>(matrixIn2);
            Func<int, int, int> addFunc = (x1, x2) => x1 + x2;

            var sumMatrix = matrix1.Add(matrix2, addFunc);

            for (int i = 0; i < sumMatrix.Size; i++)
            {
                for (int j = 0; j < sumMatrix.Size; j++)
                {
                    Assert.AreEqual(sumMatrix[i, j], matrix1[i, j]);
                }
            }
        }

        [Test]
        public void MatrixAdd_Simmetrical_Matrix()
        {
            int[,] matrixIn1 =
            {
                { 1, 3, 5, 7 },
                { 3, 5, 7, 9 },
                { 5, 7, 9, 11 },
                { 7, 9, 11, 13 }
            };

            int[,] matrixIn2 =
            {
                { 1, 3, 5, 7 },
                { 3, 5, 7, 9 },
                { 5, 7, 9, 11 },
                { 7, 9, 11, 13 }
            };

            int[,] result =
            {
                { 2, 6, 10, 14 },
                { 6, 10, 14, 18 },
                { 10, 14, 18, 22 },
                { 14, 18, 22, 26 }
            };

            var matrix1 = new SimmetricalMatrix<int>(matrixIn1);
            var matrix2 = new SimmetricalMatrix<int>(matrixIn2);
            Func<int, int, int> addFunc = (x1, x2) => x1 + x2;

            var sumMatrix = matrix1.Add(matrix2, addFunc);

            for (int i = 0; i < sumMatrix.Size; i++)
            {
                for (int j = 0; j < sumMatrix.Size; j++)
                {
                    Assert.AreEqual(sumMatrix[i, j], result[i, j]);
                }
            }
        }

        [Test]
        public void MatrixAdd_Diagonal_Matrix()
        {
            int[,] matrixIn1 =
            {
                { 1, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 0, 3, 0 },
                { 0, 0, 0, 4 }
            };

            int[,] matrixIn2 =
            {
                { 1, 0, 0, 0 },
                { 0, 2, 0, 0 },
                { 0, 0, 3, 0 },
                { 0, 0, 0, 4 }
            };

            int[,] result =
            {
                { 2, 0, 0, 0 },
                { 0, 4, 0, 0 },
                { 0, 0, 6, 0 },
                { 0, 0, 0, 8 }
            };

            var matrix1 = new DiagonalMatrix<int>(matrixIn1);
            var matrix2 = new DiagonalMatrix<int>(matrixIn2);
            Func<int, int, int> addFunc = (x1, x2) => x1 + x2;

            var sumMatrix = matrix1.Add(matrix2, addFunc);

            for (int i = 0; i < sumMatrix.Size; i++)
            {
                for (int j = 0; j < sumMatrix.Size; j++)
                {
                    Assert.AreEqual(sumMatrix[i, j], result[i, j]);
                }
            }
        }
    }
}
