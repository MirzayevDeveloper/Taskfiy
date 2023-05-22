//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using MediatR;
using Taskify.Application.UseCases.Roles.Models;

namespace Taskify.Application.UseCases.Roles.Commands
{
	public record DeleteRoleCommand(Guid roleId) : IRequest<RoleDto>;
}
