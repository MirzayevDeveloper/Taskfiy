//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.Roles;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	internal class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(r => r.Id);

			builder.HasIndex(r => r.RoleName);
		}
	}
}
