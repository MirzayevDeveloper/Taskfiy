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
using Taskify.Application.UseCases.Roles.Models;
using Taskify.Application.UseCases.Roles.Queries;
using Taskify.Application.UseCases.Roles.Validations;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Roles.QueryHandlers
{
	public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IQueryable<GetRolesDto>>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetRolesQueryHandler(
			IApplicationDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IQueryable<GetRolesDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken) =>
		RoleExceptionHandler.TryCatch(() =>
		{
			List<Role> roles = _context.GetAll<Role>().ToList();

			IQueryable<GetRolesDto> dtos =
				_mapper.Map<List<Role>, List<GetRolesDto>>(roles).AsQueryable();

			return dtos;
		});
	}
}
