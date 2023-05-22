//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using MediatR;
using Taskify.Application.UseCases.Permissions.Models;

namespace Taskify.Application.UseCases.Permissions.Commands
{
	public class CreatePermissionCommand : IRequest<PermissionDto>
	{
		private string _permissionName;

		public string PermissionName
		{
			get { return _permissionName; }
			set { _permissionName = value.ToLower(); }
		}
	}
}
