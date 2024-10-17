using System;
using System.Collections.Generic;
using System.Numerics;

// 백준 1012 - 유기농 배추 https://www.acmicpc.net/problem/1012

namespace October_1st
{
    internal class BOJ_1012
    {
        static void Main(string[] args)
        {
            int testCaseCount = int.Parse(Console.ReadLine());

            for(int i= 0; i<testCaseCount; i++)
            { 
                string[] input = Console.ReadLine().Split();
                int width = int.Parse(input[0]);
                int height = int.Parse(input[1]);

                int[,] field = new int[width, height];

                int cabbagePosCount = int.Parse(input[2]);

               for(int j=0; j<cabbagePosCount; j++)
                {
                    string[] positions = Console.ReadLine().Split();
                    field[int.Parse(positions[0]), int.Parse(positions[1])] = 1;
                }

                Console.WriteLine(CalculateEarthwormCount(field, width, height));
            }
        }

        static int CalculateEarthwormCount(int[,] field, int w, int h)
        {
            int count = 0;

            bool[,] visited = new bool[w, h];
            Vector2[] directions = new Vector2[]
            {
                new Vector2(-1, 0),
                new Vector2(1,0),
                new Vector2(0,-1),
                new Vector2(0,1)
            };

            for(int y = 0; y<h; y++)
            {
                for(int x=0; x<w; x++)
                {
                    if (visited[x, y] || field[x,y]!=1) continue;

                    Queue<Vector2> cabbagePos = new Queue<Vector2>();
                    cabbagePos.Enqueue(new Vector2(x,y));
                    visited[x, y] = true;

                    // Search with bfs
                    while (cabbagePos.Count > 0)
                    {
                        Vector2 pos = cabbagePos.Dequeue();

                        foreach (var dir in directions)
                        {
                            Vector2 newPos = pos + dir;
                            if (newPos.X >= w || newPos.X < 0) continue; // 
                            if (newPos.Y >= h || newPos.Y < 0) continue; // Exception for boundary out

                            if (visited[(int)newPos.X, (int)newPos.Y] || field[(int)newPos.X, (int)newPos.Y] != 1) continue;

                            visited[(int)newPos.X, (int)newPos.Y] = true;
                            cabbagePos.Enqueue(newPos);
                        }
                    }
                    count++;

                }
            }

            return count;
        }

    }
}

