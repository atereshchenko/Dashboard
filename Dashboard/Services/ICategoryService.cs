using Dashboard.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Services
{
	/// <summary>
	/// Интерфейс для работы с категорями
	/// Отношение (классы vs объекты) - "Реализация"
	/// </summary>
	public interface ICategoryService
	{
		/// <summary>
		/// Получить список плиток в сгруппированных по категориям
		/// </summary>
		/// <returns>список плиток в сгруппированных по категориям</returns>
		public List<Category> GetList();
		/// <summary>
		/// Создание категории
		/// </summary>
		/// <param name="category">Объект Категории</param>
		/// <returns>Идентификатор созданной записи</returns>
		public int Create(Category category);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Category GetById(int? id);
		Category Update(Category category);
	}
	public class CategoryService: ICategoryService
	{
		private readonly ApplicationContext context;

		public CategoryService(ApplicationContext context)
		{
			this.context = context;
		}

		public List<Category> GetList()
		{
			return context.Categories.Include(u => u.Tiles).ToList();
		}

		public int Create(Category category)
		{
			context.Categories.Add(category);
			var result = context.SaveChanges();
			return result;
		}

		public Category GetById(int? id)
		{
			return context.Categories.FirstOrDefault(t => t.Id == id);
		}
		public Category Update(Category category)
		{
			var result = context.Categories.SingleOrDefault(c => c.Id == category.Id);
			if (result != null)
			{
				if (result.Name != category.Name)
				{
					result.Name = category.Name;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}			

				// Сохранить изменения
				context.SaveChanges();
			}
			return result;
		}
	}
}
