// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов в каждой строке 
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int InputData(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int[,] FillMatrix(int rows, int columns, int leftRange, int rightRange)
{
    int[,] matrix = new int[rows, columns];

    Random rand = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

int SumRow(int[,] matrix, int i)
{
    int sum = matrix[i, 0];
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        sum += matrix[i, j];
    }
    return sum;
}

void MinSumRow(int[,] matrix)
{
    int minSumRow = 0;
    int minSum = SumRow(matrix, 0);
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        int tempSumRow = SumRow(matrix, i);
        if (minSum > tempSumRow)
        {
            minSum = tempSumRow;
            minSumRow = i;
        }
    }

    Console.Write($"Наименьшая сумма элементов равняется: {minSum} в строке: {minSumRow + 1}");
}

Console.WriteLine("Задайте прямоугольный двумерный массив: ");
int[,] matrix = FillMatrix(InputData("Введите количество строк: "), InputData("Введите количество столбцов: "), InputData("Введите левую границу: "), InputData("Введите правую границу: "));
Console.WriteLine();
PrintMatrix(matrix);
Console.WriteLine();
MinSumRow(matrix);
