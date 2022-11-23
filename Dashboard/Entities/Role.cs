using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Entities
{
	[Table("roles")]
    public class Role
	{
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
