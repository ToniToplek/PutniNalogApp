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

        public virtual ICollection<PutniNalog> PutniNalogs { get; set; }

    }
}
