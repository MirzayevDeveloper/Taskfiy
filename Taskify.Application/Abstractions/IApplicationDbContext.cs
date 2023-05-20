//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskify.Domain.Models.Issues;
using Taskify.Domain.Models.Roles;
using Taskify.Domain.Models.Teams;
using Taskify.Domain.Models.Users;
using Taskify.Domain.Models.UserTasks;

namespace Taskify.Application.Abstractions
{
	public interface IApplicationDbContext
	{
		DbSet<User> Users { get; set; }
		DbSet<Issue> Issues { get; set; }
		DbSet<UserIssue> UserIssues { get; set; }
		DbSet<Team> Teams { get; set; }
		DbSet<Permission> Permissions { get; set; }
		DbSet<Role> Roles { get; set; }
		DbSet<RolePermission> RolePermissions { get; set; }
		DbSet<UserRole> UserRoles { get; set; }

		public ValueTask<T> AddAsync<T>(T @object);
		public ValueTask<T> GetAsync<T>(params object[] objectIds) where T : class;
		public IQueryable<T> GetAll<T>() where T : class;
		public ValueTask<T> UpdateAsync<T>(T @object);
		public ValueTask<T> DeleteAsync<T>(T @object);
	}
}
