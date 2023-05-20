//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskify.Domain.Models.Roles
{
	public class Permission
	{
		[Column("PermissionId")]
		public Guid Id { get; set; }
		public string PermissionName { get; set; }
		public ICollection<RolePermission> RolePermissions { get; set; }
	}
}
