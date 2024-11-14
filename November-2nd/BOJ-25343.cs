namespace November_2nd
{
    // LLIS  https://www.acmicpc.net/problem/25343


    internal class BOJ25343
    {
        static int N;

        static List<List<int>> paths = new List<List<int>>();

        static void Main()
        {
            N = int.Parse(Console.ReadLine()!);

            int[,] grid = new int[N, N];

            // 1. Init grid 
            for(int i=0; i<N; i++)
            {
                string[] input = Console.ReadLine()!.Split();

                for(int j=0; j<N; j++)
                {
                    grid[i,j] = int.Parse(input[j]);
                }
            }
            // 2. Find all Paths
            List<int> currentPath = new List<int>();
            currentPath.Add(grid[0,0]);
            FindPaths(grid, 0, 0, currentPath);


            // 3. Find LIS
            int max = int.MinValue;
            foreach(List<int> path in paths)
            {
                int lisLenght = GetLISLength(path);

                if( lisLenght > max)
                {
                    max = lisLenght;
                }
            }

            Console.WriteLine(max);
        }

        static void FindPaths(int[,] grid, int i, int j, List<int> currentPath)
        {
            if (i == N - 1 && j == N - 1)
            {
                //N,N 도달시 저장
                paths.Add(new List<int>(currentPath));
                return;
            }

            if (j < N - 1)
            {
                // 오른쪽으로 이동
                currentPath.Add(grid[i, j + 1]);
                FindPaths(grid, i, j + 1, currentPath);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            if (i < N - 1)
            {
                // 아래쪽으로 이동
                currentPath.Add(grid[i + 1, j]);
                FindPaths(grid, i + 1, j, currentPath);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }


        static int GetLISLength(List<int> array)
        {
            if (array.Count <= 1)
            {
                return 1;
            }

            List<int> LIS = new List<int>();

            foreach (int num in array)
            {
                int index = LIS.BinarySearch(num);

                if (index < 0)
                    index = ~index;

                if (index == LIS.Count)
                {
                    LIS.Add(num); // 끝이면 추가
                }
                else
                {
                    LIS[index] = num; // 아니면 갱신
                }

            }
            return LIS.Count;
        }
    }
}
