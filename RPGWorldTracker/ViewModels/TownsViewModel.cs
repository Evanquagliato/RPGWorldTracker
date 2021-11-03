using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGWorldTracker.Models;

namespace RPGWorldTracker.ViewModels
{
	public class TownsViewModel
	{
		public Town Town { get; set; }
		public List<Store> Stores { get; set; }
		public List<Home> Homes { get; set; }
		public List<Character> Characters { get; set; }
	}
}
