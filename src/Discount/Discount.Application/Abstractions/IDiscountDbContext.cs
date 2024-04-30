using Discount.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Abstractions
{
    public class IDiscountDbContext
    {
        public DbSet<ProductDiscount> Discounts {  get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
    }
}
