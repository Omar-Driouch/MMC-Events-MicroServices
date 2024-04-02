using Microsoft.EntityFrameworkCore;
using SpeakerService.Domain.Data;
using SpeakerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerService.Infrastructure.Data
{
    public class SpeakerDBContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<EventSpeakers> EventSpeakers { get; set; }
        public DbSet<SpeakerSocialMedia> SpeakerSocialMedias { get; set; }
        public DbSet<Imagee> Imagess { get; set; }
        public SpeakerDBContext(DbContextOptions<SpeakerDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<EventSpeakers>()
                .HasKey(ss => ss.Id);

            modelBuilder.Entity<SpeakerSocialMedia>()
                .HasKey(ssm => ssm.Id);

           

            modelBuilder.Entity<SpeakerSocialMedia>()
                .HasOne(ssm => ssm.Speaker)
                .WithOne(s => s.SpeakerSocialMedia)
                .HasForeignKey<SpeakerSocialMedia>(ssm => ssm.SpeakerId);


            base.OnModelCreating(modelBuilder);
        }
    }
}

