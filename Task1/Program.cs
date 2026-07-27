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
        Console.SetCursorPosition(r.Next(50, 100), 0);
        while (true)
        {
            GetColor();
            int symbol = r.Next(32, 112);
            if (symbol % 2 == 0)
            {
                Console.Write("");
            }else Console.Write((char)symbol);
        }
    }

    public static void GetColor()
    {
        switch(Random.Shared.Next(1,5))
        {
            case 1: Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 2: Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 3: Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
        }
    }
    static void Main()
    {
        Thread firstThread = new Thread(SpawnSymbols);
        Thread secondThread = new Thread(SpawnSymbols);
        Thread thirdThread = new Thread(SpawnSymbols);

        firstThread.Start();
        secondThread.Start();
        thirdThread.Start();
    }
}
