// 백준 7662 - 이중 우선순위 큐  https://www.acmicpc.net/problem/7662

namespace October_2nd
{
    internal class BOJ_7662
    {

        static void Main()
        {
            int testDataCount = int.Parse(Console.ReadLine()!); // T

            for(int i = 0; i < testDataCount; i++)
            {
                GetTestData();
            }
        }

        static void GetTestData()
        {
            int operationCount = int.Parse(Console.ReadLine()!); //k (k<=1,000,000)

            SortedDictionary<int, int> sortedDictionary = new SortedDictionary<int, int>();
            // Key : N, Value : count of N

            for(int i=0; i < operationCount; i++)
            {
                string[] input = Console.ReadLine()!.Split();
                string operation = input[0]; // I -> Insert n , D -> Delete max value or min value(next int n is 1 or-1)
                int n = int.Parse(input[1]);

                if(operation == "I")
                {
                    if (!sortedDictionary.ContainsKey(n)){ 
                        sortedDictionary.Add(n, 0);
                    }
                    sortedDictionary[n]++;
                }
                else // if (operation =="D")
                {
                    int key;

                    if (sortedDictionary.Count == 0) continue;

                    if(n == 1)
                    {
                        key =sortedDictionary.Keys.Max();
                    }
                    else // if (n==-1)
                    {
                        key =sortedDictionary.Keys.Min();
                    }

                    //sortedDictionary.TryGetValue(key, out int temp);

                    if (sortedDictionary[key] ==1)
                        sortedDictionary.Remove(key);
                    else
                        sortedDictionary[key]--;
                }
                
            }
            PrintData(sortedDictionary);
        }

        const string EMPTY = "EMPTY";
        static void PrintData(SortedDictionary<int, int> sortedDictionary)
        {
            if(sortedDictionary.Count ==0)
            {
                Console.WriteLine(EMPTY);
            }
            else
            {
                Console.WriteLine($"{sortedDictionary.Keys.Max()} {sortedDictionary.Keys.Min()}");
            }
        }

    }
}
