﻿using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Interfaces
{
    public interface IAuthorRepo
    {
        public Task<IEnumerable<Author>> GetAuthorsAsync();
        public Task<Author> GetAuthorAsync(int id);
        public Task AddAuthorAsync(Author author);
        public Task UpdateAuthorAsync(Author author);
        public Task DeleteAuthorAsync(Author author);
        public Task<IEnumerable<Author>> SearchAuthors(string searchText);
    }
}
