﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Whosapp.Data;

namespace Whosapp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220622232406_MigracionRoles")]
    partial class MigracionRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Whosapp.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Whosapp.Entities.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserEmisorId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId_Emisor")
                        .HasColumnType("int");

                    b.Property<int?>("UserId_Receptor")
                        .HasColumnType("int");

                    b.Property<int?>("UserReceptorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEmisorId");

                    b.HasIndex("UserReceptorId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("Whosapp.Entities.Contacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Whosapp.Entities.GroupChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chatname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("GroupChats");
                });

            modelBuilder.Entity("Whosapp.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Admin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupAdmin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Whosapp.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactListId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupChatId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("TelNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactListId");

                    b.HasIndex("GroupChatId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Whosapp.Entities.Chat", b =>
                {
                    b.HasOne("Whosapp.Entities.ChatMessage", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId");

                    b.HasOne("Whosapp.Entities.User", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId");

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Whosapp.Entities.ChatMessage", b =>
                {
                    b.HasOne("Whosapp.Entities.User", "UserEmisor")
                        .WithMany()
                        .HasForeignKey("UserEmisorId");

                    b.HasOne("Whosapp.Entities.User", "UserReceptor")
                        .WithMany()
                        .HasForeignKey("UserReceptorId");

                    b.Navigation("UserEmisor");

                    b.Navigation("UserReceptor");
                });

            modelBuilder.Entity("Whosapp.Entities.GroupChat", b =>
                {
                    b.HasOne("Whosapp.Entities.ChatMessage", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Whosapp.Entities.User", b =>
                {
                    b.HasOne("Whosapp.Entities.Contacts", "ContactList")
                        .WithMany("Users")
                        .HasForeignKey("ContactListId");

                    b.HasOne("Whosapp.Entities.GroupChat", "GroupChat")
                        .WithMany("Users")
                        .HasForeignKey("GroupChatId");

                    b.HasOne("Whosapp.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("ContactList");

                    b.Navigation("GroupChat");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Whosapp.Entities.Contacts", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Whosapp.Entities.GroupChat", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Whosapp.Entities.User", b =>
                {
                    b.Navigation("Chats");
                });
#pragma warning restore 612, 618
        }
    }
}
