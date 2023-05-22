//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taskify.Application.UseCases.Roles.Commands;
using Taskify.Application.UseCases.Roles.Models;
using Taskify.Application.UseCases.Roles.Queries;

namespace Taskfiy.Api.Controllers
{
	[Route("api/roles")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IMediator _mediator;

		[HttpPost]
		public async ValueTask<IActionResult> PostRoleAsync(CreateRoleCommand command)
		{
			RoleDto dto = await _mediator.Send(command);

			return Ok(dto);
		}

		[HttpGet("{roleId}")]
		public async ValueTask<IActionResult> GetRoleAsync(Guid roleId)
		{
			RoleDto dto =
				await _mediator.Send(new GetRoleByIdQuery(roleId));

			return Ok(dto);
		}

		[HttpGet]
		public async ValueTask<IActionResult> GetAllRoles()
		{
			IQueryable<GetRolesDto> dtos =
				await _mediator.Send(new GetRolesQuery());

			return Ok(dtos);
		}

		[HttpPut("{roleId}")]
		public async ValueTask<IActionResult> UpdateRoleAsync(Guid roleId, RoleDto dto)
		{
			dto = await _mediator.Send(new UpdateRoleCommand()
			{
				Id = roleId,
				RoleName = dto.RoleName
			});

			return Ok(dto);
		}

		[HttpDelete]
		public async ValueTask<IActionResult> DeleteRoleAsync(Guid roleId)
		{
			RoleDto dto =
				await _mediator.Send(new DeleteRoleCommand(roleId));

			return Ok(dto);
		}
	}
}
