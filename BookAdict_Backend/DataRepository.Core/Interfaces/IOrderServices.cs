using BookAddict.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAddict.Domain.Interfaces
{
    public interface IOrderServices
    {
        public Task<Order> AddOrder(Order order);
    }
}
