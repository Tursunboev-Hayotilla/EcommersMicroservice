using Discount.Application.Abstractions;
using Discount.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infractructure.Persistance
{
    public  class DiscountDbContext:DbContext,IDiscountDbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options) { }
        public DbSet<ProductDiscount> Discounts { get; set; }
    }
}
