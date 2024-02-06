using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

/* 백준 24460 : 특별상이라도 받고 싶어(https://www.acmicpc.net/problem/24460)
 */

// 메모리 24056 KB	|   시간 356 ms
// 
namespace Week_02
{
    internal class BOJ_24460
    {
        static int N;
        static int[,] array;

        static void Main(string[] args)
        {
            GetInput();
            Console.WriteLine(Solve(0,0,N));
        }

        static void GetInput()
        {
            N = int.Parse(Console.ReadLine()!);
            array = new int[N, N];
            for(int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine()!.Split();
                for (int j = 0; j < N; j++)
                {
                    array[i,j] = int.Parse(input[j]); 
                }
            }
        }

        static int Solve(int x, int y, int size)
        {
            if (size == 1)
            {
                return array[x,y];
            }
            int halfSize = size / 2;
            int[] temp = new int[4];
            for(int i=0; i<4; i++)
            {
                temp[i] = Solve(x+(i%2)*halfSize, y+(i/2)*halfSize, halfSize);//좌상단, 우상단, 좌하단, 우하단 으로 나눠서 재귀
            }
            Array.Sort(temp); 
            return temp[1]; //정렬 후 두번째꺼 반환
        }
    }
}
