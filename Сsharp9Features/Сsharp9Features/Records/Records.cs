namespace Сsharp9Features.Records;

public class Records
{
    public record Person(string FirstName, string LastName);
    public void Test()
    {

        var p1 = new Person("Kirill", "s");
        var p2 = p1;
        

    }
}