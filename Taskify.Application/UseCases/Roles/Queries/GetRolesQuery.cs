//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Linq;
using MediatR;
using Taskify.Application.UseCases.Roles.Models;

namespace Taskify.Application.UseCases.Roles.Queries
{
	public class GetRolesQuery : IRequest<IQueryable<GetRolesDto>>
	{
	}
}
