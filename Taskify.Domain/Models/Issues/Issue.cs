//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taskify.Domain.Models.Tasks;
using Taskify.Domain.Models.UserTasks;

namespace Taskify.Domain.Models.Issues
{
	public class Issue
	{
		[Column("IssueId")]
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTimeOffset DueDate { get; set; }
		public Priority Priority { get; set; }
		public Status Status { get; set; }

		public ICollection<UserIssue> UserIssues { get; set; }
	}
}
