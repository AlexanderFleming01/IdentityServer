using System;

namespace Bushel.Idserver.Management.Models.ApiResources
{
	public class ApiSecretDTO
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string Value { get; set; }
		public DateTime? Expiration { get; set; }
		public string Type { get; set; }
	}
}