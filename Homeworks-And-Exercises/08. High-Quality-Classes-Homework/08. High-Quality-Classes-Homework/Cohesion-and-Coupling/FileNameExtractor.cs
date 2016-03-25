namespace CohesionAndCoupling
{
    using System;

    internal static class FileNameExtractor
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                //throw new IndexOutOfRangeException("File name extension cannot have negative starting index.");

                return string.Empty;
            }
            else
            {
                string extension = fileName.Substring(indexOfLastDot + 1);
                return extension;
            }
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }
            else
            {
                string name = fileName.Substring(0, indexOfLastDot);
                return name;
            }
        }
    }
}
