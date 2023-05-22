//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taskify.Application.UseCases.Permissions.Commands;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Application.UseCases.Permissions.Queries;

namespace Taskfiy.Api.Controllers
{
	[Route("api/permissions")]
	[ApiController]
	public class PermissionsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PermissionsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async ValueTask<IActionResult> PostPermissionAsync(CreatePermissionCommand command)
		{
			PermissionDto dto = await _mediator.Send(command);

			return Ok(dto);
		}

		[HttpGet("permissionId")]
		public async ValueTask<IActionResult> GetPermissionAsync(Guid permissionId)
		{
			PermissionDto dto =
				await _mediator.Send(new GetPermissionByIdQuery(permissionId));

			return Ok(dto);
		}

		[HttpGet]
		public async ValueTask<IActionResult> GetAllPermissions()
		{
			IQueryable<GetPermissionsDto> dtos =
				await _mediator.Send(new GetPermissionsQuery());

			return Ok(dtos);
		}

		[HttpPut("{permissionId}")]
		public async ValueTask<IActionResult> UpdatePermissionAsync(Guid permissionId, PermissionDto dto)
		{
			dto = await _mediator.Send(new UpdatePermissionCommand()
			{
				Id = permissionId,
				PermissionName = dto.PermissionName
			});

			return Ok(dto);
		}

		[HttpDelete]
		public async ValueTask<IActionResult> DeletePermissionAsync(Guid permissionId)
		{
			PermissionDto dto = await _mediator.Send(new DeletePermissionCommand(permissionId));

			return Ok(dto);
		}
	}
}
