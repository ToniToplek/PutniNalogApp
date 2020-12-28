using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNalogAPI.Models
{
    public class Troskovi
    {

        [Key]
        public int IdTrosak { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string OpisTrosak { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public float Iznos { get; set; }

        public int IdPutniNalog { get; set; }
        public virtual PutniNalog PutniNalog { get; set; }
    }
}
