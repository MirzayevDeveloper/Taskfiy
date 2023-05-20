//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Taskify.Domain.Models.Users;

namespace Taskify.Domain.Models.Tasks
{
	public class Task
	{
		[Column("TaskId")]
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTimeOffset DueDate { get; set; }
		public Priority Priority { get; set; }
		public Status MyProperty { get; set; }

		public ICollection<User> Users { get; set; }
	}
}
