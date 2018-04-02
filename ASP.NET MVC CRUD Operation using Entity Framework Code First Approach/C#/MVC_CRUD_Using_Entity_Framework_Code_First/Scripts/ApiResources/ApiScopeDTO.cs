using System.Collections.Generic;

namespace Bushel.Idserver.Management.Models.ApiResources
{
	public class ApiScopeDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public string Description { get; set; }
		public bool Required { get; set; }
		public bool Emphasize { get; set; }
		public bool ShowInDiscoveryDocument { get; set; }
		public List<ApiScopeClaimDTO> UserClaims { get; set; }
	}
}