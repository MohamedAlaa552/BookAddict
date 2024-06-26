﻿using BookAddict.Application.DTOS.CartDtos;
using MediatR;

namespace BookAdict.Commands.CartCommands
{
    public class DeleteCartItemRequest:IRequest<bool>
    {
        public CartItem cartItem;

        public DeleteCartItemRequest(CartItem cartItem)
        {
            this.cartItem = cartItem;
        }
    }
}
