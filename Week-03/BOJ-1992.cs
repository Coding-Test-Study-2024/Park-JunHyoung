using System.Buffers;
using System.Drawing;
using System.Text;

/* 백준 1992 : 쿼드트리 (https://www.acmicpc.net/problem/1992)
 
메모리 	5740KB  | 시간	68ms
 */

namespace Week_03
{
    internal class BOJ_1992
    {
        static int[,] image;
        static StringBuilder sb = new StringBuilder();

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            image = new int[N,N];

            for (int i = 0; i < N; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < N; j++)
                {
                    image[i, j] = int.Parse(input[j].ToString());
                }
            }
            QuadTree(0, 0, N);
            Console.WriteLine(sb.ToString());
        }

        static void QuadTree(int x, int y, int size)
        {
            if (IsAllMatched(x,y,size))
            {
                sb.Append(image[x, y]);
                return;
            }

            int halfSize = size / 2;
            sb.Append('(');
            QuadTree(x, y, halfSize); //좌상단
            QuadTree(x, y + halfSize, halfSize); //우상단
            QuadTree(x + halfSize, y, halfSize); //좌하단
            QuadTree(x + halfSize, y + halfSize, halfSize); //우하단
            sb.Append(')');
        }

        static bool IsAllMatched(int x, int y, int size)
        {
            int check = image[x, y];
            //모두 돌아서 색이 같은지 아닌지 확인
            for (int i = x; i < x + size; i++)
            {
                for (int j = y; j < y + size; j++)
                {
                    if (image[i, j] != check)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}