using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNalogAPI.Models
{
    public class KorisniciNalog
    {
        [Key]
        public int idKorisniciNalog { get; set; }

        public int idKorisnik { get; set; }
        public virtual Korisnici Korisnik{ get; set; }

        public int idPutniNalog { get; set; }
        public virtual PutniNalog PutniNalog { get; set; }

    }
}
