//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using MediatR;

namespace Taskify.Application.UseCases.Permissions.Commands
{
	public class UpdatePermissionCommand : IRequest
	{
		public Guid Id { get; set; }
		public string PermissionName { get; set; }
	}
}
