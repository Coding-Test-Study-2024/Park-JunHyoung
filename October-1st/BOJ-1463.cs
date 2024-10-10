using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October_1st
{
    internal class BOJ_1463
    {
        int[] memo = new int[1000001];


        public void Main()
        {
            int inputNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(MadeToOne(inputNumber) - 1);
        }


        int MadeToOne(int n)
        {
            if (n <= 1)
                return 1;

            if (memo[n - 1] == 0)
            {
                int divThree = int.MaxValue, divTwo = int.MaxValue, minusOne = int.MaxValue, minSolution = int.MaxValue;

                if (n % 3 == 0)
                    divThree = MadeToOne(n / 3);
                if (n % 2 == 0)
                    divTwo = MadeToOne(n / 2);

                minusOne = MadeToOne(n - 1);

                if (divThree <= divTwo)
                    minSolution = divThree;
                else
                    minSolution = divTwo;

                if (minusOne < minSolution)
                    minSolution = minusOne;

                memo[n - 1] = minSolution;
            }

            return memo[n - 1] + 1;
        }
    }
}
