using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RPGWorldTracker.Models
{
	public class Home : Building
	{
		public int HomeId { get; set; }
		public string WealthLevel { get; set; }

	}
}
