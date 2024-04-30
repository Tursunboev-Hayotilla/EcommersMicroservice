﻿using MediatR;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.UseCases.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderModel>
    {
        public Guid Id { get; set; }
    }
}
