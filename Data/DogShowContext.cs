using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Master_Andrei_Preotu.Models;

namespace Proiect_Master_Andrei_Preotu.Data
{
    public class DogShowContext: DbContext
    {
        public DogShowContext(DbContextOptions<DogShowContext> options) : base(options)
        { }
        public DbSet<Catel> Catei { get; set; }
        public DbSet<Concurs> Concursuri { get; set; }
        public DbSet<Premiu> Premii { get; set; }
        public DbSet<RegistruParticipari> RegistreParticipari { get; set; }
        public DbSet<Stapan> Stapani { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catel>().ToTable("Catel");
            modelBuilder.Entity<Concurs>().ToTable("Concurs");
            modelBuilder.Entity<Premiu>().ToTable("Premiu");
            modelBuilder.Entity<RegistruParticipari>().ToTable("RegistruParticipari");
            modelBuilder.Entity<Stapan>().ToTable("Stapan");
        }
    }
}
