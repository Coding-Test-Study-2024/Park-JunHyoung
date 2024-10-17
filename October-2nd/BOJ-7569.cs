using System.Numerics;

//백준 7569 - 토마토(3D) https://www.acmicpc.net/problem/7569

namespace October_2nd
{
    internal class BOJ_7569
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()!.Split();
            int boxX = int.Parse(input[0]); // M
            int boxZ = int.Parse(input[1]); // N
            int boxY = int.Parse(input[2]); // H

            int[,,] tomatoes = new int[boxX, boxY, boxZ];


            for (int Y = 0; Y < boxY; Y++)
            {
                for (int Z = 0; Z < boxZ; Z++)
                {
                    input = Console.ReadLine()!.Split();

                    for (int X = 0; X < boxX; X++)
                    {
                        tomatoes[X,Y,Z] = int.Parse(input[X]); 
                    }
                }
            }

            Console.WriteLine(CalculateWanSookDate(tomatoes, boxX, boxY, boxZ));
        }

        static int CalculateWanSookDate(int[,,] tomatoes, int boxX, int boxY, int boxZ)
        {
            int date = 0;

            Vector3[] directions = new Vector3[]
            {
                new Vector3(-1,0,0),
                new Vector3(1,0,0),
                new Vector3(0,0,-1),
                new Vector3(0,0,1), //

                new Vector3(0,1,0),
                new Vector3(0,-1,0)
            };

            // Init Queue 
            Queue<Vector3> tomatoPositions = new Queue<Vector3>();
            for (int Y = 0; Y < boxY; Y++)
            {
                for (int Z = 0; Z < boxZ; Z++)
                {
                    for (int X = 0; X < boxX; X++)
                    {
                        if(tomatoes[X, Y, Z] == 1)
                        {
                            tomatoPositions.Enqueue(new Vector3(X, Y, Z));
                        }
                    }
                }
            }

            int dailyTomatoCount = tomatoPositions.Count;

            // Search with bfs
            while (tomatoPositions.Count > 0)
            {
                Vector3 pos = tomatoPositions.Dequeue();
                dailyTomatoCount--;

                foreach (var dir in directions)
                {
                    Vector3 newPos = pos + dir;
                    if (newPos.Z >= boxZ || newPos.Z < 0) continue;
                    if (newPos.X >= boxX || newPos.X < 0) continue; // 
                    if (newPos.Y >= boxY || newPos.Y < 0) continue; // Exception for boundary out

                    if (tomatoes[(int)newPos.X, (int)newPos.Y, (int)newPos.Z] != 0) continue; //case in 1 or -1, 숙성 무시

                    tomatoes[(int)newPos.X, (int)newPos.Y, (int)newPos.Z] = 1;
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


        static bool CheckIsWanSook(int[,,] arr)
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
