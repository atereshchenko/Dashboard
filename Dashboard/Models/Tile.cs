namespace Dashboard.Models
{
    public class Tile
    {
		/// <summary>
		/// Идентификатор
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Порядковый номер отображения
		/// </summary>
		public int Number { get; set; }
		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Опсиание
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Ссылка
		/// </summary>
		public string Link { get; set; }
		/// <summary>
		/// Наименование ссылки
		/// </summary>
		public string LinkName { get; set; }
		/// <summary>
		/// svg-класс иконки
		/// </summary>
		public string SvgClass { get; set; }
		/// <summary>
		/// Вкл/выкл отображения
		/// </summary>
		public bool TurnOn { get; set; }		
	}
}
