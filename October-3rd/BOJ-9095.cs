using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 9095 - 1,2,3 더하기 https://www.acmicpc.net/problem/9095

//정수 n이 주어졌을 때, n을 1,2,3의 합으로 나타내는 방법의 수 구하기. 

namespace October_3rd
{
    internal class BOJ_9095
    {
        static void Main()
        {
            int testCaseCount = int.Parse(Console.ReadLine()!);  // T

            for(int i = 0; i < testCaseCount; i++)
            {
                int n = int.Parse(Console.ReadLine()!);
                Console.WriteLine(Solution(n));
            }

        }

        // 1 : 1
        // 2 : 2
        // 3 : 4 (1+1+1, 2+1, 1+2, 3)
        // 4 : 7 (case 1 + case 2+ case 3)
        // 5 : 13
        // 6 : 24 
        // 7 : 44 

        static int[] memo = new int[11];

        static int Solution(int n)
        {
            switch (n) {
                case 1:
                    memo[1] = 1;
                    return memo[1];
                case 2:
                    memo[2]= 2;
                    return memo[2];
                case 3:
                    memo[3] = 4;
                    return memo[3];
            }
            return memo[n] = Solution(n-1) + Solution(n-2) + Solution(n-3);
        }

    }
}
