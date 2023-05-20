//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskify.Domain.Models.Teams;

namespace Taskify.Infrastructure.Persistence.EntityTypeConfigurations
{
	public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
	{
		public void Configure(EntityTypeBuilder<Team> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id)
				.ValueGeneratedOnAdd();

			builder.HasMany(t => t.Users)
				.WithOne(u => u.Team)
				.HasForeignKey(u => u.TeamId)
				.IsRequired();
		}
	}
}
