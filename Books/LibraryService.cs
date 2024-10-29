using Books;
using System;
using System.Linq;
using System.Xml.Linq;

public class LibraryService
{
    private readonly LibraryContext _context;

    public LibraryService(LibraryContext context)
    {
        _context = context;
    }
       public int GetBooksCountBeforeYear(int year)
    {
        return _context.Books
            .Where(book => book.YearPublished < year)
            .Sum(book => book.CopiesCount);
    }
        public void SaveBooksToXml(string filePath)
    {
        var books = _context.Books
            .Select(book => new
            {
                book.Title,
                book.Author,
                book.YearPublished,
                book.CopiesCount
            })
            .ToList();

        var xml = new XElement("Books",
            books.Select(book => new XElement("Book",
                new XElement("Title", book.Title),
                new XElement("Author", book.Author),
                new XElement("YearPublished", book.YearPublished),
                new XElement("CopiesCount", book.CopiesCount)
            ))
        );

        xml.Save(filePath);
    }
}
