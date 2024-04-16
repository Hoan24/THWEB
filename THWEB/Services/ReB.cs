using System.Threading;
using THWEB.Data;
using THWEB.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace THWEB.Services
{
    public class ReB : IReponsitoryB
    {
        private readonly AppDbcontext _context;

        public ReB(AppDbcontext context) { _context = context; }
        // Trong class ReB
        public BooksVM AddBookWithAuthors(BooksVM book)
        {
            var newBook = new Books
            {
               
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = book.DateAdded,
                PublisherId = book.PublisherId,
            };

            _context.books.Add(newBook);
            _context.SaveChanges();

            
            return book;
        }
        void IReponsitoryB.DeleteBook(int id)
        {
            var _delete=_context.books.SingleOrDefault(b=>b.BookId == id);
            if( _delete != null)
            {
                _context.Remove(_delete);
                _context.SaveChanges();
            }
        }

        List<BooksVM> IReponsitoryB.GetAllbooks()
        {
            var list = _context.books.Select(b => new BooksVM
            {
                BookId = b.BookId,
                Title = b.Title,
                Description = b.Description,
                IsRead = b.IsRead,
                Rate = b.Rate,
                Genre = b.Genre,
                CoverUrl = b.CoverUrl,
                DateAdded = b.DateAdded,
                PublisherId =b.PublisherId,
            });
            return list.ToList();
        }

        BooksVM IReponsitoryB.GetBook(int id)
        {
            var book = _context.books.SingleOrDefault(b=> b.BookId == id);
            if(book != null)
            {
                return new BooksVM
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Description = book.Description,
                    IsRead = book.IsRead,
                    Rate = book.Rate,
                    Genre = book.Genre,
                    CoverUrl = book.CoverUrl,
                    DateAdded = book.DateAdded,
                    PublisherId = book.PublisherId,
                };
            }
            return null;
        }

        void IReponsitoryB.UpdateBook(int id, BooksVM book)
        {
            var _book=_context.books.SingleOrDefault(b=>b.BookId == id);
            book.Title = book.Title;
            book.Description = book.Description;
            book.IsRead = book.IsRead;
            book.Rate = book.Rate;
            book.Genre = book.Genre;
            book.CoverUrl = book.CoverUrl;
            book.DateAdded = book.DateAdded;
            book.PublisherId = book.PublisherId;
            _context.SaveChanges();
        }
    }
}
