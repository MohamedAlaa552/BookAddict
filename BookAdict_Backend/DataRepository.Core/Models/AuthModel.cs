﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Domain.Models
{
    public class AuthModel
    {
        public AuthModel() { }
        public AuthModel(string id, bool isAuthenticated, ApplicationUser user, List<string> roles, string token, DateTime expiresOn)
        {
            Id = id;
            IsAuthenticated = isAuthenticated;
            Username = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.Lastname;
            Roles = roles;
            Token = token;
            ExpiresOn = expiresOn;
        }
        public AuthModel(bool isAuthenticated, string username, string email, List<string> roles, string token, DateTime expiresOn)
        {
            IsAuthenticated = isAuthenticated;
            Username = username;
            Email = email;
            Roles = roles;
            Token = token;
            ExpiresOn = expiresOn;
        }
        public string Id { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Message {  get; set; }
    }

}
