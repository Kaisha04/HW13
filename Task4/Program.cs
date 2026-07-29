/*Використовуючи Visual Studio, створіть проект за шаблоном Console Application. Напишіть програму, в якій метод викликатиметься рекурсивно.
    Кожен новий виклик методу виконується окремому потоці.*/

using System;

namespace Task4;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Test.Recurs(1);
    }
}

static class Test
{

    public static void Recurs(object i) 
    {
        int tempI = (int)i;
        Thread thisThread = Thread.CurrentThread;
        thisThread.Name = tempI.ToString();
        Console.WriteLine($"Поток номер - {thisThread.Name}");
        if (tempI == 100) return;
        Thread thread = new Thread(Recurs);
        thread.Start(tempI + 1);
    }
}