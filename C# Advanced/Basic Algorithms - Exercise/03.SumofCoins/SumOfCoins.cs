﻿using System;
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

        while (sum < targetSum)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                if (sum + coins[i] <= targetSum)
                {
                    sum += coins[i];
                    continue;
                }
            }
        }

        return Dictionary<sum , 3>;
    }
}