using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PutniNalogAPI.Models
{
    public class PutniNalogContext : DbContext
    {
        public PutniNalogContext(DbContextOptions<PutniNalogContext> options) : base(options)
        {

        }

        public DbSet<PutniNalog> PutniNalogs { get; set; }
        public DbSet<Auti> Autis { get; set; }
        public DbSet<Korisnici> Korisnicis { get; set; }
        public DbSet<KorisniciNalog> KorisniciNalogs { get; set; }
        public DbSet<Lokacije> Lokacijes { get; set; }
        public DbSet<Troskovi> Troskovis { get; set; }

    }

}
