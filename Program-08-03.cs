/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
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
            matrix[i, j] = rnd.Next(1, 5);
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

//Решения задачи - перемножение матриц

int rownumberFirstMatrix = GetNumberFromConsole("Введите количество строк первой матрицы");
int colnumberFirstMatrix = GetNumberFromConsole("Введите количество столбцов первой матрицы");
int rownumberSecondMatrix = GetNumberFromConsole("Введите количество строк второй матрицы");
int colnumberSecondMatrix = GetNumberFromConsole("Введите количество столбцов второй матрицы");
int[,] firstMatrix = InitMatrix(rownumberFirstMatrix, colnumberFirstMatrix);
int[,] secondMatrix = InitMatrix(rownumberSecondMatrix, colnumberSecondMatrix);

PrintMatrix(firstMatrix);

PrintMatrix(secondMatrix);

if (rownumberFirstMatrix == colnumberSecondMatrix)
{
    int[,] newMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
    for (int i = 0; i < newMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < newMatrix.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < firstMatrix.GetLength(1); k++)
            {
                sum += firstMatrix[i, k] * secondMatrix[k, j];
                newMatrix[i, j] = sum;
            }
            
        }
    }
    PrintMatrix(newMatrix);
}
else
    {
        Console.Write("Задача не имеет решения");
    }
