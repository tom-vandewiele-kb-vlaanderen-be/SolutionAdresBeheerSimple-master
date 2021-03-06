﻿// <auto-generated />
using AdresBeheerRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdresBeheerRepository.Migrations
{
    [DbContext(typeof(AdresContext))]
    partial class AdresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdresBeheerBusinessLogic.Adres", b =>
                {
                    b.Property<int>("adresID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adresLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("appartementnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("busnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("huisnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("straatID")
                        .HasColumnType("int");

                    b.Property<int>("versieNr")
                        .HasColumnType("int");

                    b.HasKey("adresID");

                    b.HasIndex("straatID");

                    b.ToTable("adressen");
                });

            modelBuilder.Entity("AdresBeheerBusinessLogic.Gemeente", b =>
                {
                    b.Property<int>("NIScode")
                        .HasColumnType("int");

                    b.Property<string>("gemeentenaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("versieNr")
                        .HasColumnType("int");

                    b.HasKey("NIScode");

                    b.ToTable("gemeenten");
                });

            modelBuilder.Entity("AdresBeheerBusinessLogic.Straat", b =>
                {
                    b.Property<int>("straatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("gemeenteNIScode")
                        .HasColumnType("int");

                    b.Property<string>("straatnaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("versieNr")
                        .HasColumnType("int");

                    b.HasKey("straatID");

                    b.HasIndex("gemeenteNIScode");

                    b.ToTable("straten");
                });

            modelBuilder.Entity("AdresBeheerBusinessLogic.Adres", b =>
                {
                    b.HasOne("AdresBeheerBusinessLogic.Straat", "straat")
                        .WithMany()
                        .HasForeignKey("straatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdresBeheerBusinessLogic.Straat", b =>
                {
                    b.HasOne("AdresBeheerBusinessLogic.Gemeente", "gemeente")
                        .WithMany()
                        .HasForeignKey("gemeenteNIScode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
