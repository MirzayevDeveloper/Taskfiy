using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taskify.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class Initial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Issues",
				columns: table => new
				{
					IssueId = table.Column<Guid>(type: "uuid", nullable: false),
					Title = table.Column<string>(type: "text", nullable: true),
					Description = table.Column<string>(type: "text", nullable: true),
					DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
					Priority = table.Column<int>(type: "integer", nullable: false),
					Status = table.Column<int>(type: "integer", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Issues", x => x.IssueId);
				});

			migrationBuilder.CreateTable(
				name: "Permissions",
				columns: table => new
				{
					PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
					PermissionName = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Permissions", x => x.PermissionId);
				});

			migrationBuilder.CreateTable(
				name: "Roles",
				columns: table => new
				{
					RoleId = table.Column<Guid>(type: "uuid", nullable: false),
					RoleName = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Roles", x => x.RoleId);
				});

			migrationBuilder.CreateTable(
				name: "Teams",
				columns: table => new
				{
					TeamId = table.Column<Guid>(type: "uuid", nullable: false),
					TeamName = table.Column<string>(type: "text", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Teams", x => x.TeamId);
				});

			migrationBuilder.CreateTable(
				name: "RolePermissions",
				columns: table => new
				{
					RolePermissionId = table.Column<Guid>(type: "uuid", nullable: false),
					RoleId = table.Column<Guid>(type: "uuid", nullable: false),
					PermissionId = table.Column<Guid>(type: "uuid", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RolePermissions", x => x.RolePermissionId);
					table.ForeignKey(
						name: "FK_RolePermissions_Permissions_PermissionId",
						column: x => x.PermissionId,
						principalTable: "Permissions",
						principalColumn: "PermissionId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_RolePermissions_Roles_RoleId",
						column: x => x.RoleId,
						principalTable: "Roles",
						principalColumn: "RoleId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					UserId = table.Column<Guid>(type: "uuid", nullable: false),
					Username = table.Column<string>(type: "text", nullable: true),
					Password = table.Column<string>(type: "text", nullable: true),
					Email = table.Column<string>(type: "text", nullable: true),
					TeamId = table.Column<Guid>(type: "uuid", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.UserId);
					table.ForeignKey(
						name: "FK_Users_Teams_TeamId",
						column: x => x.TeamId,
						principalTable: "Teams",
						principalColumn: "TeamId");
				});

			migrationBuilder.CreateTable(
				name: "UserIssues",
				columns: table => new
				{
					UserId = table.Column<Guid>(type: "uuid", nullable: false),
					IssueId = table.Column<Guid>(type: "uuid", nullable: false),
					UserIssueId = table.Column<Guid>(type: "uuid", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserIssues", x => new { x.IssueId, x.UserId });
					table.ForeignKey(
						name: "FK_UserIssues_Issues_IssueId",
						column: x => x.IssueId,
						principalTable: "Issues",
						principalColumn: "IssueId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserIssues_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserRoles",
				columns: table => new
				{
					UserId = table.Column<Guid>(type: "uuid", nullable: false),
					RoleId = table.Column<Guid>(type: "uuid", nullable: false),
					UserRoleId = table.Column<Guid>(type: "uuid", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_UserRoles_Roles_RoleId",
						column: x => x.RoleId,
						principalTable: "Roles",
						principalColumn: "RoleId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserRoles_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_RolePermissions_PermissionId",
				table: "RolePermissions",
				column: "PermissionId");

			migrationBuilder.CreateIndex(
				name: "IX_RolePermissions_RoleId",
				table: "RolePermissions",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "IX_Roles_RoleName",
				table: "Roles",
				column: "RoleName");

			migrationBuilder.CreateIndex(
				name: "IX_UserIssues_UserId",
				table: "UserIssues",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserRoles_RoleId",
				table: "UserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "IX_Users_Email",
				table: "Users",
				column: "Email",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Users_TeamId",
				table: "Users",
				column: "TeamId");

			migrationBuilder.CreateIndex(
				name: "IX_Users_Username",
				table: "Users",
				column: "Username",
				unique: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "RolePermissions");

			migrationBuilder.DropTable(
				name: "UserIssues");

			migrationBuilder.DropTable(
				name: "UserRoles");

			migrationBuilder.DropTable(
				name: "Permissions");

			migrationBuilder.DropTable(
				name: "Issues");

			migrationBuilder.DropTable(
				name: "Roles");

			migrationBuilder.DropTable(
				name: "Users");

			migrationBuilder.DropTable(
				name: "Teams");
		}
	}
}
