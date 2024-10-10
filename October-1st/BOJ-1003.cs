using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 백준 1003 - 피보나치 함수 https://www.acmicpc.net/problem/1003

namespace October_1st
{
    internal class BOJ_1003
    {
        int[] fiboMemo = new int[41];

        public void Main()
        {
            int inputCount = int.Parse(Console.ReadLine());
            int[] inputNum = new int[inputCount];

            int max = -1;

            for (int i = 0; i < inputCount; i++)
            {
                inputNum[i] = int.Parse(Console.ReadLine());
                if (max < inputNum[i])
                    max = inputNum[i];
            }

            Fibonacci(max);


            for (int i = 0; i < inputNum.Length; i++)
            {
                PrintCount(inputNum[i]);
            }
        }

        int Fibonacci(int n)
        {
            if (n <= 0)
            {
                return fiboMemo[n] = 0;
            }

            if (n == 1)
            {
                return fiboMemo[n] = 1;
            }

            if (fiboMemo[n] != 0)
            {
                return fiboMemo[n];
            }
            else
            {
                return fiboMemo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        void PrintCount(int n) // and reset
        {
            if (n == 0)
            {
                Console.WriteLine($"1 {fiboMemo[n]}");
            }
            else
            {
                Console.WriteLine($"{fiboMemo[n - 1]} {fiboMemo[n]}");
            }
        }



    }
}
