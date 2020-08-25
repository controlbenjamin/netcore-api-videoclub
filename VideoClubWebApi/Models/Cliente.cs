using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoClubWebApi.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }


        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }


        [Required]
        [MaxLength(11)]
        [RegularExpression(@"\d{7,11}")]
        public string Dni { get; set; }
    }
}
