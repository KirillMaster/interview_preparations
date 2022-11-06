namespace Сsharp9Features.Threads;


class Reader
{
    // создаем семафор
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;// счетчик чтения
 
    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Reader {i}";
        myThread.Start();
    }
 
    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();  // ожидаем, когда освободиться место
 
            Console.WriteLine($"{Thread.CurrentThread.Name} enters");
 
            Console.WriteLine($"{Thread.CurrentThread.Name} reads");
            Thread.Sleep(1000);
 
            Console.WriteLine($"{Thread.CurrentThread.Name} leaves");
 
            sem.Release();  // освобождаем место
 
            count--;
            Thread.Sleep(1000);
        }
    }

    public static void Test()
    {
        // запускаем пять потоков
        for (int i = 1; i < 6; i++)
        {
            Reader reader = new Reader(i);
        }
    }
}