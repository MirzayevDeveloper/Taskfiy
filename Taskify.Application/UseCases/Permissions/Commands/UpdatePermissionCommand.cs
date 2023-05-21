//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using MediatR;
using Taskify.Application.UseCases.Permissions.Models;

namespace Taskify.Application.UseCases.Permissions.Commands
{
	public class UpdatePermissionCommand : IRequest<PermissionDto>
	{
		public Guid Id { get; set; }
		public string PermissionName { get; set; }
	}
}
