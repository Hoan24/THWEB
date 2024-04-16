using THWEB.Data;
using THWEB.Models;

namespace THWEB.Services
{
    public class ReA : IReponsitoryA
    {
        private readonly AppDbcontext _context;
        public ReA(AppDbcontext context) { _context = context; }
        // Trong class ReA
        public AuthorVM AddAuthor(AuthorVM author, int bookId)
        {
            var newAuthor = new Authors
            {
                AuthorId=author.AuthorId,
                FullName = author.FullName
            };

            
            _context.authors.Add(newAuthor);
            _context.SaveChanges();

            
            int newAuthorId = newAuthor.AuthorId;   
            
            var newBookAuthor = new Book_Author
            {
                
                BookId = bookId,
                AuthorId = newAuthorId
            };

            _context.books_author.Add(newBookAuthor);
            _context.SaveChanges();

            return new AuthorVM
            {
                AuthorId = newAuthorId,
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

        void IReponsitoryA.UpdateAuthor(int id, AuthorVM author)
        {
                var _author=_context.authors.SingleOrDefault(a=>a.AuthorId==id);
            if(_author != null)
            {
                author.FullName = _author.FullName;
                _context.SaveChanges();
            }
        }
    }
}
