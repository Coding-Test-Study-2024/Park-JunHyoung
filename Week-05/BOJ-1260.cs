using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 백준 1260 : DFS와 BFS (https://www.acmicpc.net/problem/1260)
 
 */
namespace Week_05
{
    internal class BOJ_1260
    {
        static int N, M, V;
        static bool[,] map;
        static bool[] visited;

        static void Main1()
        {
            string[] inputNMV = Console.ReadLine()!.Split();
            N = int.Parse(inputNMV[0]);
            M = int.Parse(inputNMV[1]);
            V = int.Parse(inputNMV[2]);

            map = new bool[N, N];
            visited = new bool[N];

            for(int i=0; i<M ; i++) {
                string[] input = Console.ReadLine()!.Split();
                int x = int.Parse(input[0]);
                int y = int.Parse(input[1]);

                map[x,y] = true;
                map[y,x] = true;
            }

            InitVisited();

        }

        static void InitVisited()
        {
            visited = Enumerable.Repeat(false, N + 1).ToArray();
        }

        static void DFS()
        {

        }


        static void BFS()
        {

        }
    }
}
