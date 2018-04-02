using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bushel.Idserver.Management.Models.ApiResources
{
    public class ApiResourcesDTO
    {
		public bool Enabled { get; set; }
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public string Description { get; set; }
		public List<ApiSecretDTO> Secrets { get; set; }
		public List<ApiScopeDTO> Scopes { get; set; }
		public List<ApiResourceClaimDTO> UserClaims { get; set; }
	}
}
