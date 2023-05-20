using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Domain.Models.Roles
{
	public class Role
	{
		[Column("RoleId")]
		public Guid Id { get; set; }
		public string RoleName { get; set; }
		public ICollection<UserRole> UserRoles { get; set; }
		public ICollection<RolePermission> RolePermissions { get; set; }
	}
}
