using System.Text.Json;

namespace MAS1;
public class Library
{
    public static List<Book> Books { get; set; } = new List<Book>(); // ekstensja 
    

    public void AddBook(Book book) => Books.Add(book);
    public void RemoveBook(Book book) => Books.Remove(book);
    public void ShowBooks()
    {
        int i = 1;
        foreach (var book in Books)
        {
            Console.WriteLine($"{i}. Tytul: {book.Title}, Autor: {book.Author}, ISBN: {book.ISBN}, Rok: {book.Year}, Data dodania: {book.AddedDate.ToString("dd-MM-yyyy")}, Ilosc dni dopuszczenia do sprzedazy: {book.DaysUntilDeadline}, Ocena: {(book.RatingAllBooks.HasValue ? book.RatingAllBooks.ToString() : "Brak oceny")}, Ma ilustracje: {book.HasIllustrations}");
            Console.WriteLine("");
            i++;
        }
    }

    public double CalcAvg()
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

    
    public string SerialLiB() => JsonSerializer.Serialize(Books);
    public void DeserialLib(string json)
    {
        if (!string.IsNullOrWhiteSpace(json))
            Books.AddRange(JsonSerializer.Deserialize<List<Book>>(json));
    }

    // Zapis
    public void SaveLibToFile()
    {
        var pathToFile = "/Users/kuba/Documents/MAS/MAS1/MAS1/MAS1/LibraryExtent.txt";
        File.WriteAllText(pathToFile, SerialLiB());
    }

   //Odczyt
    public static Library InitLibFromFile()
    {
        var library = new Library();
        var filePath = "/Users/kuba/Documents/MAS/MAS1/MAS1/MAS1/LibraryExtent.txt";

        if (File.Exists(filePath))
        {
            library.DeserialLib(File.ReadAllText(filePath));
        }
        else
        {
            Console.WriteLine("LibraryExtent.txt nie istnieje lub jest pusty. Stworz nowa biblioteke.");
        }

        return library;
    }
    
    public void RemoveBook(int index)
    {
        if (index < 0 || index >= Books.Count)
        {
            Console.WriteLine("Zly index.");
            return;
        }

        Books.RemoveAt(index);
        Console.WriteLine("Ksiazka usunieta poprawnie!");
    }

    public void RemoveBook(string title)
    {
        var bookToRemove = Books.FirstOrDefault(book => book.Title.Equals(title));
        if (bookToRemove != null)
        {
            Books.Remove(bookToRemove);
            Console.WriteLine("Ksiazka usunieta poprawnie!");
        }
        else
        {
            Console.WriteLine("Nie znaleziono ksiazki.");
        }
    }

}
