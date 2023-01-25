using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Areas.manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [StringLength(maximumLength:40)]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength:30,MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
