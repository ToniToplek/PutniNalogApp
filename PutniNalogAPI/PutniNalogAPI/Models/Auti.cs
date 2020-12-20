using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNalogAPI.Models
{

    public enum VrstaPrijevoza
    {
        Osobni_automobil, Sluzbeni_automobil, Javni_prijevoz
    }

    public class Auti
    {

        [Key]
        public int IdAuto { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string RegistracijaAuta { get; set; }


        [Column(TypeName = "nvarchar(30)")]
        public string MarkaAuta { get; set; }


        [Column(TypeName = "nvarchar(30)")]
        public string NazivAuta { get; set; }

    
        [Column(TypeName = "int")]
        public int Kilometraza { get; set; }

        [Required]
        public VrstaPrijevoza? VrstaPrijevoza { get; set; }

        public virtual ICollection<PutniNalog> PutniNalogs { get; set; }

    }
}
