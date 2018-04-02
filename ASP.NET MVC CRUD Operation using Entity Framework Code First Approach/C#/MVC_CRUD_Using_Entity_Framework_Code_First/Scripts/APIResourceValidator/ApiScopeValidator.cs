using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bushel.Idserver.Management.Models.ApiResources;
using FluentValidation;
using FluentValidation.Validators;
using IdentityServer4.EntityFramework.Entities;

namespace Bushel.Idserver.Management.Validation.APIResourceValidator
{
    public class ApiScopeValidator :AbstractValidator<ApiScopeDTO>
    {
		public ApiScopeValidator()
		{
			RuleFor(x => x.Description).MaximumLength(1000);
			RuleFor(x => x.DisplayName).MaximumLength(200);
			RuleFor(x => x.Name).MaximumLength(200).NotNull();
			RuleForEach(x => x.UserClaims).SetValidator(new ApiScopeClaimValidator());

		}
    }
}
