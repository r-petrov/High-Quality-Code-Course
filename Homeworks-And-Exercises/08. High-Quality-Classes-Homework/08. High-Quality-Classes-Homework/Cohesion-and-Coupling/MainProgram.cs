namespace CohesionAndCoupling
{
    using System;

    internal class MainProgram
    {
        internal static void Main()
        {
            try
            {
                Console.WriteLine(FileNameExtractor.GetFileExtension("example"));
                Console.WriteLine(FileNameExtractor.GetFileExtension("example.pdf"));
                Console.WriteLine(FileNameExtractor.GetFileExtension("example.new.pdf"));

                Console.WriteLine(FileNameExtractor.GetFileNameWithoutExtension("example"));
                Console.WriteLine(FileNameExtractor.GetFileNameWithoutExtension("example.pdf"));
                Console.WriteLine(FileNameExtractor.GetFileNameWithoutExtension("example.new.pdf"));

                Console.WriteLine("Distance in the 2D space = {0:f2}", DistanceCalculator.CalculateDistance2D(1, -2, 3, 4));
                Console.WriteLine("Distance in the 3D space = {0:f2}", DistanceCalculator.CalculateDistance3D(5, 2, -1, 3, -6, 4));

                CubeSizeCalculator.Width = 3;
                CubeSizeCalculator.Height = 4;
                CubeSizeCalculator.Depth = 5;
                Console.WriteLine("Volume = {0:f2}", CubeSizeCalculator.CalculateVolume());
                Console.WriteLine("Diagonal XYZ = {0:f2}", CubeSizeCalculator.CalculateDiagonalXYZ());
                Console.WriteLine("Diagonal XY = {0:f2}", CubeSizeCalculator.CalculateDiagonalXY());
                Console.WriteLine("Diagonal XZ = {0:f2}", CubeSizeCalculator.CalculateDiagonalXZ());
                Console.WriteLine("Diagonal YZ = {0:f2}", CubeSizeCalculator.CalculateDiagonalYZ());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
