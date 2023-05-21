//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Linq;
using MediatR;
using Taskify.Application.UseCases.Permissions.Models;

namespace Taskify.Application.UseCases.Permissions.Queries
{
	public class GetPermissionsQuery : IRequest<IQueryable<GetAllPermissionDto>>
	{
	}
}
