using System.ComponentModel.DataAnnotations;

namespace Webapi.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}