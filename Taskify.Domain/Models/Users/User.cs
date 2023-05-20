//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taskify.Domain.Models.Roles;
using Taskify.Domain.Models.Tasks;

namespace Taskify.Domain.Models.Users
{
	public class User
	{
		[Column("UserId")]
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public ICollection<Task> Tasks { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
