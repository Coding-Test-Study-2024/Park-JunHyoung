using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//백준 1049 : 기타줄(https://www.acmicpc.net/problem/1049)
namespace Week_06
{
    internal class BOJ_1049
    {
        static int N, M; //N: 필요한 최소 기타줄의 갯수, M:기타줄 브랜드의 갯수
        static int[] pakagePrice, singlePrice; //패키지에는 기타줄 6개 
        static void Main()
        {
            GetInput();
            Solve();
        }

        static void GetInput()
        {
            string[] input = Console.ReadLine()!.Split();

            N = int.Parse(input[0]); M = int.Parse(input[1]);


            pakagePrice = new int[M];
            singlePrice = new int[M];

            for(int i = 0; i < M; i++)
            {
                input = Console.ReadLine()!.Split();

                pakagePrice[i] = int.Parse(input[0]);
                singlePrice[i] = int.Parse(input[1]);  
            }
        }

        static void Solve()
        {
            int answer =0;
            Array.Sort(pakagePrice);
            Array.Sort(singlePrice);

            int cheapestPackage = pakagePrice[0];
            int cheapestSingle = singlePrice[0];

           if(cheapestSingle *6 > cheapestPackage) // 패키지가 낱개보다 싼 경우
            {
                if(cheapestPackage < (N%6)*cheapestSingle) // 패키지로 산 다음 낱개로 사는게 더 비싼지 싼지
                { 
                    answer = (N / 6) * cheapestPackage + cheapestPackage;
                }
                else
                {
                    answer = (N/6) * cheapestPackage + (N%6)*cheapestSingle; 
                }
            }
            else // 낱개가 더 싼 경우
            {
                answer = N * cheapestSingle;
            }
            Console.WriteLine(answer);
        }
    }
}
