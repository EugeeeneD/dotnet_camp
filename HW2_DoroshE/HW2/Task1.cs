using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal class Task1
    {
        public int[,] VerticalSnake(int row, int column)
        {
            int[,] res = new int[row, column];

            int k = 1;

            for (int i = 0; i < column; i++)
            {//Можна оптимізувати
                if (i % 2 == 0)
                {
                    for (int j = 0; j < row; j++)
                    {
                        res[j, i] = k++;
                    }
                }
                else
                {
                    for (int j = row - 1; j >= 0; j--)
                    {
                        res[j, i] = k++;
                    }
                }
            }

            return res;
        }

        public int[,] DiagonalSnake(int n)
        {
            int[,] res = new int[n, n];

            int k = 1;
// можна оптимізувати
            for (int i = 0; i < n*2; i++)
            {
                if (i < n)
                {
                    if (i % 2 == 0)
                    {
                        int l = 0;
                        for (int j = i; j >= 0; j--)
                        {
                            res[j, l++] = k++;
                        }
                    }
                    else
                    {
                        int l = i;
                        for (int j = 0; j <= i; j++)
                        {
                            res[j, l--] = k++;
                        }
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        int l = n - 1;
                        for (int j = i - n + 1; j < n; j++)
                        {
                            res[l--, j] = k++;
                        }
                    }
                    else
                    {
                        int l = n - 1;
                        for (int j = i - n + 1; j < n; j++)
                        {
                            res[j, l--] = k++;
                        }
                    }
                }
            }

            return res;
        }

/*        public void ReverseMatrix(int[,] matrix)
        {
            Task1 newMat = new Task1();

            newMat.Print(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1)  / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, matrix.GetLength(1) - j - 1];
                    matrix[i, matrix.GetLength(1) - j - 1] = temp;
                }
            }
            Console.WriteLine();
            newMat.Print(matrix);
        }*/

        public int[,] HorizontalSpiralSnake(int row, int column)
        {
            int[,] res = new int[row, column];

            int k = 1;
            int endPoint = row * column - 1;
            int x = 0, iter = 0;
//можна оптимізувати
            while (true)
            {
                for (var i = iter; i < column - x; i++)
                {
                    res[iter, i] = k++;
                }

                if (k >= endPoint) { break; }

                iter++;

                if (k >= endPoint) { break; }

                for (var i = iter; i < row - x; i++)
                {
                    res[i, column - iter] = k++;
                }
                if (k >= endPoint) { break; }

                for (var i = column - iter - 1; i >= x; i--)
                {
                    res[row - iter, i] = k++;
                }

                if (k >= endPoint) { break; }

                for (var i = row - iter - 1; i > x; i--)
                {
                    res[i, x] = k++;
                }
                x++;
            }
            return res;
        }

        public int[,] VerticalSpiralSnake(int row, int column)
        {
            int[,] res = new int[row, column];
            int endPoint = row * column + 1;
            int iter = 0;
            int k = 1;

            while(true)
            {
                if (k >= endPoint) { break; }
                //down
                for (int i = iter; i < row - iter; i++)
                {
                    res[i, iter] = k++;
                }
                if (k >= endPoint) { break; } 
                //toRight
                for (int i = iter + 1; i < column - iter; i++)
                {
                    res[row - iter - 1,i] = k++;
                }
                if (k >= endPoint) { break; }
                //up
                for (int i = row - 2 - iter; i >= iter; i--)
                {
                    res[i, column - iter - 1] = k++;
                }
                if (k >= endPoint) { break; }
                //toLeft
                for (int i = column - iter - 1; i > iter + 1; i--)
                {
                    res[iter, i - 1] = k++;
                }
                iter++;
            }

            return res;
        }

        public void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
