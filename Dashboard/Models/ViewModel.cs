using Dashboard.Entities;
using System.Collections.Generic;

namespace Dashboard.Models
{
	public class ViewModel
	{
		public List<User> Users { get; set; }
		public User User { get; set; }
		public List<Tile> Tiles { get; set; }
		public Tile Tile { get; set; }		
	}

	public class DashboardModel
	{
		/// <summary>
		/// Список историй посещения ссылок на плитке
		/// </summary>
		public IEnumerable<Entities.TilesNavigationHistory> HistoryTile { get; set; }
	}
}
