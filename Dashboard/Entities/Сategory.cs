using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Entities
{
    [Table("categories")]
    public class Category
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public List<Tile> Tiles { get; set; }
        public Category()
        {
            Tiles = new List<Tile>();
        }
    }
}
