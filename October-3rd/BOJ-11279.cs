using System.Text;


// 백준 11279 : 최대 힙 https://www.acmicpc.net/problem/11279

namespace October_3rd
{
    internal class BOJ_11279
    {

        static void Main()
        {
            int N = int.Parse(Console.ReadLine()!);

            PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < N; i++) {
                int input = int.Parse(Console.ReadLine()!);

                if(input == 0)
                {
                    if (priorityQueue.Count == 0)
                    {
                        stringBuilder.AppendLine("0");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"{priorityQueue.Peek()}");
                        priorityQueue.Dequeue();
                    }
                }
                else // if(input > 0)
                {
                    priorityQueue.Enqueue(input, -input); // * -를 붙여서 우선순위를 역으로 
                }
            
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
