using Bushel.Idserver.Management.Models.ApiResources;
using FluentValidation;
using IdentityServer4.EntityFramework.Entities;

namespace Bushel.Idserver.Management.Validation
{
    public class ApiSecretValidator : AbstractValidator<ApiSecretDTO>
    {
        public ApiSecretValidator()
        {
            RuleFor(x => x.Type)
                          .MaximumLength(250);
            RuleFor(x => x.Value)
                          .MaximumLength(2000);
			RuleFor(x => x.Description).MaximumLength(1000);	
        }
    }
}
