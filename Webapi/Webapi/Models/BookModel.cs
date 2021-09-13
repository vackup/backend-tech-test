using System.ComponentModel.DataAnnotations;

namespace Webapi.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}