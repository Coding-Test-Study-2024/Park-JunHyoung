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
                ProcessTestData();
            }
        }

        static void ProcessTestData()
        {
            int operationCount = int.Parse(Console.ReadLine()!); //k (k<=1,000,000)

            // Key : n, Value : count of n
            SortedList<int, int> sortedDictionary = new SortedList<int, int>();

            // SortedList -> 11% 이후 시간초과
            // SortedDictionary -> 1% 이후 시간초과

            for (int i=0; i < operationCount; i++)
            {
                string[] input = Console.ReadLine()!.Split();
                string operation = input[0]; // I -> Insert n , D -> Delete min/max value(next int n is -1 or 1)
                int n = int.Parse(input[1]);

                if(operation == "I") // work Insert
                {
                    if (!sortedDictionary.ContainsKey(n)){ 
                        sortedDictionary.Add(n, 0);
                    }
                    sortedDictionary[n]++;
                }
                else // if (operation =="D") // work Delete 
                {
                    if (sortedDictionary.Count == 0) continue;
                    int key;

                    if(n == 1)
                    {
                        key =sortedDictionary.Keys.Last();
                    }
                    else // if (n==-1)
                    {
                        key =sortedDictionary.Keys.First();
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
        static void PrintData(SortedList<int, int> sortedDictionary)
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
