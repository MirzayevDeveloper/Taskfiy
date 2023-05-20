﻿//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Linq;
using AutoMapper;
using Taskify.Application.UseCases.Permissions.Models;
using Taskify.Domain.Models.Roles;

namespace Taskify.Infrastructure.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Permission, PermissionDto>().ReverseMap();
			CreateMap<IQueryable<Permission>, IQueryable<PermissionDto>>().ReverseMap();
		}
	}
}
