//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using MediatR;
using Taskify.Application.UseCases.Permissions.Models;

namespace Taskify.Application.UseCases.Permissions.Queries
{
	public record GetPermissionByIdQuery(Guid permissionId) : IRequest<PermissionDto>;
}
