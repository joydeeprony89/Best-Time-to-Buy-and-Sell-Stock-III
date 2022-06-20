using System;

namespace Best_Time_to_Buy_and_Sell_Stock_III
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      // [3,3,5,0,0,3,1,4]
    }
  }

  public class Solution
  {
    public int MaxProfit(int[] prices)
    {
      // This problem is similar to Best Time to Buy and Sell Stock - with max one transaction
      // Here we are allowed to do 2 transactions
      // Example - from the first transaction I made profit of 7. So actually which I have invested to buy the first stock, I have got it(principle amount) and I made profit of 7 as well.
      // I have 7rs profit from trans 1, which I would be using in my second transaction
      // now we have two scenarios - 

      // Scenario - 1 = If I buy next stock below 7 say at 3, so I left with (7 - 3) = 4 rs from my previous profit, till now I have not put any money from my pocket for second transaction.
      // after spending 3 rs I am in profit of 4 still.
      // Now question had asked us to sell and make another profit from the second transaction
      // Example - now selling price is 10, so my profit again from 2nd transaction is = 10 entirely because I have not put money from my pocket instead I have used money from the 1st transaction profit which was 3 rs.
      // My total profit from both transaction is = (10 + 4) = 14

      // Scenario - 2 =  If I buy next stock at 12 rs, so this time I have to put money from my pocket for second transaction, which is of (12 - 7) = 5
      // So till now my expenditure is 5 including first trans.
      // Example - now selling price is 15, so my profit again from 2nd transaction is = (15 - 5) = 10
      // My total profit from both transaction is = (7(trans1 profit) + 15 - 12 (2nd trans bought cost)) = 7 + 3 = 10

      int minBuyShareOnePrice = int.MaxValue;
      int maxShareOneProfitAfterSelling = 0;
      int minBuyShareTwoPrice = int.MaxValue;
      int maxShareTwoProfitAfterSelling = 0;
      for (int i = 0; i < prices.Length; i++)
      {
        int currentPrice = prices[i];
        minBuyShareOnePrice = Math.Min(minBuyShareOnePrice, currentPrice); // Minimize 1st transaction buying cost.
        maxShareOneProfitAfterSelling = Math.Max(maxShareOneProfitAfterSelling, currentPrice - minBuyShareOnePrice); // Update the max profit for 1st transaction

        // will be investing our 1st profit now to buy second stock.
        // minimize second transaction buying cost, we are already in profit from 1st transaction
        minBuyShareTwoPrice = Math.Min(minBuyShareTwoPrice, currentPrice - maxShareOneProfitAfterSelling);

        maxShareTwoProfitAfterSelling = Math.Max(maxShareTwoProfitAfterSelling, currentPrice - minBuyShareTwoPrice);
      }

      return maxShareTwoProfitAfterSelling;
    }
  }
}
