using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Entities
{
	/// <summary>
	/// Css-цвет
	/// </summary>
	[Table("csscolors")]
    public class CssColor
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        [Column("value")]
        public string Value { get; set; }
    }
}
