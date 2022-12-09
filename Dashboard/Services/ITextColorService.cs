using Dashboard.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Services
{
	/// <summary>
	/// Интерфейс для работы с цветами текста
	/// Отношение (классы vs объекты) - "Реализация"
	/// </summary>
	public interface ITextColorService
	{
		/// <summary>
		/// Получить список классов css-цветов
		/// </summary>
		/// <returns>список классов css-цветов</returns>
		List<CssColor> GetList();
	}
	public class TextColorService : ITextColorService
	{
		private readonly ApplicationContext context;
		public TextColorService(ApplicationContext context)
		{
			this.context = context;
		}

		public List<CssColor> GetList()
		{
			return context.CssColors.ToList();
		}
	}
}
