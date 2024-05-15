using Microsoft.AspNetCore.Mvc;
using THWEB.Data;
using THWEB.Models;

namespace THWEB.Services
{
    public class ReA : IReponsitoryA
    {
        private readonly AppDbcontext _context;
        public ReA(AppDbcontext context) { _context = context; }
        // Trong class ReA
        public addAuthorVM AddAuthor(addAuthorVM author)
        {
            var _Author = new Authors
            {
                FullName = author.FullName
            };
            _context.authors.Add(_Author);
            _context.SaveChanges();
           
            return new addAuthorVM
            {
                
                FullName = author.FullName
            };
        }

        void IReponsitoryA.DeleteAuthor(int id)
        {
            var _deleteb_a=_context.books_author.SingleOrDefault(d=>d.AuthorId == id);
            if (_deleteb_a != null)
            {
                _context.books_author.Remove(_deleteb_a);
                _context.SaveChanges();
                var _delete = _context.authors.SingleOrDefault(d => d.AuthorId == id);
                if (_delete != null)
                {
                    _context.Remove(_delete);
                    _context.SaveChanges();
                }
            }
            else
            {
                var _delete = _context.authors.SingleOrDefault(d => d.AuthorId == id);
                if (_delete != null)
                {
                    _context.Remove(_delete);
                    _context.SaveChanges();
                }
            }
            
        }

        A_BVM IReponsitoryA.GetAuthor(int id)
        {
            var author=_context.authors.SingleOrDefault(a=>a.AuthorId == id);
            if(author != null)
            {
                return new A_BVM { AuthorId = author.AuthorId ,FullName=author.FullName , BookName = author.Book_Authors.Select(b => b.Book.Title).ToList() };
            }
            else
            {
                return null;
            }
        }

        List<A_BVM> IReponsitoryA.GetAuthors()
        {
            var result = _context.authors.Select(a => new A_BVM
            {
                AuthorId = a.AuthorId,
                FullName = a.FullName,
                BookName = a.Book_Authors.Select(b => b.Book.Title).ToList()
            }) ;
            return result.ToList();
        }

        void IReponsitoryA.UpdateAuthor( AuthorVM author)
        {
            var _author = _context.authors.SingleOrDefault(a => a.AuthorId == author.AuthorId);
                _author.FullName = author.FullName;
                _context.SaveChanges();
            
        }
    }
}
