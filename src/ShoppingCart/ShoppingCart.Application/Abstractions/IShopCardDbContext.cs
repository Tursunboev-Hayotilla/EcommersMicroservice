using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Abstractions
{
    public interface IShopCardDbContext
    {
        public DbSet<ShopCartModel> Carts { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
