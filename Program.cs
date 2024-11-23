namespace Task3
{
    class Book
    {
        string Title;
        string Auther;
        string ISBN;
        bool Availability;
        int Frequency;
        public Book(string title="none", string auther="unknown", string ISBN="",bool availability=true)
        {
            this.Title = title;
            this.Auther = auther;
            this.ISBN = ISBN;
            this.Availability = availability;
            Frequency = 0;
        }
        public void SetTitle(string title)
        {
            this.Title = title;
        }
        public string GetTitle()
        {
            return this.Title;
        }
        public void SetAuther(string auther)
        {
            this.Auther= auther;
        }
        public string GetAuther()
        {
            return this.Auther;
        }
        public void SetISBN(string isbn)
        {
            this.ISBN = isbn;
        }
        public string GetISBN()
        {
            return this.ISBN;
        }
        public void SetAvailability(bool availability)
        {
            this.Availability = availability;
        }
        public bool GetAvailability()
        {
            return this.Availability;
        }
        public void IncrementFrequency()
        {
            this.Frequency++;
        }
        public void DecrementFrequency()
        {
            if (this.Frequency > 1)
            {
                this.Frequency--;
            }
        }
        public int GetFrequency()
        { 
            return this.Frequency;
        }

    }
    class Library
    {
        List<Book> CollectionOfbooks;
        public Library()
        {
            CollectionOfbooks = new List<Book>();
        }
        public void AddBook(Book book)
        {
            if (CollectionOfbooks.Count() == 0)
            {
                CollectionOfbooks.Add(book);
            }
            else
            {
                bool IsFreq = false;
                for (int i = 0; i < CollectionOfbooks.Count(); i++)
                {
                    if (CollectionOfbooks[i].GetTitle() == book.GetTitle())
                    {
                        CollectionOfbooks[i].IncrementFrequency();
                        IsFreq = true;

                        break;
                    }
                }
                if (IsFreq == false)
                {
                    book.IncrementFrequency();
                    CollectionOfbooks.Add(book);
                }
            }
            Console.WriteLine("The book has been added");
        }
        public Book SearchBookByTitle(string title)
        {
            Book book=new Book();
            for (int i = 0; i < CollectionOfbooks.Count(); i++)
            {
                if(CollectionOfbooks[i].GetTitle() == title)
                {
                    book = CollectionOfbooks[i];
                    break;
                }
            }
            return book;
        }
        public Book SearchBookByAuther(string auther)
        {
            Book book = new Book();
            for (int i = 0; i < CollectionOfbooks.Count(); i++)
            {
                if (CollectionOfbooks[i].GetAuther() == auther)
                {
                    book = CollectionOfbooks[i];
                    break;
                }
            }
            return book;
        }
        public void BorrowBook(string bookName)
        {
            for (int i = 0; i < CollectionOfbooks.Count(); i++)
            {
                if (CollectionOfbooks[i].GetTitle()==bookName)
                {
                    if(CollectionOfbooks[i].GetFrequency()>1)
                    {
                        CollectionOfbooks[i].DecrementFrequency();
                    }
                    else if(CollectionOfbooks[i].GetFrequency() == 1)
                    {
                        CollectionOfbooks[i].DecrementFrequency();
                        CollectionOfbooks[i].SetAvailability(false);
                    }
                    else
                    {
                        Console.WriteLine("I am sorry, This book is not available now");
                    }
                    break;

                }
            }
        }
        public void ReturnBook(string bookName)
        {
            bool IsExist=false;
            for (int i = 0; i < CollectionOfbooks.Count(); i++)
            {
                if (CollectionOfbooks[i].GetTitle() == bookName)
                {
                    IsExist=true;
                    if (CollectionOfbooks[i].GetFrequency() >= 1)
                    {
                        CollectionOfbooks[i].IncrementFrequency();
                    }
                    if(CollectionOfbooks[i].GetFrequency() == 0)
                    {
                        CollectionOfbooks[i].SetAvailability(true);
                        CollectionOfbooks[i].IncrementFrequency();
                    }
                    break;
                }
            }
            if(IsExist==false)
            {
                Console.WriteLine("This book is not Borrowed");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
