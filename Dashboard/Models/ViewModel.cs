using System.Collections.Generic;

namespace Dashboard.Models
{
	public class ViewModel
	{
		public IEnumerable<User> Users { get; set; }
		public User User { get; set; }
		public IEnumerable<Tile> Tiles { get; set; }
		public Tile Tile { get; set; }
	}
}
