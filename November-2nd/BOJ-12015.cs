namespace November_2nd
{
    // LIS  https://www.acmicpc.net/problem/12015

    internal class BOJ12015
    {
        static void Main()
        {
            int arraySize = int.Parse(Console.ReadLine()!);

            List<int> array = new List<int>(arraySize);

            string[] input = Console.ReadLine()!.Split();

            // Init Array
            for(int i = 0; i < input.Length; i++)
            {
                array.Add(int.Parse(input[i]));
            }

            Solution(array);
        }


        static void Solution(List<int > array)
        {
            if (array.Count <= 1)
            {
                Console.WriteLine(1);
                return;
            }

            List<int> LIS = new List<int>();

            foreach (int num in array)
            {
                int index = LIS.BinarySearch(num);

                if (index < 0)
                    index = ~index;

                if(index == LIS.Count)
                {
                    LIS.Add(num); // 끝이면 추가
                }
                else
                {
                    LIS[index] = num; // 아니면 갱신
                }

            }


            Console.WriteLine(LIS.Count);
            return;
        }

    }
}
