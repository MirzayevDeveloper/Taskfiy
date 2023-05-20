//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskify.Application.Abstractions;
using Taskify.Domain.Models.Issues;
using Taskify.Domain.Models.Roles;
using Taskify.Domain.Models.Teams;
using Taskify.Domain.Models.Users;
using Taskify.Domain.Models.UserTasks;
using Taskify.Infrastructure.Persistence.EntityTypeConfigurations;

namespace Taskify.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		private readonly DbContextOptions<ApplicationDbContext> _options;

		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options)
			: base(options) => _options = options;

		public DbSet<User> Users { get; set; }
		public DbSet<Issue> Issues { get; set; }
		public DbSet<UserIssue> UserIssues { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<RolePermission> RolePermissions { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }

		public async ValueTask<T> AddAsync<T>(T @object)
		{
			var context = new ApplicationDbContext(_options);
			context.Entry(@object).State = EntityState.Added;
			await context.SaveChangesAsync();

			return @object;
		}

		public async ValueTask<T> GetAsync<T>(params object[] objectIds) where T : class
		{
			var context = new ApplicationDbContext(_options);
			return await context.FindAsync<T>(objectIds);
		}

		public IQueryable<T> GetAll<T>() where T : class
		{
			var context = new ApplicationDbContext(_options);
			return context.Set<T>();
		}

		public async ValueTask<T> UpdateAsync<T>(T @object)
		{
			var context = new ApplicationDbContext(_options);
			context.Entry(@object).State = EntityState.Modified;
			await context.SaveChangesAsync();

			return @object;
		}

		public async ValueTask<T> DeleteAsync<T>(T @object)
		{
			var context = new ApplicationDbContext(_options);
			context.Entry(@object).State = EntityState.Deleted;
			await context.SaveChangesAsync();

			return @object;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(
				new IssueEntityTypeConfiguration());

			modelBuilder.ApplyConfiguration(
				new PermissionEntityTypeConfiguration());

			modelBuilder.ApplyConfiguration(
				new RoleEntityTypeConfiguration());

			modelBuilder.ApplyConfiguration(
				new TeamEntityTypeConfiguration());

			modelBuilder.ApplyConfiguration(
				new UserEntityTypeConfiguration());

			modelBuilder.ApplyConfiguration(
				new UserIssueEntityTypeConfiguration());

			modelBuilder.ApplyConfiguration(
				new UserRoleEntityTypeConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
