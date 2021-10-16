using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGWorldTracker.Models
{
	public class Campaign
	{
		public int CampaignId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}