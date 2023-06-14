namespace Algorithms;

public class Recursive
{
    public static void CountDown(int number)
    {
        if(number < 0)
            return;
        Console.WriteLine(number);
        CountDown(number - 1);
    }
    public static int Fact(int number)
    {
        if (number == 0)
            return 1;
        return number * Fact(number - 1);
    }
}
