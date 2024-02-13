using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 백준 1780 : 종이의 개수(https://www.acmicpc.net/problem/1780)
 */


namespace Week_03
{
    internal class BOJ_1780
    {

        static int numOfMinusOne = 0; // 0이면 하양
        static int numOfZero = 0; //1이면 파랑
        static int numOfPlusOne = 0;
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
            Divide(0, 0, size);
            Console.WriteLine(numOfMinusOne);
            Console.WriteLine(numOfZero);
            Console.WriteLine(numOfPlusOne);
        }
        public static void Divide(int x, int y, int size)
        {
            if (size == 1 || IsAllColorMatched(x, y, size))
            {
                if (paper[x, y] == -1)
                {
                    numOfMinusOne++;
                    return;
                }
                else if (paper[x, y] == 0)
                {
                    numOfZero++;
                    return;
                }
                else
                {
                    numOfPlusOne++;
                    return;
                }
            }
            int newSize = size / 3;
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++) {
                    Divide(x + newSize * i, y + newSize * j, newSize);
                }
            }
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
