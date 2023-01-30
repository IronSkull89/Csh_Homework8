using System.Data.Common;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

int countTasks = 5;
int task;

string[] tasks = new string[countTasks];
tasks[0] = "1. Задайте двумерный массив. Программа, которая упорядочит по убыванию элементы каждой строки двумерного массива.";
tasks[1] = "2. Задайте прямоугольный двумерный массив. Программа, которая будет находить строку с наименьшей суммой элементов.";
tasks[2] = "3. Задайте две матрицы. Программа, которая будет находить произведение двух матриц.";
tasks[3] = "4. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Программа, которая будет построчно выводить массив, добавляя индексы каждого элемента.";
tasks[4] = "5. Программа, которая заполнит спирально массив 4 на 4.";


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

int SetNumber(string greet)
{
    Console.Write(greet);
    if (!int.TryParse(Console.ReadLine(), out int number)) number = SetNumber(greet);
    return number;
}

void Ordering(int minValue, int maxValue)
{
    if (minValue > maxValue)
    {
        int temp = minValue;
        minValue = maxValue;
        maxValue = temp;
    }
}

int[,] CreateRandomInt2DArray(int row, int column, int minValue, int maxValue)
{
    int[,] array = new int[row, column];

    Ordering(minValue, maxValue);

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

void PrintIntArray2D(int[,] array, int widthColumn)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(String.Format("{0," + -widthColumn + "}", array[i, j]));
        }
        Console.WriteLine();
        
    }
}

void PrintIntArray3DWithIndex(int[,,] array, int widthColumn)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write(String.Format("{0," + -widthColumn + "}", array[i, j, k] + $"({i},{j},{k})"));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }      
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

void FourthTask(int minValue, int maxValue) {
    int countTube = SetNumber("Введите количество строк в массиве: ");
    int countRow = SetNumber("Введите количество столбцов в массиве: ");
    int countColumn = SetNumber("Введите количество листов в массиве: ");

    if (VerificationCreateRandomNoRepeatInt3DArray(countTube, countRow, countColumn, minValue, maxValue))
    {
        int[,,] array = CreateRandomNoRepeatInt3DArray(countTube, countRow, countColumn, minValue, maxValue);
        Console.WriteLine();
        PrintIntArray3DWithIndex(array, 10);
    }
    else FourthTask(minValue, maxValue);
}

bool VerificationCreateRandomNoRepeatInt3DArray(int tube, int row, int column, int minValue, int maxValue) 
{
    Ordering(minValue, maxValue);

    int randomCount = maxValue - minValue + 1;

    if (tube * row * column > randomCount)
    {
        Console.WriteLine("Размерность массива больше возможной, для заполнения её неповторяющимися значениями из выбранного диапазона");
        return false;
    }
    else return true;
}

int[,,] CreateRandomNoRepeatInt3DArray(int tube, int row, int column, int minValue, int maxValue)
{
    int randomCount = maxValue - minValue + 1;

    int[,,] array = new int[tube, row, column];

    int[] randomNumbers = new int[randomCount];
    int indexRandomNumber;

    for (int i = 0; i < randomCount; i++)
    {
        randomNumbers[i] = i + minValue;
    }

    Random random = new Random();

    int countNumber = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                indexRandomNumber = random.Next(0, randomCount - countNumber);
                array[i, j, k] = randomNumbers[indexRandomNumber];
                randomNumbers[indexRandomNumber] = randomNumbers[randomCount - countNumber - 1];
                countNumber++;
            }
        }
    }
    return array;
}

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
        int[,] array = CreateRandomInt2DArray(SetNumber("Введите количество строк в массиве: "), SetNumber("Введите количество столбцов в массиве: "), 0, 10);
        PrintIntArray2D(array, 4);
        Console.WriteLine();
        SortRowsArrayDescend(array);
        Console.WriteLine("Массив с отсортированными по убаванию строками:");
        PrintIntArray2D(array, 4);
    }
    else if (task == 2)
    {
        int[,] array = CreateRandomInt2DArray(SetNumber("Введите количество строк в массиве: "), SetNumber("Введите количество столбцов в массиве: "), 0, 10);
        Console.WriteLine();
        PrintIntArray2D(array, 4);
        Console.WriteLine();
        int indexMinSumRow = RowMinSum(array);
        Console.WriteLine($"Наименьшая сумма {SumRow(array, indexMinSumRow)} в строке с индексом {indexMinSumRow}");
    }
    else if (task == 3)
    {
        int countRow = SetNumber("Введите количество строк в 1-м массиве (столбцов во 2-м соответственно): ");
        int countColumn = SetNumber("Введите количество столбцов в 1-м массиве (строк во 2-м ссоответственно): ");

        int[,] array1 = CreateRandomInt2DArray(countRow, countColumn, 0, 5);
        Console.WriteLine("Матрица 1:");
        PrintIntArray2D(array1, 4);

        int[,] array2 = CreateRandomInt2DArray(countColumn, countRow, 0, 5);
        Console.WriteLine("Матрица 2:");
        PrintIntArray2D(array2, 4);

        int[,] multArray = MultiplicationMatrix(array1, array2);
        Console.WriteLine("Результат перемножения матриц:");
        PrintIntArray2D(multArray, 6);
    }
    else if (task == 4)
    {
        int minValue = 10;
        int maxValue = 99;
        FourthTask(minValue, maxValue);
    }
    else if (task == 5)
    {
        int[,] spiralArray = new int[SetNumber("Введите количество строк в массиве: "), SetNumber("Введите количество столбцов в массиве: ")];
        //FillSpiralArray(spiralArray);
        FillSpiralArray2(spiralArray);
        PrintIntArray2D(spiralArray, 5);
    }
    Console.WriteLine("\r\nВведите 'Y' для продолжения или любой другой символ для закрытия...");
    working = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(working))
    {
        working = "n";
    }
}