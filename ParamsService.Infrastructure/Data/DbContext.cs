using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParamsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParamsService.Infrastructure.Data
{
    public class MMC_Params : DbContext
    {
        public MMC_Params()
        {

        }
        public MMC_Params(DbContextOptions<DbContext> options)
      : base(options)
        {
        }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Mode> Modes { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }
        public virtual DbSet<PartnerEvent> PartnerEvent { get; set; }
        public virtual DbSet<SponsorEvent> SponsorEvent { get; set; }
        public virtual DbSet<ParticipantEvent> ParticipantEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartnerEvent>(e =>
            {
                e.HasKey(p => p.Id);  
            });

            modelBuilder.Entity<SponsorEvent>(e =>
            e.HasNoKey());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MC0ORJ6\\SQLEXPRESS;Initial Catalog=MMC_Params;Integrated Security=True; TrustServerCertificate=True");

    }


}
