using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.Roles;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	public class RolePermissionEntityTypeConfiguration : IEntityTypeConfiguration<RolePermission>
	{
		public void Configure(EntityTypeBuilder<RolePermission> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(ur => ur.Id)
				.ValueGeneratedOnAdd();

			builder.HasKey(ur => new
			{
				ur.RoleId,
				ur.PermissionId
			});

			builder.HasOne(x => x.Role)
				.WithMany(x => x.RolePermissions)
				.HasForeignKey(x => x.RoleId)
				.IsRequired();

			builder.HasOne(x => x.Permission)
				.WithMany(x =>x.RolePermissions)
				.HasForeignKey(x => x.PermissionId)
				.IsRequired();
		}
	}
}
