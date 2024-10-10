using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 1697 - 숨바꼭질  https://www.acmicpc.net/problem/1697

namespace October_1st
{
    internal class BOJ_1697
    {
        const int MAXIMUMCASE = 100000;// 100,000

        public void Main()
        {
            string[] input = Console.ReadLine()!.Split();

            int pointN = int.Parse(input[0]);
            int pointK = int.Parse(input[1]);

            BFS(pointN, pointK);
        }


        void BFS(int startPos, int targetPos)
        {
            //Init
            int[] count = new int[MAXIMUMCASE + 1];
            bool[] visited = new bool[MAXIMUMCASE + 1];
            Queue<int> queue = new Queue<int>();
            visited[startPos] = true;
            queue.Enqueue(startPos);

            if (startPos == targetPos)
            {
                Console.WriteLine(0);
                return;
            }


            while (queue.Count > 0)
            {
                int curPos = queue.Dequeue();
                int newPos;

                //case 1 (move forward)
                newPos = curPos + 1;
                if (newPos >= 0 && newPos <= MAXIMUMCASE && !visited[newPos])
                {
                    queue.Enqueue(newPos);
                    count[newPos] = count[curPos] + 1;
                    visited[newPos] = true;

                    if (newPos == targetPos)
                    {
                        Console.WriteLine(count[newPos]);
                        return;
                    }
                }

                //case 2 (move backward)
                newPos = curPos - 1;
                if (newPos >= 0 && newPos <= MAXIMUMCASE && !visited[newPos])
                {
                    queue.Enqueue(newPos);
                    count[newPos] = count[curPos] + 1;
                    visited[newPos] = true;

                    if (newPos == targetPos)
                    {
                        Console.WriteLine(count[newPos]);
                        return;
                    }
                }

                //case 3 (teleportation)
                newPos = curPos * 2;
                if (newPos >= 0 && newPos <= MAXIMUMCASE && !visited[newPos])
                {
                    queue.Enqueue(newPos);
                    visited[newPos] = true;
                    count[newPos] = count[curPos] + 1;


                    if (newPos == targetPos)
                    {
                        Console.WriteLine(count[newPos]);
                        return;
                    }
                }
            }
        }

    }
}
