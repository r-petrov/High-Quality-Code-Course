using System;
using System.Diagnostics;

internal class Assertions
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[2]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    //// public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    //// {
    ////     Debug.Assert(arr.Length > 0, "Array is not initialized.");

    ////     return BinarySearch(arr, value, 0, arr.Length - 1);
    //// }

    public static int BinarySearch<T>(T[] arr, T value)
        where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Array is not initialized.");
        bool isArraySorted = IsArraySorted(arr);
        Debug.Assert(isArraySorted, "Array is not sorted.");

        //// Debug.Assert((startIndex >= 0) && (startIndex <= arr.Length - 1), "Invalid start index.");
        //// Debug.Assert((startIndex <= endIndex) && (endIndex <= arr.Length - 1), "Invalid end index.");

        int currentIndex = 0;
        int endIndex = arr.Length - 1;

        while (currentIndex <= endIndex)
        {
            int midIndex = (currentIndex + endIndex) / 2;
            Debug.Assert((midIndex >= 0) && (midIndex < arr.Length), "Result index is out of array range.");
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                currentIndex = midIndex + 1;
            }
            else
            {
                // Search on the left half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Array is not initialized.");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        bool isArraySorted = IsArraySorted(arr);
        Debug.Assert(isArraySorted, "Array is not sorted.");
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr.Length > 0, "Array is not initialized.");
        Debug.Assert((startIndex >= 0) && (startIndex <= arr.Length - 1), "Invalid start index.");
        Debug.Assert((startIndex <= endIndex) && (endIndex <= arr.Length - 1), "Invalid end index.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        bool isMinElementIndex = IsMinElementIndex(arr, minElementIndex, startIndex);
        Debug.Assert(isMinElementIndex, "The result index is not the index of minimal element in the array.");

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static bool IsArraySorted<T>(T[] array) where T : IComparable<T>
    {
        bool isArraySorted = true;
        for (int index = 0; index < array.Length - 1; index++)
        {
            if (array[index].CompareTo(array[index + 1]) > 0)
            {
                isArraySorted = false;
                break;
            }
        }

        return isArraySorted;
    }

    // Checks if the element with inputed index is the minimal element in the inputed array
    private static bool IsMinElementIndex<T>(T[] array, int elementIndex, int startIndex) where T : IComparable<T>
    {
        bool isMinElementIndex = true;
        for (int index = startIndex; index < array.Length; index++)
        {
            if (array[elementIndex].CompareTo(array[index]) > 0)
            {
                isMinElementIndex = false;
                break;
            }
        }

        return isMinElementIndex;
    }
}
