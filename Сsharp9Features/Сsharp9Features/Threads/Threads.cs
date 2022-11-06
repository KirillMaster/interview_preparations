namespace Сsharp9Features.Threads;

public class Threads
{

    
    
    public void Test()
    {
        var thread = new Thread(new ThreadStart(() =>
        {
            Thread.Sleep(100);
            Console.WriteLine("hello world");
        }));


        thread.Start();
 
    
        Console.WriteLine(thread.Name);
        Console.WriteLine("Bye world");
        Thread.Sleep(200);
        //thread.Interrupt();
  


        Console.ReadLine();
    }
}