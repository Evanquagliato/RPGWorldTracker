using RPGWorldTracker.Models;
using System.Linq;
using System.Collections.Generic;

namespace RPGWorldTracker.ViewModels
{
	public class KingdomsViewModel
	{
		public Kingdom Kingdom { get; set; }
		public List<Kingdom> Allies { get; set; }
		public List<Kingdom> Enemies { get; set; }
		public List<Town> Towns { get; set; }
	}
}
