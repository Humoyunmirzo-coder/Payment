﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Payment.Infrastructure.Data;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ServerDbcontext))]
    partial class ServerDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Payment.Domain.Enititys.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNamber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardValidData")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TotalBalance")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Payment.Domain.Enititys.UserTransoction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Amaunt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentServise")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Result")
                        .HasColumnType("boolean");

                    b.Property<string>("SendorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("UserAccountId")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("UserAccountUserTransoction", b =>
                {
                    b.Property<int>("UserAccountsId")
                        .HasColumnType("integer");

                    b.Property<int>("UserTransoctionsId")
                        .HasColumnType("integer");

                    b.HasKey("UserAccountsId", "UserTransoctionsId");

                    b.HasIndex("UserTransoctionsId");

                    b.ToTable("UserAccountUserTransoction");
                });

            modelBuilder.Entity("UserAccountUserTransoction", b =>
                {
                    b.HasOne("Payment.Domain.Enititys.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserAccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Payment.Domain.Enititys.UserTransoction", null)
                        .WithMany()
                        .HasForeignKey("UserTransoctionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
