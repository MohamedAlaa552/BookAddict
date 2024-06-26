﻿using AutoMapper;
using BookAdict.Commands;
using BookAdict.Handlers.BookHandler;
using BookAdict.Interfaces;
using BookAdict.Queries.BookQueries;
using BookAdict.Services;
using DataRepo.Ef;
using BookAddict.Application.DTOS.BookDtos;
using BookAddict.Application.Interfaces;
using BookAddict.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAdict.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController

    {
        private readonly IMediator _mediator;

        public BookController(IUnitOfWork unitOfWork, IMapper mapper, IImageServices imageServices,IMediator mediator):base(unitOfWork , mapper,imageServices)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks([FromQuery] string? sortBy , [FromQuery] string? categoryName)
        {
            var query = new GetAllBooksQuery(sortBy , categoryName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var query = new GetBookQuery(id);
            var result = await _mediator.Send(query);
            return result == null ? NotFound("This book not found") : Ok(result);
        }
        [HttpGet("SearchBookByName")]
        public async Task<IActionResult> SearchBook([FromQuery] string searchText)
        {
            var query = new SearchBookQuery(searchText);
            var result = await _mediator.Send(query);
            return result == null ? NotFound("This book not found") : Ok(result);
        }
        [HttpGet("GetBooksByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetBooksByCategoryId(int categoryId)
        {
            var query = new GetByCategoryQuery(categoryId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [Authorize(Roles = "admin")]
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromForm] BookInsertDto bookInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var command = new AddBookRequest(bookInDto);
            var result = await _mediator.Send(command);
                return Ok(result);
            
        }
        [Authorize(Roles = "admin")]
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromForm] BookInsertDto bookInDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var command = new UpdateBookRequest(bookInDto);
            var result = await _mediator.Send(command);
            if(result == null)
                return NotFound(new {message = "No Product exist" });
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> Deletebook(int id)
        {
            var deleteCommand = new DeleteBooksRequest(id);
            var result = await _mediator.Send(deleteCommand);
            return result != null ? Ok("Book deleted successfully"):NotFound("No Book found with this id");
        }

    }
}
