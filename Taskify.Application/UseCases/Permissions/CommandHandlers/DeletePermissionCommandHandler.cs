//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Permissions.Commands;
using Taskify.Application.UseCases.Permissions.Validation;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Permissions.CommandHandlers
{
	public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand>
	{
		private readonly IApplicationDbContext _context;

		public DeletePermissionCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
		{
			PermissionValidation.ValidatePermissionId(request.permissionId);

			Permission maybePermission =
				await _context.GetAsync<Permission>(request.permissionId);

			PermissionValidation.ValidatePermissionExists(maybePermission, request.permissionId);

			await _context.DeleteAsync<Permission>(maybePermission);
		}
	}
}
