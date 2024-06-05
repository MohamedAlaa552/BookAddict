using BookAdict.Services;
using BookAddict.Domain.Interfaces;
using BookAddict.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using BookAddict.Domain.Dtos.CartDtos;
using BookAddict.Domain.Dtos;
using AutoMapper;
using MediatR;
using BookAdict.Queries.OrderQueries;
using BookAddict.Application.Queries.OrderQueries;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly PaymentService _paymentService;
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public OrderController( IMediator mediator, IConfiguration configuration)
        {
            //_paymentService = paymentService;
            //_unitOfWork = unitOfWork;
            //_mapper = mapper;
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("ConfirmOrder")]
        public async Task<IActionResult> ConfirmOrder([FromBody]IEnumerable<CartItem> items , [FromQuery]bool IsCashPayment, [FromQuery] string userId)
        {
            var query = new ConfirmOrderRequest(items, IsCashPayment, userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [Route("ConfirmPayment")]
        [HttpGet]
        public async Task<IActionResult> ConfirmPayment()
        {
            var query = new RedirectOrderCreditCardPaymentRequest();
            var result = await _mediator.Send(query);
            return Redirect(result);
        }
    }
}
