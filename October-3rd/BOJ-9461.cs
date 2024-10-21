using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 9461 - 파도반 수열 https://www.acmicpc.net/problem/9461

namespace October_3rd
{
    internal class BOJ_9461
    {
        static long[] memo = new long[101]; // overflow when using int

        static void Main()
        {
            int testCaseCount = int.Parse(Console.ReadLine()!); // T

            for (int i = 0; i < testCaseCount; i++)
            {
                Solution();
            }
        }

        // P(1) ~ P(12)  : {1,1,1,2,2,3,4,5,7,9,12,16,21,28 ...}
        // 4(3+1) 5(4+1) 7(5+2) 9(7+2) 12(9+3)
        // P(N) = P(N-1) + P(N-5)
        // == P(N-2) + P(N-3)

        static void Solution()
        {
            int n = int.Parse(Console.ReadLine()!); // N ( 1<=N<=100)

            Console.WriteLine(CalculatePN(n));
        }

        static long CalculatePN(int n)
        {
            if(n<=3)
                return memo[n] = 1;
          

            if (memo[n] != 0)
                return memo[n];
            else //if (memo[n] == 0)
                return memo[n] = CalculatePN(n - 3) + CalculatePN(n - 2);
        }
    }
}
