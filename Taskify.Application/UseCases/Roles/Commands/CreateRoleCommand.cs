//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;
using Taskify.Application.UseCases.Roles.Models;

namespace Taskify.Application.UseCases.Roles.Commands
{
	public class CreateRoleCommand : IRequest<RoleDto>
	{
		private string _roleName;

		[JsonPropertyName("role_name")]
		public string RoleName
		{
			get { return _roleName; }
			set { _roleName = value.ToLower(); }
		}

		public List<string> Permissions { get; set; }
	}
}
