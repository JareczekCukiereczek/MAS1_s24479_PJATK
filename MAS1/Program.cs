namespace MAS1
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = Library.InitializeLibraryFromFile();
            MainLoop(library);
            library.SaveLibraryToFile();
        }

        static void MainLoop(Library library)
        {
            bool loop = true;
            do
            {
                Console.WriteLine("1. Show all books");
                Console.WriteLine("2. Add a book");
                Console.WriteLine("3. Remove a book");
                Console.WriteLine("4. Show average books rating");
                Console.WriteLine("5. Save and exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        library.ShowAllBooks();
                        break;
                    case 2:
                        AddBook(library);
                        break;
                    case 3:
                        RemoveBook(library);
                        break;
                    case 4:
                        var averageRating = library.CalculateAverageRating();
                        Console.WriteLine($"Average rating of all rated books: {averageRating}");
                        break;
                    case 5:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            } while (loop);
        }

        static void AddBook(Library library)
        {
            Console.WriteLine("Title: ");
            var title = Console.ReadLine();
            Console.WriteLine("Author: ");
            var authorName = Console.ReadLine();
            var author = new Author(authorName);
            Console.WriteLine("ISBN: ");
            var isbn = Console.ReadLine();
            Console.WriteLine("Year: ");
            var year = int.Parse(Console.ReadLine());
            Console.WriteLine("Rating - optional(non-rating - press space): ");
            int? rating = null;
            int parsedRating;
            if (int.TryParse(Console.ReadLine(), out parsedRating))
            {
                rating = parsedRating;
            }
            Console.WriteLine("Has illustrations (True/False): ");
            var hasIllustrations = bool.Parse(Console.ReadLine());

            var newBook = new Book(title, author, isbn, year)
            {
                RatingAllBooks = rating,
                HasIllustrations = hasIllustrations
            };
            library.AddBook(newBook);
        }

        static void RemoveBook(Library library)
        {
            library.ShowAllBooks();
            Console.WriteLine("Enter the number of the book to remove: ");
            var bookNumber = int.Parse(Console.ReadLine());

            if (bookNumber < 1 || bookNumber > Library.Books.Count)
            {
                Console.WriteLine("Invalid number");
                return;
            }

            library.RemoveBook(Library.Books[bookNumber - 1]);
            Console.WriteLine("Book removed successfully!");
        }
    }
}
