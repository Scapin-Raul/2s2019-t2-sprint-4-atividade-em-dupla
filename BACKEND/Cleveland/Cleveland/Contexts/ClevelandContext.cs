using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cleveland.Domains
{
    public partial class ClevelandContext : DbContext
    {
        public ClevelandContext()
        {
        }

        public ClevelandContext(DbContextOptions<ClevelandContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Especialidade> Especialidade { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=M_Cleveland;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.HasKey(e => e.Crm);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Especialidade)
                    .HasConstraintName("FK__Medicos__Especia__5CD6CB2B");
            });
        }
    }
}
