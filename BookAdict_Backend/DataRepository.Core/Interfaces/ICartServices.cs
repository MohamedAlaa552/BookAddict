﻿using BookAddict.Domain.Dtos.CartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Domain.Interfaces
{
    public interface ICartServices
    {
        public Task<IEnumerable<CartItem>> AddToCart(CartItem item);
        public IEnumerable<CartItem> GetCart(string UserId);
        public bool DeleteCartItem(CartItem item);
    }
}
