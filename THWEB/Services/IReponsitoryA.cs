using THWEB.Models;
namespace THWEB.Services
{
    public interface IReponsitoryA
    {
        public List<AuthorVM>GetAuthors();
        AuthorVM GetAuthor(int id);
        AuthorVM AddAuthor(AuthorVM author);
        void UpdateAuthor(AuthorVM author);
        void DeleteAuthor(int id);
    }
}
