
//백준 1026 : 보물(https://www.acmicpc.net/problem/1026)
namespace Week_06
{
    internal class BOJ_1026
    {
        static int N;
        static int[] A, B;
        static void Main1(string[] args)
        {
            GetInput();
            Solve(A, B);
        }
        static void GetInput()
        {
            N = int.Parse(Console.ReadLine()!);

            A = new int[N];
            B = new int[N];

            string[] input = Console.ReadLine()!.Split();
            for (int i = 0; i < N; i++)
            {
                A[i] = int.Parse(input[i]);
            }

            input = Console.ReadLine()!.Split();
            for (int i = 0; i < N; i++)
            {
                B[i] = int.Parse(input[i]);
            }
        }
        static void Solve(int[] A, int[] B)
        {
            Array.Sort(A);
            Array.Reverse(A);
            Array.Sort(B);

            int answer =0;
            for(int i = 0; i < N;i++)
            {
                answer += A[i]*B[i];
            }
            Console.WriteLine(answer);
        }
    }
}
