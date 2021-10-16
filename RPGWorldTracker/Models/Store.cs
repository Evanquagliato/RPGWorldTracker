using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPGWorldTracker.Models
{
	public class Store : Building
	{
		public int StoreId { get; set; }
		public string TypeOfStore { get; set; }
		public string GoodsForSale { get; set; }
	}
}