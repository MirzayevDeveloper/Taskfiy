//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Collections.Generic;
using MediatR;
using Taskify.Application.UseCases.Permissions.Models;

namespace Taskify.Application.UseCases.Permissions.Queries
{
	public class GetPermissionsQuery : IRequest<List<GetAllPermissionDto>>
	{
	}
}
