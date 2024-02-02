using System;

class Base
{
    static void Main()
    {
        Console.WriteLine("Note: ALWAYS answer with lower case letters");
        Console.WriteLine("Do you want to have randomly generated values in array?");
        string getCreationType = Console.ReadLine();
        bool consoleValues = false;
        if (getCreationType == "no")
        {
            consoleValues = true;
        }
        ArrayBase[] arrayBase = new ArrayBase[3];
        arrayBase[0] = new OneDimensional(consoleValues);
        arrayBase[1] = new TwoDimension(consoleValues);
        arrayBase[2] = new ManyDimension(consoleValues);
        for (int i = 0; i<arrayBase.Length; i++)
        {
            arrayBase[i].Average();
            arrayBase[i].Print();
            Console.WriteLine();
        }
        arrayBase[1].Recreate(consoleValues);
        arrayBase[1].Print();
    }
}

