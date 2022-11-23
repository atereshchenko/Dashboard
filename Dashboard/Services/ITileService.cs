using Dashboard.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Services
{
	/// <summary>
	/// Интерфейс для работы с плитками
	/// </summary>
	public interface ITileService
    {
		/// <summary>
		/// Получить список всех плиток
		/// </summary>
		/// <returns></returns>
		List<Tile> GetList();
		/// <summary>
		/// Получить список всех плиток
		/// </summary>
		/// <param name="turn">вкл/выкл</param>
		/// <returns></returns>
		List<Tile> GetList(bool turn);
		/// <summary>
		/// Получить плитку по идентификатору
		/// </summary>
		/// <param name="id">идентификатор записи</param>
		/// <returns></returns>
		Tile GetById(int? id);
		/// <summary>
		/// Обновить данные плитки
		/// </summary>
		/// <param name="tile"><see cref="Tile"/> плитка</param>
		/// <returns></returns>
		Tile Update(Tile tile);
		/// <summary>
		/// Создание плитки
		/// </summary>
		/// <param name="tile"><see cref="Tile"/> плитка</param>
		/// <returns></returns>
		int Create(Tile tile);
    }
    public class TileService : ITileService
    {
        private readonly ApplicationContext context;

        public TileService(ApplicationContext context)
        {
            this.context = context;
        }       

        public List<Tile> GetList()
        {
            return context.Tiles.Include(u => u.BorderColor).Include(y => y.TextColor).OrderBy(n => n.Number).ToList();
        }

        public List<Tile> GetList(bool turn)
        {
            return context.Tiles.Where(x => x.TurnOn == true).Include(u => u.BorderColor).Include(y => y.TextColor).OrderBy(t => t.Number).ToList();
        }

        public Tile GetById(int? id)
        {
            return context.Tiles.Include(u => u.BorderColor).Include(y => y.TextColor).FirstOrDefault(t => t.Id == id);
        }       

        public Tile Update(Tile tile)
        {
            var result = context.Tiles.SingleOrDefault(t => t.Id == tile.Id);
			if (result != null)
			{
				if (result.Number != tile.Number)
				{
					result.Number = tile.Number;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}

				if (result.Name != tile.Name)
				{
					result.Name = tile.Name;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}

				if (result.Description != tile.Description)
				{
					result.Description = tile.Description;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}

				if (result.Link != tile.Link)
				{
					result.Link = tile.Link;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}

				if (result.LinkName != tile.LinkName)
				{
					result.LinkName = tile.LinkName;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}

				if (result.TurnOn != tile.TurnOn)
				{
					result.TurnOn = tile.TurnOn;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}

				if (result.TextColorId != tile.TextColorId)
				{
					result.TextColorId = tile.TextColorId;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}

				if (result.BorderColorId != tile.BorderColorId)
				{
					result.BorderColorId = tile.BorderColorId;
					// Указать, что запись изменилась
					context.Entry(result).State = EntityState.Modified;
				}

				// Сохранить изменения
				context.SaveChanges();
			}

			//Update<Tile>(tile, context);

			return result;            
        }

        public int Create(Tile tile)
        {          
            context.Tiles.Add(tile);
            var result = context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Универсальный метод обновления https://professorweb.ru/my/entity-framework/6/level3/3_6.php
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="context"></param>
        public static void Update<TEntity>(TEntity entity, DbContext context) where TEntity : class
        {
            // Настройки контекста
            //context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            context.Entry<TEntity>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }    
}