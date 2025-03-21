using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Model;

namespace Backend.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=banco.db");

        }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
            .Entity<Pessoa>()
            .HasKey(p => p.Id);

            builder
            .Entity<Pessoa>()
            .Property(p=>p.Id)
            .ValueGeneratedOnAdd();

            builder
            .Entity<Pessoa>()
            .HasMany(p => p.Transacoes)
            .WithOne(t => t.Pessoa)
            .HasForeignKey(t => t.PessoaId)
            .OnDelete(DeleteBehavior.Cascade);


            builder
            .Entity<Transacao>()
            .HasKey(t=>t.Id)
            ;

            builder
            .Entity<Transacao>()
            .Property(t=>t.Id)
            .ValueGeneratedOnAdd();
        
        }
    
        public void EnsureCreated()
        {
            this.Database.EnsureCreated();
        }

    }
}