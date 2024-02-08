using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 백준 19598 : 최소 회의실 개수 (https://www.acmicpc.net/problem/19598)


namespace Week_02
{
    internal class BOJ_19598
    {
        static void Main()
        {
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();

            int meetingCount = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < meetingCount; i++)
            {
                string[] temp = Console.ReadLine()!.Split();
                priorityQueue.Enqueue(int.Parse(temp[1]), int.Parse(temp[0])); // 시작시간을 우선순위로 큐 삽입
            }
            Console.WriteLine(MinimumMeetingRoom(priorityQueue));
        }

        static int MinimumMeetingRoom(PriorityQueue<int, int> priorityQueue)
        {
            PriorityQueue<int, int> newQueue = new PriorityQueue<int, int>();

            int meetingRoom = 0;
            /*
            while (priorityQueue.Count > 0)
            {
                priorityQueue.Dequeue();
                if (newQueue.Count == 0)
                {
                    meetingRoom++;
                }
            }
            return newQueue.Count;*/

            return -1;
        }

    }
}
