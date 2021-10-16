using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGWorldTracker.Models
{
	public class Town
	{
		public Town()
		{
			this.Allies = new HashSet<Town>();
			this.Rivals = new HashSet<Town>();
		}

		public int TownId { get; set; }
		public string Name { get; set; }
		public string Geography { get; set; }
		public string ResourcesEconomy { get; set; }
		public string Culture { get; set; }
		public string Government { get; set; }
		public string HistoricalEvents { get; set; }
		public string Threats { get; set; }
		public string Defenses { get; set; }
		public string Landmarks { get; set; }
		public string OtherDetails { get; set; }

		public ICollection<Town> Allies { get; set; }
		public ICollection<Town> Rivals { get; set; }

		[ForeignKey("KingdomId")]
		public int? KingdomId { get; set; }
		public Kingdom Kingdom { get; set; }

		[ForeignKey("CampaignId")]
		public int CampaignId { get; set; }
		public Campaign Campaign { get; set; }
	}
}