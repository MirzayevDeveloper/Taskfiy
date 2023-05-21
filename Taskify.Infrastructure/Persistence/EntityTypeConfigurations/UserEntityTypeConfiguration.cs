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
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Id)
				.ValueGeneratedOnAdd();

			builder.HasIndex(e => e.Username)
				.IsUnique();

			builder.HasIndex(e => e.Email)
				.IsUnique();
		}
	}
}
