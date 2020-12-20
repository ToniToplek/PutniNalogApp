using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNalogAPI.Models
{
    public class TrosakNalog
    {

        [Key]
        public int IdTrosakNalog { get; set; }


        public virtual Troskovi Trosak { get; set; }
        public virtual PutniNalog PutniNalog { get; set; }

    }
}
