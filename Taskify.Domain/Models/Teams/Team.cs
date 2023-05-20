//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taskify.Domain.Models.Users;

namespace Taskify.Domain.Models.Teams
{
	public class Team
	{
		[Column("TeamId")]
		public Guid Id { get; set; }
		public string TeamName { get; set; }

		public ICollection<User> Users { get; set; }
	}
}
