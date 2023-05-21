//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Permissions.Commands;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Application.UseCases.Permissions.Validation;
using Taskify.Application.UseCases.Permissions.Validations;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Permissions.CommandHandlers
{
	public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, PermissionDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public UpdatePermissionCommandHandler(
			IApplicationDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<PermissionDto> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken) =>
		PermissionExceptionHandler.TryCatch(async () =>
		{
			Permission permission = _mapper.Map<Permission>(request);

			PermissionValidation.ValidatePermissionOnUpdate(permission);

			Permission maybePermission = await _context.GetAsync<Permission>(permission.Id);

			PermissionValidation.ValidatePermissionExists(maybePermission, permission.Id);

			await _context.UpdateAsync<Permission>(permission);

			return _mapper.Map<PermissionDto>(maybePermission);
		});
	}
}
