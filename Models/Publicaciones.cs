using System;
using System.Collections.Generic;

namespace ITLABlogger.Models
{
    public partial class Publicaciones
    {
        public string TituloPublicacion { get; set; }
        public string ContPublicacion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int Idpublicacion { get; set; }
        public string AspNetUserId { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
    }
}
