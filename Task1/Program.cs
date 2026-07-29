/*Використовуючи Visual Studio, створіть проект за шаблоном Console Application. 
    Створіть програму, яка виводитиме на екран ланцюжки падаючих символів. Довжина кожного ланцюжка визначається випадково. Перший символ ланцюжка – білий, другий символ – світло-зелений, решта символів темно-зелені. 
    Під час падіння ланцюжка на кожному кроці всі символи змінюють своє значення.
    Дійшовши до кінця, ланцюжок зникає і зверху формується новий ланцюжок. Дивіться example1.png представлений як зразок.*/


using System;

namespace Task1;

class Program
{
    static object locker = new();
    public static void SpawnSymbols()
    {
        Random r = new Random();
        while(true)
        {
            int y = r.Next(0,10);
            int x = r.Next(1, 110);
            int countOfSymbols = r.Next(3, 8);
            int valueColor = 0;
            while (y < Console.BufferHeight)
            {
                lock (locker)
                {
                    GetColor(0);
                    Console.SetCursorPosition(x, y);
                    Console.Write($"{(char)r.Next(32, 123)}");

                    if (y - 1 >= 0)
                    {
                        GetColor(1);
                        Console.SetCursorPosition(x, y - 1);
                        Console.Write($"{(char)r.Next(32, 123)}");
                    }

                    GetColor(2);
                    for (int i = 2; i < countOfSymbols; i++)
                    {
                        if (y - i >= 0)
                        {
                            Console.SetCursorPosition(x, y - i);
                            Console.Write($"{(char)r.Next(32, 123)}");
                        }
                        
                    }

                    if (y - countOfSymbols >= 0)
                    {
                        Console.SetCursorPosition(x, y - countOfSymbols);
                        Console.Write(" ");
                    }
                }
                Thread.Sleep(100);
                y++;
            }
        }
    }

    public static void GetColor(int value)
    {
        switch(value)
        {
            case 0: Console.ForegroundColor = ConsoleColor.White;
                break;
            case 1: Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 2:
            default: Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
        }
    }
    static void Main()
    {
        Thread firstThread = new Thread(SpawnSymbols);
        Thread secondThread = new Thread(SpawnSymbols);
        Thread thirdThread = new Thread(SpawnSymbols);

        Thread fourthThread = new Thread(SpawnSymbols);
        Thread fiveThread = new Thread(SpawnSymbols);
        Thread sixThread = new Thread(SpawnSymbols);

        firstThread.Start();
        secondThread.Start();
        thirdThread.Start();
        fourthThread.Start();
        fiveThread.Start();
        sixThread.Start();
    }
}
