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

            modelBuilder.Entity("Wtalk.Core.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Wtalk.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AvatarId")
                        .HasColumnType("int");

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

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Wtalk.Core.Entities.UserAvatar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("UserAvatars");
                });

            modelBuilder.Entity("Wtalk.Core.Entities.UserFriend", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FriendId");

                    b.HasIndex("FriendId");

                    b.ToTable("UserFriends");
                });

            modelBuilder.Entity("Wtalk.Core.Entities.Message", b =>
                {
                    b.HasOne("Wtalk.Core.Entities.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wtalk.Core.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Wtalk.Core.Entities.User", b =>
                {
                    b.HasOne("Wtalk.Core.Entities.UserAvatar", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("Wtalk.Core.Entities.UserFriend", b =>
                {
                    b.HasOne("Wtalk.Core.Entities.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wtalk.Core.Entities.User", "User")
                        .WithMany("UserFriends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wtalk.Core.Entities.User", b =>
                {
                    b.Navigation("UserFriends");
                });
#pragma warning restore 612, 618
        }
    }
}
