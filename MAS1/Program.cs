using System.Globalization;

namespace MAS1
{
    class Program{
        static void Main(string[] args){
            var lib = Library.InitLibFromFile();
            MainLoop(lib);
            lib.SaveLibToFile();
        }

        static void MainLoop(Library library){
            bool loop = true;
            do
            {
                Console.WriteLine("1. Pokaz ksiazki");
                Console.WriteLine("2. Dodaj ksiazki");
                Console.WriteLine("3. Usun ksiazki");
                Console.WriteLine("4. Pokaz srednia ocene ksiazek");
                Console.WriteLine("5. Zapisz i wyjdz");
                Console.Write("Wybierz numer: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Zly numer. Wprowadz poprawny numer.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        library.ShowBooks();
                        break;
                    case 2:
                        AddBook(library);
                        break;
                    case 3:
                        RemoveBook(library);
                        break;
                    case 4:
                        var averageRating = library.CalcAvg();
                        Console.WriteLine($"Srednia ocena ksiazek: {averageRating}");
                        break;
                    case 5:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Zly numer - wprowadz poprawny.");
                        break;
                }
                Console.WriteLine("Nacisij enter aby kontynuowac...");
                Console.ReadLine();
                Console.Clear();
            } while (loop);
        }

        static void AddBook(Library library)
        {
            Console.WriteLine("Tytul: ");
            var title = Console.ReadLine();
            Console.WriteLine("Autor: ");
            var authorName = Console.ReadLine();
            var author = new Author(authorName);
            Console.WriteLine("ISBN: ");
            var isbn = Console.ReadLine();
            Console.WriteLine("Rok: ");
            var year = int.Parse(Console.ReadLine());
            Console.WriteLine("Deadline sprzedazy (yyyy-MM-dd): ");
            DateTime salesDeadline;
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out salesDeadline))
            {
                Console.WriteLine("Zly format - wprowadz poprawny yyyy-MM-dd:");
            }
            Console.WriteLine("Ocena - opcjonalna (Enter jak bez oceny): ");
            int? rating = null;
            int parsedRating;
            if (int.TryParse(Console.ReadLine(), out parsedRating))
            {
                rating = parsedRating;
            }
            Console.WriteLine("Ma obrazki ? (True/False, enter aby kontynuowac): ");
            bool hasIllustrations;
            if (!bool.TryParse(Console.ReadLine(), out hasIllustrations))
            {
                hasIllustrations = false; 
            }

            var newBook = new Book(title, author, isbn, year)
            {
                RatingAllBooks = rating,
                HasIllustrations = hasIllustrations
            };
            newBook.SetSalesDeadline(salesDeadline);
            library.AddBook(newBook);
        }


        static void RemoveBook(Library library)
        {
            Console.WriteLine("1. Usun wg. index");
            Console.WriteLine("2. Usun wg. title");
            Console.Write("Wprowadz numer: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Zly numer. Wprowadz poprawny.");
                return;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Wprowadz index do usuniecia: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        library.RemoveBook(index-1);
                    }
                    else
                    {
                        Console.WriteLine("Zly index. Wprowadz poprawny.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Wprowadz tytul do usuniecia: ");
                    string title = Console.ReadLine();
                    library.RemoveBook(title);
                    break;
                default:
                    Console.WriteLine("Zly wybor. Wprowadz numer pomiedzy 1 - 3.");
                    break;
            }
        }
    }
}
