//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.Issues;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	public class IssueEntityTypeConfiguration : IEntityTypeConfiguration<Issue>
	{
		public void Configure(EntityTypeBuilder<Issue> builder)
		{
			builder.HasKey(i => i.Id);

			builder.Property(i => i.Id)
				.ValueGeneratedOnAdd();

			//builder.Navigation(i => i.UserIssues).AutoInclude(autoInclude: true);
		}
	}
}
