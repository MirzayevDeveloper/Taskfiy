//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Taskify.Domain.Models.Users;

namespace Taskify.Domain.Models.Roles
{
	public class UserRole
	{
		[Column("UserRoleId")]
		public Guid Id { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }

		public Guid RoleId { get; set; }
		public Role Role { get; set; }
	}
}
