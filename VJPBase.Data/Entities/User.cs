using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VJPBase.Data.Entities
{
	public partial class User 
    {
		public int Id { get; set; }
		public string StaffCode { get; set; }
		public string Username { get; set; }
		public DateTime Birthday { get; set; }
		public string FullName { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int RoleId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public Role Role { get; set; }

		[JsonIgnore]
		public string PasswordHash { get; set; }

		[JsonIgnore]
		public List<RefreshToken> RefreshTokens { get; set; }
	}
}
