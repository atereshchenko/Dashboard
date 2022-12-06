﻿using Dashboard.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Services
{
	public interface ICategoryService
	{
		public List<Category> GetList();
		public int Create(Category category);
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