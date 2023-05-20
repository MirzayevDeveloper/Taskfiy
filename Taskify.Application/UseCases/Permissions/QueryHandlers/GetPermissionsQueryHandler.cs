//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Application.UseCases.Permissions.Queries;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Permissions.QueryHandlers
{
	public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, IQueryable<PermissionDto>>
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

		public Task<IQueryable<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
		{
			IQueryable<Permission> permissions = _context.GetAll<Permission>();

			IQueryable<PermissionDto> dtos =
				_mapper.Map<IQueryable<PermissionDto>>(permissions);

			return Task.FromResult(dtos);
		}
	}
}
