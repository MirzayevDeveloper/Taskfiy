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
	public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, PermissionDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public CreatePermissionCommandHandler(
			IApplicationDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<PermissionDto> Handle(CreatePermissionCommand request, CancellationToken cancellationToken) =>
		PermissionExceptionHandler.TryCatch(async () =>
		{
			Permission permission = _mapper.Map<Permission>(request);

			PermissionValidation.ValidatePermissionOnCreate(permission);

			await _context.AddAsync<Permission>(permission, cancellationToken);

			return _mapper.Map<PermissionDto>(permission);
		});
	}
}
