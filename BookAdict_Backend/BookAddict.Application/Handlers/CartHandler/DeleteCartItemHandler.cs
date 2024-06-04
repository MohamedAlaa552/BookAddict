using BookAdict.Commands.CartCommands;
using BookAddict.Domain.Interfaces;
using MediatR;

namespace BookAdict.Handlers.CartHandler
{
    public class DeleteCartItemHandler :BaseCartHandler, IRequestHandler<DeleteCartItemRequest, bool>
    {
        public DeleteCartItemHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public Task<bool> Handle(DeleteCartItemRequest request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_unitOfWork.cartServices.DeleteCartItem(request.cartItem));
        }
    }
}
