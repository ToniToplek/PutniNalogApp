using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNalogAPI.Models
{
    public class Korisnici
    {
        [Key]
        public int IdKorisnik { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string ImeKorisnik { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string PrezimeKorisnik { get; set; }


        public virtual ICollection<KorisniciNalog> KorisniciNalogs { get; set; }

    }
}
