namespace November_2nd
{
    internal class BOJ_1717
    {
        const string NO = "NO";
        const string YES = "YES";
        static int[] parent;


        static void Main()
        {

            string[] input = Console.ReadLine()!.Split(); // N,M
            int N = int.Parse(input[0]); // N
            int testCaseCount = int.Parse(input[1]); // M

            parent = new int[N+1];
            for(int i = 0; i <=N; i++)
                parent[i] = i;

            for(int  i = 0; i < testCaseCount; i++)
            {
                input = Console.ReadLine()!.Split();

                int a = int.Parse(input[1]);
                int b = int.Parse(input[2]);

                if (input[0] == "0")
                {
                    Union(a, b);
                }else //if (input[0] == "1")
                {
                    Console.WriteLine(IsContain(a, b) ? YES : NO);
                }
            }
        }

        static void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if(rootA != rootB)
                parent[rootB] = rootA;
        }

        static bool IsContain(int a, int b)
        {
            return Find(a) == Find(b);
        }

        // Find Parent
        static int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }
    }
}
