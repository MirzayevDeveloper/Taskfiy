using Xeptions;

namespace Taskify.Application.UseCases.Roles.Exceptions
{
	public class NullRoleException : Xeption
	{
		public NullRoleException() : base("Role is null.") { }
	}
}
