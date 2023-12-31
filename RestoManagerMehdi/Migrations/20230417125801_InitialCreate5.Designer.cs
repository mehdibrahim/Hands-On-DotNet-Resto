﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestoManagerMehdi.Models.RestosModel;

#nullable disable

namespace RestoManagerMehdi.Migrations
{
    [DbContext(typeof(RestosDbContext))]
    [Migration("20230417125801_InitialCreate5")]
    partial class InitialCreate5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestoManagerMehdi.Models.RestosModel.Proprietaire", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EmailProp");

                    b.Property<string>("Gsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NomProp");

                    b.HasKey("Numero");

                    b.ToTable("TProprietaire", "resto");
                });

            modelBuilder.Entity("RestoManagerMehdi.Models.RestosModel.Restaurant", b =>
                {
                    b.Property<int>("CodeResto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeResto"));

                    b.Property<string>("NomResto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumProp")
                        .HasColumnType("int");

                    b.Property<string>("Specialite")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Tunisienne")
                        .HasColumnName("SpecResto");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TelResto");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("VilleResto");

                    b.HasKey("CodeResto");

                    b.HasIndex("NumProp");

                    b.ToTable("TRestaurant", "resto");
                });

            modelBuilder.Entity("RestoManagerMehdi.Models.RestosModel.Restaurant", b =>
                {
                    b.HasOne("RestoManagerMehdi.Models.RestosModel.Proprietaire", "LeProprio")
                        .WithMany("LesRestos")
                        .HasForeignKey("NumProp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Relation_Proprio_Restos");

                    b.Navigation("LeProprio");
                });

            modelBuilder.Entity("RestoManagerMehdi.Models.RestosModel.Proprietaire", b =>
                {
                    b.Navigation("LesRestos");
                });
#pragma warning restore 612, 618
        }
    }
}
