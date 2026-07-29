/*Використовуючи Visual Studio, створіть проект за шаблоном Console Application. Розширте завдання 2 так, щоб в одному стовпці одночасно могло бути два ланцюжки символів.
    Дивіться example2.png, представлений як зразок.*/
using System;

namespace Task2;

class Program
{
    static object locker = new();
    public static void SpawnSymbols(object X)
    {
        Random r = new Random();
        int x = (int)X;
        Thread.Sleep(r.Next(10, 5000));
        while (true)
        {
            int y = 0;
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
        switch (value)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 2:
            default:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
        }
    }
    static void Main()
    {


        for (int i = 0; i < 100; i += 2)
        {
            Thread t1 = new Thread(SpawnSymbols);
            Thread t2 = new Thread(SpawnSymbols);

            t1.Start(i);
            t2.Start(i);
        }
    }
}
