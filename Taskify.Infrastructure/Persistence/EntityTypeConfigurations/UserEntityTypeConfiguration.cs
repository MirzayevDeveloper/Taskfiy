//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.Users;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasIndex(x => x.Username)
				.IsUnique();

			builder.HasIndex(x => x.Email)
				.IsUnique();

			builder.HasOne(u => u.Team)
				.WithMany(t => t.Users)
				.HasForeignKey(u => u.TeamId)
				.IsRequired();
		}
	}
}
