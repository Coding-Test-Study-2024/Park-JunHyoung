
// 백준 9375 - 패션왕 신해빈 https://www.acmicpc.net/problem/9375
namespace October_3rd
{
    internal class BOJ_9375
    {
        static void Main()
        {
            int testCaseCount = int.Parse(Console.ReadLine()!);

            for(int i = 0; i < testCaseCount; i++)
            {
                Console.WriteLine(Solution());
            }
        }

        static int Solution()
        {
            int clothesCount = int.Parse(Console.ReadLine()!);

            // key : type  of clothes 
            // value : count of clothes
            Dictionary<string, int> clothesDic = new Dictionary<string, int>();
            

            for(int i=0; i < clothesCount; i++)
            {
                string[] input = Console.ReadLine()!.Split();

                if (clothesDic.ContainsKey(input[1]))
                {
                    clothesDic[input[1]]++;
                }
                else
                {
                    clothesDic.Add(input[1], 2); // 초기값 2인 이유 : 새 분류의 의상이 추가될때, 선택지는 해당 의상을 고르거나 안고르거나 두가지이기 때문
                }
            }

            int result = 1;
            foreach(int count  in clothesDic.Values)
            {
                result *= count;
            }

            return result - 1;
        }

    }
}
