using System;
using System.Threading;

class Program
{
    static int SumOfDigits(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    static void FindLuckyNumbersSequential()
    {
        for (int i = 100000; i < 1000000; i++)
        {
            int firstThreeDigits = i / 1000;
            int lastThreeDigits = i % 1000;
            if (SumOfDigits(firstThreeDigits) == SumOfDigits(lastThreeDigits))
            {
                Console.WriteLine(i);
            }
        }
    }

    static void FindLuckyNumbersParallel()
    {
        for (int i = 100000; i < 1000000; i++)
        {
            int firstThreeDigits = i / 1000;
            int lastThreeDigits = i % 1000;
            if (SumOfDigits(firstThreeDigits) == SumOfDigits(lastThreeDigits))
            {
                Console.WriteLine(i);
            }
        }
    }

    static void Main()
    {
        // Вычисления в одном потоке
        Console.WriteLine("Последовательные вычисления:");
        DateTime startTime = DateTime.Now;
        FindLuckyNumbersSequential();
        DateTime endTime = DateTime.Now;
        TimeSpan sequentialTime = endTime - startTime;
        Console.WriteLine($"Время выполнения: {sequentialTime.TotalMilliseconds} мс");

        // Параллельные вычисления
        Console.WriteLine("Параллельные вычисления:");
        startTime = DateTime.Now;
        Thread thread1 = new Thread(FindLuckyNumbersParallel);
        Thread thread2 = new Thread(FindLuckyNumbersParallel);
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        endTime = DateTime.Now;
        TimeSpan parallelTime = endTime - startTime;
        Console.WriteLine($"Время выполнения: {parallelTime.TotalMilliseconds} мс");
    }
}