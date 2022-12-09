using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Entities
{
	/// <summary>
	/// Плитка
	/// Отношение (классы vs объекты) - "Ассоциация"
	/// </summary>
	[Table("tiles")]
	public class Tile
    {
		/// <summary>
		/// Идентификатор
		/// </summary>
		[Column("id")]
		public int Id { get; set; }
		/// <summary>
		/// Порядковый номер отображения
		/// </summary>
		[Column("number")]
		public int Number { get; set; }
		/// <summary>
		/// Наименование
		/// </summary>
		[Column("name")]
		public string Name { get; set; }
		/// <summary>
		/// Опсиание
		/// </summary>
		[Column("description")]
		public string Description { get; set; }
		/// <summary>
		/// Ссылка
		/// </summary>
		[Column("link")]
		public string Link { get; set; }
		/// <summary>
		/// Наименование ссылки
		/// </summary>
		[Column("link_name")]
		public string LinkName { get; set; }
		/// <summary>
		/// Вкл/выкл отображения
		/// </summary>
		[Column("turn_on")]
		public bool TurnOn { get; set; }
		/// <summary>
		/// Избранное
		/// </summary>
		[Column("favorite")]
		public bool Favorite { get; set; }

		[Column("text_color_id")]
		public int TextColorId { get; set; }	
		public CssColor TextColor { get; set; }

		[Column("border_color_id")]
		public int BorderColorId { get; set; }
		public CssColor BorderColor { get; set; }

		/// <summary>
		/// Идентфикатор категории
		/// </summary>
		[Column("category_id")]
		public int? CategoryId { get; set; }
		/// <summary>
		/// Катогрия плитки
		/// </summary>
		public Category Сategory { get; set; }
	}
}
