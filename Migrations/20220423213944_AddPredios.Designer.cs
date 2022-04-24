﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asping.Data;

namespace Asping.Migrations
{
    [DbContext(typeof(AspingDbContext))]
    [Migration("20220423213944_AddPredios")]
    partial class AddPredios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asping.Model.Predios.Concelho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("codSF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Concelho");
                });

            modelBuilder.Entity("Asping.Model.Predios.Distrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConcelhoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConcelhoId");

                    b.ToTable("Distrito");
                });

            modelBuilder.Entity("Asping.Model.Predios.Freguesia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistritoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistritoId");

                    b.ToTable("Freguesia");
                });

            modelBuilder.Entity("Asping.Model.Predios.Predio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FreguesiaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FreguesiaId");

                    b.ToTable("Predio");
                });

            modelBuilder.Entity("Asping.Model.QuoteTag", b =>
                {
                    b.Property<int>("QuoteId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("QuoteId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("QuoteTags");

                    b.HasData(
                        new
                        {
                            QuoteId = 1,
                            TagId = 1
                        });
                });

            modelBuilder.Entity("QuoteTag", b =>
                {
                    b.Property<int>("QuotesId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("QuotesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("QuoteTag");
                });

            modelBuilder.Entity("asping.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Birthday")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Death")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Albert Einstein"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Abraham Lincoln"
                        });
                });

            modelBuilder.Entity("asping.Model.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 2,
                            CreatedAt = new DateTime(2022, 4, 23, 22, 39, 43, 727, DateTimeKind.Local).AddTicks(5326),
                            Value = "America will never be destroyed from the outside",
                            When = new DateTime(1838, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("asping.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "General Description",
                            Name = "General"
                        });
                });

            modelBuilder.Entity("Asping.Model.Predios.Distrito", b =>
                {
                    b.HasOne("Asping.Model.Predios.Concelho", "Concelho")
                        .WithMany("Distritos")
                        .HasForeignKey("ConcelhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concelho");
                });

            modelBuilder.Entity("Asping.Model.Predios.Freguesia", b =>
                {
                    b.HasOne("Asping.Model.Predios.Distrito", "Distrito")
                        .WithMany("Freguesias")
                        .HasForeignKey("DistritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distrito");
                });

            modelBuilder.Entity("Asping.Model.Predios.Predio", b =>
                {
                    b.HasOne("Asping.Model.Predios.Freguesia", "Freguesia")
                        .WithMany("Predios")
                        .HasForeignKey("FreguesiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Freguesia");
                });

            modelBuilder.Entity("Asping.Model.QuoteTag", b =>
                {
                    b.HasOne("asping.Model.Quote", "Quote")
                        .WithMany("QuoteTags")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asping.Model.Tag", "Tag")
                        .WithMany("QuoteTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quote");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("QuoteTag", b =>
                {
                    b.HasOne("asping.Model.Quote", null)
                        .WithMany()
                        .HasForeignKey("QuotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("asping.Model.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("asping.Model.Quote", b =>
                {
                    b.HasOne("asping.Model.Author", "Author")
                        .WithMany("Quotes")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Asping.Model.Predios.Concelho", b =>
                {
                    b.Navigation("Distritos");
                });

            modelBuilder.Entity("Asping.Model.Predios.Distrito", b =>
                {
                    b.Navigation("Freguesias");
                });

            modelBuilder.Entity("Asping.Model.Predios.Freguesia", b =>
                {
                    b.Navigation("Predios");
                });

            modelBuilder.Entity("asping.Model.Author", b =>
                {
                    b.Navigation("Quotes");
                });

            modelBuilder.Entity("asping.Model.Quote", b =>
                {
                    b.Navigation("QuoteTags");
                });

            modelBuilder.Entity("asping.Model.Tag", b =>
                {
                    b.Navigation("QuoteTags");
                });
#pragma warning restore 612, 618
        }
    }
}
