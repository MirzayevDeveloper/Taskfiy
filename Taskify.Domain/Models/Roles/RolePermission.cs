//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskify.Domain.Models.Roles
{
	public class RolePermission
	{
		[Column("RolePermissionId")]
		public Guid Id { get; set; }

		public Guid RoleId { get; set; }
		public Role Role { get; set; }

		public Guid PermissionId { get; set; }
		public Permission Permission { get; set; }
	}
}
