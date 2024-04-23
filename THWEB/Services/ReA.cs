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
        public AuthorVM AddAuthor(AuthorVM author)
        {
            var _Author = new Authors
            {
                AuthorId=author.AuthorId,
                FullName = author.FullName
            };
            _context.authors.Add(_Author);
            _context.SaveChanges();
           
            return new AuthorVM
            {
                AuthorId = author.AuthorId,
                FullName = author.FullName
            };
        }

        void IReponsitoryA.DeleteAuthor(int id)
        {
            var _delete=_context.authors.SingleOrDefault(d=>d.AuthorId == id);
            if (_delete != null)
            {
                _context.Remove(_delete);
                _context.SaveChanges();
            }
            
        }

        AuthorVM IReponsitoryA.GetAuthor(int id)
        {
            var author=_context.authors.SingleOrDefault(a=>a.AuthorId == id);
            if(author != null)
            {
                return new AuthorVM { AuthorId = author.AuthorId ,FullName=author.FullName };
            }
            else
            {
                return null;
            }
        }

        List<AuthorVM> IReponsitoryA.GetAuthors()
        {
            var result = _context.authors.Select(a => new AuthorVM
            {
                AuthorId = a.AuthorId,
                FullName = a.FullName,
            });
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
