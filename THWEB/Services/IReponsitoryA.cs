using THWEB.Models;
namespace THWEB.Services
{
    public interface IReponsitoryA
    {
        public List<A_BVM>GetAuthors();
        A_BVM GetAuthor(int id);
        AuthorVM AddAuthor(AuthorVM author);
        void UpdateAuthor(AuthorVM author);
        void DeleteAuthor(int id);
    }
}
