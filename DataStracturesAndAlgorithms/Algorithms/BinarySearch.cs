namespace Algorithms;

public class BinarySearch
{
    public static int Search(int[] array, int goal)
    {
        if (array == null || array.Length == 0) return -1;

        var low = 0;
        var high = array.Length - 1;
        
        while (low <= high)
        {
            var mid = (low + high) / 2;
            var guess = array[mid];
            if(guess == goal) return mid;
            if(guess > goal) high = mid - 1;
            else low = mid + 1;

        }
        return -1;
    }
}
