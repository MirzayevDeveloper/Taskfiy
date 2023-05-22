//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System;
using System.Text.Json.Serialization;

namespace Taskify.Application.UseCases.Permissions.Models
{
	public class GetPermissionsDto
	{
		[JsonPropertyName("permission_id")]
		public Guid Id { get; set; }

		[JsonPropertyName("permission_name")]
		public string PermissionName { get; set; }
	}
}
