using System;

public abstract class MainClass
{
    protected abstract void InputArray();
    protected abstract void RandomArray();
    public abstract void CreateArray(bool consoleValues = false);
    public abstract void CreateAgain(bool consoleValues = false);
    public abstract void middleValue();
    public abstract void Print();

}


sealed class OneDimensional : MainClass //ОДНОМЕРНЫЙ МАССИВ
{
    private Random _random = new Random();
    private int[] _array;
    public OneDimensional(bool consoleValues = false)
    {
        CreateAgain(consoleValues);
    }

    public override void CreateAgain(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }

    public override void Print()
    {
        Print(_array);
    }


    public static void Print(int[] array)//МЕТОД ВЫВОДЯЩИЙ ОДНОМЕРНЫЙ МАССИВ:
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    protected override void CreateArray(bool consoleValues = false)
    {
        Console.WriteLine("Введите размер строки: ");
        int size = int.Parse(Console.ReadLine());
        _array = new int[size];
        if (!consoleValues)
        {
            RandomArray();
        }
        else
        {
            InputArray();
        }
    }

    protected override void RandomArray()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = _random.Next(0, 100);
        }
    }

    protected override void InputArray()
    {
        Console.WriteLine("Введите строку со всеми значениями массива, разделенными пробелами: ");
        string input = Console.ReadLine();
        string[] inputLst = input.Split();
        for (int i = 0; i < _array.Length; i++)
        {
            _array[i] = int.Parse(inputLst[i]);
        }
    }

    public override void middleValue()//МЕТОД ВЫВОДЯЩИЙ СРЕДНЕЕ ЗНАЧЕНИЕ МАССИВА:
    {
        Console.WriteLine("\nTask 1");
        int counter = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            counter += _array[i];
        }
        Console.WriteLine(counter / _array.Length);
    }

    public void GetRidofValue()//МЕТОД УДАЛЕНИЯ ЭЛЕМЕНТОВ БОЛЬШЕ 100 ПО МОДУЛЮ:
    {
        Console.WriteLine("\nTask 2");
        int counter = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (Math.Abs(_array[i]) < 100)
            {
                counter += 1;
            }
        }
        int[] newArr = new int[counter];
        int j = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            if (Math.Abs(_array[i]) < 100)
            {
                newArr[j] = _array[i];
                j++;
            }
        }
        foreach (var item in newArr)
        {
            Console.WriteLine(item);
        }
    }

    public void NonRepeat()//МЕТОД БЕЗ ПОВТОРА:
    {
        Console.WriteLine("\nTask 3");
        int newArrayLength = _array.Length;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = i; j < _array.Length; j++)
            {
                if (_array[i] == _array[j] && i != j)
                {
                    newArrayLength--;
                    break;
                }
            }
        }
        int[] newArray = new int[newArrayLength];
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = int.MinValue;
        }
        int counter = 0;

        for (int i = 0; i < _array.Length; i++)
        {
            if (!Exists(_array[i], newArray))
            {
                newArray[counter] = _array[i];
                counter++;
            }
        }
        PrintArray(newArray);
    }
    private static bool Exists(int value, int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }
}

sealed class TwoDimensional : MainClass //ДВУМЕРНЫЙ МАССИВ
{
    private Random random = new Random();
    private int[,] _array;
    public TwoDimensional(bool consoleValues = false)
    {
        CreateAgain(consoleValues);
    }

    public override void CreateAgain(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }

    protected override void CreateArray(bool consoleValues = false)
    {
        Console.WriteLine("Введите количество строк массива: ");
        int line = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество столбцов массива: ");
        int column = int.Parse(Console.ReadLine());
        _array = new int[line, column];
        if (!consoleValues)
        {
            RandomArray();
        }
        else
        {
            InputArray();
        }
    }

    protected override void InputArray()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            Console.WriteLine("Введите значения в 1 строку в 1 строке с пробелами между элементами: ");
            string input = Console.ReadLine();
            string[] input_lst = input.Split();
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = int.Parse(input_lst[j]);
            }
        }
        Console.WriteLine();
    }





    protected override void RandomArray()
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                _array[i, j] = random.Next(0, 100);
            }
        }
    }



    public override void middleValue()//СРЕДНЕЕ ЗНАЧЕНИЕ ДВУМЕРНОГО МАССИВА:
    {
        Console.WriteLine("\nTask 4");
        int summ = 0;
        foreach (int number in _array)
        {
            summ += number;
        }
        decimal avg = summ / _array.Length;
        Console.WriteLine($"Average = {avg}");
    }

    public override void Print() //ВЫВОД ДВУМЕРНОГО  МАССИВА:
    {
        Console.WriteLine("Вывод массива:");

        for (int x = 0; x < _array.GetLength(0); x++)
        {
            for (int y = 0; y < _array.GetLength(1); y++)
            {
                Console.Write(_array[x, y] + " ");
            }
            Console.WriteLine(" ");
        }

    }

    public void PrintSnake()
    {
        Console.WriteLine("\nTask 5");
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                Console.Write($"{_array[i, j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Введите массив с перевернутыми четными строками:");
        PrintReverseLines();
    }

    private void PrintReverseLines() //ЭЛЕМЕНТЫ ЧЕТНЫХ СТРОК НАОБОРОТ
    {
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            string line = "";
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                if (j != _array.GetLength(1) - 1)
                {
                    line += _array[i, j].ToString() + " ";
                }
                else
                {
                    line += _array[i, j].ToString();
                }
            }
            if (i % 2 == 0)
            {
                line = Reverse(line);
            }
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

    public string Reverse(string s)
    {
        string reversed = "";
        string[] s_split = s.Split(' ');
        for (int k = s_split.Length - 1; k >= 0; k--)
        {
            reversed += s_split[k] + " ";
        }
        return reversed;
    }
}


sealed class StepArray : MainClass //СТУПЕНЧАТЫЙ МАССИВ:
{
    private Random _random = new Random();
    private int[][] _array;
    public StepArray(bool consoleValues = false)
    {
        CreateAgain(consoleValues);
    }

    public override void CreateAgain(bool consoleValues = false)
    {
        CreateArray(consoleValues);
    }

    protected override void CreateArray(bool consoleValues = false)
    {
        Console.WriteLine("Введите количество массивов в большом массиве: ");
        int size = int.Parse(Console.ReadLine());
        _array = new int[size][];
        if (!consoleValues)
        {
            RandomArray();
        }
        else
        {
            InputArray();
        }
    }

    protected override void InputArray()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            Console.WriteLine("Введите размер внутреннего массива: ");
            int size = int.Parse(Console.ReadLine());
            _array[i] = new int[size];
            Console.WriteLine("Введите значения 1 внутреннего массива в 1 строку с пробелами между элементами: ");
            string input = Console.ReadLine();
            string[] input_lst = input.Split();
            for (int j = 0; j < _array[i].Length; j++)
            {
                _array[i][j] = int.Parse(input_lst[j]);
            }
        }
    }
    protected override void RandomArray()
    {
        for (int i = 0; i < _array.Length; i++)
        {
            Console.WriteLine("Введите размер внутреннего массива: ");
            int size = int.Parse(Console.ReadLine());
            _array[i] = new int[size];
            for (int j = 0; j < _array[i].Length; j++)
            {
                _array[i][j] = _random.Next(1, 100);
            }
        }
    }

    public override void Print()
    {
        Print(_array);
    }

    public void FillRandom()// МЕТОД ЗАПОЛНЕНИЯ МАССИВА СЛУЧАЙНЫМИ ЧИСЛАМИ:
    {
        Console.WriteLine("\nTask 6");
        Random random = new Random();
        for (int x = 0; x < _array.Length; x++)
        {
            for (int y = 0; y < _array[x].Length; y++)
            {
                _array[x][y] = random.Next(0, 10);
            }
        }
    }

    public override void Print()//ВЫВОД СТУПЕНЧАТОГО МАССИВА:
    {
        Console.WriteLine("Вывод массива:");

        for (int x = 0; x < _array.Length; x++)
        {
            for (int y = 0; y < _array[x].Length; y++)
            {
                Console.Write(_array[x][y] + " ");
            }
            Console.WriteLine(" ");
        }

    }

    public void FillKeyboard()//МЕТОД ВВОДА С КЛАВИАТУРЫ:
    {
        Console.WriteLine("Ввод с клавиатуры:");

        for (int x = 0; x < _array.Length; x++)
        {
            for (int y = 0; y < _array[x].Length; y++)
            {
                Console.Write($"[{x}][{y}] = ");
                _array[x][y] = int.Parse(Console.ReadLine());
            }
        }

    }

    public override void middleValue()// СРЕДНЕЕ ЗНАЧЕНИЕ В МАССИВЕ:
    {
        Console.WriteLine("\nTask 6");
        for (int i = 0; i < _array.Length; i++)
        {
            int summ = 0;
            for (int j = 0; j < _array[i].Length; j++)
            {
                summ += _array[i][j];
            }
            decimal avg = summ / _array[i].Length;
            Console.WriteLine($"Average of values in {i} inner array = {avg}");
        }
        middleValueOfAll();
    }

    private void middleValueOfAll()// СРЕДНЕЕ ЗНАЧЕНИЕ ВО ВСЕХ МАССИВАХ:
    {
        Console.WriteLine("\nTask 7");
        int summ = 0;
        int totalLength = 0;
        for (int i = 0; i < _array.Length; i++)
        {
            for (int j = 0; j < _array[i].Length; j++)
            {
                summ += _array[i][j];
                totalLength++;
            }
        }
        decimal avg = summ / totalLength;
        Console.WriteLine($"Среднее значение всех элементов массива = {avg}");
    }

    public void ChangeEvenNumbers()// ИЗМЕНЕНИЕ ВСЕХ ЧЕТНИХ ПО ЗНАЧЕНИЮ ЭЛЕМЕНТА МАССИВА НА ПРОИЗВЕДЕНИЯ ИХ ИНДЕКСОВ:
    {
        Console.WriteLine("\nTask 8");
        int[][] newArray = new int[_array.Length][];
        Array.Copy(_array, newArray, _array.Length);
        for (int i = 0; i < _array.Length; i++)
        {
            for (int y = 0; y < _array[i].Length; y++)
            {
                if (_array[i][y] % 2 == 0)
                {
                    newArray[i][y] = i * y;
                }
            }
        }
        Print(newArray);
    }
}

