using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_Order.Models.Entities;

namespace WpfApp_Order.Models
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

    }
}
