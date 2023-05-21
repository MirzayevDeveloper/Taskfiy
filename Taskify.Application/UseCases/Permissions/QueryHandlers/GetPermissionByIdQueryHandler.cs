//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Application.UseCases.Permissions.Queries;
using Taskify.Application.UseCases.Permissions.Validation;
using Taskify.Application.UseCases.Permissions.Validations;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Permissions.QueryHandlers
{
	public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, PermissionDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetPermissionByIdQueryHandler(
			IApplicationDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<PermissionDto> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken) =>
		PermissionExceptionHandler.TryCatch(async () =>
		{
			PermissionValidation.ValidatePermissionId(request.permissionId);

			Permission maybePermission =
				await _context.GetAsync<Permission>(request.permissionId);

			PermissionValidation.ValidatePermissionExists(maybePermission, request.permissionId);

			PermissionDto dto = _mapper.Map<PermissionDto>(maybePermission);

			return dto;
		});
	}
}
