﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MtgMeta.Data;

#nullable disable

namespace MtgMeta.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221129103547_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("MtgMeta.Models.Carta", b =>
                {
                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("MazzoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Prezzo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Nome");

                    b.HasIndex("MazzoId");

                    b.ToTable("Carte");
                });

            modelBuilder.Entity("MtgMeta.Models.Mazzo", b =>
                {
                    b.Property<int>("MazzoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PercentualeMeta")
                        .HasColumnType("INTEGER");

                    b.HasKey("MazzoId");

                    b.ToTable("Mazzi");
                });

            modelBuilder.Entity("MtgMeta.Models.Carta", b =>
                {
                    b.HasOne("MtgMeta.Models.Mazzo", "Mazzo")
                        .WithMany("Carte")
                        .HasForeignKey("MazzoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mazzo");
                });

            modelBuilder.Entity("MtgMeta.Models.Mazzo", b =>
                {
                    b.Navigation("Carte");
                });
#pragma warning restore 612, 618
        }
    }
}
