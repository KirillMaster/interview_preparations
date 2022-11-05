namespace Сsharp9Features.PatternMatching;

public class PatternMatching
{
    public void Test()
    {
        var numbers = new int[] { 10, 20, 30 };
        Console.WriteLine(GetSourceLabel(numbers));  // output: 1

        var letters = new List<char> { 'a', 'b', 'c', 'd' };
        Console.WriteLine(GetSourceLabel(letters));  // output: 2

        static int GetSourceLabel<T>(IEnumerable<T> source) => source switch
        {
            Array array => 1,
            ICollection<T> collection => 2,
            _ => 3,
        };
        
        static string GetCalendarSeason(DateTime date) => date.Month switch
        {
            3 or 4 or 5 => "spring",
            6 or 7 or 8 => "summer",
            9 or 10 or 11 => "autumn",
            12 or 1 or 2 => "winter",
            _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
        };
        
        Console.WriteLine(GetCalendarSeason(DateTime.UtcNow));
        
        Console.WriteLine(TakeFive("Hello, world!"));  // output: Hello
        Console.WriteLine(TakeFive("Hi!"));  // output: Hi!
        Console.WriteLine(TakeFive(new[] { '1', '2', '3', '4', '5', '6', '7' }));  // output: 12345
        Console.WriteLine(TakeFive(new[] { 'a', 'b', 'c' }));  // output: abc
        Console.WriteLine(TakeFive(new Records.Records.Person(FirstName: "Kirill", LastName: "test")));

        static string TakeFive(object input) => input switch
        {
            string { Length: >= 5 } s => s.Substring(0, 5),
            string s => s,
            Records.Records.Person {FirstName: "Kirill"} p => "Hi " + p.FirstName,

            ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
            ICollection<char> symbols => new string(symbols.ToArray()),

            null => throw new ArgumentNullException(nameof(input)),
            _ => throw new ArgumentException("Not supported input type."),
        };
    }
}