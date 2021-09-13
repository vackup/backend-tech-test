using System.ComponentModel.DataAnnotations;

namespace Webapi.Models
{
    public class AuthorCreationModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}