using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNalogAPI.Models
{
    public class PutniNalog
    {
        [Key]
        public int IdPutniNalog { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(200)")]
        public string RazlogPutovanja { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime VrijemePolazak { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime VrijemePovratak { get; set; }


        [Column(TypeName = "nvarchar(200)")]
        public string Komentar { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Email { get; set; }


        [Column(TypeName = "int")]
        public int KmPocetak { get; set; }

        [Column(TypeName = "int")]
        public int KmZavrsetak { get; set; }

        public virtual ICollection<KorisniciNalog> KorisniciNalogs { get; set; }

        public virtual ICollection<TrosakNalog> TrosakNalogs { get; set; }

        public virtual Auti Auti { get; set; }

        public virtual Lokacije Lokacije { get; set; }

    }



}
