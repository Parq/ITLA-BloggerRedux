using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITLABlogger.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Campo Requerido")]
        [Display(Name ="Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Contraseñas no coinciden")]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; }

    }
}
