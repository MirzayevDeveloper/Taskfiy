//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Collections.Generic;

namespace Taskify.Application.UseCases.Roles.Models
{
	public class RoleDto
	{
		public string RoleName { get; set; }
		public List<string> Permissions { get; set; }
	}
}
