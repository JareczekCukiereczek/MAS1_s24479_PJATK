namespace MAS1;
public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; } // Atrybut złozony
    public string ISBN { get; set; }// Atrybut obiektowy
    public static string Material = "Papier";// Atrybut klasowy - wspolny
    public List<string> LanguagesOfBooks = new List<string>() { "ENG", "Pl", "GER", "SPA" };//Atrybyt powtrzalny
    public int? RatingAllBooks { get; set; }// Atrybut opcjonalny ocena książki/pochodny
    public bool? HasIllustrations { get; set; }// Atrybut opcjonalny
    public DateTime AddedDate { get; set; }
    private DateTime _salesDeadline;

    public DateTime SalesDeadline
    {
        get => _salesDeadline;
        set
        {
            if (value >= AddedDate) 
                _salesDeadline = value;
            else
                Console.WriteLine("Deadline nie moze byc wczesniejszy niz data dodania.");
        }
    }
    public int DaysUntilDeadline => (int)(SalesDeadline - AddedDate).TotalDays; 

    public int Year { get; set; }
    
    // atytbut opcjonalny - nei wszystkie ksiazki maja  np.ilustracje  lub rating           +         
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
        SalesDeadline = AddedDate.AddDays(365);
    }

    public void SetSalesDeadline(DateTime deadline)
    {
        SalesDeadline = deadline;
    }

    public override string ToString()
    {
        return $"Tytul: {Title}, Autor: {Author}, ISBN: {ISBN}, Rok: {Year}, Data dodania: {AddedDate.ToString("dd-MM-yyyy")}, Ilosc dni dopuszczenia do sprzedazy: {DaysUntilDeadline}, Ocena: {(RatingAllBooks.HasValue ? RatingAllBooks.ToString() : "Brak oceny")}, Ma ilustracje: {HasIllustrations}";
    }
}