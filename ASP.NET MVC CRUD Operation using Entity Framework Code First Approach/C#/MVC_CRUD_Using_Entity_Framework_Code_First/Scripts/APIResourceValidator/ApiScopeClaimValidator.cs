using Bushel.Idserver.Management.Models.ApiResources;
using FluentValidation;

namespace Bushel.Idserver.Management.Validation.APIResourceValidator
{
	public class ApiScopeClaimValidator : AbstractValidator<ApiScopeClaimDTO>
	{
		public ApiScopeClaimValidator()
		{
			RuleFor(x => x.Type).NotNull().MaximumLength(200);
		}
	}
}