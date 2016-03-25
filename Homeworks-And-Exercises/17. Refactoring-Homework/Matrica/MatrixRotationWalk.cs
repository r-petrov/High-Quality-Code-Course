namespace RotatingWalkInMatrix
{
    using System;

    public class MatrixRotationWalk
    {
        static void change(ref int dx, ref int dy)
        {
            int[] dirX =
            {
                1, 1, 1, 0, -1, -1, -1, 0
            };

            int[] dirY =
            {
                1, 0, -1, -1, -1, 0, 1, 1
            };

            int cd = 0;
            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count;

                    break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0];
                dy = dirY[0];

                return;
            }

            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }

        static bool CheckIsNextMatrixCellEmpty(int[,] matrix, int matrixCurrentRow, int matrixCurrentCol)
        {
            int[] nextMatrixRowStepsClockwise =
            {
                1, 1, 1, 0, -1, -1, -1, 0
            };

            int[] nextMatrixColStepsClockwise =
            {
                1, 0, -1, -1, -1, 0, 1, 1
            };

            for (int i = 0; i < 8; i++)
            {
                if (matrixCurrentRow + nextMatrixRowStepsClockwise[i] >= matrix.GetLength(0) || matrixCurrentRow + nextMatrixRowStepsClockwise[i] < 0)
                {
                    nextMatrixRowStepsClockwise[i] = 0;
                }

                if (matrixCurrentCol + nextMatrixColStepsClockwise[i] >= matrix.GetLength(0) || matrixCurrentCol + nextMatrixColStepsClockwise[i] < 0)
                {
                    nextMatrixColStepsClockwise[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                var matrixNextRow = matrixCurrentRow + nextMatrixRowStepsClockwise[i];
                var matrixNextCol = matrixCurrentCol + nextMatrixColStepsClockwise[i];
                if (matrix[matrixNextRow, matrixNextCol] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void find_cell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;

                        return;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            // Console.WriteLine( "Enter a positive number " );
            // string input = Console.ReadLine(  );
            // int n = 0;
            // while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            // {
            //     Console.WriteLine( "You haven't entered a correct positive number" );
            //     input = Console.ReadLine(  );
            // }
            int matrixSize = 3;
            int[,] matrix = new int[matrixSize, matrixSize];
            int initialCellValue = 1;
            int matrixCurrentRow = 0;
            int matrixCurrentCol = 0;
            int nextRowStep = 1;
            int nextColStep = 1;

            while (true)
            { 
                // malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[matrixCurrentRow, matrixCurrentCol] = initialCellValue;
                if (!CheckIsNextMatrixCellEmpty(matrix, matrixCurrentRow, matrixCurrentCol))
                {
                    break; // prekusvame ako sme se zadunili
                }

                var isOutsideMatrixRowsRange = (matrixCurrentRow + nextRowStep >= matrixSize) || (matrixCurrentRow + nextRowStep < 0);
                var isOutsideMatrixColsRange = (matrixCurrentCol + nextColStep >= matrixSize) || (matrixCurrentCol + nextColStep < 0);
                var isOutsideMatrix = isOutsideMatrixRowsRange || isOutsideMatrixColsRange;
                if (isOutsideMatrix || matrix[matrixCurrentRow + nextRowStep, matrixCurrentCol + nextColStep] != 0)
                {
                    while (matrixCurrentRow + nextRowStep >= matrixSize || matrixCurrentRow + nextRowStep < 0 || matrixCurrentCol + nextColStep >= matrixSize || matrixCurrentCol + nextColStep < 0 || matrix[matrixCurrentRow + nextRowStep, matrixCurrentCol + nextColStep] != 0)
                    {
                        change(ref nextRowStep, ref nextColStep);
                    }
                }

                matrixCurrentRow += nextRowStep;
                matrixCurrentCol += nextColStep;
                initialCellValue++;
            }

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }

            find_cell(matrix, out matrixCurrentRow, out matrixCurrentCol);

            if (matrixCurrentRow != 0 && matrixCurrentCol != 0)
            {
                // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                nextRowStep = 1;
                nextColStep = 1;
                while (true)
                {
                    // malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[matrixCurrentRow, matrixCurrentCol] = initialCellValue;
                    if (!CheckIsNextMatrixCellEmpty(matrix, matrixCurrentRow, matrixCurrentCol))
                    {
                        break; // prekusvame ako sme se zadunili
                    }

                    if (matrixCurrentRow + nextRowStep >= matrixSize || matrixCurrentRow + nextRowStep < 0 || matrixCurrentCol + nextColStep >= matrixSize || matrixCurrentCol + nextColStep < 0 || matrix[matrixCurrentRow + nextRowStep, matrixCurrentCol + nextColStep] != 0)
                    {
                        while (matrixCurrentRow + nextRowStep >= matrixSize || matrixCurrentRow + nextRowStep < 0 || matrixCurrentCol + nextColStep >= matrixSize || matrixCurrentCol + nextColStep < 0 || matrix[matrixCurrentRow + nextRowStep, matrixCurrentCol + nextColStep] != 0)
                        {
                            change(ref nextRowStep, ref nextColStep);
                        }
                    }

                    matrixCurrentRow += nextRowStep;
                    matrixCurrentCol += nextColStep;
                    initialCellValue++;
                }
            }

            for (int pp = 0; pp < matrixSize; pp++)
            {
                for (int qq = 0; qq < matrixSize; qq++)
                {
                    Console.Write("{0,3}", matrix[pp, qq]);
                }

                Console.WriteLine();
            }
        }
    }
}
