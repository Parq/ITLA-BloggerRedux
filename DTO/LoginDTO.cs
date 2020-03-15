using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITLABlogger.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name ="Recuerdame")]
        public bool RememberMe { get; set; }
    }
}
