using Microsoft.EntityFrameworkCore;
using ShoppingCart.Application.Abstractions;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure.Persistance
{
    public class ShopCartDbContext : DbContext, IShopCardDbContext
    {
        public ShopCartDbContext(DbContextOptions<ShopCartDbContext> options) : base(options) { }
        public DbSet<ShopCartModel> Carts {  get; set; }
    }
}