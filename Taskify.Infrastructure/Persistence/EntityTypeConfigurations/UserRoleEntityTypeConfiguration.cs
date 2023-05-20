//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.Roles;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.HasKey(ur => ur.Id);

			builder.Property(ur => ur.Id)
				.ValueGeneratedOnAdd();

			builder.HasKey(ur => new
			{
				ur.UserId,
				ur.RoleId
			});

			builder.HasOne(ur => ur.User)
				.WithMany(u => u.UserRoles)
				.HasForeignKey(ur => ur.UserId)
				.IsRequired();

			builder.HasOne(ur => ur.Role)
				.WithMany(r => r.UserRoles)
				.HasForeignKey(ur => ur.RoleId)
				.IsRequired();
		}
	}
}
