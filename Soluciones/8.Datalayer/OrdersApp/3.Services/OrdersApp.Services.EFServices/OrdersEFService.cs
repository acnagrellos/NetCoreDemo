using OrdersApp.Domain.Data;
using OrdersApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersApp.Services.EFServices
{
    public class OrdersEFService : IOrdersService
    {
        private readonly OrdersAppContext _context;
        public OrdersEFService(OrdersAppContext context)
        {
            _context = context;
        }
    }
}
