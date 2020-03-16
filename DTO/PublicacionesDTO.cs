using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITLABlogger.DTO
{
    public class PublicacionesDTO
    {
        [Required(ErrorMessage ="Favor escibir un título")]
        [Display(Name ="Título:")]
        public string TituloPublicacion { get; set; }

        [Required(ErrorMessage ="Favor escribir algun contenido")]
        [Display(Name ="Contenido:")]
        public string ContPublicacion { get; set; }

        //Sera necesario?
        public DateTime FechaPublicacion { get; set; }
        public int Idpublicacion { get; set; }
        public string AspNetUserId { get; set; }
    }
}
