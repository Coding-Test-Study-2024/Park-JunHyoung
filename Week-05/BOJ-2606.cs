using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 백준 2606 : 바이러스 (https://www.acmicpc.net/problem/2606)
 
메모리 	 5940KB  | 시간	 68ms
 */

namespace Week_05
{
    internal class BOJ_2606
    {
        static int N;
        static int M;

        static int count;

        static public int[,] map = new int[101, 101];
        static public bool[] visited = new bool[101];

        static public Queue<int> queue = new Queue<int>();


        static void Main1(string[] args)
        {
            N = int.Parse(Console.ReadLine()!);
            M = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < M; i++)
            {
                string[] input = Console.ReadLine()!.Split();
                int x= int.Parse(input[0]);
                int y= int.Parse(input[1]);
                map[x,y] = 1;
                map[y,x] = 1;
            }

            initalize();
            BFS();
            Console.WriteLine(count - 1);
        }

        static void initalize()
        {
            for (int i = 1; i <= N; i++)
            {
                visited[i] = false;
            }
        }

        static void BFS()
        {
            queue.Enqueue(1);
            visited[1] = true;

            int start;

            while (queue.Count != 0)
            {
                start = queue.Dequeue();
                count++;
                for (int i = 1; i <= N; i++)
                {
                    if (map[start, i] == 1 && visited[i] == false)
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }
    }
}
