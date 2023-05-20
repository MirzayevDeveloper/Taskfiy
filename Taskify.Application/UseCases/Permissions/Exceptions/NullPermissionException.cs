//=================================================
// Copyright (c) Coalition of Good-Hearted Engineer
//=================================================

using Xeptions;

namespace Taskify.Application.UseCases.Permissions.Exceptions
{
	public class NullPermissionException : Xeption
	{
        public NullPermissionException() : base("Permission is null.") { }
    }
}
