using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public partial class stores
    {
        [Key, Column("Id")]
        public int IdStore { get; set; }
        [Required(ErrorMessage = "Digite un Nombre")]
        [StringLength(150)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Digite una Direccion")]
        [StringLength(250)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Digite un Telefono")]
        [StringLength(30)]
        public string Telefono { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
    }
}
