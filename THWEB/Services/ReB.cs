using Microsoft.EntityFrameworkCore;
using System.Threading;
using THWEB.Data;
using THWEB.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace THWEB.Services
{
    public class ReB : IReponsitoryB
    {
        private readonly AppDbcontext _context;
        public static int Page_size { get; set; } = 5;
        public ReB(AppDbcontext context) { _context = context; }
        // Trong class ReB
        public BooksVM AddBookWithAuthors(BooksVM book)
        {
            var _book = new Books
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

            _context.books.Add(_book);
            _context.SaveChanges();
            foreach(var id in book.AuthorId)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.BookId,
                    AuthorId = id,
                };
                _context.books_author.Add(_book_author);
                _context.SaveChanges();
            }
            
            return book;
        }
        void IReponsitoryB.DeleteBook(int id)
        {
            var _deleb_a=_context.books_author.SingleOrDefault(a=>a.BookId == id);
            {
                if (_deleb_a != null)
                {
                    _context.Remove(_deleb_a);
                    _context.SaveChanges();
                    var _delete = _context.books.SingleOrDefault(b => b.BookId == id);
                    if (_delete != null)
                    {

                        _context.books.Remove(_delete);
                        _context.SaveChanges();
                    }
                }
            }
            
        }

        List<BooksVM> IReponsitoryB.GetAllbooks(string ? search, string ? sort,int page=1)
        {
            var bookquery = _context.books.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                bookquery = _context.books.Where(b => b.Title.Contains(search));
            }
            if (!string.IsNullOrEmpty(sort))
            {
                bookquery=_context.books.OrderBy(b=>b.Title);
            }
            bookquery=bookquery.Skip((page-1)*Page_size).Take(Page_size);
            var list = bookquery. Select(b => new BooksVM
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
                PublisherName=b.Publishers.Name,
                AuthorId=_context.books_author.Select(a=>a.Authors.AuthorId).ToList(),
                AuthorName = _context.books_author.Select(a => a.Authors.FullName).ToList(),
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
                    AuthorName = _context.books_author.Select(a => a.Authors.FullName).ToList(),
                };

            }
            return null;
        }

        void IReponsitoryB.UpdateBook( BooksVM book)
        {
            var _book=_context.books.SingleOrDefault(b=>b.BookId == book.BookId);
            _book.Title = book.Title;
            _book.Description = book.Description;
            _book.IsRead = book.IsRead;
            _book.Rate = book.Rate;
            _book.Genre = book.Genre;
            _book.CoverUrl = book.CoverUrl;
            _book.DateAdded = book.DateAdded;
            _book.PublisherId = book.PublisherId;
            _context.SaveChanges();
        }
    }
}
