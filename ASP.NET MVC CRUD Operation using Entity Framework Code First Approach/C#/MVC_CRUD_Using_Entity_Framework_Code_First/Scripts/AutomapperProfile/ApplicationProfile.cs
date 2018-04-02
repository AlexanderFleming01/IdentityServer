using Bushel.Idserver.Management.Models;
using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bushel.Idserver.Management.Models.ApiResources;

namespace Bushel.Idserver.Management.Utility.AutomapperProfile
{
    public class ApplicationProfile : AutoMapper.Profile
    {
		public ApplicationProfile()
		{
			CreateMap<IdentityResource,IdentityResourceDTO>().ReverseMap();
			CreateMap<IdentityClaim, IdentityClaimDTO>().ReverseMap();
			CreateMap<ApiResource, ApiResourcesDTO>().ReverseMap();
			CreateMap<ApiSecret, ApiSecretDTO>().ReverseMap();
			CreateMap<ApiScope, ApiScopeDTO>().ReverseMap();
			CreateMap<ApiResourceClaim, ApiResourceClaimDTO>().ReverseMap();
			CreateMap<ApiScopeClaim, ApiScopeClaimDTO>().ReverseMap();
		}

	}
}
