using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

int countTasks = 5;
int task;

string[] tasks = new string[countTasks];
tasks[0] = "1. Задайте двумерный массив. Программа, которая упорядочит по убыванию элементы каждой строки двумерного массива.";
tasks[1] = "2. Задайте прямоугольный двумерный массив. Программа, которая будет находить строку с наименьшей суммой элементов.";
tasks[2] = "3. Задайте две матрицы. Программа, которая будет находить произведение двух матриц.";
tasks[3] = "4. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Программа, которая будет построчно выводить массив, добавляя индексы каждого элемента.";
tasks[4] = "3. Программа, которая заполнит спирально массив 4 на 4.";


int SelectionTask(string[] tasks, int countTasks)
{
    for (int i = 0; i < countTasks; i++)
    {
        Console.WriteLine(tasks[i]);
    }

    Console.Write($"Выберите задачу (от 1 до {countTasks}): ");
    if (!int.TryParse(Console.ReadLine(), out int task) || task > countTasks || task < 1)
    {
        Console.Clear();
        task = SelectionTask(tasks, countTasks);
    }
    return task;
}

int[,] CreateRandomInt2DArray(int row, int column, int minValue, int maxValue)
{
    int[,] array = new int[row, column];

    if (minValue > maxValue)
    {
        int temp = minValue;
        minValue = maxValue;
        maxValue = temp;
    }

    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(minValue, maxValue + 1);
        }
    }
    return array;
}

double[,] CreateRandomDouble2DArray(int row, int column, double minValue, double maxValue)
{
    double[,] array = new double[row, column];

    if (minValue > maxValue)
    {
        double temp = minValue;
        minValue = maxValue;
        maxValue = temp;
    }

    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
    return array;
}

void PrintDoubleArray1D(double[] array, int digits)
{
    int widthColumn = GetMaxLengthDoubleItem1DArray(array) + digits + 2;

    foreach (var item in array)
    {
        Console.Write(String.Format("{0," + widthColumn + "}", Math.Round(item, digits)));
    }
}

void PrintIntArray2D(int[,] array, int interval)
{
    int widthColumn = GetMaxLengthIntItem2DArray(array) + interval;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0," + widthColumn + "}", array[i, j]));
        }
        Console.WriteLine();
    }
}

void PrintDoubleArray2D(double[,] array, int digits)
{
    int widthColumn = GetMaxLengthDoubleItem2DArray(array) + digits + 2;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0," + widthColumn + "}", Math.Round(array[i, j], digits)));
        }
        Console.WriteLine();
    }
}

int GetMaxLengthDoubleItem1DArray(double[] array)
{
    int maxLength = 0;
    int itemLength = 0;

    for (int i = 0; i < array.Length; i++)
    {
        itemLength = Convert.ToInt32(array[i]).ToString().Length;
        if (maxLength < itemLength) maxLength = itemLength;
    }
    return maxLength;
}

int GetMaxLengthIntItem2DArray(int[,] array)
{
    int maxLength = 0;
    int itemLength = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            itemLength = array[i, j].ToString().Length;
            if (maxLength < itemLength) maxLength = itemLength;
        }
    }
    return maxLength;
}

int GetMaxLengthDoubleItem2DArray(double[,] array)
{
    int maxLength = 0;
    int itemLength = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            itemLength = Convert.ToInt32(array[i, j]).ToString().Length;
            if (maxLength < itemLength) maxLength = itemLength;
        }
    }
    return maxLength;
}


int SetNumber(string greet)
{
    Console.Write(greet);
    if (!int.TryParse(Console.ReadLine(), out int number)) number = SetNumber(greet);
    return number;
}

// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

void SortRowDescend(int[,] array, int row)
{
    bool sort = false;
    int Temp;
    int length = array.GetLength(1);

    for (int i = length - 1; i > 0; i--)
    {
        if (!sort)
        {
            sort = true;
            for (int j = 0; j < i; j++)
            {
                if (array[row, j] < array[row, j + 1])
                {
                    Temp = array[row, j];
                    array[row, j] = array[row, j + 1];
                    array[row, j + 1] = Temp;
                    sort = false;
                }
            }
        }
    }
}


void SortRowsArrayDescend(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        SortRowDescend(array, i);
    }
}


// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int RowMinSum(int[,] array)
{
    int indexMinSum = -1;
    int minSum = int.MaxValue;
    int sum;
    for (int i = 0; i < array.GetLength(0); i++)
    {
       sum = SumRow(array, i);
        if (sum < minSum) 
        { 
            minSum = sum;
            indexMinSum = i;
        }
    }
    return indexMinSum;
}
int SumRow(int[,] array, int row)
{
    int sum = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        sum += array[row, i];
    }
    return sum;
}

// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int MultiplicationElement(int[,] array1, int[,] array2, int row, int column)
{
    int count = array1.GetLength(1);
    int mult = 0;
    for (int i = 0; i < count; i++)
    {
        mult += array1[row, i] * array2[i, column];
    }
    return mult;
}

int[,] MultiplicationMatrix(int[,] array1, int[,] array2)
{
    if (array1.GetLength(0) == array2.GetLength(1) && array1.GetLength(1) == array2.GetLength(0))
    {
        int count = array1.GetLength(0);
        int[,] multArray = new int[count, count];
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                multArray[i, j] = MultiplicationElement(array1, array2, i, j);
            }
        }
        return multArray;
    }
    else return new int[1, 1];
}


// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.



// Напишите программу, которая заполнит спирально массив 4 на 4.

void FillSpiralArray(int[,] array)
{
    int countRow = array.GetLength(0);
    int countColumn = array.GetLength(1);

    bool[,] fillArrayValue = new bool[countRow, countColumn];

    int[][] vectorArray =
    {
      new int[] { 0,1 },  //left
      new int[]  { 1,0},  //down
      new int[]  { 0,-1}, //right
      new int[]  { -1,0}  //up
    };

    int row = 0;
    int column = 0;
    int number = 1;
    int countVectors = vectorArray.GetLength(0);
    int countTurns = 0;
    int indexVector = 0;
    int[] vector = vectorArray[indexVector]; //указываем направление
    while (true)
    {
        array[row, column] = number; //записываем число
        fillArrayValue[row, column] = true; //помечаем что здесь уже были
        if ((row + vector[0] > -1 && row + vector[0] < countRow)
            && (column + vector[1] > -1 && column + vector[1] < countColumn)
         && !fillArrayValue[row + vector[0], column + vector[1]]) //проверяем можем ли пойти в указанном напрвлении
        {
            row += vector[0];
            column += vector[1]; //сместились
            countTurns = 0; // по сторонам ещё не смотрели
            number++; // увеличили записываемое число
        }
        else
        {
            if (countTurns == countVectors) return; //если проверили со всех сторон
            if (indexVector == vectorArray.Length - 1) indexVector = 0;  // если проверили снизу, указываем направление
            else indexVector++;
            vector = vectorArray[indexVector]; //указываем направление
            countTurns++;
        }
    }
}


void FillUp(int[,] array, int row, int columnFirst, int columnLast, ref int number)
{
    for (int i = columnFirst; i <= columnLast; i++)
    {
        number++;
        array[row, i] = number;
    }
}

void FillRight(int[,] array, int column, int rowFirst, int rowLast, ref int number)
{
    for (int i = rowFirst; i <= rowLast; i++)
    {
        number++;
        array[i, column] = number;
    }
}

void FillDown(int[,] array, int row, int columnFirst, int columnLast, ref int number)
{
    for (int i = columnFirst; i >= columnLast; i--)
    {
        number++;
        array[row, i] = number;
    }
}

void FillLeft(int[,] array, int column, int rowFirst, int rowLast, ref int number)
{
    for (int i = rowFirst; i >= rowLast; i--)
    {
        number++;
        array[i, column] = number;
    }
}

void FillSquare(int[,] array, int layer, ref int number)
{
    int countRow = array.GetLength(0);
    int countColumn = array.GetLength(1);

    FillUp(array, layer - 1, layer - 1, countColumn - layer, ref number);
    FillRight(array, countColumn - layer, layer, countRow - layer, ref number);
    if (layer - 1 != countRow - layer) FillDown(array, countRow - layer, countColumn - layer - 1, layer - 1, ref number);
    if (layer - 1 != countColumn - layer) FillLeft(array, layer - 1, countRow - layer - 1, layer, ref number);
}

void FillSpiralArray2(int[,] array)
{
    int countRow = array.GetLength(0);
    int countColumn = array.GetLength(1);

    int number = 0;
    int layer;
    for (int i = 0; i < (Math.Min(countRow, countColumn) + 1) / 2; i++)
    {
        layer = i + 1;
        FillSquare(array, layer, ref number);
    }

}




//--------------------------------------------
string? working = "Y";
while (working.ToLower() == "Y".ToLower())
{
    Console.Clear();
    task = SelectionTask(tasks, countTasks);
    if (task == 1)
    {
        int countRow = SetNumber("Введите количество строк в массиве: ");
        int countColumn = SetNumber("Введите количество столбцов в массиве: ");
        int[,] array = CreateRandomInt2DArray(countRow, countColumn, 0, 10);
        PrintIntArray2D(array, 2);
        Console.WriteLine();
        SortRowsArrayDescend(array);
        Console.WriteLine("Массив с отсортированными по убаванию строками:");
        PrintIntArray2D(array, 2);
        Console.WriteLine();
    }
    else if (task == 2)
    {
        int countRow = SetNumber("Введите количество строк в массиве: ");
        int countColumn = SetNumber("Введите количество столбцов в массиве: ");
        int[,] array = CreateRandomInt2DArray(countRow, countColumn, 0, 10);
        PrintIntArray2D(array, 2);
        Console.WriteLine();
        int indexMinSumRow = RowMinSum(array);
        Console.WriteLine($"Наименьшая сумма {SumRow(array, indexMinSumRow)} в строке с индексом {indexMinSumRow}\r\n");
    }
    else if (task == 3)
    {
        int countRow = SetNumber("Введите количество строк в 1-м массиве и столбцов во 2-м: ");
        int countColumn = SetNumber("Введите количество столбцов в 1-м массиве и строк во 2-м: ");

        int[,] array1 = CreateRandomInt2DArray(countRow, countColumn, 0, 5);
        Console.WriteLine("Матрица 1:");
        PrintIntArray2D(array1, 2);

        int[,] array2 = CreateRandomInt2DArray(countColumn, countRow, 0, 5);
        Console.WriteLine("Матрица 2:");
        PrintIntArray2D(array2, 2);

        int[,] multArray = MultiplicationMatrix(array1, array2);
        Console.WriteLine("Результат перемножения матриц:");
        PrintIntArray2D(multArray, 4);
    }
    else if (task == 4)
    {
        //int[,] array2 = CreateRandomInt2DArray(6, 6, -10, 10);
        //PrintIntArray2D(array2, 2);
        //int findNumber = SetNumber("Введите искомое число: ");
        //int[] findIndex = FindInArray2D(array2, findNumber);

        //if (findIndex[0] == -1) Console.WriteLine($"Число {findNumber} не найдено");
        //else Console.WriteLine($"Число {findNumber} находится на позиции ({String.Join(",", findIndex)})");
    }
    else if (task == 5)
    {
        int[,] spiralArray = new int[SetNumber("Введите количество строк в массиве: "), SetNumber("Введите количество столбцов в массиве: ")];

        FillSpiralArray2(spiralArray);
        PrintIntArray2D(spiralArray, 5);
    }
    Console.WriteLine("Введите 'Y' для продолжения или любой другой символ для закрытия...");
    working = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(working))
    {
        working = "n";
    }
}