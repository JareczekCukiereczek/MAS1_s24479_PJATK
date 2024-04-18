namespace MAS1;
public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; } // Atrybut złozony
    public string ISBN { get; set; } // Atrybut obiektowy

    public static string Material = "Paper"; // Atrubut klasowy - wspolny

    public List<string> LanguagesOfBooks = new List<string>(){"ENG", "Pl","GER","SPA"}; //Atrybyt powtrzalny
    
    public int OptionalRateBook { get; set; } //wyliczanie średniej
    
    // atytbut opcjonalny - nei wszystkie ksiazki maja                                      
    // atrybut powtarzlny - cos co jest kilka - lista - w kilku językach                    + 
    // atrybut wspolny dla wszystkich ksiązek - material = paper statick atrybt - dodany    + 
    //atrybut pochodny - wyliczalny z pozostałych dwóch - najlepiej w getterze wyliczać
    //atrubt ocena ksiąki 
    public int Year { get; set; }

    public Book(string title, Author author, string isbn, int year)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Year = year;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Year: {Year}";
    }
}
