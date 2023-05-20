//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using MediatR;

namespace Taskify.Application.UseCases.Permissions.Commands
{
	public record DeletePermissionCommand(Guid permissionId) : IRequest;
}
