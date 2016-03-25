namespace CohesionAndCoupling
{
    using System;

    internal static class CubeSizeCalculator
    {
        public static double Width { get; set; }

        public static double Height { get; set; }

        public static double Depth { get; set; }

        public static double CalculateVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalculateDiagonalXYZ()
        {
            double diagonal = DistanceCalculator.CalculateDistance3D(0, 0, 0, Width, Height, Depth);
            return diagonal;
        }

        public static double CalculateDiagonalXY()
        {
            double diagonal = DistanceCalculator.CalculateDistance2D(0, 0, Width, Height);
            return diagonal;
        }

        public static double CalculateDiagonalXZ()
        {
            double diagonal = DistanceCalculator.CalculateDistance2D(0, 0, Width, Depth);
            return diagonal;
        }

        public static double CalculateDiagonalYZ()
        {
            double diagonal = DistanceCalculator.CalculateDistance2D(0, 0, Height, Depth);
            return diagonal;
        }
    }
}
