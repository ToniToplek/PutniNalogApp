using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace PutniNalogAPI.Models
{
    public class Lokacije
    {
        [Key]
        public int IdLokacija { get; set; }

        [Required]
        public string Naziv { get; set; }

        [InverseProperty("Odrediste")]
        public virtual ICollection<PutniNalog> PutniNalogOdrediste { get; set; }

        [InverseProperty("Polaziste")]
        public virtual ICollection<PutniNalog> PutniNalogPolaziste { get; set; }

    }
}
