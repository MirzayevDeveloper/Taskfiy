//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taskify.Domain.Models.Issues;
using Taskify.Domain.Models.Roles;
using Taskify.Domain.Models.Teams;
using Taskify.Domain.Models.UserTasks;

namespace Taskify.Domain.Models.Users
{
	public class User
	{
		[Column("UserId")]
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

        public Team Team { get; set; }

        public ICollection<UserIssue> UserIssues { get; set; }
		public ICollection<UserRole> UserRoles { get; set; }
	}
}
