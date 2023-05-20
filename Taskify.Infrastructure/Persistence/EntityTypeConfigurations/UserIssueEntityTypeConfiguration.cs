//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.UserTasks;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	public class UserIssueEntityTypeConfiguration : IEntityTypeConfiguration<UserIssue>
	{
		public void Configure(EntityTypeBuilder<UserIssue> builder)
		{
			builder.HasKey(u => u.Id);

			builder.Property(u => u.Id)
				.ValueGeneratedOnAdd();

			builder.HasKey(ui => new
			{
				ui.IssueId,
				ui.UserId
			});

			builder.HasOne(ui => ui.User)
				.WithMany(u => u.UserIssues)
				.HasForeignKey(u => u.UserId)
				.IsRequired();

			builder.HasOne(ui => ui.Issue)
				.WithMany(i => i.UserIssues)
				.HasForeignKey(i => i.IssueId)
				.IsRequired();
		}
	}
}
