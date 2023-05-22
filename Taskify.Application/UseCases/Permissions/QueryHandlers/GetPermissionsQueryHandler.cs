//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Application.UseCases.Permissions.Queries;
using Taskify.Application.UseCases.Permissions.Validations;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Permissions.QueryHandlers
{
	public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, IQueryable<GetPermissionsDto>>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetPermissionsQueryHandler(
			IApplicationDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IQueryable<GetPermissionsDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken) =>
		PermissionExceptionHandler.TryCatch(() =>
		{
			List<Permission> permissions = _context.GetAll<Permission>().ToList();

			IQueryable<GetPermissionsDto> dtos =
				_mapper.Map<List<Permission>, List<GetPermissionsDto>>(permissions).AsQueryable();

			return dtos;
		});
	}
}
