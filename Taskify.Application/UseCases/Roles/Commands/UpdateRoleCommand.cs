//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using MediatR;
using Taskify.Application.UseCases.Roles.Models;

namespace Taskify.Application.UseCases.Roles.Commands
{
	public class UpdateRoleCommand : IRequest<RoleDto>
	{
		public Guid Id { get; set; }
		public string RoleName { get; set; }
	}
}
