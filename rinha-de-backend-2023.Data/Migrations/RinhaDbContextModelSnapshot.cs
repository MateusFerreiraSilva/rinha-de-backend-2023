﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using rinha_de_backend_2023.Data;

#nullable disable

namespace rinha_de_backend_2023.Data.Migrations
{
    [DbContext(typeof(RinhaDbContext))]
    partial class RinhaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PessoaTechnology", b =>
                {
                    b.Property<string>("PessoasId")
                        .HasColumnType("text");

                    b.Property<string>("TechnologiesId")
                        .HasColumnType("text");

                    b.HasKey("PessoasId", "TechnologiesId");

                    b.HasIndex("TechnologiesId");

                    b.ToTable("PessoaTechnology");
                });

            modelBuilder.Entity("rinha_de_backend_2023.Data.Models.Pessoa", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nascimento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("rinha_de_backend_2023.Data.Models.Technology", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("PessoaTechnology", b =>
                {
                    b.HasOne("rinha_de_backend_2023.Data.Models.Pessoa", null)
                        .WithMany()
                        .HasForeignKey("PessoasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rinha_de_backend_2023.Data.Models.Technology", null)
                        .WithMany()
                        .HasForeignKey("TechnologiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
