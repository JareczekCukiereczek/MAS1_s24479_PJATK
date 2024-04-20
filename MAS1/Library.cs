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
            Console.WriteLine($"{i}. Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Year: {book.Year}, Added Date: {book.AddedDate.ToString("dd-MM-yyyy")}, Days Until Sales Deadline: {book.DaysUntilDeadline}, Rating: {(book.RatingAllBooks.HasValue ? book.RatingAllBooks.ToString() : "Not rated")}, Has Illustrations: {book.HasIllustrations}");
            Console.WriteLine("");
            i++;
        }
    }

    public double CalculateAverageRating()
    {
        if (Books.Count == 0)
        {
            return 0;
        }

        double totalRating = 0;
        int ratedBooksCount = 0;
        foreach (var book in Books)
        {
            if (book.RatingAllBooks.HasValue)
            {
                totalRating += book.RatingAllBooks.Value;
                ratedBooksCount++;
            }
        }

        if (ratedBooksCount == 0)
        {
            return 0;
        }

        return totalRating / ratedBooksCount;
    }

    //przeciązenie - metoda ta sama nazwa inna liczba argumentów
    public string SerializeLibrary() => JsonSerializer.Serialize(Books);
    public void DeserializeLibrary(string json)
    {
        if (!string.IsNullOrWhiteSpace(json))
            Books.AddRange(JsonSerializer.Deserialize<List<Book>>(json));
    }

    // Metoda do zapisywania biblioteki do pliku
    public void SaveLibraryToFile()
    {
        var filePath = "/Users/kuba/Documents/MAS/MAS1/MAS1/MAS1/LibraryExtent.txt";
        File.WriteAllText(filePath, SerializeLibrary());
    }

    // Metoda do inicjalizacji biblioteki z pliku
    public static Library InitializeLibraryFromFile()
    {
        var library = new Library();
        var filePath = "/Users/kuba/Documents/MAS/MAS1/MAS1/MAS1/LibraryExtent.txt";

        if (File.Exists(filePath))
        {
            library.DeserializeLibrary(File.ReadAllText(filePath));
        }
        else
        {
            Console.WriteLine("LibraryExtent.txt does not exist or is empty. Creating a new library.");
        }

        return library;
    }
}
