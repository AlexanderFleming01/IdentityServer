using Bushel.Idserver.Management.Models.ApiResources;
using Bushel.Idserver.Management.Validation.APIResourceValidator;
using FluentValidation;
using IdentityServer4.EntityFramework.Entities;

namespace Bushel.Idserver.Management.Validation

{
    public class ApiResourceValidator : AbstractValidator<ApiResourcesDTO>
    {
        public ApiResourceValidator()
        {
            RuleFor(x => x.Name)
                          .NotNull().MaximumLength(200);

            RuleFor(x => x.Description)
                          .MaximumLength(1000);

            RuleFor(x => x.DisplayName)
                          .MaximumLength(200);
			RuleForEach(x => x.Secrets).SetValidator(new ApiSecretValidator());
			RuleForEach(x => x.Scopes).SetValidator(new ApiScopeValidator());
			RuleForEach(x => x.UserClaims).SetValidator(new ApiResourceClaimValidator());
        }

    }
}
