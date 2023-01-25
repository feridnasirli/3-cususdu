using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30)]
        public string FullName { get; set; }
        [StringLength(maximumLength: 20)]
        public string Pression { get; set; }
        public string InstagramURL { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
