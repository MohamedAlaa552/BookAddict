using BookAddict.Domain.Dtos;
using BookAddict.Domain.Dtos.CartDtos;
using MediatR;

namespace BookAdict.Queries.OrderQueries
{
    public class ConfirmOrderRequest:IRequest<ConfirmPaymentResponse>
    {
        public ConfirmOrderRequest(IEnumerable<CartItem> items, bool isCashPayment, string userId)
        {
            Items = items;
            IsCashPayment = isCashPayment;
            this.userId = userId;
        }

        public IEnumerable<CartItem> Items { get; }
        public bool IsCashPayment { get; }
        public string userId { get; }
    }
}
