//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using MediatR;
using Taskify.Application.UseCases.Roles.Models;

namespace Taskify.Application.UseCases.Roles.Queries
{
	public record GetRoleByIdQuery(Guid roleId) : IRequest<RoleDto>;
}
