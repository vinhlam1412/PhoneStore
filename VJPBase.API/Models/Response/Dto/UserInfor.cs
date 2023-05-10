using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VJPBase.Data.Entities;

namespace VJPBase.API.Models.Response.Dto
{
    public class UserInfor
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
}
