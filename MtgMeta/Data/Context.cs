using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtgMeta.Models;

namespace MtgMeta.Data
{
    public partial class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options)
    : base(options)
        {
        }

        public DbSet<Mazzo> Mazzi { get ; set; }
        public DbSet<Carta> Carte { get; set; }
        //public DbSet<CartaMazzo> carteInUnMazzo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
      => optionsBuilder.UseSqlite(@"Datasource= C:\Users\a.vecchiatti\source\repos\MtgMeta\MtgMeta\Data\MtgMetaDatabase");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            //modelBuilder.Entity<PosProcess>().HasIndex(x => x.Order).IsUnique();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}
