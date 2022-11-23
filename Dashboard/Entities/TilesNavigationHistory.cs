using System;

namespace Dashboard.Entities
{
	public class TilesNavigationHistory
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Дата создания записи
		/// </summary>
		public DateTime CreatedOn { get; set; }		
		public int TileId { get; set; }		
		private Tile Tile { get; set; }		
		public int HistoryCount { get; set; }
	}
}
