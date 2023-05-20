//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Taskify.Domain.Models.Tasks;
using Taskify.Domain.Models.Users;

namespace Taskify.Domain.Models.UserTasks
{
	public class UserTask
	{
		[Column("UserTaskId")]
		public Guid Id { get; set; }

		public Guid UserId { get; set; }
		public Guid TaskId { get; set; }

		public User User { get; set; }
		public Task Task { get; set; }
	}
}
