using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Author : BaseEntity<int>
    {
        public List<Book> Books { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}