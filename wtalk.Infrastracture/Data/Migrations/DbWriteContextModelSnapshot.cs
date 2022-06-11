﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wtalk.Infrastracture.Data.Context;

#nullable disable

namespace Wtalk.Infrastracture.Data.Migrations
{
    [DbContext(typeof(DbWriteContext))]
    partial class DbWriteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Wtalk.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("longblob");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Salt")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
