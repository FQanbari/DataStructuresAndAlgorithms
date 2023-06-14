namespace Algorithms;

public class SelectionSort
{
    public static int[] Sort(int[] array)
    {
        var newArray = new int[array.Length];
        for (int i = 0; i < newArray.Length; i++)
        {
            var smallest = FindSmallestIndex(array);
            newArray[i] = array[smallest];
            array = array.Where((val, idx) => idx != smallest).ToArray();
        }

        return newArray;
    }
    private static int FindSmallestIndex(int[] array)
    {
        var smallest = array[0];
        var smallestIndex = 0;
        for (int i= 0; i < array.Length; i++)
        {
            if (array[i] < smallest)
            {
                smallest = array[i];
                smallestIndex = i;
            }
        }

        return smallestIndex;
    }
}
