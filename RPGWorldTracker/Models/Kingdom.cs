using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGWorldTracker.Models
{
	public class Kingdom
	{
		public Kingdom()
		{
			this.Allies = new HashSet<Kingdom>();
			this.Enemies = new HashSet<Kingdom>();
		}

		public int KingdomId { get; set; }
		public string Name { get; set; }
		public string Geography { get; set; }
		public string ResourcesEconomy { get; set; }
		public string Culture { get; set; }
		public string Government { get; set; }
		public string HistoricalEvents { get; set; }
		public string Threats { get; set; }

		public virtual ICollection<Kingdom> Allies { get; set; }

		public virtual ICollection<Kingdom> Enemies { get; set; }

		public string Landmarks { get; set; }
		public string OtherDetails { get; set; }

		[ForeignKey("CampaignId")]
		public int CampaignId { get; set; }
		public Campaign Campaign { get; set; }
	}
}