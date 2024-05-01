using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class ShopCartModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; } = Guid.NewGuid();
        public double Price {  get; set; }
        // Keyinchalik List<Product> Qo'shiladi
        public bool IsSold { get; set; } = false;
    }
}
