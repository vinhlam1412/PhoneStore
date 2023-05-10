using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class Order : Base 
    {
        public int Id { get; set; }
        public int Id_Customer { get; set; }
        public  Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<Order_Detail> order_Details { get; set; }
    }
}
