using System.Text.Json;

namespace MAS1;
public class Library
{
    public static List<Book> Books { get; set; } = new List<Book>(); // ekstensja

    public void AddBook(Book book) => Books.Add(book);
    public void RemoveBook(Book book) => Books.Remove(book);
    public void ShowAllBooks()
    {
        int i = 1;
        foreach (var book in Books)
        {
            Console.WriteLine($"{i}. {book}");
            Console.WriteLine("");
            i++;
        }
    }
    //wylicz srednią ocene wszydstkich ksiązek
    //przeciązenie - metoda ta sama nazwa inna liczba argumentów
    public string SerializeLibrary() => JsonSerializer.Serialize(Books);
    public void DeserializeLibrary(string json)
    {
        if (!string.IsNullOrWhiteSpace(json))
            Books.AddRange(JsonSerializer.Deserialize<List<Book>>(json));
    }
}