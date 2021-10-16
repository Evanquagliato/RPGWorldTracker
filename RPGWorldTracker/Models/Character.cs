using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGWorldTracker.Models
{
	public class Character
	{
		public int CharacterId { get; set; }
		public string Name { get; set; }
		public string Race { get; set; }
		public string Profession { get; set; }
		public string Appearance { get; set; }
		public string Background { get; set; }
		public string OtherDetails { get; set; }

		[ForeignKey("CampaignId")]
		public int CampaignId { get; set; }
		public Campaign Campaign { get; set; }

		[ForeignKey("StoreId")]
		public int? JobId { get; set; }
		public Store Job { get; set; }

		[ForeignKey("HomeId")]
		public int? HomeId { get; set; }
		public Home Home { get; set; }
	}
}