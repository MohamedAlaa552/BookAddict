using BookAddict.Domain.Dtos;
using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Domain.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthModel> RegisterAsync(RegisterRequestDto registerModel);
        public Task<AuthModel> GetTokenasync(TokenRequestDto tokenRequestModel);
        public Task<string> AddRoleAsync(AddRoleDto roleDto);
    }
}
