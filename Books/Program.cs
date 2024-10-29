namespace Books
{ 

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryContext())
            {
                var service = new LibraryService(context);

                
                int year = 2000;
                int count = service.GetBooksCountBeforeYear(year);
                Console.WriteLine($"Кількість примірників книг, виданих до {year} року: {count}");

                
                string filePath = "books.xml";
                service.SaveBooksToXml(filePath);
                Console.WriteLine($"Дані таблиці збережено у файл {filePath}");
            }
        }
    }

}
