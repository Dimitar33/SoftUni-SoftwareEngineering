using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(int[] coins, int targetSum)
    {
        int sum = 0;
        Dictionary<int, int> change = new Dictionary<int, int>();


        for (int i = coins.Length - 1; i >= 0; i--)        
        {
            while (sum + coins[i] <= targetSum)
            {
                sum += coins[i];

                if (!change.ContainsKey(coins[i]))
                {
                    change.Add(coins[i], 0);
                }
                change[coins[i]]++;
            }

        }


        return change;
    }
}