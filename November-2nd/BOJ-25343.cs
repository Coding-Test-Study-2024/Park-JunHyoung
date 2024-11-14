namespace November_2nd
{
    // LLIS  https://www.acmicpc.net/problem/25343


    internal class BOJ25343
    {
        static int N;

        static void Main()
        {
            N = int.Parse(Console.ReadLine()!);

            int[,] grid = new int[N, N];

            // Init grid 
            for(int i=0; i<N; i++)
            {
                string[] input = Console.ReadLine()!.Split();

                for(int j=0; j<N; j++)
                {
                    grid[i,j] = int.Parse(input[j]);
                }
            }

            // Init DP
            int[,] dp = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    dp[i, j] = 1;
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    // 왼쪽에서 오는 경우
                    if (j > 0)
                    {
                        if (grid[i, j - 1] < grid[i, j])
                        {
                            dp[i, j] = Math.Max(dp[i, j], dp[i, j - 1] + 1);
                        }
                        else
                        {
                            dp[i, j] = Math.Max(dp[i, j], dp[i, j - 1]);
                        }
                    }
                    // 위쪽에서 오는 경우
                    if (i > 0)
                    {
                        if (grid[i - 1, j] < grid[i, j])
                        {
                            dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j] + 1);
                        }
                        else
                        {
                            dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j]);
                        }
                    }
                }
            }

            Console.WriteLine();
            for (int  i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    Console.Write($"{ dp[i, j]} ");
                }Console.WriteLine();
            }

            Console.WriteLine(dp[N-1,N-1]);
        }
    }
}
