﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
    public class Store : Base
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ICollection<Store_Detail>  store_Details { get; set; }
    }
}
