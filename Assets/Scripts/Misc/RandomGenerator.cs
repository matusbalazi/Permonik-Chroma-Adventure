using System;

public class RandomNumberGenerator
{
    private static readonly Random random = new Random();

    public static bool GetRandomBoolean(int successProbability)
    {
        int randomNumber = random.Next(1, 101);
        return randomNumber <= successProbability;
    }

    public static int GetRandomInt()
        => random.Next(1, 101);
}
