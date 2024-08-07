﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using muzickeStolice.Data;

#nullable disable

namespace muzickeStolice.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240703144825_BendClanovi")]
    partial class BendClanovi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("muzickeStolice.Model.Bend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DatumOsnivanja")
                        .HasColumnType("date");

                    b.Property<int>("IzvodjacID")
                        .HasColumnType("integer");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IzvodjacID");

                    b.ToTable("Bendovi");
                });

            modelBuilder.Entity("muzickeStolice.Model.Izdanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DatumIzdanja")
                        .HasColumnType("date");

                    b.Property<int>("DeloID")
                        .HasColumnType("integer");

                    b.Property<int>("OcenljivoID")
                        .HasColumnType("integer");

                    b.Property<int>("Tip")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OcenljivoID");

                    b.ToTable("Izdanja");
                });

            modelBuilder.Entity("muzickeStolice.Model.IzdanjeIzvodjenja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("IzvodjenjeID")
                        .HasColumnType("integer");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("IzdanjaIzvodjenja");
                });

            modelBuilder.Entity("muzickeStolice.Model.Izvodjac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("IzvodjenjeId")
                        .HasColumnType("integer");

                    b.Property<int?>("MuzickoDeloId")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("IzvodjenjeId");

                    b.HasIndex("MuzickoDeloId");

                    b.ToTable("Izvodjaci");
                });

            modelBuilder.Entity("muzickeStolice.Model.Izvodjenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Datum")
                        .HasColumnType("date");

                    b.Property<int>("DeloID")
                        .HasColumnType("integer");

                    b.Property<int>("OcenljivoID")
                        .HasColumnType("integer");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OcenljivoID");

                    b.ToTable("Izvodjenja");
                });

            modelBuilder.Entity("muzickeStolice.Model.Korisnik", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tip")
                        .HasColumnType("integer");

                    b.HasKey("Email");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("muzickeStolice.Model.MuzickoDelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OcenljivoID")
                        .HasColumnType("integer");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PlejlistaID")
                        .HasColumnType("integer");

                    b.Property<int>("Tip")
                        .HasColumnType("integer");

                    b.Property<string>("ZanrDelaNaziv")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OcenljivoID");

                    b.HasIndex("PlejlistaID");

                    b.HasIndex("ZanrDelaNaziv");

                    b.ToTable("MuzickaDela");
                });

            modelBuilder.Entity("muzickeStolice.Model.Ocena", b =>
                {
                    b.Property<int>("primalacId")
                        .HasColumnType("integer");

                    b.Property<string>("autorEmail")
                        .HasColumnType("text");

                    b.Property<int>("Vrednost")
                        .HasColumnType("integer");

                    b.HasKey("primalacId", "autorEmail");

                    b.ToTable("Ocene");
                });

            modelBuilder.Entity("muzickeStolice.Model.Ocenljivo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("Ocenljivosti");
                });

            modelBuilder.Entity("muzickeStolice.Model.Osoba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("BendId")
                        .HasColumnType("integer");

                    b.Property<string>("Biografija")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DatumRodjenja")
                        .HasColumnType("date");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IzvodjacID")
                        .HasColumnType("integer");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BendId");

                    b.HasIndex("IzvodjacID");

                    b.ToTable("Osobe");
                });

            modelBuilder.Entity("muzickeStolice.Model.Plejlista", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ZanrNaziv")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ZanrNaziv");

                    b.ToTable("Plejliste");
                });

            modelBuilder.Entity("muzickeStolice.Model.Profil", b =>
                {
                    b.Property<string>("korisnikEmail")
                        .HasColumnType("text");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("PrikaziOcene")
                        .HasColumnType("boolean");

                    b.Property<bool>("PrikaziRecenzije")
                        .HasColumnType("boolean");

                    b.HasKey("korisnikEmail");

                    b.ToTable("Profili");
                });

            modelBuilder.Entity("muzickeStolice.Model.Recenzija", b =>
                {
                    b.Property<int>("primalacId")
                        .HasColumnType("integer");

                    b.Property<string>("autorEmail")
                        .HasColumnType("text");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("primalacId", "autorEmail");

                    b.ToTable("Recenzije");
                });

            modelBuilder.Entity("muzickeStolice.Model.Zanr", b =>
                {
                    b.Property<string>("Naziv")
                        .HasColumnType("text");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Naziv");

                    b.ToTable("Zanrovi");
                });

            modelBuilder.Entity("muzickeStolice.Model.Bend", b =>
                {
                    b.HasOne("muzickeStolice.Model.Izvodjac", "Izvodjac")
                        .WithMany()
                        .HasForeignKey("IzvodjacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Izvodjac");
                });

            modelBuilder.Entity("muzickeStolice.Model.Izdanje", b =>
                {
                    b.HasOne("muzickeStolice.Model.Ocenljivo", "Ocenljivo")
                        .WithMany()
                        .HasForeignKey("OcenljivoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ocenljivo");
                });

            modelBuilder.Entity("muzickeStolice.Model.Izvodjac", b =>
                {
                    b.HasOne("muzickeStolice.Model.Izvodjenje", null)
                        .WithMany("Izvodjaci")
                        .HasForeignKey("IzvodjenjeId");

                    b.HasOne("muzickeStolice.Model.MuzickoDelo", null)
                        .WithMany("Izvodjaci")
                        .HasForeignKey("MuzickoDeloId");
                });

            modelBuilder.Entity("muzickeStolice.Model.Izvodjenje", b =>
                {
                    b.HasOne("muzickeStolice.Model.Ocenljivo", "Ocenljivo")
                        .WithMany()
                        .HasForeignKey("OcenljivoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ocenljivo");
                });

            modelBuilder.Entity("muzickeStolice.Model.MuzickoDelo", b =>
                {
                    b.HasOne("muzickeStolice.Model.Ocenljivo", "Ocenljivo")
                        .WithMany()
                        .HasForeignKey("OcenljivoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("muzickeStolice.Model.Plejlista", null)
                        .WithMany("Muzika")
                        .HasForeignKey("PlejlistaID");

                    b.HasOne("muzickeStolice.Model.Zanr", "ZanrDela")
                        .WithMany()
                        .HasForeignKey("ZanrDelaNaziv");

                    b.Navigation("Ocenljivo");

                    b.Navigation("ZanrDela");
                });

            modelBuilder.Entity("muzickeStolice.Model.Osoba", b =>
                {
                    b.HasOne("muzickeStolice.Model.Bend", null)
                        .WithMany("clanovi")
                        .HasForeignKey("BendId");

                    b.HasOne("muzickeStolice.Model.Izvodjac", "Izvodjac")
                        .WithMany()
                        .HasForeignKey("IzvodjacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Izvodjac");
                });

            modelBuilder.Entity("muzickeStolice.Model.Plejlista", b =>
                {
                    b.HasOne("muzickeStolice.Model.Zanr", "Zanr")
                        .WithMany()
                        .HasForeignKey("ZanrNaziv");

                    b.Navigation("Zanr");
                });

            modelBuilder.Entity("muzickeStolice.Model.Bend", b =>
                {
                    b.Navigation("clanovi");
                });

            modelBuilder.Entity("muzickeStolice.Model.Izvodjenje", b =>
                {
                    b.Navigation("Izvodjaci");
                });

            modelBuilder.Entity("muzickeStolice.Model.MuzickoDelo", b =>
                {
                    b.Navigation("Izvodjaci");
                });

            modelBuilder.Entity("muzickeStolice.Model.Plejlista", b =>
                {
                    b.Navigation("Muzika");
                });
#pragma warning restore 612, 618
        }
    }
}
