//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using AutoMapper;
using Taskify.Application.UseCases.Permissions.Commands;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Domain.Models.Roles;

namespace Taskify.Infrastructure.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Permission, PermissionDto>().ReverseMap();
			CreateMap<Permission, CreatePermissionCommand>().ReverseMap();
		}
	}
}
