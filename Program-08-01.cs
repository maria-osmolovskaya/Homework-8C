/*Задача 54: Задайте двумерный массив. 
Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

//метод введения количества строк и столбцов

int GetNumberFromConsole(string message)
{
    Console.WriteLine(message);
    int result;
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.WriteLine("Это не число");
        }
    }
    return result;
}

//метод инициализации и заполнения матрицы
int[,] InitMatrix(int m, int n)
{
    int[,] matrix = new int[m, n];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(0, 99);
        }
    }
    return matrix;
}

// метод печати матрицы
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

// метод сортировки элементов каждой строки массива
int[,] GetSortedLinesMatrix(int[,] matrix)
{
    int[,] newmatrix = matrix;
    
    for (int i = 0; i < newmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < newmatrix.GetLength(1); j++)
        {
            for (int k = 0; k < newmatrix.GetLength(1)-1; k++)
            {
                if (matrix[i,k] < matrix[i,k+1])
                {
                    int temp = newmatrix[i, k+1];
                    newmatrix[i, k+1] = newmatrix[i, k];
                    newmatrix[i, k] = temp;
                }

            }
        }

    }
    return newmatrix;
}

int rownumber = GetNumberFromConsole("Введите количество строк");
int colnumber = GetNumberFromConsole("Введите количество столбцов");
int[,] matrix = InitMatrix(rownumber, colnumber);
PrintMatrix(matrix);
int[,] newmatrix = GetSortedLinesMatrix(matrix);
PrintMatrix(newmatrix);