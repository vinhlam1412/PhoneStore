using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class Store_Detail : Base
    {
        public int Id_Product { get; set; }
     
        public  Product Product { get; set; }

        public int Id_Store { get; set; }
    
        public  Store Store { get; set; }

        public int Quantity { get; set; }
    }
}
