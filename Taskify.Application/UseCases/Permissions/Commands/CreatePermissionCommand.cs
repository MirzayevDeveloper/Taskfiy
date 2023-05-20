//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using MediatR;

namespace Taskify.Application.UseCases.Permissions.Commands
{
	public class CreatePermissionCommand : IRequest
	{
		public string PermissionName { get; set; }
	}
}
