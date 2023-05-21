//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Permissions.Commands;
using Taskify.Application.UseCases.Permissions.Validation;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Permissions.CommandHandlers
{
	public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand>
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

		public async Task Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
		{
			Permission permission = _mapper.Map<Permission>(request);

			PermissionValidation.ValidatePermissionOnCreate(permission);

			await _context.AddAsync<Permission>(permission, cancellationToken);
		}
	}
}
