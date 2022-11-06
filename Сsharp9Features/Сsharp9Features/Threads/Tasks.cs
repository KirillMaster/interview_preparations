namespace Сsharp9Features.Threads;

public class Tasks
{
    void Print()
    {
        Console.WriteLine($"Method Print thread ID : {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(200);     // имитация продолжительной работы
        Console.WriteLine("Hello METANIT.COM");
    }
 
    // определение асинхронного метода
    async Task PrintAsync()
    {
        Console.WriteLine("Start PrintAsync"); // выполняется синхронно
        await Task.Run(Print);                // выполняется асинхронно
        Console.WriteLine("End  PrintAsync");
    }   
    
    public async Task Test()
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        await PrintAsync();   // вызов асинхронного метода
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("method Main");
    }
}