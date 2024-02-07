using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 백준 2630 : 색종이 만들기 (https://www.acmicpc.net/problem/2630)
 * 입력
첫째 줄에는 전체 종이의 한 변의 길이 N이 주어져 있다. N은 2, 4, 8, 16, 32, 64, 128 중 하나이다.
색종이의 각 가로줄의 정사각형칸들의 색이 윗줄부터 차례로 둘째 줄부터 마지막 줄까지 주어진다.
하얀색으로 칠해진 칸은 0, 파란색으로 칠해진 칸은 1로 주어지며, 각 숫자 사이에는 빈칸이 하나씩 있다.

출력
첫째 줄에는 잘라진 햐얀색 색종이의 개수를 출력하고, 둘째 줄에는 파란색 색종이의 개수를 출력한다.

분할 정복 문제
 */

// 메모리 6296KB || 시간 68ms

namespace Week_02
{
    internal class BOJ_2630
    {
        static int white = 0; // 0이면 하양
        static int blue = 0; //1이면 파랑
        static int[,] paper;
        static void Main()
        {
            int size = int.Parse(Console.ReadLine()!);

            paper = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] input = Console.ReadLine()!.Split();
                for (int j = 0; j < size; j++)
                {
                    paper[i, j] = int.Parse(input[j]);
                }
            }
            Devide(0, 0, size);
            Console.WriteLine(white);
            Console.WriteLine(blue);
        }
        public static void Devide(int x, int y, int size)
        {
            if (size==1 ||IsAllColorMatched(x, y, size))
            {
                if (paper[x, y] == 0)
                {
                    white++;
                    return;
                }
                else if(paper[x, y]== 1)
                {
                    blue++;
                    return;
                }
            }
            int halfSize = size / 2;
            Devide(x, y, halfSize); //좌상단
            Devide(x, y + halfSize, halfSize); //우상단
            Devide(x + halfSize, y, halfSize); //좌하단
            Devide(x + halfSize, y + halfSize, halfSize); //우하단
        }

        public static bool IsAllColorMatched(int x, int y, int size)
        {
            int check = paper[x, y];
            //모두 돌아서 색이 같은지 아닌지 확인
            for (int i = x; i < x + size; i++)
            {
                for (int j = y; j < y + size; j++)
                {
                   if (paper[i, j] != check)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
