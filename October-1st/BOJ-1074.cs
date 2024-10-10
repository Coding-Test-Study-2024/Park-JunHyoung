using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//백준 1074 - Z https://www.acmicpc.net/problem/1074
namespace October_1st
{
    internal class BOJ_1074
    {

        public void Main()
        {
            string[] input = Console.ReadLine().Split();

            int sizeOfArray = (int)Math.Pow(2, int.Parse(input[0]));
            int targetRow = int.Parse(input[1]);
            int targetColumm = int.Parse(input[2]);

            Console.WriteLine(GetTargetOrder(targetRow, targetColumm, sizeOfArray));
        }

        int GetTargetOrder(int row, int colum, int size)
        {
            if (size == 1)
                return 0;

            int newSize = size / 2;
            int newArea = newSize * newSize;

            if (row < newSize && colum < newSize)
                return GetTargetOrder(row, colum, newSize);
            else if (row < newSize && colum >= newSize)
                return newArea + GetTargetOrder(row, colum - newSize, newSize);
            else if (row >= newSize && colum < newSize)
                return newArea * 2 + GetTargetOrder(row - newSize, colum, newSize);
            else //if(row>=newSize && colum >= newSize)
                return newArea * 3 + GetTargetOrder(row - newSize, colum - newSize, newSize);
        }

    }
}
