// 백준 11047 - 동전 0  https://www.acmicpc.net/problem/11047

namespace October_3rd
{
    internal class BOJ_11047
    {
        static void Main()
        {
            string[] input = Console.ReadLine()!.Split();

            
            int coinTypeCount = int.Parse(input[0]); // N (1<= N <= 10)
            int sumOfCoinValues = int.Parse(input[1]); // K (1<= K <= 100,000,000)

            List<int> coins = new List<int>();
            for(int i = 0; i < coinTypeCount; i++)
            {
                coins.Add(int.Parse(Console.ReadLine()!));
            }

            Console.WriteLine(Solution(coins, sumOfCoinValues));
        }
        /// <summary>
        /// 동전개수의 최소값 출력
        /// </summary>
        /// <param name="cointTypeCount"></param>
        /// <param name="sumOfCoinValues"></param>
        /// <returns></returns>
        static int Solution(List<int> coins, int sumOfCoinValues)
        {
            int usedCoinCount = 0;
            coins.Reverse(); // 큰거부터 순회 돌도록 Reverse()

            foreach(int coin in coins){
                if(sumOfCoinValues >= coin)
                {
                    usedCoinCount += sumOfCoinValues / coin;
                    sumOfCoinValues %= coin;
                }
            }
            
            return usedCoinCount;
        }

    }
}
