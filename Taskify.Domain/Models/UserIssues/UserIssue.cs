//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Taskify.Domain.Models.Issues;
using Taskify.Domain.Models.Users;

namespace Taskify.Domain.Models.UserTasks
{
	public class UserIssue
	{
		[Column("UserIssueId")]
		public Guid Id { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }

		public Guid IssueId { get; set; }
		public Issue Issue { get; set; }
	}
}
