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
	public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand>
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

		public async Task Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
		{
			Permission maybePermission = _mapper.Map<Permission>(request);

			PermissionValidation.ValidatePermissionOnUpdate(maybePermission);

			maybePermission = await _context.GetAsync<Permission>(request.Id);

			PermissionValidation.ValidatePermissionExists(maybePermission, request.Id);

			await _context.UpdateAsync<Permission>(maybePermission);
		}
	}
}
