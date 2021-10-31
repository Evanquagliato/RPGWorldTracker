using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGWorldTracker.Models;

namespace RPGWorldTracker.ViewModels
{
	public class CampaignDetailsViewModel
	{
		public Campaign Campaign { get; set; }
		public List<Kingdom> Kingdoms { get; set; }
		public List<Town> Towns { get; set; }
		public List<Store> Stores { get; set; }
		public List<Home> Homes { get; set; }
		public List<Character> Characters { get; set; }
	}
}
