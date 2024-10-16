using System.Numerics;

//백준 7576 - 토마토 (2D) https://www.acmicpc.net/problem/7576


namespace October_2nd
{
    internal class BOJ_7576
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()!.Split();
            int boxWidth = int.Parse(input[0]);
            int boxHeight = int.Parse(input[1]);

            int[,] tomatoes = new int[boxWidth, boxHeight];

            for (int h = 0; h < boxHeight; h++)
            {
                input = Console.ReadLine()!.Split();

                for (int w = 0; w < boxWidth; w++)
                {
                    tomatoes[w, h] = int.Parse(input[w]);
                }
            }

            Console.WriteLine(CalculateWanSookDate(tomatoes, boxWidth, boxHeight));
        }

        static int CalculateWanSookDate(int[,] tomatoes, int w, int h)
        {
            int date = 0;

            Vector2[] directions = new Vector2[]
            {
                new Vector2(-1, 0),
                new Vector2(1,0),
                new Vector2(0,-1),
                new Vector2(0,1)
            };

            // Init Queue 
            Queue<Vector2> tomatoPositions = new Queue<Vector2>();
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (tomatoes[i, j] == 1)
                    {
                        tomatoPositions.Enqueue(new Vector2(i, j));
                    }
                }
            }

            int dailyTomatoCount = tomatoPositions.Count;

            // Search with bfs
            while (tomatoPositions.Count > 0)
            {
                Vector2 pos = tomatoPositions.Dequeue();
                dailyTomatoCount--;

                foreach (var dir in directions)
                {
                    Vector2 newPos = pos + dir;
                    if (newPos.X >= w || newPos.X < 0) continue; // 
                    if (newPos.Y >= h || newPos.Y < 0) continue; // Exception for boundary out

                    if (tomatoes[(int)newPos.X, (int)newPos.Y] != 0) continue; //case in 1 or -1, 숙성 무시

                    tomatoes[(int)newPos.X, (int)newPos.Y] = 1;
                    tomatoPositions.Enqueue(newPos);
                }

                // 하루치 순회 다 하면,
                if (dailyTomatoCount == 0)
                {
                    date++;
                    dailyTomatoCount = tomatoPositions.Count;
                }
            }


            if (CheckIsWanSook(tomatoes))
                return date - 1;
            else
                return -1;
        }


        static bool CheckIsWanSook(int[,] arr)
        {
            foreach (var item in arr)
            {
                if (item == 0)
                    return false;
            }
            return true;
        }

    }
}
