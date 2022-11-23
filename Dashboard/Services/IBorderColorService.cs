using Dashboard.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Services
{
	/// <summary>
	/// Интерфейс для работы с цветами рамки
	/// </summary>
	public interface IBorderColorService
	{
		/// <summary>
		/// Получить список классов css-цветов
		/// </summary>
		/// <returns>список классов css-цветов</returns>
		List<CssColor> GetList();
	}

	public class BorderColorService : IBorderColorService
	{
		private readonly ApplicationContext context;
		public BorderColorService(ApplicationContext context)
		{
			this.context = context;
		}

		public List<CssColor> GetList()
		{
			return context.CssColors.ToList();
		}
	}
}
