namespace MAS1;
class Program
    {
        static void Main(string[] args)
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

            var loop = true;
            while (loop)
            {
                Console.WriteLine("1. Show all books");
                Console.WriteLine("2. Add a book");
                Console.WriteLine("3. Remove a book");
                Console.WriteLine("4. Save and exit");
                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        library.ShowAllBooks();
                        break;
                    case 2:
                        Console.WriteLine("Title: ");
                        var title = Console.ReadLine();
                        Console.WriteLine("Author: ");
                        var authorName = Console.ReadLine();
                        var author = new Author(authorName);
                        Console.WriteLine("ISBN: ");
                        var isbn = Console.ReadLine();
                        Console.WriteLine("Year: ");
                        var year = int.Parse(Console.ReadLine());

                        var newBook = new Book(title, author, isbn, year);
                        library.AddBook(newBook);
                        break;
                    case 3:
                        library.ShowAllBooks();
                        Console.WriteLine("Enter the number of the book to remove: ");
                        var bookNumber = int.Parse(Console.ReadLine());

                        if (bookNumber < 1 || bookNumber >= Library.Books.Count)
                        {
                            Console.WriteLine("Invalid number");
                            break;
                        }

                        library.RemoveBook(Library.Books[bookNumber - 1]);
                        Console.WriteLine("Book removed successfully!");
                        break;
                    case 4:
                        loop = false;
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
            File.WriteAllText(filePath, library.SerializeLibrary());
        }
    }



