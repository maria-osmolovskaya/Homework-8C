/* Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и 
выдаёт номер строки с наименьшей суммой элементов: 1 строка
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

// метод нахождения сумм элементов строк и номера строки с минимальной суммой элементов

void GetRowSumElements(int[,] matrix)
{
    int minSumRow = int.MaxValue;
    int rowIndex = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sumRow = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sumRow += matrix[i, j];

        }

        if (minSumRow > sumRow)
        {
            minSumRow = sumRow;
            rowIndex = i + 1;
        }

    }
    Console.WriteLine($"{rowIndex} строка");
}

int rownumber = GetNumberFromConsole("Введите количество строк");
int colnumber = GetNumberFromConsole("Введите количество столбцов");
int[,] matrix = InitMatrix(rownumber, colnumber);
PrintMatrix(matrix);
GetRowSumElements(matrix);