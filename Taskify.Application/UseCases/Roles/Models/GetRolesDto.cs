//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Text.Json.Serialization;

namespace Taskify.Application.UseCases.Roles.Models
{
	public class GetRolesDto
	{
		[JsonPropertyName("role_id")]
		public Guid Id { get; set; }

		[JsonPropertyName("role_name")]
		public string RoleName { get; set; }
	}
}
