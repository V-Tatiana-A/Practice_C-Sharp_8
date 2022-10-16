// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2


using static System.Console;
Clear();
WriteLine("Задача 54");
Write("Введите размер матрицы, мин и макс значения через пробел:  ");
int[] data = Array.ConvertAll(((ReadLine()!).Split(" ", System.StringSplitOptions.RemoveEmptyEntries)), int.Parse);
int[,] matrix = GetMatrixArray(data[0], data[1], data[2], data[3]);
PrintMatrix(matrix);
SortRows(matrix);
WriteLine();
PrintMatrix(matrix);


// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


WriteLine();
WriteLine("Задача 56");
Write("Введите размер матрицы, мин и макс значения через пробел:  ");
int[] data2 = Array.ConvertAll(((ReadLine()!).Split(" ", System.StringSplitOptions.RemoveEmptyEntries)), int.Parse);
int[,] matrix2 = GetMatrixArray(data2[0], data2[1], data2[2], data2[3]);
PrintMatrix(matrix2);
WriteLine();
GetSmallestSumInRows(matrix2);



// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

WriteLine();
WriteLine("Задача 58");
Write("Введите размер первой матрицы, мин и макс значения через пробел:  ");
int[] input1 = Array.ConvertAll(((ReadLine()!).Split(" ", System.StringSplitOptions.RemoveEmptyEntries)), int.Parse);
int[,] matr1 = GetMatrixArray(input1[0], input1[1], input1[2], input1[3]);
PrintMatrix(matr1);
WriteLine();
Write("Введите размер второй матрицы, мин и макс значения через пробел:  ");
int[] input2 = Array.ConvertAll(((ReadLine()!).Split(" ", System.StringSplitOptions.RemoveEmptyEntries)), int.Parse);
int[,] matr2 = GetMatrixArray(input2[0], input2[1], input2[2], input2[3]);
PrintMatrix(matr2);
WriteLine();
if (matr1.GetLength(1) != matr2.GetLength(0)) WriteLine("Заданные матрицы не совместимы");
else
{
    WriteLine("Итоговая матрица:");
    PrintMatrix(MatrixMultiplication(matr1, matr2));
}


// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


WriteLine();
WriteLine("Задача 60");
Write("Введите размер трехмерной матрицы:    ");
int[] data3 = Array.ConvertAll(((ReadLine()!).Split(" ", System.StringSplitOptions.RemoveEmptyEntries)), int.Parse);
if (data3[0]*data3[1]*data3[2]>90) WriteLine("Слишком большой размер массива для заполнения уникальными числами");
else
{
    int[,,] matrix3 = Get3DimArray(data3[0], data3[1], data3[2]);
    Print3DMatrix(matrix3);
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07


WriteLine();
WriteLine("Задача 62");
WriteLine("Введите число строк");
int rows = int.Parse(ReadLine()!);
WriteLine("Введите число столбцов");
int columns = int.Parse(ReadLine()!);
int[,] FilledMatrix = SpiralyFillArray(rows, columns);
WriteLine("Матрица заполнена:");
PrintMatrix(FilledMatrix);







//

void PrintMatrix(int[,] inMatrix)
{
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < inMatrix.GetLength(1); j++)
        {
            Write($"{inMatrix[i, j]}\t");
        }
        WriteLine();
    }
}

int[,] GetMatrixArray(int rows, int columns, int minValue, int maxValue)
{
    int[,] resultMatrix = new int[rows, columns];
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            resultMatrix[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return resultMatrix;
}


void SortRows(int[,] inMatrix)
{
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        int j = 1;
        while (j < inMatrix.GetLength(1))
        {
            if (inMatrix[i, j - 1] < inMatrix[i, j])
            {
                int temp = inMatrix[i, j - 1];
                inMatrix[i, j - 1] = inMatrix[i, j];
                inMatrix[i, j] = temp;
                j = 1;
            }
            else j++;
        }
    }
}


void GetSmallestSumInRows(int[,] inMatrix)
{
    int row = 0;
    int sum = Int32.MaxValue;
    for (int i = 0; i < inMatrix.GetLength(0); i++)
    {
        int result = 0;
        for (int j = 0; j < inMatrix.GetLength(1); j++)
        {
            result = result + inMatrix[i, j];
        }
        if (result < sum)
        {
            sum = result;
            row = i;
        }
    }
    WriteLine($"Строка с минимальной суммой элементов {row} (по порядку {row + 1}), эта сумма равна {sum}");
}


int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            int multipl = 0;
            for (int m = 0; m < matrix1.GetLength(1); m++)
            {
                multipl = multipl + (matrix1[i, m] * matrix2[m, j]);
            }
            result[i, j] = multipl;
        }
    }
    return result;
}



int[,,] Get3DimArray(int rows, int columns, int debth)
{
    int[,,] resultMatrix = new int[rows, columns, debth];
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < resultMatrix.GetLength(2); k++)
            {
                int temp = new Random().Next(10, 100);
                bool uniq = true;
                foreach (int item in resultMatrix)
                {
                    if (item == temp) uniq = false;
                }
                if (uniq == true) resultMatrix[i,j,k] = temp;
                else k = k - 1;
            }
        }
    }
    return resultMatrix;
}


void Print3DMatrix(int[,,] inMatrix)
{
    for (int k = 0; k < inMatrix.GetLength(0); k++)
    {
        for (int i = 0; i < inMatrix.GetLength(1); i++)
        {
            for (int j = 0; j < inMatrix.GetLength(2); j++)
            {
                Write($"{inMatrix[i, j, k]}({i},{j},{k})\t");
            }
            WriteLine();
        }
        WriteLine();
    }
}


int[,] SpiralyFillArray(int row, int column)
{
    int[,] matrix = new int[rows, columns];
    int num = 1;
    bool StraightOrder = true;
    int rowLenMod = 0;
    int colLenMod = 0;
    int i = 0;
    int j = -1;
    while (num<(row*column)+1)
    {
        if (StraightOrder == true && i==rowLenMod)
        {
            j+=1;
            while (j < matrix.GetLength(1)-colLenMod)
            {
                matrix[i,j] = num;
                num += 1;
                j += 1;
            }
            j -= 1;
        }
        if (StraightOrder == true && j==matrix.GetLength(1)-colLenMod-1)
        {
            i+=1;
            while (i < matrix.GetLength(0)-rowLenMod)
            {
                matrix[i, j] = num;
                num += 1;
                i += 1;
            }
            i -= 1;
            StraightOrder = false;
        }
        if (StraightOrder == false && i==matrix.GetLength(0)-rowLenMod-1)
        {
            j-=1;
            while (j > colLenMod-1)
            {
                matrix[i, j] = num;
                num += 1;
                j -= 1;
            }
            j+=1;
            rowLenMod += 1;
        }
        if (StraightOrder == false && j==colLenMod)
        {
            i-=1;
            while (i > rowLenMod-1)
            {           
                matrix[i, j] = num;
                num += 1;
                i -= 1;
            }
            i+=1;
            colLenMod += 1;
            StraightOrder = true;
        }
    }
    return matrix;
}