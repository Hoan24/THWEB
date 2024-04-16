using THWEB.Models;
namespace THWEB.Services
{
    public interface IReponsitoryB
    {
        public List<BooksVM> GetAllbooks();
        BooksVM GetBook(int id);
        BooksVM AddBookWithAuthors(BooksVM book);
        void UpdateBook(int id,BooksVM book);  
        void DeleteBook(int id);
    }
}
