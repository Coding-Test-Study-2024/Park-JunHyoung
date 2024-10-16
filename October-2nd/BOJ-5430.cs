using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 5430 - AC https://www.acmicpc.net/problem/5430

namespace October_2nd
{
    internal class BOJ_5430
    {
        const string errorMsg = "error";
        static void Main()
        {
            int testCaseCount = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < testCaseCount; i++)
            {
                GetTestCase(out string commands, out List<int>? array);
                Console.WriteLine(Solution(commands, array));
            }

        }
        static void GetTestCase(out string commands, out List<int>? array)
        {
            commands = Console.ReadLine()!; // RD 로 이뤄진 명령어 셋
            int countOfArray = int.Parse(Console.ReadLine()!);
            string arrayTemp = Console.ReadLine()!.Trim('[', ']');

            if (string.IsNullOrEmpty(arrayTemp))
                array = null;
            else
            {
                array = arrayTemp.Split(',').Select(int.Parse).ToList();
            }

        }

        static string Solution(string commands, List<int>? array)
        {
            bool isReversed = false;
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'R':
                        isReversed = !isReversed;
                        break;
                    case 'D': //배열 하나 빼기 
                        if (array == null || array.Count == 0)
                            return errorMsg;
                        if (isReversed)
                            array.RemoveAt(array.Count - 1);
                        else
                            array.RemoveAt(0);
                        break;
                }
            }


            // case : 배열 비었을 때            
            if (array == null || array.Count == 0)
            {
                return "[]";
            }

            if (isReversed)
                array.Reverse();

            // case : 정상 출력
            StringBuilder result = new StringBuilder();
            result.Append('[');
            for (int i = 0; i < array.Count - 1; i++)
            {
                result.Append($"{array[i]},");
            }
            result.Append(array[array.Count - 1]);
            result.Append(']');
            return result.ToString();
        }
    }
}
