using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RPGWorldTracker.Models
{
	public abstract class Building
	{
		public string Name { get; set; }
		public string ExteriorDesc { get; set; }
		public string InteriorDesc { get; set; }
		public string OtherDetails { get; set; }

		[ForeignKey("TownId")]
		public int? TownId { get; set; }
		public Town Town { get; set; }

		[ForeignKey("CampaignId")]
		public int CampaignId { get; set; }
		public Campaign Campaign { get; set; }
	}
}
