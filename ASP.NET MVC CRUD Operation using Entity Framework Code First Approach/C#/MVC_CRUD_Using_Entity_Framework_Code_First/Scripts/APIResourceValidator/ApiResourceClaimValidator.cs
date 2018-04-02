using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bushel.Idserver.Management.Models.ApiResources;
using FluentValidation;
using IdentityServer4.EntityFramework.Entities;

namespace Bushel.Idserver.Management.Validation.APIResourceValidator
{
    public class ApiResourceClaimValidator :AbstractValidator<ApiResourceClaimDTO>
    {
		public ApiResourceClaimValidator()
		{
			RuleFor(x => x.Type).MaximumLength(200).NotNull();
		}
    }
}
