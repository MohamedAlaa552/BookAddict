﻿using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Interfaces
{
    public interface IBookRepo
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync(string? sortBy , string? categoryId);
        public Task<Book> GetBookAsync(int id);
        public Task<IEnumerable<Book>> SearchBookByName(string searchText);
        public Task AddBookAsync(Book book, List<int> authorsIds);
        public Task UpdateBookAsync(Book book, List<int> authorsIds);
        public Task<Book> DeleteBookAsync(int id);
        public Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int CategoryId);
        public bool IsBookExist(int id);
    }
}
