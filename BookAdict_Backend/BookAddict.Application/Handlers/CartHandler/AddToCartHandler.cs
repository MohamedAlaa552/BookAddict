using BookAdict.Commands.CartCommands;
using BookAddict.Domain.Dtos.CartDtos;
using BookAddict.Domain.Interfaces;
using MediatR;

namespace BookAdict.Handlers.CartHandler
{
    public class AddToCartHandler : BaseCartHandler , IRequestHandler<AddToCartRequest, IEnumerable<CartItem>>
    {
        public AddToCartHandler(IUnitOfWork unitOfWork):base(unitOfWork) { }

        public async Task<IEnumerable<CartItem>> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.cartServices.AddToCart(request.CartItem);
        }
    }
}
