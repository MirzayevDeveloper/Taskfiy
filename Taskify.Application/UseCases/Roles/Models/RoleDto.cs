//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using System.Collections.Generic;

namespace Taskify.Application.UseCases.Roles.Models
{
	public class RoleDto
	{
		private List<string> _permissions;
		public string RoleName { get; set; }

		public List<string> Permissions
		{
			get { return _permissions; }
			set { _permissions = ConvertListToLower(value); }
		}

		private List<string> ConvertListToLower(List<string> inputList)
		{
			List<string> lowercaseList = new List<string>();

			foreach (string item in inputList)
			{
				lowercaseList.Add(item.ToLower());
			}

			return lowercaseList;
		}
	}
}
