//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

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
	public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetRoleByIdQueryHandler(
			IApplicationDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken) =>
		RoleExceptionHandler.TryCatch(async () =>
		{
			RoleValidation.ValidateRoleId(request.roleId);

			Role maybeRole = await _context.GetAsync<Role>(request.roleId);

			RoleValidation.ValidateRoleExists(maybeRole, request.roleId);

			return _mapper.Map<RoleDto>(maybeRole);
		});
	}
}
