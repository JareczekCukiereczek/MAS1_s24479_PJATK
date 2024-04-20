namespace MAS1;
public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; } // Atrybut złozony
    public string ISBN { get; set; }// Atrybut obiektowy
    public static string Material = "Paper";// Atrubut klasowy - wspolny
    public List<string> LanguagesOfBooks = new List<string>() { "ENG", "Pl", "GER", "SPA" };//Atrybyt powtrzalny
    public int? RatingAllBooks { get; set; }// Atrybut opcjonalny ocena książki/pochodny
    public bool HasIllustrations { get; set; }// Atrybut opcjonalny
    public DateTime AddedDate { get; set; }
    private DateTime _salesDeadline;

    public DateTime SalesDeadline
    {
        get => _salesDeadline;
        set
        {
            if (value >= AddedDate) // Sprawdzenie czy data sprzedaży jest równa lub późniejsza niż data dodania
                _salesDeadline = value;
            else
                Console.WriteLine("Sales deadline cannot be earlier than the added date.");
        }
    }
    public int DaysUntilDeadline => (int)(SalesDeadline - AddedDate).TotalDays; // Liczba dni do terminu sprzedaży

    public int Year { get; set; }
    
    // atytbut opcjonalny - nei wszystkie ksiazki maja  np.ilustracje                       +         
    // atrybut powtarzlny - cos co jest kilka - lista - w kilku językach                    + 
    // atrybut wspolny dla wszystkich ksiązek - material = paper statick atrybt - dodany    + 
    //atrybut pochodny - wyliczalny z pozostałych dwóch - najlepiej w getterze wyliczać     +
    //atrubt ocena ksiąki                                                                   +
    

    public Book(string title, Author author, string isbn, int year)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Year = year;
        AddedDate = DateTime.Now;
        SalesDeadline = AddedDate.AddDays(365);// Domyślnie ustawiamy termin sprzedaży na rok od daty dodania
    }

    public void SetSalesDeadline(DateTime deadline)
    {
        SalesDeadline = deadline;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Year: {Year}, Added Date: {AddedDate.ToString("dd-MM-yyyy")}, Days Until Sales Deadline: {DaysUntilDeadline}, Rating: {(RatingAllBooks.HasValue ? RatingAllBooks.ToString() : "Not rated")}, Has Illustrations: {HasIllustrations}";
    }
}