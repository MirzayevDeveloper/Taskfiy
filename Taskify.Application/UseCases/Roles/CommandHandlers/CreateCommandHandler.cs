//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Taskify.Application.Abstractions;
using Taskify.Application.UseCases.Roles.Commands;
using Taskify.Application.UseCases.Roles.Models;
using Taskify.Application.UseCases.Roles.Validations;
using Taskify.Domain.Models.Roles;

namespace Taskify.Application.UseCases.Roles.CommandHandlers
{
	public class CreateCommandHandler : IRequestHandler<CreateRoleCommand, RoleDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public CreateCommandHandler(
			IApplicationDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken) =>
		RoleExceptionHandler.TryCatch(async () =>
		{
			Role role = _mapper.Map<Role>(request);

			RoleValidation.ValidateRoleOnCreate(role);

			RoleDto dto = _mapper.Map<RoleDto>(request);

			await _context.AddAsync<Role>(role);

			role = await _context.GetAll<Role>()
						.FirstOrDefaultAsync(p => p.RoleName
						.Equals(request.RoleName));

			List<RolePermission> rolePermissions = 
				await RoleValidation.ValidateRolePermissions(dto, role.Id);

			await _context.RolePermissions.AddRangeAsync(rolePermissions);
			
			return _mapper.Map<RoleDto>(role);
		});
	}
}
