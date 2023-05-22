//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using AutoMapper;
using Taskify.Application.UseCases.Permissions.Commands;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Application.UseCases.Roles.Commands;
using Taskify.Application.UseCases.Roles.Models;
using Taskify.Domain.Models.Roles;

namespace Taskify.Infrastructure.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Permission, PermissionDto>().ReverseMap();
			CreateMap<Permission, GetPermissionsDto>().ReverseMap();
			CreateMap<Permission, CreatePermissionCommand>().ReverseMap();
			CreateMap<Permission, UpdatePermissionCommand>().ReverseMap();

			CreateMap<Role, CreateRoleCommand>().ReverseMap();
			CreateMap<Role, RoleDto>().ReverseMap();
			CreateMap<Role, UpdateRoleCommand>().ReverseMap();
			CreateMap<Role, GetRolesDto>().ReverseMap();
		}
	}
}
