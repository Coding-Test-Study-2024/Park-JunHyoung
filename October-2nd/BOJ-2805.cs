using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 백준 2805 - 나무자르기 https://www.acmicpc.net/problem/2805

namespace October_2nd
{
    internal class BOJ_2805
    {
        static void Main()
        {
            string[] input = Console.ReadLine()!.Split();

            int treeCount = int.Parse(input[0]); // 나무의 수 N
            int treeLength = int.Parse(input[1]); // 목표로하는 나무의 길이 M


            input = Console.ReadLine()!.Split();

            int[] trees = new int[treeCount];

            for (int i = 0; i < treeCount; i++)
            {
                trees[i] = int.Parse(input[i]);
            }

            Array.Sort(trees);
            Array.Reverse(trees); // 내림차순으로 정렬

            int maxHeight = Solution(trees, treeLength);

            Console.WriteLine(maxHeight);
        }


        static long Cutting(int[] array, int cuttingHeight) // int형이면 오버플로나서 2%에서 틀림뜸 
        {
            long sum = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                if (array[i] <= cuttingHeight)
                    break;

                sum += array[i] - cuttingHeight;
            }
            return sum;
        }

        static int Solution(int[] array, int targetLength)
        {
            int maxHeight = array[0] - targetLength;
            int low = 0;
            int high = array[0];

            while (low <= high)
            {
                int mid = (low + high) / 2;
                long cuttingLength = Cutting(array, mid);

                if (cuttingLength >= targetLength)
                {
                    maxHeight = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return maxHeight;
        }




    }
}
