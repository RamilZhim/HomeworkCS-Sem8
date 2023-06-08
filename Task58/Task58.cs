// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18.

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

int[,] MultiplyMatrix(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] resultMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

    for (int i = 0; i < firstMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < secondMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < firstMatrix.GetLength(1); k++)
            {
                resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
            }
        }
    }
    return resultMatrix;
}

Console.WriteLine("Задайте первую матрицу: ");
int[,] firstMatrix = FillMatrix(InputData("Введите количество строк первой матрицы: "), InputData("Введите количество столбцов первой матрицы: "), InputData("Введите левую границу: "), InputData("Введите правую границу: "));
Console.WriteLine();
PrintMatrix(firstMatrix);
Console.WriteLine();

Console.WriteLine("Задайте вторую матрицу: ");
int[,] secondMatrix = FillMatrix(InputData("Введите количество строк второй матрицы: "), InputData("Введите количество столбцов второй матрицы: "), InputData("Введите левую границу: "), InputData("Введите правую границу: "));
Console.WriteLine();
PrintMatrix(secondMatrix);
Console.WriteLine();

MultiplyMatrix(firstMatrix, secondMatrix);
Console.WriteLine("Произведение двух матриц: ");
Console.WriteLine();
PrintMatrix(MultiplyMatrix(firstMatrix, secondMatrix));