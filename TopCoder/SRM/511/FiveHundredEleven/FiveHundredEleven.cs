using System;

public class FiveHundredEleven
{
    int recur(int mask, int steps, int[,] dp, int[] cards)
    {
        if (dp[mask, steps] != -1)
        {
            return dp[mask, steps];
        }
        if (steps == cards.Length)
        {
            dp[mask, steps] = 0;
            return 0;
        }
        int cnt = 0;
        for (int i = 0; i < cards.Length; ++ i)
        {
            int nextMask = mask | cards[i];
            if (nextMask == mask)
            {
                ++ cnt;
            }
            else if (nextMask != 511)
            {
                int ret = recur(mask | cards[i], steps + 1, dp, cards);
                if (ret == 0)
                {
                    dp[mask, steps] = 1;
                    return 1;
                }
            }
        }
        dp[mask, steps] = 0;
        if (steps < cnt)
        {
            int ret = recur(mask, steps + 1, dp, cards);
            if (ret == 0)
            {
                dp[mask, steps] = 1;
            }
        }
        return dp[mask, steps];
    }

    public String theWinner(int[] cards)
    {
        int n = cards.Length;
        int[,] dp = new int[512, n + 1];
        for (int i = 0; i < 512; ++ i)
        {
            for (int j = 0; j <= n; ++ j)
            {
                dp[i, j] = -1;
            }
        }
        int res = recur(0, 0, dp, cards);
        if (res == 1)
        {
            return "Fox Ciel";
        }
        return "Toastman";
    }

    static void Main()
    {
        FiveHundredEleven obj = new FiveHundredEleven();
        int[] cards = new int[]{3, 5, 7, 9, 510};
        Console.WriteLine(obj.theWinner(cards));
        cards = new int[]{0, 0, 0, 0};
        Console.WriteLine(obj.theWinner(cards));
        cards = new int[]{511};
        Console.WriteLine(obj.theWinner(cards));
        cards = new int[]{5, 58, 192, 256};
        Console.WriteLine(obj.theWinner(cards));
        cards = new int[]{0};
        Console.WriteLine(obj.theWinner(cards));
    }
}