﻿using THWEB.Models;
namespace THWEB.Services
{
    public interface IReponsitoryB
    {
        public List<BooksVM> GetAllbooks(string ? search,string sort,int page=1);
        BooksVM GetBook(int id);
        BooksVM AddBookWithAuthors(BooksVM book);
        void UpdateBook(BooksVM book);  

        void DeleteBook(int id);
    }
}
