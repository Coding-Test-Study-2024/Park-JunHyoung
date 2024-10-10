using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 1764 - 듣보잡 https://www.acmicpc.net/problem/1764

namespace October_1st
{
    internal class BOJ_1764
    {
        void Main()
        {
            string[] input = Console.ReadLine()!.Split();

            int peopleNotHeardCount = int.Parse(input[0]);
            int peopleNotSeenCount = int.Parse(input[1]);

            HashSet<string> peopleNotHeard = new HashSet<string>();
            //string[] peopleNotSeen = new string[peopleNotSeenCount];

            for (int i = 0; i < peopleNotHeardCount; i++)
            {
                peopleNotHeard.Add(Console.ReadLine()!);
            }

            List<string> peopleNotHeardNotSeen = new List<string>();
            for (int i = 0; i < peopleNotSeenCount; i++)
            {
                string people = Console.ReadLine()!;

                if (!peopleNotHeard.Add(people)) // 보지 못한 사람 셋에 추가가 안됨 == 중복임 == 듣도 보도 못한 사람임
                {
                    peopleNotHeardNotSeen.Add(people);
                }
            }

            peopleNotHeardNotSeen.Sort();


            Console.WriteLine(peopleNotHeardNotSeen.Count);

            foreach (string output in peopleNotHeardNotSeen)
            {
                Console.WriteLine(output);
            }
        }

    }
}
