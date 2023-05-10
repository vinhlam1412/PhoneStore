using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class Product : Base
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        public string Description { get; set; }
        public int Id_Brand { get; set; }
        public  Brand Brand { get; set; }

        public ICollection<Store_Detail> store_Details { get; set;}
        public ICollection<Order_Detail> order_Details { get; set; }

    }
}
