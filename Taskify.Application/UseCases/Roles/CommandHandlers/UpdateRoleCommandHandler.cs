//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Roles.Commands;
using Taskify.Application.UseCases.Roles.Models;
using Taskify.Application.UseCases.Roles.Validations;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Roles.CommandHandlers
{
	public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public UpdateRoleCommandHandler(
			IApplicationDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken) =>
		RoleExceptionHandler.TryCatch(async () =>
		{
			Role role = _mapper.Map<Role>(request);

			RoleValidation.ValidateRoleOnUpdate(role);

			Role maybeRole = await _context.GetAsync<Role>(role.Id);

			RoleValidation.ValidateRoleExists(maybeRole, role.Id);

			maybeRole = await _context.UpdateAsync<Role>(role);

			return _mapper.Map<RoleDto>(maybeRole);
		});
	}
}
