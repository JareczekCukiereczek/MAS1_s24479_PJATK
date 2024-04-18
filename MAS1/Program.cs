namespace MAS1;
class Program
    {
        static void Main(string[] args)
        {
            var library = InitializeLibrary();
            MainLoop(library);
            SaveLibrary(library);
        }

        static Library InitializeLibrary()
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

        static void MainLoop(Library library)
        {
            bool loop = true;
            do
            {
                Console.WriteLine("1. Show all books");
                Console.WriteLine("2. Add a book");
                Console.WriteLine("3. Remove a book");
                Console.WriteLine("4. Save and exit");
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
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
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

            var newBook = new Book(title, author, isbn, year);
            library.AddBook(newBook);
        }

        static void RemoveBook(Library library)
        {
            library.ShowAllBooks();
            Console.WriteLine("Enter the number of the book to remove: ");
            var bookNumber = int.Parse(Console.ReadLine());

            if (bookNumber < 1 || bookNumber >= Library.Books.Count)
            {
                Console.WriteLine("Invalid number");
                return;
            }

            library.RemoveBook(Library.Books[bookNumber - 1]);
            Console.WriteLine("Book removed successfully!");
        }

        static void SaveLibrary(Library library)
        {
            var filePath = "/Users/kuba/Documents/MAS/MAS1/MAS1/MAS1/LibraryExtent.txt";
            File.WriteAllText(filePath, library.SerializeLibrary());
        }
    }



