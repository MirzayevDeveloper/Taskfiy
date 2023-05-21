//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using MediatR;
using Taskify.Application.UseCases.Permissions.Models;

namespace Taskify.Application.UseCases.Permissions.Commands
{
	public class CreatePermissionCommand : IRequest<PermissionDto>
	{
		public string PermissionName { get; set; }
	}
}
