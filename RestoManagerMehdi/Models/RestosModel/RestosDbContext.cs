using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestoManagerMehdi.Models.RestosModel
{
    public class RestosDbContext : DbContext
    {
        public RestosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Proprietaire> Proprietaires { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set;} = null!;
        public DbSet<Avis> Avis { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Proprietaire> PropBuilder = modelBuilder.Entity<Proprietaire>();
            PropBuilder.ToTable("TProprietaire","resto");
            PropBuilder.HasKey(p => p.Numero);
            PropBuilder.Property(p => p.Nom).HasColumnName("NomProp").HasMaxLength(20).IsRequired();
            PropBuilder.Property(p => p.Email).HasColumnName("EmailProp").HasMaxLength(50).IsRequired();


            EntityTypeBuilder<Restaurant> RestoBuilder = modelBuilder.Entity<Restaurant>();
            RestoBuilder.ToTable("TRestaurant", "resto");
            RestoBuilder.HasKey(p => p.CodeResto);
            RestoBuilder.Property(p => p.Specialite).HasColumnName("SpecResto").HasMaxLength(20).IsRequired().HasDefaultValue("Tunisienne");
            RestoBuilder.Property(p => p.Ville).HasColumnName("VilleResto").HasMaxLength(20).IsRequired();
            RestoBuilder.Property(p => p.Tel).HasColumnName("TelResto").HasMaxLength(20).IsRequired();

            PropBuilder.HasMany(p => p.LesRestos).WithOne(r => r.LeProprio).HasForeignKey(r => r.NumProp).HasConstraintName("Relation_Proprio_Restos").IsRequired();
            
            EntityTypeBuilder<Avis> AvisBuilder = modelBuilder.Entity<Avis>();
            AvisBuilder.ToTable("TAvis", "admin");
            AvisBuilder.HasKey(p => p.CodeAvis);
            AvisBuilder.Property(p => p.NomPersonne).HasColumnName("NomPersonne").HasMaxLength(30).IsRequired();
            AvisBuilder.Property(p => p.Note).HasColumnName("Note").IsRequired();
            AvisBuilder.Property(p => p.Commentaire).HasColumnName("Commentaire").HasMaxLength(256).IsRequired();

            RestoBuilder.HasMany(p => p.LesAvis).WithOne(r => r.LeResto).HasForeignKey(r => r.NumResto).HasConstraintName("Relation_Resto_Avis").IsRequired();

        }
    }
}
