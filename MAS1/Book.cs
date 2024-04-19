namespace MAS1;
public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; } // Atrybut złozony
    public string ISBN { get; set; } // Atrybut obiektowy

    public static string Material = "Paper"; // Atrubut klasowy - wspolny
    
    public List<string> LanguagesOfBooks = new List<string>(){"ENG", "Pl","GER","SPA"}; //Atrybyt powtrzalny
    public int? RatingAllBooks { get; set; } // Atrybut opcjonalny ocena książki/pochodny
    
    public bool HasIllustrations { get; set; } // Atrybut opcjonalny

    public DateTime AddedDate { get; set; } // Data dodania książki
    public DateTime SalesDeadline { get; set; } // Termin sprzedaży książki
    public int DaysUntilDeadline => (int)(SalesDeadline - AddedDate).TotalDays; // Liczba dni do terminu sprzedaży

    
    // atytbut opcjonalny - nei wszystkie ksiazki maja  np.ilustracje                       +         
    // atrybut powtarzlny - cos co jest kilka - lista - w kilku językach                    + 
    // atrybut wspolny dla wszystkich ksiązek - material = paper statick atrybt - dodany    + 
    //atrybut pochodny - wyliczalny z pozostałych dwóch - najlepiej w getterze wyliczać  - zrobić aby date sprzedazy ostatniej sameum mozna bylo ustawic 
    //atrubt ocena ksiąki 
    //przeniesc metody do klasy book
    public int Year { get; set; }

    public Book(string title, Author author, string isbn, int year)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Year = year;
        AddedDate = DateTime.Now; // Ustawienie daty dodania na bieżącą datę
        SalesDeadline = new DateTime(2024, 12, 31); // Ustawienie stałego terminu sprzedaży
    }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Year: {Year}, Added Date: {AddedDate.ToString("dd-MM-yyyy")}, Days Until Sales Deadline: {DaysUntilDeadline}, Rating: {(RatingAllBooks.HasValue ? RatingAllBooks.ToString() : "Not rated")}, Has Illustrations: {HasIllustrations}";
    }

}
