using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.Issues;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	public class IssueEntityTypeConfiguration : IEntityTypeConfiguration<Issue>
	{
		public void Configure(EntityTypeBuilder<Issue> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Navigation(x => x.UserIssues).AutoInclude(autoInclude: true);
		}
	}
}
