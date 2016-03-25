using System;

namespace ConsoleApplication1
{
    public class MatrixMultiplication
    {
        public static void Main(string[] args)
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var resultMatrix = MultiplyMatrices(firstMatrix, secondMatrix);

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    Console.Write(resultMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static double[,] MultiplyMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var firstMatrixColumnsCount = firstMatrix.GetLength(1);
            var resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (int row = 0; row < resultMatrix.GetLength(0); row++) 
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    for (int equalDimensionsIndex = 0;
                        equalDimensionsIndex < firstMatrixColumnsCount;
                        equalDimensionsIndex++)
                    {
                        resultMatrix[row, col] += firstMatrix[row, equalDimensionsIndex] * secondMatrix[equalDimensionsIndex, col];
                    }
                }
            }

            return resultMatrix;
        }
    }
}