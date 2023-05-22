//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.Roles;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(r => r.Id);

			builder.Property(r => r.Id)
				.ValueGeneratedOnAdd();

			builder.HasIndex(r => r.RoleName)
				.IsUnique();
		}
	}
}
