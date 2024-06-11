using BookAddict.Domain.Dtos;
using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Application.Interfaces
{
    public interface IUserRepo
    {
        public Task<ApplicationUser> GetUser(string id);
        public Task<IEnumerable<ApplicationUser>> GetAllUsers();
        public Task<bool> IsUserExist(string id);
    }
}
