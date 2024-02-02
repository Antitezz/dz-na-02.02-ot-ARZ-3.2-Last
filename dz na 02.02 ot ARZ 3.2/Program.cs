using System;

class Base
{
    static void Main()
    {
        Console.WriteLine("Нужно ли вам случайно сгенерировать значения в массиве?");
        string getCreationType = Console.ReadLine();
        bool consoleValues = false;
        if (getCreationType == "no")
        {
            consoleValues = true;
        }
        ArrayBase[] arrayBase = new ArrayBase[3];
        arrayBase[0] = new OneDimensional(consoleValues);
        arrayBase[1] = new TwoDimensional(consoleValues);
        arrayBase[2] = new StepArray(consoleValues);
        for (int i = 0; i<arrayBase.Length; i++)
        {
            arrayBase[i].middleValue();
            arrayBase[i].Print();
            Console.WriteLine();
        }
        arrayBase[1].CreateAgain(consoleValues);
        arrayBase[1].Print();
    }
}

