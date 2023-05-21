//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Application.UseCases.Permissions.Queries;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Permissions.QueryHandlers
{
	public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, List<GetAllPermissionDto>>
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

		public async Task<List<GetAllPermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
		{
			List<Permission> permissions = await _context.GetAll<Permission>().ToListAsync();

			List<GetAllPermissionDto> dtos =
				_mapper.Map<List<Permission>, List<GetAllPermissionDto>>(permissions);

			return dtos;
		}
	}
}
