using THWEB.Models;
namespace THWEB.Services
{
    public interface IReponsitoryA
    {
        public List<AuthorVM>GetAuthors();
        AuthorVM GetAuthor(int id);
        AuthorVM AddAuthor(AuthorVM author, int bookId);
        void UpdateAuthor(int id,AuthorVM author);
        void DeleteAuthor(int id);
    }
}
